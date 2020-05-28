package com.nolin.mytunes.fragments;

import android.content.Context;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
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
import com.nolin.mytunes.json.JSONArtiste;

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

    private AudioPlayer audioPlayer;
    private Handler handler;
    private Runnable runnable;



    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_home, container, false);
        return myView;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        tvAlbum = myView.findViewById(R.id.album);
        tvTitre = myView.findViewById(R.id.titre);
        tvArtiste = myView.findViewById(R.id.artiste);

        ivPochette = myView.findViewById(R.id.pochette);
        seekBar = myView.findViewById(R.id.seekBar);

        ibPrevious = myView.findViewById(R.id.ib_previous);
        ibPlay = myView.findViewById(R.id.ib_play);
        ibNext = myView.findViewById(R.id.ib_next);

        Bundle bundle = getArguments();
        if( bundle  != null )
        {
            AudioModel audioModel = (AudioModel)bundle.getSerializable("morceauCourant");
            if( audioModel != null )
            {
                StringBuilder artistes = new StringBuilder();
                JSONArtiste current;
                for(int i=0 ; i<audioModel.getArtistes().size(); i++){
                    current= audioModel.getArtiste(i);
                    if (current.getArtiste().getPrenom()!=null)
                        artistes.append(current.getArtiste().getPrenom()).append(" ");
                    if (current.getArtiste().getNom()!=null)
                        artistes.append(current.getArtiste().getNom()).append("   ");
                }
                tvArtiste.setText(artistes.toString());
                tvAlbum.setText("");
                tvTitre.setText(audioModel.getTitre());
            }
        }


        /**
         *
         */



        //if (AudioPlayer.ifIsPlaying()) {
            /*AudioPlayer.getInstance(getContext(), Uri.parse("http://www.google.com")).getMediaPlayer().setOnPreparedListener(new MediaPlayer.OnPreparedListener() {
                @Override
                public void onPrepared(MediaPlayer mediaPlayer) {
                    seekBar.setMax(AudioPlayer.getInstance(getContext(), Uri.parse("http://www.google.com")).getMediaPlayer().getDuration());
                    seekBar.setProgress(AudioPlayer.getInstance(getContext(), Uri.parse("http://www.google.com")).getMediaPlayer().getCurrentPosition());
                }
            });*/

            /*seekBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
                @Override
                public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
                    if (b) {
                        AudioPlayer.getInstance(getContext(), Uri.parse("http://www.google.com")).getMediaPlayer().seekTo(i);
                    }
                }

                @Override
                public void onStartTrackingTouch(SeekBar seekBar) {

                }

                @Override
                public void onStopTrackingTouch(SeekBar seekBar) {

                }
            });
        }*/








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

    /*public void setSeekBar(MediaPlayer mediaPlayer) {
        seekBar.setMax(mediaPlayer.getDuration());
        seekBar.setProgress(mediaPlayer.getCurrentPosition());
    }*/

    /*@Override
    public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
        if (b) {
            AudioPlayer.getInstance(getContext(), Uri.parse("http://www.google.com")).getMediaPlayer().seekTo(i);
        }
    }*/
}

