package com.nolin.mytunes.fragments;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import androidx.fragment.app.Fragment;

import com.nolin.mytunes.AudioPlayer;
import com.nolin.mytunes.R;
import com.nolin.mytunes.models.AudioEtImages;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.ui.AudioAdapter;
import com.nolin.mytunes.ui.MusiqueAdapter;
import com.nolin.mytunes.utils.Connection;
import com.nolin.mytunes.utils.LoadingDialog;

import java.util.ArrayList;

public class LibraryFragment extends Fragment {

    private final String URL_TO_HIT = "https://mytunes20200429155409.azurewebsites.net/api/Musiques";

    private ListView lvAudio;
    private View myView;
    private MusiqueAdapter adapter;
    private ArrayList<AudioModel> audioModelList;
    public static Uri uri;
    private AudioPlayer audioPlayer;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_library, container, false);

        new Connection(this).execute(URL_TO_HIT);

        lvAudio = myView.findViewById(R.id.lvAudio);
        lvAudio.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                uri = Uri.parse(audioModelList.get(i).getURL());
                AudioPlayer.start(getContext(), uri);
                Log.i( "TEST PASSAGE BUNDLE", "onItemClick() : Récupération du bundle");
                Bundle bundle = getArguments();

                if( bundle != null )
                {
                    bundle.putSerializable("morceauCourant", audioModelList.get(i));
                    Log.i( "TEST PASSAGE BUNDLE", "onItemClick() : Apres ajout audioModel");
                }
            }
        });
        return myView;
    }

    public void updateAdapter(ArrayList<AudioEtImages> object) {
        ArrayList<AudioModel> audios = new ArrayList<>();
        ArrayList<Bitmap> images = new ArrayList<>();

        if (object != null){
            for(int i=0; i<object.size(); i++){
                audios.add(object.get(i).getMusique());
                images.add(object.get(i).getImage());
            }
        }
        Bundle bundle = getArguments();
        this.audioModelList = audios;
        adapter = new MusiqueAdapter(getContext(), R.layout.row, audios,images);
        lvAudio.setAdapter(adapter);

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
