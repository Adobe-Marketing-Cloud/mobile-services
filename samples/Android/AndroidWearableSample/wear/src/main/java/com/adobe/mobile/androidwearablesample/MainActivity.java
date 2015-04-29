package com.adobe.mobile.androidwearablesample;

import android.app.Activity;
import android.os.Bundle;
import android.support.wearable.view.WatchViewStub;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.adobe.mobile.Analytics;
import com.adobe.mobile.Config;

public class MainActivity extends Activity {

    private TextView mTextView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        final WatchViewStub stub = (WatchViewStub) findViewById(R.id.watch_view_stub);
        stub.setOnLayoutInflatedListener(new WatchViewStub.OnLayoutInflatedListener() {
            @Override
            public void onLayoutInflated(WatchViewStub stub) {
                mTextView = (TextView) stub.findViewById(R.id.text);


                 findViewById(R.id.TrackAction).setOnClickListener(new View.OnClickListener() {

                     @Override
                     public void onClick(View v) {
                         Analytics.trackAction("Action Name", null);
                     }
                 });


                findViewById(R.id.TrackState).setOnClickListener(new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        Analytics.trackAction("State Name", null);
                    }
                });

            }
        });

        Config.setContext(getApplicationContext(), Config.ApplicationType.APPLICATION_TYPE_WEARABLE);
        Config.setDebugLogging(true);

    }
}
