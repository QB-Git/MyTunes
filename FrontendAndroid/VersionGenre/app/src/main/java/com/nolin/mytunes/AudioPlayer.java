package com.nolin.mytunes;

import android.app.Application;
import android.content.Context;
import android.media.MediaPlayer;
import android.net.Uri;
import android.view.View;
import android.widget.ImageButton;
import android.widget.Toast;

public class AudioPlayer {
    private static MediaPlayer mediaPlayer;

    public static void start(Context context, Uri uri) {
        stop();
        mediaPlayer = MediaPlayer.create(context, uri);
        mediaPlayer.start();
    }

    public static void stop() {
        if (mediaPlayer != null) {
            mediaPlayer.release();
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
}
