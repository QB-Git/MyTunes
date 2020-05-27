package com.nolin.mytunes.models;


// Un AudioModel a une liste d'Artistes
public class JSONArtiste {
    private int id_artiste;
    private ArtisteModel artiste;
    private int id_musique;

    public int getId_artiste() {    return id_artiste;}

    public void setId_artiste(int id_artiste) {
        this.id_artiste = id_artiste;
    }

    public ArtisteModel getArtiste() {  return artiste;}

    public void setArtiste(ArtisteModel artiste) {
        this.artiste = artiste;
    }

    public int getId_musique() {    return id_musique; }

    public void setId_musique(int id_musique) {
        this.id_musique = id_musique;
    }
}
