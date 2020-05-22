package com.nolin.mytunes.utils;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.util.Log;

import com.google.gson.Gson;
import com.nolin.mytunes.fragments.SearchFragment;
import com.nolin.mytunes.models.AudioEtImages;
import com.nolin.mytunes.models.AudioModel;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
public class ConnectionRecherche extends AsyncTask<String, String, ArrayList<AudioEtImages>> {

    private SearchFragment searchFragment;

    public ConnectionRecherche(SearchFragment searchFragment) {
        this.searchFragment = searchFragment;
    }

    @Override
    //c'est là où je fais le taff, load JSON en background
    protected ArrayList<AudioEtImages> doInBackground(String... urls) {
        HttpURLConnection connection = null;
        BufferedReader reader = null;

        try {
            URL url = new URL(urls[0]);
            connection = (HttpURLConnection) url.openConnection();
            connection.connect();
            InputStream stream = connection.getInputStream();
            reader = new BufferedReader(new InputStreamReader(stream));
            StringBuffer buffer = new StringBuffer();
            String line="";
            while ((line = reader.readLine()) != null){
                buffer.append(line);
            }
            //récupération des données OK
            String finalJson = buffer.toString();

            JSONArray parentArray = new JSONArray(finalJson);

            ArrayList<AudioEtImages> audioModelList = new ArrayList<>();

            Gson gson = new Gson();
            for(int i = 0; i<parentArray.length(); i++){
                JSONObject finalObject = parentArray.getJSONObject(i);
                AudioModel audioModel = gson.fromJson(finalObject.toString(), AudioModel.class);

                String urldisplay = audioModel.getPochette().getImg_pochette();
                Bitmap mIcon11 = null;
                try {
                    InputStream in = new java.net.URL(urldisplay).openStream();
                    mIcon11 = BitmapFactory.decodeStream(in);
                } catch (Exception e) {
                    Log.e("Error", e.getMessage());
                    e.printStackTrace();
                }

                audioModelList.add(new AudioEtImages(audioModel, mIcon11));
            }
            return audioModelList;

        } catch (IOException | JSONException e) {
            e.printStackTrace();
        } finally {
            if (connection != null) {
                connection.disconnect();
            }try {
                if(reader != null) {
                    reader.close();
                }
            }catch (IOException e){
                e.printStackTrace();
            }
        }
        //récupération des données pas OK
        return null;
    }

    //c'est là où j'envoie le résultat à l'adapter
    @Override
    protected void onPostExecute(ArrayList<AudioEtImages> result) {
        super.onPostExecute(result);
        searchFragment.updateAdapter(result);
    }
}
