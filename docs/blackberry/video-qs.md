# Video Analytics

The general process to measure video is very similar across all AppMeasurement platforms. This section provides a basic overview of the developer tasks along with code samples.

For more information about Video measurement, see the [Measuring streaming media in Adobe Analytics](https://experienceleague.adobe.com/docs/media-analytics/using/media-overview.html) guide.  The following table lists the media data that is sent to Analytics. Use processing rules to map the context data in the Context Data Variable column to an Analytics variable as described in the Variable Type column.

## Map player events to Analytics variables

* **a.media.name**

  (Required) Collects the name of the video, as specified in the implementation, when a visitor views the video in some way.You can add classifications for this variable.

  **(Optional)** The Custom Insight variable provides video pathing information.

  * Variable name: eVar
    * Default expiration: Visit
    * Custom Insight (s.prop, used for video pathing)

* **a.media.name**

  (**Optional**) Provides video pathing information. Pathing must be enabled for this variable by Customer Care.
  
  * Event type: Custom Insight (s.prop)
  * Custom Insight (s.prop)

* **a.media.segment**

  (**Required**) Collects video segment data, including the segment name and the order in which the segment occurs in the video. This variable is populated by enabling the `segmentByMilestones` variable when tracking player events automatically, or by setting a custom segment name when tracking player events manually.
  
  For example, when a visitor views the first segment in a video, SiteCatalyst might collect `1:M:0-25` in the Segments eVar. The default video data collection method collects data at the video start (play), segment begin, and video end (stop) points.
  
  Analytics counts the first segment view at the start of the segment, when the visitor starts watching. Subsequent segment views as the segment begins.

  * Variable type: eVar
  * Default expiration: Page view

* **a.contentType**

  Collects data about the type of content viewed by a visitor. Hits sent by video measurement are assigned a content type of "video". This variable does not need to be reserved exclusively for video tracking. Having other content report content type using this same variable lets you analyze the distribution of visitors across the different types of content. For example, you could tag other content types using values such as "article" or "product page" using this variable. From a video measurement perspective, Content Type lets you identify video visitors and thereby calculate video conversion rates.

  * Variable type: eVar
  * Default expiration: Page view

* **a.media.timePlayed**

  Counts the time, in seconds, spent watching a video since the last data collection process (image request).

  * Variable type: Event
  * Type: Counter

* **a.media.view**

  Indicates that a visitor has viewed some portion of a video. However, it does not provide any information about how much, or what part, of a video the visitor viewed.

  * Variable type: Event
  * Type: Counter

* **a.media.segmentView**

  Indicates that a visitor has viewed some portion of a video segment. However, it does not provide any information about how much, or what part, of a video the visitor viewed.

  * Variable type: Event
  * Type: Counter

* **a .media.complete**

  Indicates that a user has viewed a complete video. By default, the complete event is measured 1 second before the end of the video. During implementation, you can specify how many seconds from the end of the video you would like to consider a view complete. For live video and other streams that don't have a defined end, you can specify a custom point to measure completes. For example, after a specific time viewed.

  * Variable type: Event
  * Type: Counter

## Track player events

To measure video playback, The `mediaPlay`, `mediaStop`, and `mediaClose` methods need to be called at the appropriate times. For example, when the player is paused, `mediaStop`. `mediaPlay` is called when playback starts or is resumed.

## Media measurement class and method reference

* **open**

  Opens a video for tracking.

  * Here is the syntax for this method:

    ```cpp
    void open(QString name, double length, QString playerName, QString playerID = QString()); 
    ```

  * Here is the code sample for this method:

    ```cpp
      ADBMediaAnalytics::sharedInstance()->open("name", 10.0, "playerName", "playerID"); 
    ```

* **openAd**

  Opens a `MediaSettings` object for tracking. 

  * Here is the syntax for this method:

    ```cpp
    void openAd(QString name, double length, QString playerName, QString parentName, QString parentPod, double parentPodPosition, QString CPM); 
    ```

  * Here is the code sample for this method:

    ```cpp
    ADBMediaAnalytics::sharedInstance()->openAd("name", 10, "playerName", "parentName", "podName", 0, "CPM"); 
    ```

* **close**

  Closes the media item named *`name`*.

  * Here is the syntax for this method:

    ```cpp
    void close(QString name);
    ```

  * Here is the code sample for this method:

    ```cpp
    ADBMediaAnalytics::sharedInstance()->close("name");
    ```

* **play**

  Plays the media item named *`name`* at the given *`offset`* (in seconds).

  * Here is the syntax for this method:

    ```cpp
    void play(QString name, double offset);
    ```

  * Here is the code sample for this method:

    ```cpp
    ADBMediaAnalytics::sharedInstance()->play("name", 0); 
    ```

* **complete**

  Manually mark the media item as complete at the *`offset`* provided (in seconds).

  * Here is the syntax for this method:

    ```cpp
    void complete(QString name, double offset);
    ```

  * Here is the code sample for this method:

    ```cpp
    ADBMediaAnalytics::sharedInstance()->complete("name", 0);
    ```

* **stop**

  Notifies the media module that the video has been stopped or paused at the given *offset*.

  * Here is the syntax for this method:

    ```cpp
    stop(QString name, double offset);
    ```

  * Here is the code sample for this method:

    ```cpp
    ADBMediaAnalytics::sharedInstance()->stop("name", 0);
    ```

* **click**

  Notifies the media module that the media item has been clicked.

  * Here is the syntax for this method:

    ```cpp
    void click(QString name, double offset);
    ```

  * Here is the code sample for this method:

    ```cpp
    ADBMediaAnalytics::sharedInstance()->close("name", 0);
    ```

* **track**

  Sends a track action call (no page view) for the current media state. 

  * Here is the syntax for this method:

    ```cpp
    track(QString name, QHash<QString, QString> additionalData = QHash<QString, QString>()); 
    ```

  * Here is the code sample for this method:

    ```cpp
    ADBMediaAnalytics::sharedInstance()->track("name", null);
    ```
