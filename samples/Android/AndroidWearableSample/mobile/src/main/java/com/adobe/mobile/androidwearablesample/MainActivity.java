package com.adobe.mobile.androidwearablesample;

import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;

import com.adobe.mobile.Analytics;
import com.adobe.mobile.Config;
import com.adobe.mobile.MobilePrivacyStatus;


public class MainActivity extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Config.setContext(this);
        Config.setDebugLogging(true);



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

        findViewById(R.id.SetUserIdentifier).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Config.setUserIdentifier("custom identifier");
            }
        });

        findViewById(R.id.SetPrivacyOptOut).setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Config.setPrivacyStatus(MobilePrivacyStatus.MOBILE_PRIVACY_STATUS_OPT_OUT);
            }
        });


        findViewById(R.id.SetPrivacyOptIn).setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Config.setPrivacyStatus(MobilePrivacyStatus.MOBILE_PRIVACY_STATUS_OPT_IN);
            }
        });

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }
    @Override
    protected void onResume() {
        super.onResume();
        Config.collectLifecycleData(this);
    }

    @Override
    protected void onPause() {
        super.onPause();
        Config.pauseCollectingLifecycleData();
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
