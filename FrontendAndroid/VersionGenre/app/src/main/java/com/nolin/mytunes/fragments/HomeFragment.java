package com.nolin.mytunes.fragments;

import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.nolin.mytunes.GenreAdapter;
import com.nolin.mytunes.R;
import com.nolin.mytunes.models.GenreModel;
import com.nolin.mytunes.utils.Connection;

import java.util.ArrayList;
import java.util.concurrent.ExecutionException;

public class HomeFragment extends Fragment {

    private final String URL_TO_HIT = "https://mytunes20200429155409.azurewebsites.net/api/Genres";

    private ListView lvGenres;
    private View myView;
    private GenreAdapter adapter;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_home, container, false);

        lvGenres = myView.findViewById(R.id.lvGenres);

        new Connection(this).execute(URL_TO_HIT);

        return myView;
    }

    public void updateAdapter(ArrayList<GenreModel> object) {
        adapter = new GenreAdapter(getContext(), R.layout.row, object);
        lvGenres.setAdapter(adapter);
        adapter.notifyDataSetChanged();
    }
}

