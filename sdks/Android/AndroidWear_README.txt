====================================
Android Wearable Implementation
====================================

Starting in Android SDK version 4.5.0, Android Wearable are supported. This allows you to collect usage data from your Android Wearable Apps.

====================================
Getting Started
====================================
The following steps are to be performed in your Android Studio project.  This guide is written assuming you have a project with at least two (2) modules in it; one for the Handheld app, and one for the Wearable app. For more information on developing for Android Wearable, please go to https://developer.android.com/training/building-wearables.html.


## Configure the SDK for Handheld app (Android Studio) ##

1. Add the ADBMobileConfig.json file to the assets folder of your project.
2. Add the adobeMobileLibrary-*.jar file to the libs folder, or make sure it get referenced by the project. You might need to sync the gradle project after adding the jar file.
3. In the onCreate method of your main activity, allow the SDK access to your application context using Config.setContext:

@Override
public void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.main);
     
    // Allow the SDK access to the application context
    Config.setContext(this.getApplicationContext());
}

4. Add following code to AndroidManifest.xml

    <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
    <uses-permission android:name="android.permission.INTERNET" />
    <uses-permission android:name="android.permission.READ_PHONE_STATE" />

	<application>
		.......
		<meta-data android:name="com.google.android.gms.version" android:value="@integer/google_play_services_version" />
	</application>

5. Make sure your project has included google-play-services.jar
6. Implement WearableListenerService, or add the corresponding code into your own WearableListenerService:

public class WearListenerService extends WearableListenerService {

    @Override
    public void onMessageReceived(MessageEvent messageEvent) {
        super.onMessageReceived(messageEvent);
    }

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

7. Add WearListenerService into AndroidManifest.xml

<application>
	.......
	<service
		android:name=".WearListenerService" >
		<intent-filter>
		 	<action android:name="com.google.android.gms.wearable.BIND_LISTENER" />
		</intent-filter>
	</service>
</application>
 
 
## Configure the SDK for Wear app (Android Studio) ##

1. Add the same ADBMobileConfig.json file to the assets folder of your wearable project.
Or you can change the gradle config to use the ADBMobileConfig.json in the assets folder of the handheld app.
android {
    
    sourceSets {
        main {
            assets.srcDirs = ['src/main/assets','../mobile/src/main/assets']
        }
   }
}
2. Add the adobeMobileLibrary-*.jar file to the libs folder, or make sure it get referenced by the project.  You might need to sync the gradle project after adding the jar file.
3. In the onCreate method of the main activity, allow the SDK access to your application context using Config.setContext:

@Override
public void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.main);     
    // Allow the SDK access to the application context
    Config.setContext(this.getApplicationContext(), Config.ApplicationType.APPLICATION_TYPE_WEARABLE);
}

4. Add following code to AndroidManifest.xml
	<application>
		.......
		<meta-data android:name="com.google.android.gms.version" android:value="@integer/google_play_services_version" />
	</application>

5. Make sure your project has included google-play-services.jar
6. Implement WearableListenerService, or add the corresponding code into your own WearableListenerService:

public class WearListenerService extends WearableListenerService {
    @Override
    public void onDataChanged(com.google.android.gms.wearable.DataEventBuffer dataEvents) {
        DataListenerWearable.onDataChanged(dataEvents);
    }
}

7. Add WearListenerService into AndroidManifest.xml

	<application>
    	......
		<service android:name=".WearListenerService">
            <intent-filter>
                <action android:name="com.google.android.gms.wearable.BIND_LISTENER" />
            </intent-filter>
		</service>
	</application>


For full documentation on how to use the iOS 4.x SDK, please visit https://marketing.adobe.com/resources/help/en_US/mobile/android/dev_qs.html

Notes:
1. There is one additional context(A.RunMode) added to indicate whether the data comes from handheld app or wearable app.
a.RunMode = Application means the hit comes from handheld app
a.RunMode = Extension means the hit comes from wearable app
2. SDK automatically sync aid/vid/visitor service id/privacy status from the handheld app to wearable app, so it's better not calling setPrivacyStatus/setUserIdentifier/idSync from wearable app.
3. In-app messages, target and aam are disabled for wearable app.
