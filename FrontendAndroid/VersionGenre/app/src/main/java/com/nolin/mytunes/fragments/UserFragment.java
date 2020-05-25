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
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.google.android.material.textfield.TextInputEditText;
import com.google.android.material.textfield.TextInputLayout;
import com.nolin.mytunes.AudioPlayer;
import com.nolin.mytunes.R;
import com.nolin.mytunes.models.AudioEtImages;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.models.UserModel;
import com.nolin.mytunes.ui.AudioAdapter;
import com.nolin.mytunes.ui.MusiqueAdapter;
import com.nolin.mytunes.utils.ConnectionMusiqueId;
import com.nolin.mytunes.utils.ConnectionRecherche;
import com.nolin.mytunes.utils.ConnectionUser;
import com.nolin.mytunes.utils.LoadingDialog;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Objects;

public class UserFragment extends Fragment {

    private ListView lv_fav;
    private EditText ti_user;
    private EditText ti_passwd;
    private TextInputLayout til_un;
    private TextInputLayout til_deux;
    private Button button_co;
    private View myView;
    private MusiqueAdapter adapter;
    private MediaPlayer mediaPlayer;
    private List<UserModel> users;
    private List<AudioModel> musiques;
    private UserModel good_user;

    private String url_users = "https://mytunes20200429155409.azurewebsites.net/api/Users";

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_user, container, false);

        lv_fav = myView.findViewById(R.id.lv_fav);
        ti_user = myView.findViewById(R.id.ti_user);
        ti_passwd = myView.findViewById(R.id.ti_passwd);
        button_co = myView.findViewById(R.id.button_co);
        til_un = myView.findViewById(R.id.til_un);
        til_deux = myView.findViewById(R.id.til_deux);

        button_co.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new ConnectionUser(UserFragment.this).execute(url_users);
            }});

        lv_fav.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                Log.e("MediaPlyer", "onItemClickListener");
                AudioPlayer.beginAudio(getContext(), Uri.parse(musiques.get(i).getURL()));
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
                ArrayList<String> test = new ArrayList<>();
                for(int j=0; j<good_user.getPlaylist().size(); j++){
                    test.add("https://mytunes20200429155409.azurewebsites.net/api/Musiques/"+good_user.getPlaylist().get(j).getId_musique());
                }
                /*
                WARNING, c'est pas ouf mais j'ai pas mieux hein
                 */
                String[] urls = new String[test.size()];
                urls = test.toArray(urls);
                new ConnectionMusiqueId(UserFragment.this).execute(urls);
            }
        }
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
        adapter = new MusiqueAdapter(getContext(), R.layout.recherche_row, audios,images);
        lv_fav.setAdapter(adapter);
        adapter.notifyDataSetChanged();
        ti_user.setVisibility(View.GONE);
        ti_passwd.setVisibility(View.GONE);
        button_co.setVisibility(View.GONE);
        til_un.setVisibility(View.GONE);
        til_deux.setVisibility(View.GONE);
    }
}
