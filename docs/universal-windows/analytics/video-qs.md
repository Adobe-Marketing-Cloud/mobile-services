# Video Analytics

Information to help you with Video Analytics.

Video measurement is described in detail in the [Measuring streaming media in Adobe Analytics](https://experienceleague.adobe.com/docs/media-analytics/using/media-overview.html) guide. The general process to measure video is very similar across all AppMeasurement platforms. This quick start section provides a basic overview of the developer tasks along with code samples.

The following table lists the media data that is sent to Analytics. Use processing rules to map the context data to an Analytics variable.

* **a.media.name**

  (**Required**) Collects the name of the video, as specified in the implementation, when a visitor views the video in some way.You can add classifications for this variable.
  
  (**Optional**) The Custom Insight variable provides video pathing information.

  * Variable type: eVar
  * Default expiration: Visit
  * Custom Insight (s.prop, used for video pathing)

* **a.media.name**

  (**Optional**) Provides video pathing information. Pathing must be enabled for this variable by Customer Care.
  
  * Event type: Custom Insight (s.prop).
  * Variable type: Custom Insight (s.prop)

* **a.media.segment**

  (**Required**) Collects video segment data, including the segment name and the order in which the segment occurs in the video.
  
  This variable is populated by enabling the `segmentByMilestones` variable when tracking player events automatically, or by setting a custom segment name when tracking player events manually. For example, when a visitor views the first segment in a video, SiteCatalyst might collect the following in the `1:M:0-25` segments eVar.
  
  The default video data collection method collects data at the following points: video start (play), segment begin, and video end (stop). Analytics counts the first segment view at the start of the segment, when the visitor starts watching. Subsequent segment views as the segment begins.

  * Variable type: eVar
  * Default expiration: Page view

* **a.contentType**

  Collects data about the type of content viewed by a visitor. Hits sent by video measurement are assigned a content type of "video". This variable does not need to be reserved exclusively for video tracking. Having other content report content type using this same variable lets you analyze the distribution of visitors across the different types of content. For example, you could tag other content types using values such as "article" or "product page" using this variable.
  
  From a video measurement perspective, Content Type lets you identify video visitors and thereby calculate video conversion rates.

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

## Configure media settings

Configure a `MediaSettings` object with the settings you want to use to track video:

```js
var mySettings = ADB.Media.settingsWith("name", 10, "playerName", "playerId");
```

## Track player events

To measure video playback, The `Play`, `Stop`, and `Close` methods need to be called at the appropriate times. For example, when the player is paused, `Stop`. `Play` is called when playback starts or is resumed.

## Classes

### Class: MediaSettings

```
property Platform::String ^name; 
property Platform::String ^playerName; 
property Platform::String ^playerID; 
property double length; 
property Platform::String ^channel; 
property Platform::String ^milestones; 
property Platform::String ^offsetMilestones; 
property bool segmentByMilestones; 
property bool segmentByOffsetMilestones; 
property int trackSeconds; 
property int completeCloseOffsetThreshold; 
 
// MediaAnalytics Ad settings 
property Platform::String ^parentName; 
property Platform::String ^parentPod; 
property Platform::String ^CPM; 
property double parentPodPosition; 
property bool isMediaAd;
```

### Media measurement class and method reference

* **SettingsWith (winJS: settingsWith)**

  Returns a `MediaSettings` object with specified parameters.

  * Here is the syntax for this method:

    ```csharp
    static MediaSettings ^SettingsWith(Platform::String ^name,  double length, Platform::String ^playerName, Platform::String  ^playerID); 
    ```

  * Here is the code sample for this method:

    ```js
    var  mySettings  =  ADB.Media.settingsWith("name", 10,  "playerName", "playerId"); 
    ```

* **AdSettingsWith (winJS: adSettingsWith)**

  Returns a `MediaSettings` object for use with tracking an ad video.

  * Here is the syntax for this method:

    ```csharp
    static MediaSettings ^AdSettingsWith(Platform::String ^name,  double length, Platform::String ^playerName, Platform::String  ^parentName, Platform::String ^parentPod, double parentPosition,  Platform::String ^CPM);
    ```

  * Here is the code sample for this method:

    ```js
    var  myAdSettings = ADB.Media.adSettingsWith("name", 10,  "playerName", "parentName", "parentPod", 5, "myCPM");
    ```

* **Open (winJS: open)**

  Tracks a media open using the settings defined in `settings`.

  * Here is the syntax for this method:

    ```csharp
    static void Open(MediaSettings ^settings);
    ```

  * Here is the code sample for this method:

    ```js
    ADB.Media.open(mySettings);
    ```

* **Close (winJS: close)**

  Tracks a media close for the media item named *`name`*.

  * Here is the syntax for this method:

    ```csharp
    static  void  Close(Platform::String  ^name);
    ```

  * Here is the code sample for this method:

    ```js
    ADB.Media.close("mediaName"); 
    ```

* **Play (winJS: play)**

  Tracks a media play for the media item named *`name`* at the given *offset* (in seconds).

  * Here is the syntax for this method:

    ```csharp
    static  void  Play(Platform::String ^name, double offset);
    ```

  * Here is the code sample for this method:

     ```js
     ADB.Media.play("mediaName",  0);
     ```

* **Complete (winJS: complete)**

  Manually mark the media item as complete at the *offset* provided (in seconds).

  * Here is the syntax for this method:

    ```csharp
    static  void  Complete(Platform::String ^name, double offset);
    ```

  * Here is the code sample for this method:

    ```js
    ADB.Media.complete("mediaName", 8);
    ```

* **Stop (winJS: stop)**

  Notifies the media module that the video has been stopped or paused at the given *offset*.

  * Here is the syntax for this method:

    ```csharp
    static void Stop(Platform::String ^name, double offset);
    ```

  * Here is the code sample for this method:

    ```js
    ADB.Media.stop("mediaName",  4);
    ```

* **Click (winJS: click)**

  Notifies the media module that the media item has been clicked.

  * Here is the syntax for this method:

    ```csharp
    static void Click(Platform::String ^name, double  offset);
    ```

  * Here is the code sample for this method:

    ```js
    ADB.Media.click("mediaName",  3); 
    ```

* **Track (winJS: track)**

  Sends a track action call (no page view) for the current media state.

  * Here is the syntax for this method:

    ```csharp
    static void Track(Platform::String ^name, Windows::Foundation::Collections::IMap<Platform::String^,  Platform::Object> ^contextData); 
    ```

  * Here is the code sample for this method:

    ```js
    ADB.Media.track("mediaName",  null);
    ```
