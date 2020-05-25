package com.nolin.mytunes.models;

import java.util.Objects;

public class PochetteModel {
    private int id_pochette;
    private String img_pochette;

    public PochetteModel(int id_pochette, String img_pochette) {
        this.id_pochette = id_pochette;
        this.img_pochette = img_pochette;
    }

    public int getId_pochette() {
        return id_pochette;
    }

    public void setId_pochette(int id_pochette) {
        this.id_pochette = id_pochette;
    }

    public String getImg_pochette() {
        return img_pochette;
    }

    public void setImg_pochette(String img_pochette) {
        this.img_pochette = img_pochette;
    }


}
