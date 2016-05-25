/*************************************************************************

 ADOBE SYSTEMS INCORPORATED
 Copyright 2016 Adobe Systems Incorporated
 All Rights Reserved.

 NOTICE:  Adobe permits you to use, modify, and distribute this file in accordance with the
 terms of the Adobe license agreement accompanying it.  If you have received this file from a
 source other than Adobe, then your use, modification, or distribution of it requires the prior
 written permission of Adobe.

 **************************************************************************/

package com.adobe.adbmobilesamples.deeplinks;

import android.app.Activity;
import android.app.TaskStackBuilder;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;

import com.adobe.adbmobilesamples.MenuActivity;
import com.adobe.adbmobilesamples.R;
import com.adobe.adbmobilesamples.analytics.LifetimeValueActivity;
import com.adobe.adbmobilesamples.analytics.MediaActivity;
import com.adobe.adbmobilesamples.analytics.SimpleTrackingActivity;
import com.adobe.adbmobilesamples.analytics.TimedActionsActivity;
import com.adobe.adbmobilesamples.gallery.GalleryActivity;
import com.adobe.adbmobilesamples.messaging.InAppMessagingActivity;
import com.adobe.adbmobilesamples.postbacks.PostbackActivity;
import com.adobe.adbmobilesamples.target.TargetingLocationActivity;
import com.adobe.mobile.Config;
import com.adobe.mobile.TargetLocationRequest;

import java.util.List;

public class ParseDeepLinkActivity extends Activity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Config.collectLifecycleData(this);

        Intent intent = getIntent();
        if (intent == null || intent.getData() == null) {
            finish();
        }

        openDeepLink(intent.getData());

        // Finish this activity
        finish();
    }

    private void openDeepLink(Uri deepLink) {
        TaskStackBuilder stackBuilder = TaskStackBuilder.create(this);

        // Treat each path segment of the URI as a deep link
        List<String> segments = deepLink.getPathSegments();

        // Create a task stack from the deep links
        if (segments != null) {
            for (String segment : segments) {
                Intent route = null;
                if (getString(R.string.path_gallery_activity).equals(segment)) {
                    route = new Intent(getApplicationContext(), GalleryActivity.class);
                } else if (getString(R.string.path_messaging_activity).equals(segment)) {
                    route = new Intent(getApplicationContext(), InAppMessagingActivity.class);
                } else if (getString(R.string.path_postbacks_activity).equals(segment)) {
                    route = new Intent(getApplicationContext(), PostbackActivity.class);
                } else if (getString(R.string.path_target_activity).equals(segment)) {
                    route = new Intent(getApplicationContext(), TargetingLocationActivity.class);
                } else if (getString(R.string.path_analytics_simple_activity).equals(segment)) {
                    route = new Intent(getApplicationContext(), SimpleTrackingActivity.class);
                } else if (getString(R.string.path_analytics_ltv_activity).equals(segment)) {
                    route = new Intent(getApplicationContext(), LifetimeValueActivity.class);
                } else if (getString(R.string.path_analytics_timed_actions_activity).equals(segment)) {
                    route = new Intent(getApplicationContext(), TimedActionsActivity.class);
                } else if (getString(R.string.path_analytics_media_activity).equals(segment)) {
                    route = new Intent(getApplicationContext(), MediaActivity.class);
                }

                if (route != null) {
                    stackBuilder.addNextIntentWithParentStack(route);
                }
            }
        }

        // Fall back to the main activity
        if (stackBuilder.getIntentCount() == 0) {
            stackBuilder.addNextIntent(new Intent(this, MenuActivity.class));
        }

        // Launch the activities
        stackBuilder.startActivities();
    }
}
