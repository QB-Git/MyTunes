package com.nolin.mytunes;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import android.app.ProgressDialog;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.nolin.mytunes.fragments.HomeFragment;
import com.nolin.mytunes.fragments.LibraryFragment;
import com.nolin.mytunes.fragments.SearchFragment;
import com.nolin.mytunes.fragments.UserFragment;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.models.UserModel;
import com.nolin.mytunes.utils.LoadingDialog;

public class MainActivity extends AppCompatActivity {

    private MediaPlayer mMediaPlayer;
    public BottomNavigationView bottomNav;
    private Bundle bundle;
    private UserModel user;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        user = null;
        bundle = new Bundle();
        bottomNav = findViewById(R.id.nav_view);
        final LoadingDialog loadingDialog = new LoadingDialog(MainActivity.this);

        bottomNav.setOnNavigationItemSelectedListener(new BottomNavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                Fragment selectedFragment = null;
                switch (item.getItemId()) {
                    case R.id.nav_home:
                        selectedFragment = new HomeFragment();
                        selectedFragment.setArguments( bundle );
                        Log.i( "TEST PASSAGE BUNDLE", "mainActivity.onCreate() : Set du bundle home");
                        break;
                    case R.id.nav_library:
                        loadingDialog.startLoadingDialog();
                        selectedFragment = new LibraryFragment();
                        bundle.putSerializable("mainActivity_loadingDialog", loadingDialog);
                        selectedFragment.setArguments( bundle );
                        Log.i( "TEST PASSAGE BUNDLE", "mainActivity.onCreate() : Set du bundle lib");

                        break;
                    case R.id.nav_search:
                        selectedFragment = new SearchFragment();
                        bundle.putSerializable("mainActivity_loadingDialog", loadingDialog);
                        selectedFragment.setArguments( bundle );
                        break;
                    case R.id.nav_user:
                        selectedFragment = new UserFragment(MainActivity.this, user);
                        selectedFragment.setArguments( bundle );
                        break;
                }
                getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, selectedFragment).commit();
                return true;
            }
        });
    }
    public void updateUser(UserModel user){
        this.user = user;
    }

    public void resetUser(){
        this.user = null;
    }
}
