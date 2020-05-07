package com.nolin.mytunes.models;

import java.util.Objects;

public class GenreModel {
    private int mID_Genre;
    private String mGenre;

    public GenreModel() {
    }

    public int getID_Genre() {
        return mID_Genre;
    }
    public String getID_Genre_String() {
        return Integer.toString(mID_Genre);
    }

    public void setID_Genre(int mID_Genre) {
        this.mID_Genre = mID_Genre;
    }

    public String getGenre() {
        return mGenre;
    }

    public void setGenre(String mGenre) {
        this.mGenre = mGenre;
    }

    @Override
    public String toString() {
        return "GenreModel{" +
                "ID_Genre=" + mID_Genre +
                ", Genre='" + mGenre + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        GenreModel that = (GenreModel) o;
        return mID_Genre == that.mID_Genre &&
                Objects.equals(mGenre, that.mGenre);
    }

}
