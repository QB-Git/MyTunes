package com.nolin.mytunes.ui;

import com.nolin.mytunes.R;
import android.content.Context;
import android.graphics.Bitmap;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import androidx.annotation.NonNull;

import com.nolin.mytunes.models.JSONArtiste;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.R;
import java.util.List;

public class MusiqueAdapter extends ArrayAdapter {

    private List<AudioModel> musiqueModelList;
    private int ressource;
    private ImageView ivPochette;
    private TextView tvArtiste;
    private TextView tvMusique;
    List<Bitmap> imageList;

    public MusiqueAdapter(@NonNull Context context, int resource, List<AudioModel> objects, List<Bitmap> imageList) {
        super(context, resource, objects);
        musiqueModelList = objects;
        this.ressource = resource;
        this.imageList = imageList;
    }

    @NonNull
    @Override
    public View getView(int position, View convertView, @NonNull ViewGroup parent) {
        if(convertView==null){
            convertView = LayoutInflater.from(getContext()).inflate(ressource, null);
        }

        ivPochette = convertView.findViewById(R.id.ivPochette_recherche);
        tvMusique = convertView.findViewById(R.id.tvMusique);
        tvArtiste = convertView.findViewById(R.id.tvArtiste_recherche);
        tvMusique.setText(musiqueModelList.get(position).getTitre());
        ivPochette.setImageBitmap(imageList.get(position));

        StringBuilder temp = new StringBuilder();

        JSONArtiste current;
        for(int i=0 ; i<musiqueModelList.get(position).getArtistes().size(); i++){
            current= musiqueModelList.get(position).getArtiste(i);
            if (current.getArtiste().getPrenom()!=null)
                temp.append(current.getArtiste().getPrenom()).append(" ");
            if (current.getArtiste().getNom()!=null)
                temp.append(current.getArtiste().getNom()).append("   ");
        }

        tvArtiste.setText(temp.toString());
        return convertView;
    }
}