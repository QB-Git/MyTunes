package com.nolin.mytunes;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.nolin.mytunes.fragments.HomeFragment;
import com.nolin.mytunes.fragments.LibraryFragment;
import com.nolin.mytunes.fragments.SearchFragment;
import com.nolin.mytunes.fragments.UserFragment;

public class MainActivity extends AppCompatActivity {

    private MediaPlayer mMediaPlayer;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //mMediaPlayer = MediaPlayer.create(this, Uri.parse("https://drive.google.com/uc?id=1pQGaaCz1KkAPxz5tmvzNQLeMTzDpNas6"));


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
                        selectedFragment = new LibraryFragment(mMediaPlayer);
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
