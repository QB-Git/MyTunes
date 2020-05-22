package com.nolin.mytunes.fragments;

import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;

import androidx.fragment.app.Fragment;

import com.nolin.mytunes.ui.MusiqueAdapter;
import com.nolin.mytunes.R;
import com.nolin.mytunes.models.AudioEtImages;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.utils.ConnectionRecherche;

import java.util.ArrayList;
import java.util.List;

public class SearchFragment extends Fragment {

    private final String URL_TO_HIT = "https://mytunes20200429155409.azurewebsites.net/api/Musiques";

    private ListView lvMusiques;
    private EditText tiRecherche;
    private ImageButton buttonRecherche;
    private View myView;
    private MusiqueAdapter adapter;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_search, container, false);

        lvMusiques = myView.findViewById(R.id.lvMusiques);
        tiRecherche = myView.findViewById(R.id.tiRecherche);
        buttonRecherche = myView.findViewById(R.id.buttonRecherche);

        new ConnectionRecherche(this).execute(URL_TO_HIT);

        return myView;
    }

    public void updateAdapter(ArrayList<AudioEtImages> object){
        List<AudioModel> audios = new ArrayList<>();
        List<Bitmap> images = new ArrayList<>();
        for(int i=0; i<object.size(); i++){
            audios.add(object.get(i).getMusique());
            images.add(object.get(i).getImage());
        }
        adapter = new MusiqueAdapter(getContext(), R.layout.recherche_row, audios,images);
        lvMusiques.setAdapter(adapter);
        adapter.notifyDataSetChanged();
    }
}
