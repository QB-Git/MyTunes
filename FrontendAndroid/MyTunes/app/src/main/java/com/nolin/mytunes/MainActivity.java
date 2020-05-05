package com.nolin.mytunes;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import android.media.MediaPlayer;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.google.android.material.bottomnavigation.BottomNavigationView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class MainActivity extends AppCompatActivity {

    private MediaPlayer mMediaPlayer;
    private TextView mTextViewResult;

    // connection
    protected class JSONTask extends AsyncTask<String, String, String>{
        @Override
        protected String doInBackground(String... urls) {
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
                return buffer.toString();

            } catch (IOException e) {
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

        @Override
        protected void onPostExecute(String result) {
            super.onPostExecute(result);
            mTextViewResult.setText(result);
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        // Bouton Parse JSON, avec Editeur
        Button buttonParse = (Button)findViewById(R.id.button_parse);
        mTextViewResult = (TextView)findViewById(R.id.text_view_result);

        buttonParse.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                new JSONTask().execute("https://mytunes20200429155409.azurewebsites.net/api/Editeurs");
            }
        });

        // Bouton lecture
        mMediaPlayer = MediaPlayer.create(this, R.raw.sound);
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


}
