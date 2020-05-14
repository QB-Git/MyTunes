package com.nolin.mytunes.fragments;

import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import androidx.fragment.app.Fragment;

import com.nolin.mytunes.R;
import com.nolin.mytunes.models.AudioModel;
import com.nolin.mytunes.ui.AudioAdapter;
import com.nolin.mytunes.utils.Connection;

import java.util.ArrayList;

public class LibraryFragment extends Fragment {

    private final String URL_TO_HIT = "https://mytunes20200429155409.azurewebsites.net/api/Musiques";

    private ListView lvAudio;
    private View myView;
    private AudioAdapter adapter;
    private MediaPlayer mediaPlayer;

    private ArrayList<AudioModel> object;
    public static Uri uri;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        myView = inflater.inflate(R.layout.fragment_library, container, false);

        lvAudio = myView.findViewById(R.id.lvAudio);

        new Connection(this).execute(URL_TO_HIT);

        lvAudio.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                stopMediaPlayer();
                uri = Uri.parse(object.get(i).getURL());
                mediaPlayer = MediaPlayer.create(getContext(), uri);
                mediaPlayer.start();
            }
        });

        return myView;
    }

    private void stopMediaPlayer() {
        if (mediaPlayer != null) {
            mediaPlayer.release();
            mediaPlayer = null;
        }
    }

    public void updateAdapter(ArrayList<AudioModel> object) {
        this.object = object;
        adapter = new AudioAdapter(getContext(), R.layout.row, object);
        lvAudio.setAdapter(adapter);
        adapter.notifyDataSetChanged();
    }
}
