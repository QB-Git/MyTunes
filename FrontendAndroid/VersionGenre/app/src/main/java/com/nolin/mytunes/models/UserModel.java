package com.nolin.mytunes.models;

import java.util.ArrayList;
import java.util.Objects;

public class UserModel {
    private int id_user;
    private String pseudo;
    private String password;
    private ArrayList<Playlists> playlists;

    public UserModel(int id_user, String pseudo, String password, ArrayList<Playlists> playlist) {
        this.id_user = id_user;
        this.pseudo = pseudo;
        this.password = password;
        this.playlists = playlist;
    }

    public int getId_user() {
        return id_user;
    }

    public void setId_user(int id_user) {
        this.id_user = id_user;
    }

    public String getPseudo() {
        return pseudo;
    }

    public void setPseudo(String pseudo) {
        this.pseudo = pseudo;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public ArrayList<Playlists> getPlaylist() {
        return playlists;
    }

    public void setPlaylist(ArrayList<Playlists> playlist) {
        this.playlists = playlist;
    }

}
