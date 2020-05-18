package com.nolin.mytunes.models;

import java.util.ArrayList;

// Modèle de base d'un Artiste
public class ArtisteModel {
    private int id_artiste;
    private String nom;
    private String prenom;
    private ArrayList<AudioModel> musiques;

    public int getID_Artiste() {
        return id_artiste;
    }
    public String getID_Artiste_String() {
        return Integer.toString(id_artiste);
    }

    public void setID_Artiste(int mID_Artiste) {
        this.id_artiste = mID_Artiste;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getPrenom() {
        return prenom;
    }

    public void setPrenom(String mPrenom) {
        this.prenom = mPrenom;
    }
}
