# Video Analytics

Here is some information about measuring video on Android by the video measurement solution.

> **Tip:** During video playback, frequent "heartbeat" calls are sent to this service to measure time played. These heartbeat calls are sent every 10 seconds, which results in granular video engagement metrics and more accurate video fallout reports. For more information about Adobe's video measurement solution, see [Measuring streaming media in Adobe Analytics](https://experienceleague.adobe.com/docs/media-analytics/using/media-overview.html).

The general process to measure video is similar across all platforms. This content provides an overview of the developer tasks with code samples. The following table lists the media data that is sent to Analytics. Processing rules are used to map the context data to an Analytics variable.

## Map player events to Analytics variables

* **a.media.name**
  * Variable type: eVar 
    * Default expiration: Visit 
    * Custom Insight (s.prop, used for video pathing) 
  * (**Required**) When a visitor views the video in some way, this context data variable collects the name of the video, as specified in the implementation. You can add classifications for this variable. 
  * (**Optional**) The Custom Insight variable provides video pathing information. 

* **a.media.name**
  * Variable type: Custom Insight (s.prop)
  * (**Optional**) Provides video pathing information. 
  
    > **Important:** Pathing must be enabled for this variable by ExpCare.
  * Event type: Custom Insight (s.prop)

* **a.media.segment**
  * Variable type: eVar
  * Default expiration: Page view 
  * (**Required**) Collects video segment data, including the segment name and the order in which the segment occurs in the video. 

    This variable is populated by enabling the `segmentByMilestones` variable when automatically tracking player events or by setting a custom segment name when manually tracking player events. For example, when a visitor views the first segment in a video, SiteCatalyst might collect the following in the Segments eVar: `1:M:0-25`.

    The default video data collection method collects data at the following points: 
  
    * video start (play)
    * segment begin
    * video end (stop)

    Analytics counts the first segment view at the start of the segment, when the visitor starts watching. Subsequent segment views as the segment begins. 

* **a.contentType**
  * Variable type: eVar
  * Default expiration: Page view
  * Collects data about the type of content that is viewed by a visitor. 
  
    Hits sent by video measurement are assigned a content type of `video`. From a video measurement perspective, **Content Type** allows you identify video visitors and calculate video conversion rates. 

* **a.media.timePlayed**
  * Variable type: Event
  * Type: Counter
  * Counts the time, in seconds, that is spent watching a video since the last data collection process (image request). 

* **a.media.view**
  * Variable type: Event
  * Type: Counter
  * Indicates that a visitor has viewed some portion of a video. 
  
    However, it does not provide any information about how much, or which part, of a video that the visitor viewed.

* **a.media.segmentView**
  * Variable type: Event
  * Type: Counter
  * Indicates that a visitor has viewed some portion of a video segment. 
  
    However, it does not provide any information about how much, or which part, of a video that the visitor viewed. 

* **a .media.complete**
  * Variable type: Event
  * Type: Counter
  * Indicates that a user has viewed a complete video. 
  
    By default, the complete event is measured 1 second before the end of the video. During implementation, you can specify how many seconds from the end of the video you would like to consider a view as being complete. For live video and other streams that do not have a defined end, you can specify a custom point to measure completes (for example, after a specific time viewed). 


## Configure media settings

Configure a `MediaSettings` object with the settings you want to use to track video:

```java
MediaSettings mySettings = Media.settingsWith("name", 10, "playerName", "playerId");
```

## Track player events

To measure video playback, the `mediaPlay`, `mediaStop`, and `mediaClose` methods need to be called at the appropriate times. For example, when the player is paused, call `mediaStop`. `mediaPlay` is called when playback starts or is resumed.

## Classes

**Class: MediaSettings**

```java
public String name; 
public String playerName; 
public String playerID; 
public double length; 
public String channel; 
public String milestones; 
public String offsetMilestones; 
public boolean segmentByMilestones; 
public boolean segmentByOffsetMilestones; 
public int trackSeconds = 0; 
public int completeCloseOffsetThreshold = 1; 
 
// MediaAnalytics Ad settings 
public String parentName; 
public String parentPod; 
public String CPM; 
public double parentPodPosition; 
public boolean isMediaAd;
```

**Class: MediaState**

```java
public Date openTime = new Date(); 
public String name; 
public String segment; 
public String playerName; 
public String mediaEvent; 
public int offsetMilestone; 
public int segmentNum; 
public int milestone; 
public double length; 
public double offset; 
public double percent; 
public double timePlayed; 
public double segmentLength; 
public boolean complete = false; 
public boolean clicked = false; 
public boolean ad; 
public boolean eventFirstTime;
```

## Media Measurement class and method reference

Here are the methods in the Media Measurement class:

* **settingsWith**
  
  Returns a `MediaSettings` object with specified parameters. 

  * Here is the syntax for this method:
  
    ```java
    public static MediaSettings adSettingsWith(String name, double length, String playerName, String parentName, String parentPod, double parentPodPosition, String CPM);
    ```

  * Here is the code sample for this method:

    ```java
    MediaSettingsmySettings = Media.settingsWith("name", 10, "playerName", "playerId");
    ```

* **adSettingsWith**

  Returns a `MediaSettings` object for use with tracking an ad video.
  * Here is the syntax for this method:
  
    ```java
    public static MediaSettings adSettingsWith(String name, double length, String playerName, String parentName, String parentPod, double parentPodPosition, String CPM);
    ```

* **open**
  
  Opens a `MediaSettings` object for tracking.

  * Here is the syntax for this method:

    ```java
    public static void open(MediaSettings settings, MediaCallback callback); 
    ```

  * Here is the code sample for this method:

    ```java
    Media.open(mySettings, new Media.MediaCallback() { 
      @Override 
      public void call(Object item)
      {//  monitor  callback  if  you  want  to  be  notified  every  second  the  media  is  playing  }
      }); 
    ```

  * **close**

    Closes the media item named *name*.

    * Here is the syntax for this method:
  
    ```java
    public static void close(String name);
    ``` 

  * Here is the code sample for this method:

    ```java
    Media.close("name"); 
    ```

* **play**
  * Plays the media item named *name* at the given *offset* in seconds.
  * Here is the syntax for this method:
  
    ```java
    publicstatic void play(String name, double offset); 
    ```

* **complete**
  
  Manually mark the media item as complete at the *offset* provided in seconds. 

  * Here is the syntax for this method:

    ```java
    public static void complete(String name, double offset); 
    ```

  * Here is the code sample for this method:

    ```java
    Media.complete("name", 0); 
    ```

* **stop**

  Notifies the media module that the video has been stopped or paused at the given *offset*.

  * Here is the syntax for this method:

    ```java
    public static void stop(String name, double offset); 
    ```

  * Here is the code sample or this method:

    ```java
    Media.stop("name", 0);
    ```

* **click**
  
  Notifies the media module that the media item has been clicked. 

  * Here is the syntax for this method:

    ```java
    public static void click(String name double offset); 
    ```

  * Here is the code sample for this method:

    ```java
    Media.click("name", 0);
    ```

* **track**

  Sends a track action call (no page view) for the current media state. 

  * Here is the syntax for this method:

    ```java
    publicstatic void track(String name, Map<String, Object> data); 
    ```

  * Here is the code sample for this method:
  
    ```java
    Media.track("name", null); 
    ```
