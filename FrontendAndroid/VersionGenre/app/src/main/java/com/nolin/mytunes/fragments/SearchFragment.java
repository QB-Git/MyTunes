package com.nolin.mytunes.fragments;

import android.graphics.Bitmap;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;

import androidx.fragment.app.Fragment;

import com.google.android.material.textfield.TextInputEditText;
import com.nolin.mytunes.AudioPlayer;
import com.nolin.mytunes.ui.MusiqueAdapter;
import com.nolin.mytunes.R;
import com.nolin.mytunes.models.AudioEtImages;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.utils.ConnectionRecherche;
import com.nolin.mytunes.utils.LoadingDialog;
import java.util.ArrayList;

public class SearchFragment extends Fragment {

    private String url_all_musiques = "https://mytunes20200429155409.azurewebsites.net/api/Musiques";
    private String url_titre_musiques = "https://mytunes20200429155409.azurewebsites.net/api/Musiques/recherche/titre/";
    private ListView lvMusiques;
    private EditText tiRecherche;
    private ImageButton buttonRecherche;
    private View myView;
    private MusiqueAdapter adapter;
    private ArrayList<AudioModel> musiques;
    private AudioPlayer audioPlayer;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_search, container, false);

        lvMusiques = myView.findViewById(R.id.lvMusiques);
        tiRecherche = myView.findViewById(R.id.tiRecherche);
        buttonRecherche = myView.findViewById(R.id.buttonRecherche);

        buttonRecherche.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String recherche = tiRecherche.getText().toString();
                Bundle bundle = getArguments();
                if( bundle != null )
                {
                    LoadingDialog loadingDialog = (LoadingDialog)bundle.getSerializable("mainActivity_loadingDialog");
                    if( loadingDialog != null )
                    {
                        loadingDialog.startLoadingDialog();
                    }
                }

                if (recherche.isEmpty()){
                    new ConnectionRecherche(SearchFragment.this).execute(url_all_musiques);
                } else {

                    new ConnectionRecherche(SearchFragment.this).execute(url_titre_musiques+recherche);
                }
            }});
        lvMusiques.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                AudioPlayer.start(getContext(), Uri.parse(musiques.get(i).getURL()));
                //AudioPlayer.getInstance(getContext(), Uri.parse(musiques.get(i).getURL()));
                Bundle bundle = getArguments();

                if( bundle != null )
                {
                    bundle.putSerializable("morceauCourant", musiques.get(i));
                }

            }
        });
        return myView;
    }

    public void updateAdapter(ArrayList<AudioEtImages> object){
        ArrayList<AudioModel> audios = new ArrayList<>();
        ArrayList<Bitmap> images = new ArrayList<>();

        if (object != null){
            for(int i=0; i<object.size(); i++){
                audios.add(object.get(i).getMusique());
                images.add(object.get(i).getImage());
            }
        }
        this.musiques = audios;
        adapter = new MusiqueAdapter(getContext(), R.layout.row, audios,images);
        lvMusiques.setAdapter(adapter);

        Bundle bundle = getArguments();
        if( bundle != null )
        {
            LoadingDialog loadingDialog = (LoadingDialog)bundle.getSerializable("mainActivity_loadingDialog");

            if( loadingDialog != null )
            {
                loadingDialog.dismissDialog();
            }

        }


        adapter.notifyDataSetChanged();
    }
}
