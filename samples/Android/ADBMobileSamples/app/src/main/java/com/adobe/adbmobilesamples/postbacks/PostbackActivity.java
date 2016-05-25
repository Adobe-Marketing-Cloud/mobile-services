package com.adobe.adbmobilesamples.postbacks;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.EditText;

import com.adobe.adbmobilesamples.R;
import com.adobe.mobile.Analytics;

import java.util.HashMap;

public class PostbackActivity extends Activity {
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        this.requestWindowFeature(Window.FEATURE_NO_TITLE);
        setContentView(R.layout.postback);
    }

    @Override
    protected void onPause() {
        super.onPause();
    }

    @Override
    protected void onResume() {
        super.onResume();
    }

    public void sendPostback(View view) {
        HashMap<String, Object> contextData = new HashMap<String, Object>();

        EditText custVal1 = (EditText)findViewById(R.id.custTextVal1);
        if (custVal1.getText().length() > 0) {
            contextData.put("k1", custVal1.getText());
        }

        EditText custVal2 = (EditText)findViewById(R.id.custTextVal2);
        if (custVal2.getText().length() > 0) {
            contextData.put("k2", custVal2.getText());
        }

        Analytics.trackAction("test-postback", contextData);
    }


}
