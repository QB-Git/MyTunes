package com.nolin.mytunes.fragments;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.nolin.mytunes.R;
import com.nolin.mytunes.models.AudioModel;

public class HomeFragment extends Fragment {

    private View myView;

    private TextView tvAlbum;
    private TextView tvTitre;
    private TextView tvArtiste;

    private ImageButton ibPrevious;
    private ImageButton ibPlay;
    private ImageButton ibNext;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_home, container, false);


        return myView;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        tvTitre = myView.findViewById(R.id.titre);

        Bundle bundle = getArguments();
        Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : Get du bundle");

        if( bundle  != null )
        {
            AudioModel audioModel = (AudioModel)bundle.getSerializable("libraryFragment_morceauCourant");
            Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : Get du AudioModel");

            if( audioModel != null )
            {
                Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : Récup du titre");
                Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : "+audioModel.getTitre());
                tvTitre.setText(audioModel.getTitre());

            }
            else
                Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : audioModel null");
        }
        else
            Log.i( "TEST PASSAGE BUNDLE", "HomeFragment.onViewCreated() : bundle null");
    }

    /*
    public void displayReceivedData(AudioModel audioModel){
        tvTitre.setText(audioModel.getTitre());
    }

    @Override
    public void onMusiqueClick(AudioModel audioModel) {
        Log.e("TAG", "YOUPIIII !!!");
        tvTitre.setText(audioModel.getTitre());
        // traitement de l audioModel
    }*/
}

