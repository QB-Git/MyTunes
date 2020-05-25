package com.nolin.mytunes.models;

import java.util.ArrayList;

public class AlbumModel {
    private int id_album;
    private String nom_album;
    private PochetteModel pochette;
    private ArrayList<JSONAudio> musiques;

    public int getId_album() {
        return id_album;
    }

    public void setId_album(int id_album) {
        this.id_album = id_album;
    }

    public String getNom_album() {
        return nom_album;
    }

    public void setNom_album(String nom_album) {
        this.nom_album = nom_album;
    }

    public PochetteModel getPochette() {
        return pochette;
    }

    public void setPochette(PochetteModel pochette) {
        this.pochette = pochette;
    }
}
