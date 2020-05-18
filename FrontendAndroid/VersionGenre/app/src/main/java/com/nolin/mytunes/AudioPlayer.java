package com.nolin.mytunes;

import android.content.Context;
import android.media.MediaPlayer;
import android.net.Uri;

public class AudioPlayer {
    private static MediaPlayer audioPlayer;

    public static void beginAudio(Context context, Uri uri) {
        stopMediaPlayer();
        audioPlayer = MediaPlayer.create(context, uri);
        audioPlayer.start();
    }

    private static void stopMediaPlayer() {
        if (audioPlayer != null) {
            audioPlayer.release();
            audioPlayer = null;
        }
    }
}
