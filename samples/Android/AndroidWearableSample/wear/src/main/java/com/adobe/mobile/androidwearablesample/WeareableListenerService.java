package com.adobe.mobile.androidwearablesample;

import com.adobe.mobile.DataListenerWearable;
import com.google.android.gms.wearable.WearableListenerService;

public class WeareableListenerService extends WearableListenerService {

    @Override
    public void onDataChanged(com.google.android.gms.wearable.DataEventBuffer dataEvents) {

        DataListenerWearable.onDataChanged(dataEvents);
    }
}
