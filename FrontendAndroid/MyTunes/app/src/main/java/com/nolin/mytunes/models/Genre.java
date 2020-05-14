package com.nolin.mytunes.models;

import java.util.ArrayList;
import java.util.Objects;

public class Genre {
    private int mId_Genre;
    private String mGenre;
    private ArrayList<AudioModel> mMusiques;

    public Genre(int mId_Genre, String mGenre) {
        this.mId_Genre = mId_Genre;
        this.mGenre = mGenre;
    }

    public Genre() {
    }

    public int getId_Genre() {
        return mId_Genre;
    }

    public void setId_Genre(int mId_Genre) {
        this.mId_Genre = mId_Genre;
    }

    public String getGenre() {
        return mGenre;
    }

    public void setGenre(String mGenre) {
        this.mGenre = mGenre;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Genre genre = (Genre) o;
        return mId_Genre == genre.mId_Genre &&
                Objects.equals(mGenre, genre.mGenre);
    }

    @Override
    public String toString() {
        return "Genre{" +
                "mId_Genre=" + mId_Genre +
                ", mGenre='" + mGenre + '\'' +
                '}';
    }
}
