package com.adobe.mobile.androidwearablesample;

import com.adobe.mobile.DataListenerHandheld;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.wearable.Wearable;

public class WearableListenerService  extends com.google.android.gms.wearable.WearableListenerService {
    private GoogleApiClient mGoogleApiClient;

    @Override
    public void onCreate() {
        super.onCreate();
        mGoogleApiClient = new GoogleApiClient.Builder(this)
                .addApi(Wearable.API)
                .build();
        mGoogleApiClient.connect();
    }
    @Override
    public void onDestroy() {
        super.onDestroy();
        mGoogleApiClient.disconnect();
    }

    @Override
    public void onDataChanged(com.google.android.gms.wearable.DataEventBuffer dataEvents) {
        DataListenerHandheld.onDataChanged(dataEvents, mGoogleApiClient, this);
    }
}
