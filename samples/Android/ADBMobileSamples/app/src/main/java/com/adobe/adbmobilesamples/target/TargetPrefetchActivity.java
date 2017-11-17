package com.adobe.adbmobilesamples.target;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.EditText;
import android.widget.TextView;

import com.adobe.adbmobilesamples.R;
import com.adobe.mobile.Config;
import com.adobe.mobile.Target;
import com.adobe.mobile.TargetPrefetchObject;
import com.adobe.mobile.TargetRequestObject;
import com.adobe.mobile.Visitor;
import com.adobe.mobile.VisitorID;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class TargetPrefetchActivity extends Activity {
    private TextView lblLoadRequestResponse;
    private TextView lblPrefetchCache;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        this.requestWindowFeature(Window.FEATURE_NO_TITLE);
        setContentView(R.layout.target_prefetch);

        Config.setContext(this.getApplicationContext());
        Visitor.syncIdentifier("testType", "testID", VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_LOGGED_OUT);

        lblLoadRequestResponse = (TextView)findViewById(R.id.lblLoadRequestResponse);
        lblPrefetchCache = (TextView)findViewById(R.id.lblPrefetchCache);
    }

    public void prefetchTest(View view) {
        List<TargetPrefetchObject> prefetchList = new ArrayList<>();
        prefetchList.add(Target.createTargetPrefetchObject("prefetchTest1", new HashMap<String, Object>() {{
            put("ad", "1");
        }}));
        Target.TargetCallback<Boolean> callback = new Target.TargetCallback<Boolean>() {
            @Override
            public void call(final Boolean status) {
                TargetPrefetchActivity.this.runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        String cachingStatus = status ? "YES" : "NO";
                        lblPrefetchCache.setText("Content was cached: " + cachingStatus);
                    }
                });
            }};

        Target.prefetchContent(prefetchList, new HashMap<String, Object>(), callback);
    }

    public void prefetchTest2 (View view){
        List<TargetPrefetchObject> prefetchList = new ArrayList<>();
        prefetchList.add(Target.createTargetPrefetchObject("prefetchTest2", new HashMap<String, Object>() {{
            put("ad", "2");
        }}, new HashMap<String, Object>() {
            {
                put("id", "34");
                put("total", 125.34);
                put("purchasedProductIds", "34, 125, 99");
            }}, null));

        Target.TargetCallback<Boolean> callback = new Target.TargetCallback<Boolean>() {
            @Override
            public void call(final Boolean status) {
                TargetPrefetchActivity.this.runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        String cachingStatus = status ? "YES" : "NO";
                        lblPrefetchCache.setText("Content was cached: " + cachingStatus);
                    }
                });
            }};

        Target.prefetchContent(prefetchList, new HashMap<String, Object>(), callback);
    }

    public void loadRequest(View view) {
        EditText etMboxName = (EditText)findViewById(R.id.etMboxName);
        String mboxName = etMboxName.getText().toString();
        Target.TargetCallback<String> callback = new Target.TargetCallback<String>() {
            @Override
            public void call(final String content) {
                TargetPrefetchActivity.this.runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        lblLoadRequestResponse.setText("Returned content: " + content);
                    }
                    });
        }};

        if (mboxName != null && !mboxName.isEmpty()) {
            Target.loadRequest(mboxName, "default content", null, null, null, callback);
        }
    }

    public void loadRequest2(View view) {
        EditText etMboxName = (EditText)findViewById(R.id.etMboxName);
        String mboxName = etMboxName.getText().toString();
        Target.TargetCallback<String> callback = new Target.TargetCallback<String>() {
            @Override
            public void call(final String content) {
                TargetPrefetchActivity.this.runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        lblLoadRequestResponse.setText("Returned content: " + content);
                    }
                });
            }};

        if (mboxName != null && !mboxName.isEmpty()) {
            Target.loadRequest(mboxName, "default content", null, null, null, callback);
        }
    }

    public void loadBatchRequest(View view) {

        ArrayList<TargetRequestObject> locationRequests = new ArrayList<TargetRequestObject>();

        Target.TargetCallback<String> callback1 = new Target.TargetCallback<String>() {
            @Override
            public void call(final String content) {
                TargetPrefetchActivity.this.runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        lblLoadRequestResponse.setText("Returned content: " + content);
                    }
                });
            }};

        TargetRequestObject firstRequest = Target.createTargetRequestObject("prefetchTest1", "default1", null, callback1);
        locationRequests.add(firstRequest);

        Target.TargetCallback<String> callback2 = new Target.TargetCallback<String>() {
            @Override
            public void call(final String content) {
                TargetPrefetchActivity.this.runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        lblLoadRequestResponse.setText("Returned content: " + content);
                    }
                });
            }};

        TargetRequestObject secondRequest = Target.createTargetRequestObject("prefetchTest2", "default2", null, callback2);
        locationRequests.add(secondRequest);

        Target.loadRequests(locationRequests, null);
    }
}
