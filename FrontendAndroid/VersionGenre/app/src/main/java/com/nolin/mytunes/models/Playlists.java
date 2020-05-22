package com.nolin.mytunes.models;

import java.util.Objects;

public class Playlists {
    private int id_user;
    private int id_musique;
    private AudioModel musique;

    public Playlists(int id_user, int id_musique, AudioModel musique) {
        this.id_user = id_user;
        this.id_musique = id_musique;
        this.musique = musique;
    }

    public int getId_user() {
        return id_user;
    }

    public void setId_user(int id_user) {
        this.id_user = id_user;
    }

    public int getId_musique() {
        return id_musique;
    }

    public void setId_musique(int id_musique) {
        this.id_musique = id_musique;
    }

    public AudioModel getMusique() {
        return musique;
    }

    public void setMusique(AudioModel musique) {
        this.musique = musique;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Playlists playlists = (Playlists) o;
        return id_user == playlists.id_user &&
                id_musique == playlists.id_musique &&
                Objects.equals(musique, playlists.musique);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id_user, id_musique, musique);
    }
}
