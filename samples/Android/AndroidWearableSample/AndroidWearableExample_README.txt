===================================
== AndroidWearableExample Application ==
===================================
The AndroidWearableExample application is being provided by Adobe to demonstrate how to track your Android Wearable applications using the Adobe Marketing Cloud SDK.  

## Build Requirements ##
- Android Studio
- Android 4.4W.2 (API 20) or higher 


## Getting Started ##
1. Setup your environment for Wearable following the android docs https://developer.android.com/training/wearables/apps/creating.html	
2. Launch the Android Studio, choose Import project(Eclipse ADT, Gradle, etc.), and select the folder of this sample app.
3. Android Studio should automatically update the Android SDK path for you, but if not then you need to update the sdks.dir in local.properties manually.
4. Open mobile -> assets -> ADBMobileConfig.json , and update the server address pointing to the your Bloodhound server.

## Building the App ##
In order for the ADBMobile SDK to run properly in the wearable app, the handheld app must first be launched.To run the handheld app, select the “mobile” and run the project. To run the wearable app, select the “wear” and run the project.

You need to launch the handheld app before launching the wearable app in order to make the hits from wearable come through.