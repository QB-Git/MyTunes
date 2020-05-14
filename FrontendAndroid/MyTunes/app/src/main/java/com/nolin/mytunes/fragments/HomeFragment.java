package com.nolin.mytunes.fragments;

import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.SeekBar;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.nolin.mytunes.R;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.models.GenreModel;
import com.nolin.mytunes.ui.AudioAdapter;
import com.nolin.mytunes.utils.Connection;

import java.net.URI;
import java.net.URISyntaxException;
import java.util.ArrayList;

public class HomeFragment extends Fragment {

    private View myView;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_home, container, false);
        return myView;
    }


}

