package com.nolin.mytunes.utils;

import android.os.AsyncTask;

import com.google.gson.Gson;
import com.nolin.mytunes.MainActivity;
import com.nolin.mytunes.fragments.HomeFragment;
import com.nolin.mytunes.models.GenreModel;

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

public class Connection extends AsyncTask<String, String, ArrayList<GenreModel>> {

    private HomeFragment homeFragment;

    public Connection(HomeFragment homeFragment) {
        this.homeFragment = homeFragment;
    }

    @Override
    //c'est là où je fais le taff, load JSON en background
    protected ArrayList<GenreModel> doInBackground(String... urls) {
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

            ArrayList<GenreModel> genreModelList = new ArrayList<>();

            Gson gson = new Gson();
            for(int i = 0; i<parentArray.length(); i++){
                JSONObject finalObject = parentArray.getJSONObject(i);
                GenreModel genreModel = gson.fromJson(finalObject.toString(), GenreModel.class);

                genreModel.setID_Genre(finalObject.getInt("id_genre"));
                genreModel.setGenre(finalObject.getString("genre"));
                genreModelList.add(genreModel);
            }
            return genreModelList;

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
    protected void onPostExecute(ArrayList<GenreModel> result) {
        super.onPostExecute(result);
        homeFragment.updateAdapter(result);
    }
}
