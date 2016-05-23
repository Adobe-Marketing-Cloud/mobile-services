/*************************************************************************

 ADOBE SYSTEMS INCORPORATED
 Copyright 2015 Adobe Systems Incorporated
 All Rights Reserved.

 NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
 terms of the Adobe license agreement accompanying it.  If you have received this file from a
 source other than Adobe, then your use, modification, or distribution of it requires the prior
 written permission of Adobe.

 **************************************************************************/

/*
 * Visit https://marketing.adobe.com/resources/help/en_US/mobile/in_app_messaging.html for more information about
 * in-app messaging.
 */

package com.adobe.adbmobilesamples.messaging;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;

import com.adobe.adbmobilesamples.R;
import com.adobe.mobile.Analytics;
import com.adobe.mobile.Config;
import java.util.*;

public class InAppMessagingActivity extends Activity {
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.in_app_messages);
    }

    @Override
    protected void onPause() {
        super.onPause();
		/*
		 * Adobe Tracking - Config
		 *
		 * call pauseCollectingLifecycleData() in case leaving this activity also means leaving the app
		 * must be in the onPause() of every activity in your app
		 */
        Config.pauseCollectingLifecycleData();
    }

    @Override
    protected void onResume() {
        super.onResume();
		/*
		 * Adobe Tracking - Config
		 *
		 * call collectLifecycleData() to begin collecting lifecycle data
		 * must be in the onResume() of every activity in your app
		 */
        Config.collectLifecycleData(this);

        /*
         * Adobe Tracking - Analytics
         *
         * call to trackState:data: for view states report
         * trackState:data: increments the page view
         */
        Analytics.trackState("In-App Message Example", null);
    }

    public void showFullscreenMessage(View view) {
        /*
         * Adobe Tracking - Analytics
         *
         * triggering an in-app message on a custom state
         */
        Analytics.trackState("fullscreen example", null);
    }

    public void showAlertMessage(View view) {
        /*
         * Adobe Tracking - Analytics
         *
         * triggering an in-app message on a custom action
         */
        Analytics.trackAction("alert example", null);
    }

    public void showLocalNotification(View view) {
        /*
         * Adobe Tracking - Analytics
         *
         * triggering an in-app message on context data
         */
        HashMap<String, Object> exampleContextData = new HashMap<String, Object>();
        exampleContextData.put("local", "notification");
        Analytics.trackAction("local notification sample", exampleContextData);
    }
}