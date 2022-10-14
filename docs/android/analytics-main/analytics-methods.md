# Analytics methods

Here is a list of Adobe Analytics methods that are provided by the Android library.

The SDK currently supports multiple Adobe Experience Cloud Solutions, including Analytics, Target, Audience Manager, and the Adobe Experience Platform Identity Service. Methods are prefixed according to the solution, for example, Experience Cloud ID methods are prefixed with `analytics`.

Each of the following methods is used to send data to your Adobe Analytics report suite:

* **trackState**

  Tracks an app state with optional context data. States are the views that are available in your app, such as `home dashboard`, `app settings`, `cart`, and so on. These states are similar to pages on a website, and `trackState` calls increment page views.

  If `state` is empty, `app name app version (build)` is displayed in reports. If you see this value in reports, ensure that you set `state` in each `trackState` call.

  > **Tip:** This is the only tracking call that increments page views.

  * Here is the syntax for this method:

    ```java
    public static void trackState(String state, Map<String, Object> contextData);
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.trackState("loginScreen", null);
    ```

* **trackAction**
  Tracks an action in your app.

  Actions that you want to measure, such as `logons`, `banner taps`, `feed subscriptions`, and other metrics, that occur in your app.

  * Here is the syntax for this method:

    ```java
    public static void trackAction(String state, Map<String, Object> contextData);
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.trackAction("heroBannerTouched", null);
    ```

* **getTrackingIdentifier**
  Returns the automatically generated visitor identifier for Analytics.

  This is an app-specific, unique visitor ID that is generated at the initial launch and is stored and used from that point forward. The ID is preserved between app upgrades and is removed when the app is uninstalled.

  * Here is the syntax for this method:

    ```java
    public static String getTrackingIdentifier();
    ```

  * Here is the code sample for this method:

    ```java
    String trackingId = Analytics.getTrackingIdentifier();
    ```

* **trackLocation**

  Sends the current latitude, longitude, and location in a defined point of interest. For more information, see [Geo-location and points of interest](/docs/android/location/geo-poi.md).

  * Here is the syntax for this method:

    ```java
    public static void trackLocation(Location location, Map<String, Object> contextData);
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.trackLocation(userLocation, null);
    ```

* **trackLifetime​ValueIncrease**

  Adds `amount` to the user's lifetime value.

  * Here is the syntax for this method:

    ```java
    public static void trackLifetimeValueIncrease(BigDecimal amount, Map<String, Object> contextData);
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.trackLifetimeValueIncrease(new BigDecimal(30), null);
    ```

* **trackTimed​ActionStart**

  Start a timed action with name `action`.

  If you call this method for an action that has already started, the previous timed action is overwritten.

  > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

   ```java
   public static void trackTimedActionStart(String action, Map<String, Object> contextData);
   ```

  * Here is the code sample for this method:

    ```java
    Analytics.trackTimedActionStart("cartToCheckout", null)
    ```

* **trackTimed​ActionUpdate**

  Pass in `contextData` to update the context data that is associated with the `action`. The `data` that is passed in is appended to the existing data for the action, and if the same key is already defined for `action`, overwrites the data.

   > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

    ```java
    public static void trackTimedActionUpdate(String action, Map<String, Object> contextData);
    ```

  * Here is a code sample for this method:

    ```java
    HashMap cdata = new HashMap<String Object> ();
    cdata.put("quantity",3);
    Analytics.trackTimedActionUpdate("cartToCheckout", cdata);
    ```

* **trackTimed​ActionEnd**

  End a timed action. If you provide `block`, you can access the final time values and can manipulate `data` before sending the final hit.

   > **Tip:** If you provide `block`, you must return `true` to send a hit. Passing `null` for `block` sends the final hit.

  * Here is the syntax for this method:

    ```java
    public static void trackTimedActionEnd(String action, TimedActionBlock<Boolean> logic);
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.trackTimedActionEnd("cartToCheckout",new
    Analytics.TimedActionBlock<Boolean>(){
        @Override
        public Boolean call(long inAppDuration, long totalDuration, Map<String, Object> contextData) {
            contextData.put("price", 49.95);
            return true;
        }
    });
    ```

* **sendQueuedHits**

  **Requires SDK 4.1.**

  Regardless of how many hits are queued, this method forces the library to send all hits in the offline queue.

  * Here is the syntax for this method:

    ```java
    public static void sendQueuedHits();
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.sendQueuedHits();
    ```

* **getQueueSize**

  Returns the number of stored tracking calls in the offline queue.

  * Here is the syntax for this method:

    ```java
    public static long getQueueSize();
    ```

  * Here is the code sample for this method:

    ```java
    long queueSize = Analytics.getQueueSize();
    ```

* **clearQueue**

  Clears all of the hits from the offline queue.

  * Here is the syntax for this method:

    ```java
    public static void clearQueue();
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.clearQueue();
    ```

    > **Warning:**  Use caution when manually clearing the queue. This process cannot be reversed.

* **processReferrer**

  Processes referrer campaign data from the Google Play Store for later use.

  * Here is the syntax for this method:

    ```java
    public static void processReferrer(final Context context, final Intent intent);
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.processReferrer(getApplicationContext(), intent);
    ```

* **processGooglePlayInstallReferrerUrl**

    > **Important:**  This API is available starting in SDK Version 4.18.0

    Retrieves acquisition data from the provided Google Play Install Referrer URL.

    The data collected from this API will be sent on install hits sent to Analytics, and will be available in the Adobe Data Callback.

    If referrer data has already been collected by the SDK, calling this method will result in a no-op.

    For information on how to retrieve the referrer URL, see the Google documentation: https://developer.android.com/google/play/installreferrer/library.

  * Here is the syntax for this method:

    ```java
    public static void processGooglePlayInstallReferrerUrl(final String referrerUrl);
    ```

  * Here is the code sample for this method:

    ```java
    Analytics.processGooglePlayInstallReferrerUrl(referrerUrl);
    ```
