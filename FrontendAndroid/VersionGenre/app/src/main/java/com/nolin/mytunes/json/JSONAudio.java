package com.nolin.mytunes.json;

import com.nolin.mytunes.models.AudioModel;

public class JSONAudio {
    private int id_album;
    private int id_musique;
    private AudioModel musique;

    public int getId_album() {
        return id_album;
    }

    public void setId_album(int id_album) {
        this.id_album = id_album;
    }

    public int getId_musique() {
        return id_musique;
    }

    public void setId_musique(int id_musique) {
        this.id_musique = id_musique;
    }
}
