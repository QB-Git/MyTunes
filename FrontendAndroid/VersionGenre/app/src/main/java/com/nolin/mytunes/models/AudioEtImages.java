package com.nolin.mytunes.models;

import android.graphics.Bitmap;

public class AudioEtImages {
    AudioModel musique;
    Bitmap image;

    public AudioEtImages(AudioModel musique, Bitmap image) {
        this.musique = musique;
        this.image = image;
    }

    public AudioModel getMusique() {
        return musique;
    }

    public void setMusique(AudioModel musique) {
        this.musique = musique;
    }

    public Bitmap getImage() {
        return image;
    }

    public void setImage(Bitmap image) {
        this.image = image;
    }
}
