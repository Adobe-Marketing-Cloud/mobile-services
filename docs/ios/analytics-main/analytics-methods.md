# Analytics methods

Here is a list of Adobe Analytics methods that are provided by the iOS library.

 The SDK currently has support for multiple Adobe Experience Cloud Solutions, including Analytics, Target, Audience Manager, and the Adobe Experience Platform Identity Service. Methods are prefixed according to the solution. Experience Cloud ID methods are prefixed with `track`.

Each of these methods is used to send data into your Adobe Analytics report suite. 

* **trackState:​data:**

  States are the views that are available in your app, such as `home dashboard`, `app settings`, `cart`, and so on. These states are similar to pages on a website, and `trackState` calls increment page views. If `state` is empty, it displays as *app name app version (build)* in reports. If you see this value in reports, ensure you are setting `state` in each `trackState` call. 
  
  > **Tip:** This is the only tracking call that increments page views. 

  * Here is the syntax for this method:

    ```objective-c
    + (void)  trackState:(NSString  *)state
                    data:(NSDictionary  *)data;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile  trackState:@"loginScreen"
                      data:nil]; 
    ```

* **trackAction:​data:**

  Tracks an action in your app. Actions that you want to measure, such as `logons`, `banner taps`, `feed subscriptions`, and other metrics, occur in your app. 
  
  > **Tip:** If you have code that might run while the app is in the background (for example, a background data retrieval), use `trackActionFromBackground` instead. 

  * Here is the syntax for this method:

    ```objective-c
    +  (void)  trackAction:(NSString  *)action
                      data:(NSDictionary  *)data; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile  trackAction:@"heroBannerTouched"
                       data:nil]; 
    ```

* **trackingIdentifier**

  Retrieves the analytics tracking identifier. 

  * Here is the syntax for this method:

    ```objective-c
    + (NSString *) trackingIdentifier; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSString *trackingId = [ADBMobile trackingIdentifier];
    ```

* **trackActionFromBackground:​data:**

  Tracks an action that occurred in the background, which suppresses lifecycle events from firing in certain scenarios. 
  
  > **Tip:** This method should only be called in code that runs while your app is in the background. 

  * Here is the syntax for this method:

    ```objective-c
     +  (void)  trackActionFromBackground:(NSString  *)action
                                     data:(NSDictionary  *)data; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile  trackActionFromBackground:@"downloadedUpdate"
                                     data:nil];
    ```

* **trackLocation:​data:**

  Sends the current x y coordinates. Also uses points of interest that are defined in the `ADBMobileConfig.json` file to determine if the location provided as a parameter is in any of your POIs. If the current coordinates are in a defined POI, a context data variable is populated and sent with the `trackLocation` call.

  * Here is the syntax for this method:

    ```objective-c
    +  (void)  trackLocation:(CLLocation  *)location
                        data:(NSDictionary  *)data; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile  trackLocation:userLocation
                         data:nil]; 
    ```

* **trackBeacon:​data:**

  Tracks when a users enters proximity of a beacon.

  * Here is the syntax for this method:

    ```objective-c
    +  (void)  trackLocation:(CLBeacon  *)beacon
                        data:(NSDictionary  *)data;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile  trackBeacon:beacon
                       data:nil];
    ```

* **trackingClearCurrentBeacon**

  Clears beacons data after a user leaves the proximity of the beacon. 

  * Here is the syntax for this method:

    ```objective-c
    + (void) trackingClearCurrentBeacon;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile trackingClearCurrentBeacon];
    ```

* **trackLifetimeValueIncrease:​data:**

  Adds `amount` to the user's lifetime value.

  * Here is the syntax for this method:

    ```objective-c
     +  (void)  trackLifetimeValueIncrease:(NSDecimalNumber  *)amount
                                     data:(NSDictionary  *)data; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile  trackLifetimeValueIncrease:30
                                       data:nil];
    ```

