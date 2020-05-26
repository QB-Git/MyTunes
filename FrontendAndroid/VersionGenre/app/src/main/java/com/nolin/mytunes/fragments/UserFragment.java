package com.nolin.mytunes.fragments;

import android.graphics.Bitmap;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.nolin.mytunes.AudioPlayer;
import com.nolin.mytunes.MainActivity;
import com.nolin.mytunes.R;
import com.nolin.mytunes.models.AudioEtImages;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.models.UserModel;
import com.nolin.mytunes.ui.MusiqueAdapter;
import com.nolin.mytunes.utils.ConnectionMusiqueId;
import com.nolin.mytunes.utils.ConnectionUser;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

public class UserFragment extends Fragment {

    private ListView lv_fav;
    private EditText ti_user;
    private EditText ti_passwd;
    private LinearLayout layoutConnexion;
    private LinearLayout layoutDeconnexion;
    private Button button_co;
    private Button button_deco;
    private View myView;
    private MusiqueAdapter adapter;
    private List<UserModel> users;
    private List<AudioModel> musiques;
    private UserModel good_user;
    MainActivity ma;

    private String url_users = "https://mytunes20200429155409.azurewebsites.net/api/Users";

    public UserFragment(MainActivity ma, UserModel user){
        good_user = user;
        this.ma = ma;
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_user, container, false);

        lv_fav = myView.findViewById(R.id.lv_fav);
        ti_user = myView.findViewById(R.id.etUser);
        ti_passwd = myView.findViewById(R.id.etPasswd);
        button_co = myView.findViewById(R.id.btConnexion);
        button_deco  =myView.findViewById(R.id.btDeconnexion);
        layoutConnexion = myView.findViewById(R.id.layout);
        layoutDeconnexion = myView.findViewById(R.id.layoutDeco);

        if(good_user != null){
            layoutConnexion.setVisibility(View.GONE);
            layoutDeconnexion.setVisibility(View.VISIBLE);
            getMusiquesFromPlaylist();
        } else {
            layoutConnexion.setVisibility(View.VISIBLE);
            layoutDeconnexion.setVisibility(View.GONE);
        }

        button_co.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new ConnectionUser(UserFragment.this).execute(url_users);
            }});

        button_deco.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                ma.resetUser();
                layoutConnexion.setVisibility(View.VISIBLE);
                layoutDeconnexion.setVisibility(View.GONE);
                musiques = new ArrayList<>();
                ti_user.setText(null);
                ti_passwd.setText(null);
                lv_fav.setAdapter(null);
            }
        });

        lv_fav.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                Log.e("MediaPlyer", "onItemClickListener");
                AudioPlayer.start(getContext(),Uri.parse(musiques.get(i).getURL()));
            }
        });
        return myView;
    }

    public void testUser(ArrayList<UserModel> object) {
        this.users = object;
        for(int i=0; i<users.size(); i++){
            if(users.get(i).getPseudo().equals(Objects.requireNonNull(ti_user.getText()).toString()) &&
                    users.get(i).getPassword().equals(Objects.requireNonNull(ti_passwd.getText()).toString())){
                good_user = users.get(i);
                i = users.size();
                ma.updateUser(good_user);
                getMusiquesFromPlaylist();
            }
        }
    }

    private void getMusiquesFromPlaylist(){
        ArrayList<String> pourAffichage = new ArrayList<>();
        for(int j=0; j<good_user.getPlaylist().size(); j++){
            pourAffichage.add("https://mytunes20200429155409.azurewebsites.net/api/Musiques/"+good_user.getPlaylist().get(j).getId_musique());
        }
        /*
        WARNING, c'est pas ouf mais j'ai pas mieux hein
        */
        String[] urls = new String[pourAffichage.size()];
        urls = pourAffichage.toArray(urls);
        new ConnectionMusiqueId(UserFragment.this).execute(urls);
    }

    public void updateAdapter(ArrayList<AudioEtImages> object){
        List<AudioModel> audios = new ArrayList<>();
        List<Bitmap> images = new ArrayList<>();
        if (object != null){
            for(int i=0; i<object.size(); i++){
                audios.add(object.get(i).getMusique());
                images.add(object.get(i).getImage());
            }
        }
        this.musiques = audios;
        adapter = new MusiqueAdapter(getContext(), R.layout.row, audios,images);
        lv_fav.setAdapter(adapter);
        adapter.notifyDataSetChanged();
        layoutConnexion.setVisibility(View.GONE);
        layoutDeconnexion.setVisibility(View.VISIBLE);
    }
}
