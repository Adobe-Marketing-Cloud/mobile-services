# Video Analytics

Here is some information about measuring video on iOS by using milestone video measurement.

> **Tip:** During video playback, frequent "heartbeat" calls are sent to this service to measure time played. These heartbeat calls are sent every 10 seconds, which results in granular video engagement metrics and more accurate video fallout reports. For more information, see [Measuring streaming media in Adobe Analytics](https://experienceleague.adobe.com/docs/media-analytics/using/media-overview.html).

The general process to measure video is very similar across all platforms. This content provides a basic overview of the developer tasks with code samples.

## Map player events to Analytics variables

The following table lists the media data that is sent to Analytics. Use processing rules to map the context data to an Analytics variable.

* **a.media.name**

  (Required) Collects the name of the video, as specified in the implementation, when a visitor views the video in some way. You can add classifications for this variable.
  
  (Optional) The Custom Insight variable provides video pathing information.

  * Variable type: eVar
  * Default expiration: Visit
  * Custom Insight (s.prop, used for video pathing)

* **a.media.name**

  (Optional) Provides video pathing information. Pathing must be enabled for this variable by Customer Care.

  * Variable type: Custom Insight (s.prop)
  * Event type: Custom Insight (s.prop)

* **a.media.segment**

  (Required) Collects video segment data, including the segment name and the order in which the segment occurs in the video. This variable is populated by enabling the `segmentByMilestones` variable when tracking player events automatically, or by setting a custom segment name when tracking player events manually. For example, when a visitor views the first segment in a video, SiteCatalyst might collect the following in the `1:M:0-25` Segments eVar.
  
  The default video data collection method collects data at the following points:  

  * video start (play)  
  * segment begin  
  * video end (stop)
  
  Analytics counts the first segment view at the start of the segment, when the visitor starts watching. Subsequent segment views as the segment begins.

  * Variable type: eVar
  * Default expiration: Page view

* **a.contentType**

  Collects data about the type of content that is viewed by a visitor. Hits sent by video measurement are assigned a content type of `video`. This variable does not need to be reserved exclusively for video tracking. Having other content report content type by using this same variable lets you analyze the distribution of visitors across the different types of content. For example, you could tag other content types using values such as "article" or "product page" using this variable. From a video measurement perspective, Content Type allows you to identify video visitors and calculate video conversion rates.

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

* **a.media.complete**

  Indicates that a user has viewed a complete video. By default, the complete event is measured 1 second before the end of the video. During implementation, you can specify how many seconds from the end of the video you would like to consider a view complete. For live video and other streams that do not have a defined end, you can specify a custom point to measure completes, for example, after a specific time viewed.

  * Variable type: Event
  * Type: Counter

## Configure media settings

Configure an `ADBMediaSettings` object with the settings you want to use to track video:

```objective-c
ADBMediaSettings *mediaSettings = [ADBMobile mediaCreateSettingsWithName:MEDIA_NAME  
length:MEDIA_LENGTH playerName:PLAYER_NAME playerID:PLAYER_ID]; 
 
// milestone tracking. Use either standard milestones (percentage of total length) 
// or offset milestones (seconds elapsed from the beginning of the video) 
mediaSettings.milestones = @"25,50,75"; 
mediaSettings.segmentByMilestones = YES; 
 
mediaSettings.offsetMilestones = @"60,120"; 
mediaSettings.segmentByOffsetMilestones = YES; 
 
// seconds tracking - sends a hit every x seconds 
mediaSettings.trackSeconds = 30; // sends a hit every 30 seconds 
 
// open the video 
[ADBMobile mediaOpenWithSettings:mediaSettings callback:nil]; 
 
// You are now ready to play the video, for example, [movieViewController.moviePlayer play]; 
// Note the mediaPlay, mediaStop and mediaClose methods are called in the 
// event handlers described in the next section
```

## Track player events

To measure video playback, The `mediaPlay`, `mediaStop`, and `mediaClose` methods need to be called at the appropriate times. For example, when the player is paused, `mediaStop`. `mediaPlay` is called when playback starts or is resumed.

The following example demonstrates configuring notifications and calling the media methods to measure video:

```objective-c
// configure notifications for when the video is finished, and when the 
media playback state changes 
 
- (void) configureNotifications:(MPMoviePlayerController *) movieController { 
 [[NSNotificationCenter defaultCenter] 
  addObserver: self 
  selector: @selector(mediaFinishedCallback:) 
  name: MPMoviePlayerPlaybackDidFinishNotification 
  object: movieController]; 
  
 [[NSNotificationCenter defaultCenter] 
  addObserver: self 
  selector: @selector(mediaPlaybackChangedCallback:) 
  name: MPMoviePlayerPlaybackStateDidChangeNotification 
  object: movieController]; 
} 
 
// define your notification callbacks. 
 
- (void) mediaFinishedCallback: (NSNotification*) notification { [ADBMobile mediaClose:MEDIA_NAME];} 
 
- (void) mediaPlaybackChangedCallback: (NSNotification*) notification { 
 MPMoviePlayerController *mediaController = notification.object; 
 if (mediaController.playbackState == MPMoviePlaybackStatePlaying) { 
  [ADBMobile mediaPlay:MEDIA_NAME offset: isnan(mediaController.currentPlaybackTime) ? 0.0 : mediaController.currentPlaybackTime]; 
 } 
 else if (mediaController.playbackState == MPMoviePlaybackStateSeekingBackward) { 
  [ADBMobile mediaStop:MEDIA_NAME offset:mediaController.currentPlaybackTime]; 
 } 
 else if (mediaController.playbackState == MPMoviePlaybackStateSeekingForward) { 
  [ADBMobile mediaStop:MEDIA_NAME offset:mediaController.currentPlaybackTime]; 
 } 
 else if (mediaController.playbackState == MPMoviePlaybackStatePaused) { 
  [ADBMobile mediaStop:MEDIA_NAME offset:mediaController.currentPlaybackTime]; 
 } 
 else if (mediaController.playbackState == MPMoviePlaybackStateInterrupted) { 
  [ADBMobile mediaStop:MEDIA_NAME offset:mediaController.currentPlaybackTime]; 
 } 
 else if (mediaController.playbackState == MPMoviePlaybackStateStopped) { 
  [ADBMobile mediaStop:MEDIA_NAME offset:mediaController.currentPlaybackTime]; 
 } 
}
```

## Classes

### Class: ADBMediaSettings

```objective-c
bool segmentByMilestones; 
bool segmentByOffsetMilestones; 
double length; 
NSString *channel; 
NSString *name; 
NSString *playerName; 
NSString *playerID; 
NSString *milestones; 
NSString *offsetMilestones; 
NSUInteger trackSeconds; 
NSUInteger completeCloseOffsetThreshold; 
// settings used for ad tracking. For  
bool isMediaAd; 
double parentPodPosition; 
NSString *CPM; 
NSString *parentName; 
NSString *parentPod; 
```

### Class: ADBMediaState

```objective-c
bool ad; 
bool clicked; 
bool complete; 
bool eventFirstTime; 
double length; 
double offset; 
double percent; 
double segmentLength; 
double timePlayed; 
double timePlayedSinceTrack; 
double timestamp; 
NSDate *openTime  
NSString *name 
NSString *playerName 
NSString *mediaEvent 
NSString *segment 
NSUInteger milestone 
NSUInteger offsetMilestone 
NSUInteger segmentNum 
NSUInteger eventType
```

## Media measurement class and method reference

* **mediaCreateSettings​WithName:​length:​playerName:​playerID:**

  Returns an `ADBMediaSettings` object with specified parameters.

  * Here is the syntax for this method:

    ```objective-c
    +(ADBMediaSettings *) mediaCreateSettingsWithName:(NSString *)name
                                               length:(double)length
                                            playerName:(NSString *)playerName
                                             playerID:(NSString *)playerID;
    ```

  * Here is the code sample for this method:

    ```objective-c
    ADBMediaSettings *myCatSettings =
          [ADBMobile mediaCreateSettingsWithName:@"catVideo"                                               length:85
                                      playerName:@"catVideoPlayer"
                                        playerID:@"catPlayerId"]; 
    ```

* **mediaAdCreateSettings​WithName:​length:​playerName:​parentName:​parentPod:​parentPodPosition:​CPM:**

  Returns an `ADBMediaSettings` object for use with tracking an ad video.

  * Here is the syntax for this method:

    ```objective-c
    + (ADBMediaSettings *) mediaAdCreateSettingsWithName:(NSString *)name
                                                  length:(double)length   
                                              playerName:(NSString *)playerName
                                              parentName:(NSString *)parentName
                                               parentPod:(NSString *)parentPod
                                      parentPodPosition:(double)parentPodPosition
                                                    CPM:(NSString *)CPM; 
    ```

  * Here is the code sample for this method:

    ```objective-c
      ADBMediaSettings *mySettings = 
           [ADBMobile mediaAdCreateSettingsWithName:@"ad"                                       length:30
                                         playerName:@"adPlayer"
                                         parentName:@"catVideo"
                                         parentPod:@"catCollection"
                                         parentPodPosition:2
                                                      CPM:nil];
    ```

* **mediaOpenWithSettings:​callback:**

  Opens an `ADBMediaSettings` object for tracking.

  * Here is the syntax for this method:

    ```objective-c
    + (void) mediaOpenWithSettings:(ADBMediaSettings *)settings
                          callback:(void (^)(ADBMediaState *mediaState))callback; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile mediaOpenWithSettings:mySettings callback:^(ADBMediaState *mediaState) {
         // do something with media state if you want}];
    ```

* **mediaClose:**

  Closes the media item named *name*.

  * Here is the syntax for this method:

    ```objective-c
     + (void) mediaClose:(NSString *)name; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile mediaClose:@"kittiesPlaying"];
    ```

* **mediaPlay:​offset:**

  Plays the media item named *name* at the given *offset* (in seconds).

  * Here is the syntax for this method:

    ```objective-c
     + (void) mediaPlay:(NSString *)name offset:(double)offset;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile mediaPlay:@"cats" offset:25];
    ```

* **mediaComplete:​offset:**

  Manually mark the media item as complete at the *offset* provided (in seconds).

  * Here is the syntax for this method:

    ```objective-c
     + (void) mediaComplete:(NSString *)name offset:(double)offset;
    ```

  * Here is the code sample for this method:

    ```objective-c
     [ADBMobile mediaComplete:@"meowzah" offset:90]; 
    ```

* **mediaStop:​offset:**

  Notifies the media module that the video has been stopped or paused at the given *offset*.

  * Here is the syntax for this method:

    ```objective-c
    + (void) mediaStop:(NSString *)name offset:(double)offset; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile mediaStop:@"toonses" offset:30]; 
    ```

* **mediaClick:​offset:**

  Notifies the media module that the media item has been clicked.

  * Here is the syntax for this method:

    ```objective-c
    + (void) mediaClick:(NSString *)name offset:(double)offset;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile mediaClick:@"soManyCats" offset:47];
    ```

* **mediaTrack:​withData:**

  Sends a track action call (no page view) for the current media state.

  * Here is the syntax for this method:

    ```objective-c
    + (void) mediaTrack:(NSString *)name withData:(NSDictionary *)data;
    ```
