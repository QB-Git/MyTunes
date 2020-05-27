package com.nolin.mytunes.fragments;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.SeekBar;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.nolin.mytunes.AudioPlayer;
import com.nolin.mytunes.R;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.models.JSONAlbum;
import com.nolin.mytunes.models.JSONArtiste;
import com.squareup.picasso.Picasso;

public class HomeFragment extends Fragment {

    private View myView;

    private TextView tvAlbum;
    private TextView tvTitre;
    private TextView tvArtiste;

    private ImageView ivPochette;

    private SeekBar seekBar;

    private ImageButton ibPrevious;
    private ImageButton ibPlay;
    private ImageButton ibNext;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_home, container, false);


        return myView;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        tvTitre = myView.findViewById(R.id.titre);
        tvArtiste = myView.findViewById(R.id.artiste);
        ivPochette = myView.findViewById(R.id.pochette);
        ibPrevious = myView.findViewById(R.id.ib_previous);
        ibPlay = myView.findViewById(R.id.ib_play);
        ibNext = myView.findViewById(R.id.ib_next);

        Bundle bundle = getArguments();
        Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : Get du bundle");

        if( bundle  != null )
        {
            AudioModel audioModel = (AudioModel)bundle.getSerializable("libraryFragment_morceauCourant");
            Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : Get du AudioModel");

            if( audioModel != null )
            {
                Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : Récup du titre");
                Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : "+audioModel.getTitre());



                StringBuilder artistes = new StringBuilder();
                StringBuilder albums = new StringBuilder();

                JSONArtiste current;
                JSONAlbum album;
                for(int i=0 ; i<audioModel.getArtistes().size(); i++){
                    current= audioModel.getArtiste(i);
                    if (current.getArtiste().getPrenom()!=null)
                        artistes.append(current.getArtiste().getPrenom()).append(" ");
                    if (current.getArtiste().getNom()!=null)
                        artistes.append(current.getArtiste().getNom()).append("   ");
                }

                /*
                for(int i=0 ; i<audioModel.getAlbums().size(); i++){
                    album = audioModel.getAlbum(i);
                    if (album.getAlbum().getNom_album()!=null)
                        albums.append(album.getAlbum().getNom_album());
                }*/

                tvArtiste.setText(artistes.toString());
                //tvAlbum.setText(albums.toString());
                tvTitre.setText(audioModel.getTitre());

            }
            else
                Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : audioModel null");
        }
        else
            Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : bundle null");

        ibPrevious.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

            }
        });

        ibPlay.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AudioPlayer.pause(view);
            }
        });

        ibNext.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

            }
        });
    }

}

