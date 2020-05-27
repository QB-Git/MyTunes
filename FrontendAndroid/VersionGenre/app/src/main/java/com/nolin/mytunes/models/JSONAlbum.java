package com.nolin.mytunes.models;

public class JSONAlbum {
    private int id_album;
    private AlbumModel album;
    private int id_musique;
    private int num_piste;

    public int getId_album() {
        return id_album;
    }

    public void setId_album(int id_album) {
        this.id_album = id_album;
    }

    public AlbumModel getAlbum() {
        return album;
    }

    public void setAlbum(AlbumModel album) {
        this.album = album;
    }

    public int getId_musique() {
        return id_musique;
    }

    public void setId_musique(int id_musique) {
        this.id_musique = id_musique;
    }

    public int getNum_piste() {
        return num_piste;
    }

    public void setNum_piste(int num_piste) {
        this.num_piste = num_piste;
    }
}
