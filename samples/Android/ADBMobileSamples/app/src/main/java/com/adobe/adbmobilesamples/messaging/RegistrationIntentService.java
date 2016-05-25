package com.adobe.adbmobilesamples.messaging;

import android.app.IntentService;
import android.content.Intent;
import android.util.Log;

import com.adobe.mobile.Config;
import com.google.android.gms.gcm.GcmPubSub;
import com.google.android.gms.gcm.GoogleCloudMessaging;
import com.google.android.gms.iid.InstanceID;

public class RegistrationIntentService extends IntentService {

    private static final String TAG = "ADBRegIntentServ";

    public RegistrationIntentService() {
        super(TAG);
    }

    @Override
    protected void onHandleIntent(Intent intent) {
        try {
            synchronized (TAG) {
                InstanceID instanceID = InstanceID.getInstance(this);
                String token = instanceID.getToken("<sender_id>", /*replace with your sender id*/
                        GoogleCloudMessaging.INSTANCE_ID_SCOPE, null);

                //send the gcm registration token to the adobemobile sdk
                Config.setPushIdentifier(token);

                GcmPubSub pubSub = GcmPubSub.getInstance(this);
                pubSub.subscribe(token, "/topics/global", null);

                Log.d("", "////////////////////////////////////////");
                Log.d(TAG, "PushID (reg token): " + token);
                Log.d("", "////////////////////////////////////////");
            }
        } catch (Exception e) {
            Log.d(TAG, "Failed to refresh token", e);
        }
    }
}
