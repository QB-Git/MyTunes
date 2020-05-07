package com.nolin.mytunes;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import android.content.Context;
import android.media.MediaPlayer;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.google.android.material.bottomnavigation.BottomNavigationView;
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
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private final String URL_TO_HIT = "https://mytunes20200429155409.azurewebsites.net/api/Genres";
    private MediaPlayer mMediaPlayer;
    private ListView lvGenres;

    // connection
    protected class JSONTask extends AsyncTask<String, String, ArrayList<GenreModel>>{

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
                for(int i = 0; i<parentArray.length(); i++){
                    JSONObject finalObject = parentArray.getJSONObject(i);
                    GenreModel genreModel = new GenreModel();

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
            GenreAdapter adapter = new GenreAdapter(getApplicationContext(), R.layout.row, result);
            lvGenres.setAdapter(adapter);
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        lvGenres = findViewById(R.id.lvGenres);

        new JSONTask().execute(URL_TO_HIT);


        // Bouton lecture
        mMediaPlayer = MediaPlayer.create(this, R.raw.bubblegumkk);
        Button playButton = (Button) findViewById(R.id.start);
        playButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                mMediaPlayer.start();
                mMediaPlayer.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
                    @Override
                    public void onCompletion(MediaPlayer mp) {
                        Toast.makeText(MainActivity.this, "La chanson est finie", Toast.LENGTH_SHORT).show();
                    }
                });
            }
        });
        // Bouton pause
        Button pauseButton = (Button) findViewById(R.id.stop);
        pauseButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                mMediaPlayer.pause();
            }
        });

        BottomNavigationView bottomNav = findViewById(R.id.nav_view);
        bottomNav.setOnNavigationItemSelectedListener(new BottomNavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                Fragment selectedFragment = null;
                switch (item.getItemId()) {
                    case R.id.nav_home:
                        selectedFragment = new HomeFragment();
                        break;
                    case R.id.nav_library:
                        selectedFragment = new LibraryFragment();
                        break;
                    case R.id.nav_search:
                        selectedFragment = new SearchFragment();
                        break;
                    case R.id.nav_user:
                        selectedFragment = new UserFragment();
                        break;
                }
                getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, selectedFragment).commit();
                return true;
            }
        });
    }


    public class GenreAdapter extends ArrayAdapter {

        private List<GenreModel> genreModelList;
        private int ressource;
        private LayoutInflater inflater;
        public GenreAdapter(@NonNull Context context, int resource, List<GenreModel> objects) {
            super(context, resource, objects);
            genreModelList = objects;
            this.ressource = resource;
            inflater= (LayoutInflater) getSystemService(LAYOUT_INFLATER_SERVICE);

        }

        @NonNull
        @Override
        public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
            if(convertView==null){
                convertView = inflater.inflate(ressource, null);
            }
            ImageView ivAudioIcon;
            TextView tvID_Genre;
            TextView tvGenre;


            ivAudioIcon = convertView.findViewById(R.id.ivPochette);
            tvID_Genre = convertView.findViewById(R.id.tvID_Genre);
            tvGenre = convertView.findViewById(R.id.tvGenre);


            /*
                ATTENTION NE SURTOUT PAS OUBLIER DE FAIRE UN COUP DE SETTER
                APRES LE FindViewById !!!!!
             */
            tvGenre.setText(genreModelList.get(position).getGenre());
            tvID_Genre.setText(genreModelList.get(position).getID_Genre_String());
            ivAudioIcon.setImageResource(R.drawable.bubblegumkk);

            return convertView;
        }
    }


}
