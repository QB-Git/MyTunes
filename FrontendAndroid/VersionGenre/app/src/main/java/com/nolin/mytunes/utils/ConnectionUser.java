package com.nolin.mytunes.utils;

import android.os.AsyncTask;

import com.google.gson.Gson;
import com.nolin.mytunes.fragments.LibraryFragment;
import com.nolin.mytunes.fragments.UserFragment;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.models.UserModel;

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

public class ConnectionUser extends AsyncTask<String, String, ArrayList<UserModel>> {

    private UserFragment userFragment;

    public ConnectionUser(UserFragment userFragment) {
        this.userFragment = userFragment;
    }

    @Override
    //c'est là où je fais le taff, load JSON en background
    protected ArrayList<UserModel> doInBackground(String... urls) {
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

            ArrayList<UserModel> userModelList = new ArrayList<>();

            Gson gson = new Gson();
            for(int i = 0; i<parentArray.length(); i++){
                JSONObject finalObject = parentArray.getJSONObject(i);
                UserModel userModel = gson.fromJson(finalObject.toString(), UserModel.class);
                userModelList.add(userModel);
            }
            return userModelList;

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
    protected void onPostExecute(ArrayList<UserModel> result) {
        super.onPostExecute(result);
        userFragment.testUser(result);
    }
}
