package com.nolin.mytunes;

import android.content.Context;
import android.media.MediaPlayer;
import android.net.Uri;
import android.view.View;
import android.widget.ImageButton;
import android.widget.Toast;

public class AudioPlayer {

    private static AudioPlayer INSTANCE = null;
    private static MediaPlayer mediaPlayer;
    private static boolean isPlaying = false;

    /*private AudioPlayer(Context context, Uri uri) {
        stop();
        mediaPlayer = MediaPlayer.create(context, uri);
        isPlaying = true;
        mediaPlayer.start();
    }*/

    /** Point d'accès pour l'instance unique du singleton */
    /*public static AudioPlayer getInstance(Context context, Uri uri)
    {
        if (INSTANCE == null) {
            INSTANCE = new AudioPlayer(context, uri);
        }
        return INSTANCE;
    }*/

    public static boolean ifIsPlaying() {
        return isPlaying;
    }

    public static void start(Context context, Uri uri) {
        stop();
        mediaPlayer = MediaPlayer.create(context, uri);
        isPlaying = true;
        mediaPlayer.start();
    }

    private static void stop() {
        if (mediaPlayer != null) {
            mediaPlayer.release();
            isPlaying = false;
            mediaPlayer = null;
        }
    }

    public static void pause(View view) {
        ImageButton ib = view.findViewById(R.id.ib_play);
        if(mediaPlayer == null) {
            Toast.makeText(view.getContext(),"Pas de musique en cours", Toast.LENGTH_LONG).show();
            return;
        }
        if(mediaPlayer.isPlaying()){
            mediaPlayer.pause();
            ib.setImageResource(R.drawable.ic_play);
        } else {
            mediaPlayer.start();
            ib.setImageResource(R.drawable.ic_pause);
        }
    }

    public int getDuration(){
       return mediaPlayer.getDuration();
    }

    public void seekTo(int progress){
        mediaPlayer.seekTo(progress);
    }

    public int getCurrentPosition(){
        return mediaPlayer.getCurrentPosition();
    }

}


