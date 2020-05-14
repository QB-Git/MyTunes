package com.nolin.mytunes.ui;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;

import com.nolin.mytunes.R;
import com.nolin.mytunes.models.AudioModel;

import java.util.List;


public class AudioAdapter extends ArrayAdapter {

    private List<AudioModel> audioModelList;
    private int ressource;

    public AudioAdapter(@NonNull Context context, int ressource, List<AudioModel> objects) {
        super(context, ressource,objects);
        audioModelList = objects;
        this.ressource = ressource;
    }

    @NonNull
    @Override
    public View getView(int position, View convertView, @NonNull ViewGroup parent){
        if(convertView==null){
            convertView = LayoutInflater.from(getContext()).inflate(ressource, null);
        }
        ImageView ivAudioIcon;
        TextView tvTitre;
        TextView tvArtiste;


        ivAudioIcon = convertView.findViewById(R.id.ivPochette);
        tvTitre = convertView.findViewById(R.id.tvTitre);


        tvTitre.setText(audioModelList.get(position).getTitre());
        //tvArtiste.setText(audioModelList.get(position).getArtistes());
        ivAudioIcon.setImageResource(R.drawable.bubblegumkk);

        return convertView;
    }
}
