package com.nolin.mytunes.models;

import java.util.ArrayList;

public class ArtisteModel {
    private int mID_Artiste;
    private String mNom;
    private String mPrenom;
    private ArrayList<AudioModel> mAudioModelList;

    public int getID_Artiste() {
        return mID_Artiste;
    }
    public String getID_Artiste_String() {
        return Integer.toString(mID_Artiste);
    }

    public void setID_Artiste(int mID_Artiste) {
        this.mID_Artiste = mID_Artiste;
    }

    public String getNom() {
        return mNom;
    }

    public void setNom(String mNom) {
        this.mNom = mNom;
    }

    public String getPrenom() {
        return mPrenom;
    }

    public void setPrenom(String mPrenom) {
        this.mPrenom = mPrenom;
    }
}