* **trackTimedActionStart:​data:**

  Start a timed action with name `action`. If you call this method for an action that has already started, the previous timed action is overwritten. 
  
  > **Tip:** This call does not send a hit. 

  * Here is the syntax for this method:

    ```objective-c
    +  (void)  trackTimedActionStart:(NSString  *)action
                                data:(NSDictionary  *)data; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile  trackTimedActionStart:@"cartToCheckout"
                                data:nil]; 
    ```

* **trackTimedActionUpdate:​data:**

  Pass in `data` to update the context data associated with the given `action`. The `data` that is passed in is appended to the existing data for the action, and if the same key is already defined for `action`, overwrites the data. 
  
  > **Tip:** This call does not send a hit.

  * Here is the syntax for this method:

    ```objective-c
     +  (void)  trackTimedActionUpdate:(NSString  *)action
                                  data:(NSDictionary  *)data; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile  trackTimedActionUpdate:@"cartToCheckout"
                                  data:@{@"quantity":@"3"}];
    ```

* **trackTimedActionEnd:​logic:**

  End a timed action. If you provide `block`, you will have access to the final time values and be able to manipulate `data` prior to sending the final hit. 
  
  > **Tip:** If you provide `block`, you must return `YES` to send a hit. Passing in `nil` for `block` sends the final hit. 

  * Here is the syntax for this method:

    ```objective-c
    +  (void)  trackTimedActionEnd:(NSString  *)action
                        logic:(BOOL  (^)  (NSTimeInterval  inAppDuration,
                                                NSTimeInterval totalDuration,
                                                NSMutableDictionary *data))block; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile  trackTimedActionEnd:@"cartToCheckout"
                  logic:^(NSTimeInterval inApp,
                  NSTimeInterval  total,
                  NSMutableDictionary  *data)  {
                      data[@"price"]  =  @"49.95";
                      return  YES;
                  }];
    ```

* **trackingTimedActionExists**

  Returns whether a timed action is in progress.

  * Here is the syntax for this method:

    ```objective-c
    + (BOOL) trackingTimedActionExists:(NSString *)action;
    ```

  * Here is the code sample for this method:

    ```objective-c
    BOOL *actionExists = [ADBMobile trackingTimedActionExists];
    ```

* **trackingSendQueuedHits**

  Requires SDK 4.1. Regardless of how many hits are currently queued, forces the library to send all hits in the offline queue. 

  * Here is the syntax for this method:

    ```objective-c
    + (void) trackingSendQueuedHits;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile trackingSendQueuedHits]; 
    ```

* **trackingGetQueueSize**

  Retrieves the number of hits currently in the offline queue.

  * Here is the syntax for this method:

    ```objective-c
     + (NSUInteger) trackingGetQueueSize;
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSUInteger *queueSize = [ADBMobile trackingGetQueueSize];
    ```

* **trackingClearQueue**

  Clears all hits from the offline queue. 

  > **Caution:** Use caution when clearing the queue manually. This process cannot be reversed. 

  * Here is the syntax for this method:

    ```objective-c
    + (void) trackingClearQueue;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile trackingClearQueue]; 
    ```

 

* **trackPushMessageClickThrough**

  Tracks a push message click-through. 
  
  > **Important:** This method does not increment page views. 

  * Here is the syntax for this method:

    ```objective-c
    + (void) trackPushMessageClickThrough:(NSDictionary *)userInfo;
    ```

  * Here is the code sample for this method:

    ```objective-c
    -  (void)application:(UIApplication  *)application  
    didReceiveRemoteNotification:(NSDictionary  *)userInfo  
    fetchCompletionHandler:(void  (^)
    (UIBackgroundFetchResult))completionHandler  {
        // only send the hit if the app is not active
        if (application.applicationState !=  UIApplicationStateActive)  {
            [ADBMobile  trackPushMessageClickThrough:userInfo];

        }
        completionHandler(UIBackgroundFetchResultNoData);
    }
    ```
