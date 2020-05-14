package com.nolin.mytunes.models;

import java.util.Objects;

public class AudioModel{
    private int id_musique;
    private String url;
    private String titre;
    private PochetteModel pochette;
    private String langue;

    public AudioModel(int id_musique, String url, String titre, PochetteModel pochette, String langue) {
        this.id_musique = id_musique;
        this.url = url;
        this.titre = titre;
        this.pochette = pochette;
        this.langue = langue;
    }

    public int getId_musique() {
        return id_musique;
    }

    public void setId_musique(int id_musique) {
        this.id_musique = id_musique;
    }

    public String getURL() {
        return url;
    }

    public void setURL(String url) {
        this.url = url;
    }

    public String getTitre() {
        return titre;
    }

    public void setTitre(String titre) {
        this.titre = titre;
    }

    public PochetteModel getPochette() {
        return pochette;
    }

    public void setPochette(PochetteModel pochette) {
        this.pochette = pochette;
    }

    public String getLangue() {
        return langue;
    }

    public void setLangue(String langue) {
        this.langue = langue;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        AudioModel that = (AudioModel) o;
        return id_musique == that.id_musique &&
                Objects.equals(url, that.url) &&
                Objects.equals(titre, that.titre) &&
                Objects.equals(pochette, that.pochette) &&
                Objects.equals(langue, that.langue);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id_musique, url, titre, pochette, langue);
    }
}