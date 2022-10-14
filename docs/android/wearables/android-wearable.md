# Android Wearables: getting started

Starting in Android SDK version 4.5, a new Android extension was added that allows you to collect data from your Android Wearable app.

## Configuring the SDK for a handheld app (Android Studio)

For more information about importing the SDK into your project, see [Core Implementation and Lifecycle](/docs/android/getting-started/dev-qs.md).

1. Add the `ADBMobileConfig.json` file to the assets folder of your project. 
1. Add the `adobeMobileLibrary-*.jar` file to the libs folder or make sure this file is referenced by the project.

   > **Tip:** You might need to sync the gradle project after adding the `.jar` file.

1. In the `onCreate` method, allow the SDK access to your application context by using `Config.setContext`: 

   ```java
   @Override 
   public void onCreate(Bundle savedInstanceState) { 
       super.onCreate(savedInstanceState); 
       setContentView(R.layout.main); 

       // Allow the SDK access to the application context 
       Config.setContext(this.getApplicationContext()); 
   }
   ```

1. Add the following code to the `AndroidManifest.xml` file: 

   ```java
       <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" /> 
       <uses-permission android:name="android.permission.INTERNET" /> 
       <uses-permission android:name="android.permission.READ_PHONE_STATE" /> 

   <application> 
   ....... 
   <meta-data android:name="com.google.android.gms.version" 
               android:value="@integer/google_play_services_version" /> 
   </application>
   ```

1. Make sure your project includes the Google play-services library. 
1. Implement `WearableListenerService` or add the corresponding code to your `WearableListenerService`: 

   ```java
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
   ```

1. Add `WearListenerService` to the `AndroidManifest.xml` file: 

   ```java
   If you are using Google Play Services  < 8.2 
   <application> 
       ...... 
        <service 
               android:name=".WearListenerService" > 
               <intent-filter> 
                   <action android:name="com.google.android.gms.wearable.BIND_LISTENER" /> 
               </intent-filter> 
       </service> 
   </application> 
   If you are using Google Play Services >= 8.2 
   <application> 
       ...... 
        <service 
               android:name=".WearListenerService" > 
               <intent-filter> 
                     <action android:name="com.google.android.gms.wearable.DATA_CHANGED" /> 
                    <data android:scheme="wear" android:host="*" android:pathPrefix="/abdmobile" /> 
               </intent-filter> 
       </service> 
   </application> 

   Please find more information from google's blog https://android-developers.googleblog.com/2016/04/deprecation-of-bindlistener.html. 
   Permalink Edit
   ```

## Configuring the SDK for a Wearable app (Android Studio)

1. Complete one of the following tasks:

    * Add the same `ADBMobileConfig.json` file to the assets folder of your wearable project. 
    * Change the gradle config to use the  `ADBMobileConfig.json` in the assets folder of the handheld app:

      ```java
      android { 

          sourceSets { 
              main { 
                  assets.srcDirs = ['src/main/assets','../mobile/src/main/assets'] 
              } 
         } 
      }
      ```

1. Add the `adobeMobileLibrary-*.jar` file to the libs folder or make sure it get referenced by the project.

   You might need to sync the gradle project after adding the jar file. 

1. In the `onCreate` method, allow the SDK access to your application context using `Config.setContext`: 

   ```java
   @Override 
   public void onCreate(Bundle savedInstanceState) { 
       super.onCreate(savedInstanceState); 
       setContentView(R.layout.main);      
       // Allow the SDK access to the application context 
       Config.setContext(this.getApplicationContext(), Config.ApplicationType.APPLICATION_TYPE_WEARABLE); 
   }
   ```

1. Add the following code to `AndroidManifest.xml`: 

   ```java
   <application> 
   ....... 
   <meta-data android:name="com.google.android.gms.version" 
               android:value="@integer/google_play_services_version" /> 
   </application>
   ```

1. Ensure that your project includes the Google play-services library. 
1. Implement `WearableListenerService` or add the corresponding code to your `WearableListenerService`: 

   ```java
   public class WearListenerService extends WearableListenerService { 

       @Override 
       public void onDataChanged(com.google.android.gms.wearable.DataEventBuffer dataEvents) { 
           DataListenerWearable.onDataChanged(dataEvents); 
       } 

   }
   ```

1. Add `WearListenerService` to the `AndroidManifest.xml` file: 

   ```java
   If you are using Google Play Services  < 8.2 
   <application> 
       ...... 
        <service 
               android:name=".WearListenerService" > 
               <intent-filter> 
                   <action android:name="com.google.android.gms.wearable.BIND_LISTENER" /> 
               </intent-filter> 
       </service> 
   </application> 
   If you are using Google Play Services >= 8.2 
   <application> 
       ...... 
        <service 
               android:name=".WearListenerService" > 
               <intent-filter> 
                     <action android:name="com.google.android.gms.wearable.DATA_CHANGED" /> 
                    <data android:scheme="wear" android:host="*" android:pathPrefix="/abdmobile" /> 
               </intent-filter> 
       </service> 
   </application> 
   Please find more information from google's blog https://android-developers.googleblog.com/2016/04/deprecation-of-bindlistener.html. 
   Permalink Edit
   ```
