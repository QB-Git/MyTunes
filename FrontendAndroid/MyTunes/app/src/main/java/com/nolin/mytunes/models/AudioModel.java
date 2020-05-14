package com.nolin.mytunes.models;

import java.util.ArrayList;
import java.util.Date;
/*
TO DO : Pochette Note Date Artistes et Albums
 */
public class AudioModel {

    private int mId_Musique;
    private String mUrl;
    private String mTitre;
    private String mLangue;

    private Editeur mEditeur;

    public int getId_Musique() {
        return mId_Musique;
    }

    public void setId_Musique(int mId_Musique) {
        this.mId_Musique = mId_Musique;
    }

    public String getURL() {
        return mUrl;
    }

    public void setURL(String mUrl) {
        this.mUrl = mUrl;
    }

    public String getTitre() {
        return mTitre;
    }

    public void setTitre(String mTitre) {
        this.mTitre = mTitre;
    }

    public String getLangue() {
        return mLangue;
    }

    public void setLangue(String langue) {
        this.mLangue = langue;
    }

    public Editeur getEditeur() {
        return mEditeur;
    }

    public void setEditeur(Editeur mEditeur) {
        this.mEditeur = mEditeur;
    }




    // TO DO
    //private Pochette mPochette
    //private ArrayList<Artiste> mArtistes;
    //private ArrayList<Album> mAlbums;
    // private Date mDate;





}
