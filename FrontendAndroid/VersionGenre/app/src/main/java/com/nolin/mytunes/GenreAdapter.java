package com.nolin.mytunes;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;

import com.nolin.mytunes.models.GenreModel;
import java.util.List;

public class GenreAdapter extends ArrayAdapter {

    private List<GenreModel> genreModelList;
    private int ressource;
    public GenreAdapter(@NonNull Context context, int resource, List<GenreModel> objects) {
        super(context, resource, objects);
        genreModelList = objects;
        this.ressource = resource;
    }

    @NonNull
    @Override
    public View getView(int position, View convertView, @NonNull ViewGroup parent) {
        if(convertView==null){
            convertView = LayoutInflater.from(getContext()).inflate(ressource, null);
        }
        ImageView ivAudioIcon;
        TextView tvID_Genre;
        TextView tvGenre;


        ivAudioIcon = convertView.findViewById(R.id.ivPochette);
        tvID_Genre = convertView.findViewById(R.id.tvID_Genre);
        tvGenre = convertView.findViewById(R.id.tvGenre);


        tvGenre.setText(genreModelList.get(position).getGenre());
        tvID_Genre.setText(genreModelList.get(position).getID_Genre_String());
        ivAudioIcon.setImageResource(R.drawable.bubblegumkk);

        return convertView;
    }
}