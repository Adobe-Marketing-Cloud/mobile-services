# Timed actions

Timed actions allow you to measure the in-app time and total time between the start and the end of an action. The SDK calculates the amount of time in each session and the total time across sessions that it will take for the action to be completed. You can use timed actions to define segments and compare time to purchase, pass level, checkout flow, and so on.

The following metrics are reported for timed actions:

* Total # of seconds in the app between start and end (cross sessions) 
* Total # of seconds between start and end (clock time)

An optional callback allows you to take additional action when the timed action completes:

* Run code and add any logic - optional custom logic based on duration results. 
* Add context data before passing in durations. 
* Cancel hit and durations not yet sent.

## Track timed actions

1. Add the library to your project and implement lifecycle. 

   For more information, see *Add the SDK and Config File to your IntelliJ IDEA or Eclipse Project* in [Core implementation and lifeycle](/docs/android/getting-started/dev-qs.md). 
1. Import the library: 

   ```java
   import com.adobe.mobile.*;
   ```

1. Call `trackTimedActionStart` and provide a timed action name and optional context data. 

   ```java
   HashMap cdata = new HashMap<String, Object>(); 
   cdata.put("ExperienceName", experience); 
   Analytics.trackTimedActionStart("TimeUntilPurchase", cdata);
   ```

1. (Optional) At any point, you can call `trackTimedActionUpdate` with the timed action name to add additional context data. 

   ```java
   HashMap cdata = new HashMap<String, Object>(); 
   cdata.put("myapp.ImageLiked", imageName); 
   Analytics.trackTimed​ActionUpdate("TimeUntilPurchase", cdata);
   ```

1. When the event completes, call `trackTimedActionEnd` and pass the timed action name and `TimedActionBlock` (callback), which will look up all data and calculate durations. 

   ```java
   Analytics.trackTimedActionEnd("TimeUntilPurchase", cdata);
   ```

   Timed event metrics are saved in mobile solution variables for automatic reporting.

## Sending additional data

In addition to the timed action name, you can also send additional context data with the action start and action update calls:

```java
HashMap cdata = new HashMap<String, Object>(); 
cdata.put("myapp.ImageLiked", imageName); 
Analytics.trackTimed​ActionUpdate("TimeUntilPurchase", cdata);
```

Context data values must be mapped to custom variables in Adobe Mobile services:

![](assets/map-variable-context-ltv.png)

## Examples

```java
// Timed Action Start Example 
HashMap cdata = new HashMap<String, Object>(); 
cdata.put("ExperienceName", experience); 
Analytics.trackTimedActionStart("TimeUntilPurchase", cdata); 
 
// Timed Action Update Example 
cdata = new HashMap<String, Object>(); 
cdata.put("ImageLiked", imageName); 
Analytics.trackTimed​ActionUpdate("TimeUntilPurchase", cdata); 
 
// Timed Action End Example 
Analytics.trackTimedActionEnd("TimeUntilPurchase", null); 
 
// Timed Action End Example with Callback 
Analytics.trackTimedActionEnd("TimeUntilPurchase", new Analytics.TimedActionBlock<Boolean>() { 
 @Override 
 public Boolean call(long inAppDuration, long totalDuration, Map<String, Object> contextData) { 
  contextData.put("PurchaseItem", "Item453"); 
  return true; // return true to send the hit, false to cancel 
 } 
});
```
