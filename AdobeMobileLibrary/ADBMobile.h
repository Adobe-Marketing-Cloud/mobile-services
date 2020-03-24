//
//  ADBMobile.h
//  Adobe Experience Cloud -- iOS Library
//
//  Copyright 1996-2020. Adobe, Inc. All Rights Reserved
//
//  SDK Version: 4.19.2

#import <Foundation/Foundation.h>
@class CLLocation, CLBeacon, TVApplicationController,
ADBTargetLocationRequest, ADBMediaSettings, ADBMediaState, ADBTargetPrefetchObject, ADBTargetRequestObject;

#pragma mark - ADBMobile

/**
 * 	@brief An enum type.
 *  The possible privacy statuses.
 *  @see privacyStatus
 *  @see setPrivacyStatus
 */
typedef NS_ENUM(NSUInteger, ADBMobilePrivacyStatus) {
    ADBMobilePrivacyStatusOptIn   = 1, /*!< Enum value ADBMobilePrivacyStatusOptIn. */
    ADBMobilePrivacyStatusOptOut  = 2, /*!< Enum value ADBMobilePrivacyStatusOptOut. */
    ADBMobilePrivacyStatusUnknown = 3  /*!< Enum value ADBMobilePrivacyStatusUnknown. @note only available in conjunction with offline tracking */
};

/**
 * 	@brief An enum type.
 *  The possible authentication state.
 *  @see visitorSyncIdentifiers
 */
typedef NS_ENUM(NSUInteger, ADBMobileVisitorAuthenticationState) {
    ADBMobileVisitorAuthenticationStateUnknown			= 0, /*!< Enum value ADBMobileVisitorAuthenticationStateUnknown. */
    ADBMobileVisitorAuthenticationStateAuthenticated	= 1, /*!< Enum value ADBMobileVisitorAuthenticationStateAuthenticated. */
    ADBMobileVisitorAuthenticationStateLoggedOut		= 2  /*!< Enum value ADBMobileVisitorAuthenticationStateLoggedOut. */
};

/**
 * 	@brief An enum type.
 *  The possible types of app extension you might use
 *  @see setAppExtensionType
 */
typedef NS_ENUM(NSUInteger, ADBMobileAppExtensionType) {
    ADBMobileAppExtensionTypeRegular	= 0, /*!< Enum value ADBMobileAppExtensionTypeRegular. */
    ADBMobileAppExtensionTypeStandAlone	= 1 /*!< Enum value ADBMobileAppExtensionTypeStandAlone. */
};

/**
 * 	@brief An enum type.
 *  The possible callback events with registerAdobeDataCallback
 *  @see registerAdobeDataCallback
 */
typedef NS_ENUM(NSUInteger, ADBMobileDataEvent) {
    ADBMobileDataEventLifecycle,
    ADBMobileDataEventAcquisitionInstall,
    ADBMobileDataEventAcquisitionLaunch,
    ADBMobileDataEventDeepLink
};

/** @defgroup ADBConfigParameters
 *  These constant strings can be used as the keys for common parameters within Configuration
 *  Example: NSURL *url = callbackData[ADBConfigKeyCallbackDeepLink];
 */

/*
 * Used within ADBMobileDataCallback
 * Key for deep link URL.
 */
FOUNDATION_EXPORT NSString *const __nonnull ADBConfigKeyCallbackDeepLink;


/**
 * 	@class ADBMobile
 *  This class is used for all interaction with the Adobe Mobile Services.
 */
@interface ADBMobile : NSObject {}

#pragma mark - Configuration

/**
 * 	@brief Gets the version.
 *  @return a string pointer containing the version value.
 */
#pragma GCC diagnostic push
#pragma GCC diagnostic ignored "-Woverriding-method-mismatch"
+ (nonnull NSString *) version;
#pragma GCC diagnostic pop

/**
 * 	@brief Gets the privacy status.
 *  @return an ADBMobilePrivacyStatus enum value of the privacy status.
 *  @see ADBMobilePrivacyStatus
 */
+ (ADBMobilePrivacyStatus) privacyStatus;

/**
 * 	@brief Sets the privacy status.
 *  @param status an ADBMobilePrivacyStatus enum value of the privacy status.
 *  @see ADBMobilePrivacyStatus
 */
+ (void) setPrivacyStatus:(ADBMobilePrivacyStatus)status;

/**
 * 	@brief Gets user's current lifetime value
 *  @return a NSDecimalNumber pointer to the current user's value.
 */
+ (nullable NSDecimalNumber *) lifetimeValue;

/**
 * 	@brief Gets the user identifier.
 *  @return a string pointer containing the user identifier value.
 */
+ (nullable NSString *) userIdentifier;

/**
 * 	@brief Sets the user identifier.
 *  @param identifier a string pointer containing the user identifier value.
 */
+ (void) setUserIdentifier:(nullable NSString *)identifier;

/**
 * 	@brief Sets the IDFA.
 *  @param identifier a string pointer containing the IDFA value.
 */
+ (void) setAdvertisingIdentifier:(nullable NSString *)identifier;

/**
 * 	@brief Sets the device token for push notifications
 *  @param deviceToken an NSData pointer containing the deviceToken value.
 *	@note This method should only be used within the application:didRegisterForRemoteNotificationsWithDeviceToken: method
 */
+ (void) setPushIdentifier:(nullable NSData *)deviceToken;

/**
 * 	@brief Gets the preference for debug log output.
 *  @return a bool value indicating the preference for debug log output.
 */
+ (BOOL) debugLogging;

/**
 * 	@brief Sets the preference of debug log output.
 *  @param debug a bool value indicating the preference for debug log output.
 */
+ (void) setDebugLogging:(BOOL)debug;

/**
 * 	@brief Sets the preference of lifecycle session keep alive.
 *  @note Calling keepLifecycleSessionAlive will prevent your app from launching a new session the next time it is resumed from background
 *  @note Only use this if your app registers for notifications in the background
 */
+ (void) keepLifecycleSessionAlive;

/**
 * 	@brief Begins the collection of lifecycle data.
 *  @note This should be the first method called upon app launch.
 */
+ (void) collectLifecycleData;
/**
 * 	@brief Begins the collection of lifecycle data.
 *  @note This should be the first method called upon app launch.
 *  @param data a dictionary pointer containing the context data to be added to the lifecycle hit.
 */
+ (void) collectLifecycleDataWithAdditionalData:(nullable NSDictionary *)data;

/**
 *  @brief Pauses the collection of lifecycle data.
 *  @note Should only use this method in the applicationDidEnterBackground delegate method, and it is best to make this call first in the applicationDidEnterBackground method.
 */
+ (void) pauseCollectingLifecycleData;

/**
 *	@brief allows one-time override of the path for the json config file
 *	@note This *must* be called prior to AppDidFinishLaunching has completed and before any other interactions with the Adobe Mobile library have happened.
 *		Only the first call to this function will have any effect.
 */
+ (void) overrideConfigPath: (nullable NSString *) path;

/**
 *	@brief set the app group used to sharing user defaults and files among containing app and extension apps
 *	@note This *must* be called in AppDidFinishLaunching and before any other interactions with the Adobe Mobile library have happened.
 *		Only the first call to this function will have any effect.
 */
+ (void) setAppGroup: (nullable NSString *) appGroup;

/**
 *	@brief Configures the Adobe Mobile SDK setting to determines what kind of extension is currently being executed.
 *	@note When using the extension library, please refer to the online documentation to help you decide which setting you need
 *	@param type an ADBMobileAppExtensionType value indicating the type of extension for your currently running executable
 *  @see ADBMobileAppExtensionType
 */
+ (void) setAppExtensionType:(ADBMobileAppExtensionType)type;

/**
 *	@brief Synchronize certain defaults between a Watch app and the iOS app in the SDK via Watch Connectivity
 *	@note This method should only be used in WCSessionDelegate methods.
 *  @return a bool value indicating if the settings dictionary was meant for consumption by ADBMobile
 */
+ (BOOL) syncSettings:(nullable NSDictionary *) settings;

/**
 *	@brief Initialize the SDK for WatchKit apps
 *	@note This method should only be called from applicationDidFinishLaunching in your WKExtensionDelegate class
 */
+ (void) initializeWatch;

/**
 *	@brief Registers the ADBMobile class in the JSContext object of the tv application controller
 *	@note This method should only be called from AppleTV apps written using TVML/TVJS
 *  @param tvController is the TVApplicationController initialized to bridge the native and JS environments for the app
 */
+ (void) installTVMLHooks:(nullable TVApplicationController *)tvController;

/**
 * 	@brief Register the callback for Adobe data. The callback block will get called when SDK receive any form of data that is populated by the sdk automatically (eg. lifecycle, acquisition).
 * 	@param callback a block pointer to call any time adobe creates a piece of data. event(String) is the name of the event that caused the callback. adobeData is a dictionary with all the context data created during that session.
 */
+ (void) registerAdobeDataCallback:(nullable void (^)(ADBMobileDataEvent event, NSDictionary* __nullable adobeData))callback;

/**
 * @brief Registers a callback to allow for the modification of NSURLSessionConfiguration used by all SDK network methods.
 * @note Warning: incorrect usage of this method may interrupt the SDK's ability to transmit data.
 * @param callback a block pointer to call any time a new NSURLSession is being created for internal usage.  configuration(NSURLSessionConfiguration) is a pointer to the configuration that will be used.
 */
+ (void) registerURLSessionConfigurationCallback: (nullable void (^)(NSURLSessionConfiguration* __nonnull configuration))callback;

#pragma mark - Analytics

/**
 * 	@brief Tracks a state with context data.
 * 	@param state a string pointer containing the state value to be tracked.
 * 	@param data a dictionary pointer containing the context data to be tracked.
 *  @note This method increments page views.
 */
+ (void) trackState:(nullable NSString *)state data:(nullable NSDictionary *)data;

/**
 * 	@brief Tracks an action with context data.
 * 	@param action a string pointer containing the action value to be tracked.
 * 	@param data a dictionary pointer containing the context data to be tracked.
 *  @note This method does not increment page views.
 */
+ (void) trackAction:(nullable NSString *)action data:(nullable NSDictionary *)data;

/**
 * 	@brief Tracks an action with context data.
 * 	@param action a string pointer containing the action value to be tracked.
 * 	@param data a dictionary pointer containing the context data to be tracked.
 *  @note This method does not increment page views.
 *  @note This method is intended to be called while your app is in the background(it will not cause lifecycle data to send if the session timeout has been exceeded)
 */
+ (void) trackActionFromBackground:(nullable NSString *)action data:(nullable NSDictionary *)data;

/**
 * 	@brief Tracks a location with context data.
 * 	@param location a CLLocation pointer containing the location information to be tracked.
 * 	@param data a dictionary pointer containing the context data to be tracked.
 *  @note This method does not increment page views.
 */
+ (void) trackLocation:(nullable CLLocation *)location data:(nullable NSDictionary *)data;

#if !TARGET_OS_WATCH && !TARGET_OS_TV
/**
 * 	@brief Tracks a beacon with context data.
 * 	@param beacon a CLBeacon pointer containing the beacon information to be tracked.
 * 	@param data a dictionary pointer containing the context data to be tracked.
 *  @note This method does not increment page views.
 */
+ (void) trackBeacon:(nullable CLBeacon *)beacon data:(nullable NSDictionary *)data;

/**
 * 	@brief Clears beacon data persisted for Target
 */
+ (void) trackingClearCurrentBeacon;
#endif

/**
 * 	@brief Tracks a push message click-through
 * 	@param userInfo an NSDictionary pointer containing the push message payload to be tracked.
 *  @note This method does not increment page views.
 */
+ (void) trackPushMessageClickThrough:(nullable NSDictionary *)userInfo;


/**
 * 	@brief Tracks a local notification message click-through
 * 	@param userInfo an NSDictionary pointer containing the message payload to be tracked.
 *  @note This method does not increment page views.
 */
+ (void) trackLocalNotificationClickThrough:(nullable NSDictionary *)userInfo;

/**
 * 	@brief Tracks a Adobe Deep Link click-through
 * 	@param url The URL resource received from UIApplication delegate method.
 *  @note Adobe Link data will be appended to the lifecycle call if it is a launch event, otherwise an extra call will be sent.
 */
+ (void) trackAdobeDeepLink:(nullable NSURL *)url;

/**
 * 	@brief Tracks an increase in a user's lifetime value.
 * 	@param amount a positive NSDecimalNumber detailing the amount to increase lifetime value by.
 * 	@param data a dictionary pointer containing the context data to be tracked.
 *  @note This method does not increment page views.
 */
+ (void) trackLifetimeValueIncrease:(nullable NSDecimalNumber *)amount data:(nullable NSDictionary *)data;

/**
 * 	@brief Tracks the start of a timed event
 *  @param action a required NSString value that denotes the action name to track.
 *  @param data optional dictionary pointer containing context data to track with this timed action.
 *  @note This method does not send a tracking hit
 *  @attention If an action with the same name already exists it will be deleted and a new one will replace it.
 */
+ (void) trackTimedActionStart:(nullable NSString *)action data:(nullable NSDictionary *)data;

/**
 * 	@brief Tracks the start of a timed event
 *  @param action a required NSString value that denotes the action name to track.
 *  @param data optional dictionary pointer containing context data to track with this timed action.
 *  @note This method does not send a tracking hit
 *  @attention When the timed event is updated the contents of the parameter data will overwrite existing context data keys and append new ones.
 */
+ (void) trackTimedActionUpdate:(nullable NSString *)action data:(nullable NSDictionary *)data;

/**
 * 	@brief Tracks the end of a timed event
 *
 *  Valid values for inAppDuration and totalDuration are non-negative and fewer than the number of seconds in a year.
 *  If the value returned is negative, it is considered corrupt and will be ignored.
 *
 *  @param action a required NSString pointer that denotes the action name to finish tracking.
 * 	@param block optional block to perform logic and update parameters when this timed event ends, this block can cancel the sending of the hit by returning NO.
 *  @note This method will send a tracking hit if the parameter logic is nil or returns YES.
 */
+ (void) trackTimedActionEnd:(nullable NSString *)action
                       logic:(nullable BOOL (^)(NSTimeInterval inAppDuration, NSTimeInterval totalDuration, NSMutableDictionary* __nullable data))block;

/**
 * 	@brief Returns whether or not a timed action is in progress
 *  @return a bool value indicating the existence of the given timed action
 */
+ (BOOL) trackingTimedActionExists:(nullable NSString *)action;

/**
 *	@brief Retrieves the analytics tracking identifier
 *	@return an NSString value containing the tracking identifier
 *	@note This method can cause a blocking network call and should not be used from a UI thread.
 */
+ (nullable NSString *) trackingIdentifier;

/**
 *	@brief Force library to send all queued hits regardless of current batch options
 */
+ (void) trackingSendQueuedHits;

/**
 *	@brief Clears any hits out of the tracking queue and removes them from the database
 */
+ (void) trackingClearQueue;

/**
 *	@brief Retrieves the number of hits currently in the tracking queue
 *	@return an NSUInteger indicating the size of the queue
 */
+ (NSUInteger) trackingGetQueueSize;

#pragma mark - Acquisition
/**
 *	@brief Allows developer to start an app acquisition campaign as if the user had clicked on a link. This his helpful for creating manual acquisition links and handling the app store redirect yourself (such as with an SKStoreView)
 *  @param appId ID of the app in Adobe Mobile Services
 *  @param data optional dictionary pointer containing context data, should at least contain keys a.referrer.campaign.name and a.referrer.campaign.source
 */
+ (void) acquisitionCampaignStartForApp:(nullable NSString *)appId data:(nullable NSDictionary *)data;

#pragma mark - Media Analytics

/**
 * 	@brief Creates an ADBMediaSettings populated with the parameters.
 *  @param name name of media item.
 *  @param length length of media (in seconds).
 * 	@param playerName name of media player.
 * 	@param playerID ID of media player.
 *  @return An ADBMediaSettings pointer.
 */
+ (nonnull ADBMediaSettings *) mediaCreateSettingsWithName:(nullable NSString *)name
                                                    length:(double)length
                                                playerName:(nullable NSString *)playerName
                                                  playerID:(nullable NSString *)playerID;

/**
 * 	@brief Creates an ADBMediaSettings populated with the parameters.
 *  @param name name of media item.
 *  @param length length of media (in seconds).
 * 	@param parentName name of the ads parent video.
 * 	@param parentPod of the media item that the media ad is playing in.
 * 	@param parentPodPosition position of parent pod (in seconds).
 * 	@param CPM .
 *  @return An ADBMediaSettings pointer.
 */
+ (nonnull ADBMediaSettings *) mediaAdCreateSettingsWithName:(nullable NSString *)name
                                                      length:(double)length
                                                  playerName:(nullable NSString *)playerName
                                                  parentName:(nullable NSString *)parentName
                                                   parentPod:(nullable NSString *)parentPod
                                           parentPodPosition:(double)parentPodPosition
                                                         CPM:(nullable NSString *)CPM;

/**
 * 	@brief Opens a media item for tracking.
 *  @param settings a pointer to the configured ADBMediaSettings
 *  @param callback a block pointer to call with an ADBMediaState pointer every second.
 */
+ (void) mediaOpenWithSettings:(nullable ADBMediaSettings *)settings
                      callback:(nullable void (^)(ADBMediaState* __nullable mediaState))callback;

/**
 * 	@brief Closes a media item.
 *  @param name name of media item.
 */
+ (void) mediaClose:(nullable NSString *)name;

/**
 * 	@brief Begins tracking a media item.
 *  @param name name of media item.
 *	@param offset point that the media items is being played from (in seconds)
 */
+ (void) mediaPlay:(nullable NSString *)name offset:(double)offset;

/**
 * 	@brief Artificially completes a media item.
 *  @param name name of media item.
 *	@param offset point that the media items is when complete is called (in seconds)
 */
+ (void) mediaComplete:(nullable NSString *)name offset:(double)offset;

/**
 * 	@brief Notifies the media module that the media item has been paused or stopped
 *	@param name name of media item.
 *	@param offset point that the media item was stopped (in seconds)
 */
+ (void) mediaStop:(nullable NSString *)name offset:(double)offset;

/**
 * 	@brief Notifies the media module that the media item has been clicked
 *	@param name name of media item.
 *	@param offset point that the media item was clicked (in seconds)
 */
+ (void) mediaClick:(nullable NSString *)name offset:(double)offset;

/**
 *	@brief Sends a track event with the current media state
 *
 *	@param name name of media item.
 *  @param data optional dictionary pointer containing context data to track with this media action.
 */
+ (void) mediaTrack:(nullable NSString *)name data:(nullable NSDictionary *)data;

#pragma mark - Target
/**
 *  @brief Creates an ADBTargetPrefetchObject for the given name and mbox parameters
 *  @param name NSString value representing the name for location/mbox you wish to prefetch
 *  @param mboxParameters optional dictionary of key-value pairs representing mbox parameters for this request
 *  @return a pointer to an ADBTargetPrefetchObject containing values provided by the parameters
 *  @see ADBTargetPrefetchObject
 *  @see targetPrefetchContentForObjects:withProfileParameters:callback:
 */
+ (nullable ADBTargetPrefetchObject *) targetPrefetchObjectWithName:(nonnull NSString *)name
                                                     mboxParameters:(nullable NSDictionary *)mboxParameters;

/**
 *  @brief Creates an ADBTargetRequestObject for the given name, default content, mbox parameters, and callback function pointer
 *  @param name NSString value representing the name for location/mbox you wish to retrieve
 *  @param defaultContent NSString value returned by the callback if the SDK is unable to retrieve content for the given mbox/location
 *  @param mboxParameters optional dictionary of key-value pairs representing mbox parameters for this request
 *  @param callback method which will be invoked once content is available for requested mbox/location
 *  @return a pointer to an ADBTargetRequestObject containing pre-set values provided by the parameters
 *  @see ADBTargetRequestObject
 *  @see targetLoadRequests:withProfileParameters
 */
+ (nullable ADBTargetRequestObject *) targetRequestObjectWithName:(nonnull NSString *)name
                                                   defaultContent:(nonnull NSString *)defaultContent
                                                   mboxParameters:(nullable NSDictionary *)mboxParameters
                                                         callback:(nullable void (^)(NSString* __nullable content))callback;

/**
 *  @brief Prefetch multiple Target mboxes simultanously.  The content will be cached and returned immediately after
 *         any prefetched mbox is requested
 *  @param targetPrefetchObjectArray an array of ADBTargetPrefetchObjects representing the desired mboxes to prefetch
 *  @param profileParameters a dictionary of key-value pairs used as profile parameters for all prefetch requests
 *  @param callback a function pointer which will be called after the prefetch is complete.  The success parameter
 *         in the callback will be YES if the prefetch completed successfully
 *  @see targetPrefetchObjectWithName:mboxParameters:
 *  @see ADBTargetPrefetchObject
 */
+ (void) targetPrefetchContent:(nonnull NSArray *)targetPrefetchObjectArray
         withProfileParameters:(nullable NSDictionary *)profileParameters
                      callback:(nullable void(^)(BOOL success))callback;

/**
 *  @brief Retrieves content for multiple Target Locations at once.  The requests parameter contains ADBTargetRequestObject
 *         objects.  Each ADBTargetRequestObject object must have a name and default content.  Once content is available for
 *         the given mbox name, the callback in the ADBTargetRequestObject object will be called with content from Target
 *  @param requests An array of ADBTargetRequestObject objects that will all be requested at once
 *  @param profileParameters a dictionary of key-value pairs used as profile parameters for all locations in the requests array
 *  @see ADBTargetRequestObject
 *  @see targetRequestObjectWithName:defaultContent:mboxParameters:callback:
 */
+ (void) targetLoadRequests:(nonnull NSArray *)requests
      withProfileParameters:(nullable NSDictionary *)profileParameters;

/**
 * @brief Sends a click notification to Target if a click metric is defined for the provided location name.
 *
 * Click notification can be sent for a location provided a load request has been executed for that prefetched or regular mbox
 * location before, indicating that the mbox was viewed. This request helps Target record the clicked event for the given location or mbox.
 *
 * @param name NSString value representing the name for location/mbox
 * @param mboxParameters a dictionary of key-value pairs representing mbox parameters for this request
 * @param productParameters a dictionary of key-value pairs representing product parameters for this request
 * @param orderParameters a dictionary of key-value pairs representing order parameters for this request
 * @param profileParameters a dictionary of key-value pairs representing profile parameters for this request
 *
 */
+ (void)locationClickedWithName:(nonnull NSString *)name
                 mboxParameters: (nullable NSDictionary *) mboxParameters
              productParameters: (nullable NSDictionary *) productParameters
                orderParameters: (nullable NSDictionary *) orderParameters
              profileParameters:(nullable NSDictionary *)profileParameters;

/**
 *  @brief Clears data cached by Target Prefetch
 */
+ (void) targetPrefetchClearCache;

#if TARGET_OS_IOS
/**
 * 	@brief Receives the deeplink url calls the application when target preview experience is selected.
 * 	@param callbackURL that openURL method should be passed for the application to handle.
 */
+ (void) targetPreviewRestartDeepLink:(nullable NSString *)callbackURL;
#endif

/**
 * 	@brief Processes a Target service request.
 * 	@param request a ADBTargetLocationRequest pointer.
 * 	@param callback a block pointer to call with a response string pointer parameter upon completion of the service request.
 */
+ (void) targetLoadRequest:(nullable ADBTargetLocationRequest *)request callback:(nullable void (^)(NSString* __nullable content))callback;

/**
 * 	@brief Processes a Target service request.
 * 	@param name a string pointer containing the name of the mbox
 *  @param defaultContent a string pointer containing the content to be returned on failure
 *  @param profileParameters a dictionary of parameters to be added to the profile
 *  @param orderParameters a dictionary
 *  @param mboxParameters a dictionary of parameters for the mbox
 * 	@param callback a block pointer to call with a response string pointer parameter upon completion of the service request.
 */
+ (void) targetLoadRequestWithName:(nullable NSString *)name
                    defaultContent:(nullable NSString *)defaultContent
                 profileParameters:(nullable NSDictionary *)profileParameters
                   orderParameters:(nullable NSDictionary *)orderParameters
                    mboxParameters:(nullable NSDictionary *)mboxParameters
                          callback:(nullable void (^)(NSString* __nullable content))callback;

/**
 * 	@brief Processes a Target service request.
 * 	@param name a string pointer containing the name of the mbox
 *  @param defaultContent a string pointer containing the content to be returned on failure
 *  @param profileParameters a dictionary of parameters to be added to the profile
 *  @param orderParameters a dictionary
 *  @param mboxParameters a dictionary of parameters for the mbox
 *	@param requestLocationParameters a dictionary of parameters for request location
 * 	@param callback a block pointer to call with a response string pointer parameter upon completion of the service request.
 */
+ (void) targetLoadRequestWithName:(nullable NSString *)name
                    defaultContent:(nullable NSString *)defaultContent
                 profileParameters:(nullable NSDictionary *)profileParameters
                   orderParameters:(nullable NSDictionary *)orderParameters
                    mboxParameters:(nullable NSDictionary *)mboxParameters
         requestLocationParameters:(nullable NSDictionary *)requestLocationParameters
                          callback:(nullable void (^)(NSString* __nullable content))callback;

/**
 * 	@brief Creates a ADBTargetLocationRequest populated with the parameters.
 * 	@param name a string pointer.
 * 	@param defaultContent a string pointer.
 *  @param parameters a dictionary of key-value pairs that will be added to the request.
 *  @return A ADBTargetLocationRequest pointer.
 *  @see targetLoadRequest:callback: for processing the returned ADBTargetLocationRequest pointer.
 */
+ (nullable ADBTargetLocationRequest *) targetCreateRequestWithName:(nullable NSString *)name
                                                     defaultContent:(nullable NSString *)defaultContent
                                                         parameters:(nullable NSDictionary *)parameters;

/**
 * 	@brief Creates a ADBTargetLocationRequest populated with the parameters.
 * 	@param name a string pointer containing the value of the order name.
 * 	@param orderId a string pointer containing the value of the order id.
 * 	@param orderTotal a string pointer containing the value of the order total.
 * 	@param productPurchasedId a string pointer containing the value of the product purchased id.
 *  @param parameters a dictionary of key-value pairs that will be added to the request.
 *  @return A ADBTargetLocationRequest pointer.
 *  @see targetLoadRequest:callback: for processing the returned ADBTargetLocationRequest pointer.
 */
+ (nullable ADBTargetLocationRequest *) targetCreateOrderConfirmRequestWithName:(nullable NSString *)name
                                                                        orderId:(nullable NSString *)orderId
                                                                     orderTotal:(nullable NSString *)orderTotal
                                                             productPurchasedId:(nullable NSString *)productPurchasedId
                                                                     parameters:(nullable NSDictionary *)parameters;

/**
 * 	@brief Gets the custom visitor ID for target
 *	@return thirdPartyId a string pointer containing the value of the third party id (custom visitor id)
 */
+ (nullable NSString *) targetThirdPartyID;

/**
 * 	@brief Sets the custom visitor ID for target
 *	@param thirdPartyID a string pointer containing the value of the third party id (custom visitor id)
 */
+ (void) targetSetThirdPartyID:(nullable NSString *)thirdPartyID;

/**
 * 	@brief Resets the user's experience
 */
+ (void) targetClearCookies;

/**
 * 	@brief Gets the value of the PcID cookie returned for this visitor by the Target server
 *  @return An NSString pointer containing the PcID for this user
 */
+ (nullable NSString *) targetPcID;

/**
 * 	@brief Gets the value of the SessionID cookie returned for this visitor by the Target server
 *  @return An NSString pointer containing the SessionID for this user
 */
+ (nonnull NSString *) targetSessionID;

#pragma mark - Audience Manager

/**
 * 	@brief Gets the visitor's profile.
 *  @return A dictionary pointer containing the visitor's profile information.
 */
+ (nullable NSDictionary *) audienceVisitorProfile;

/**
 * 	@brief Gets the DPID.
 *  @return A string pointer containing the DPID value.
 */
+ (nullable NSString *) audienceDpid;

/**
 * 	@brief Gets the DPUUID.
 *  @return A string pointer containing the DPUUID value.
 */
+ (nullable NSString *) audienceDpuuid;

/**
 * 	@brief Sets the DPID and DPUUID.
 *  @param dpid a string pointer containing the DPID value.
 * 	@param dpuuid a string pointer containing the DPUUID value.
 */
+ (void) audienceSetDpid:(nullable NSString *)dpid dpuuid:(nullable NSString *)dpuuid;

/**
 * 	@brief Processes an Audience Manager service request.
 * 	@param data a dictionary pointer.
 * 	@param callback a block pointer to call with a response dictionary pointer parameter upon completion of the service request.
 */
+ (void) audienceSignalWithData:(nullable NSDictionary *)data callback:(nullable void (^)(NSDictionary* __nullable response))callback;

/**
 * 	@brief Resets audience manager UUID and purges current visitor profile
 */
+ (void) audienceReset;

#pragma mark - Visitor ID Service
/**
 *	@brief Retrieves the Marketing Cloud Identifier from the Visitor ID Service
 *	@return an NSString value containing the Marketing Cloud ID
 *	@note This method can cause a blocking network call and should not be used from a UI thread.
 */
+ (nullable NSString *) visitorMarketingCloudID;

/**
 *	@brief Synchronizes the provided identifiers to the visitor id service
 *	@param identifiers a dictionary containing identifiers, with the keys being the id types and the values being the correlating identifiers
 */
+ (void) visitorSyncIdentifiers: (nullable NSDictionary *) identifiers;

/**
 *	@brief Synchronizes the provided identifiers to the visitor id service
 *	@param identifiers a dictionary containing identifiers, with the keys being the id types and the values being the correlating identifiers
 *	@param authState a authentication state will be applied for all the items in identifiers dictionary
 */
+ (void) visitorSyncIdentifiers: (nullable NSDictionary *) identifiers authenticationState:(ADBMobileVisitorAuthenticationState) authState;

/**
 *	@brief Synchronizes the provided identifiers to the visitor id service
 *	@param identifierType a string pointer containing the identifier type
 *	@param identifier a string pointer containing the identifier
 *	@param authState a authentication state will be applied
 */
+ (void) visitorSyncIdentifierWithType: (nullable NSString *) identifierType identifier:(nullable NSString *)identifier authenticationState:(ADBMobileVisitorAuthenticationState) authState;

/**
 *	@brief Returns all visitorIDs that have been synced
 *  @return an array of readonly ADBVisitorIDs
 */
+ (nullable NSArray *) visitorGetIDs;

/**
 *  @brief Appends visitor identifiers to the given URL
 *  @return NSURL object containing the modified URL
 *	@note This method can cause a blocking network call.  Blocking time is limited to 100ms, but care should still be taken to not call this on time-sensitive threads.
 */
+ (nullable NSURL *) visitorAppendToURL: (nullable NSURL *) url;

/**
 *  @brief Gets Visitor ID Service identifiers in URL query string form for consumption in hybrid mobile apps.
 *         There will be no leading '&' or '?' punctuation, as the caller is responsible for placing the string in the correct location
 *         of their resulting URL.
 *         If there is not a valid URL string to return, if an error occurs or the identifiers retrieval takes longer than 30 seconds,
 *         callback will contain nil.
 *  @param callback a block pointer to call with an NSString value containing the visitor identifiers as a query string upon completion of the service request
 */
+ (void) visitorGetUrlVariablesAsync:(nullable void (^)(NSString* __nullable urlVariables))callback;

#pragma mark - PII collection

/**
 *	@brief Submits a PII collection request
 *	@param data a dictionary containing PII data
 */
+ (void) collectPII:(nullable NSDictionary<NSString *, NSString *> *)data;

#pragma mark - User Identification

/**
 * @brief Calls the provided callback with a JSON string containing all of the User's identifiers known by the SDK
 * @param callback a void-returning method that has an NSString param containing a JSON string
 */
+ (void) getAllIdentifiersAsync:(nullable void (^)(NSString* __nullable content))callback;

@end

#pragma mark - ADBVisitorID
@interface ADBVisitorID : NSObject
- (nullable NSString *)idType;
- (nullable NSString *)identifier;
- (ADBMobileVisitorAuthenticationState) authenticationState;
@end

#pragma mark - ADBTargetLocationRequest

/** @defgroup ADBTargetParameters
 *  These constant strings can be used as the keys for add common Target parameters to context data.
 *  Example: contextData[ADBTargetParameterOrderId] = @"12345";
 *  @{
 */
FOUNDATION_EXPORT NSString *const __nonnull ADBTargetParameterOrderId;            ///< The key for an Order ID.
FOUNDATION_EXPORT NSString *const __nonnull ADBTargetParameterOrderTotal;         ///< The key for an Order Total.
FOUNDATION_EXPORT NSString *const __nonnull ADBTargetParameterProductPurchasedId; ///< The key for a Product Purchased ID.
FOUNDATION_EXPORT NSString *const __nonnull ADBTargetParameterCategoryId;         ///< The key for a Category ID.
FOUNDATION_EXPORT NSString *const __nonnull ADBTargetParameterMbox3rdPartyId;     ///< The key for an Mbox 3rd Party ID.
FOUNDATION_EXPORT NSString *const __nonnull ADBTargetParameterMboxPageValue;      ///< The key for an Mbox Page Value.
FOUNDATION_EXPORT NSString *const __nonnull ADBTargetParameterMboxPc;             ///< The key for an Mbox PC.
FOUNDATION_EXPORT NSString *const __nonnull ADBTargetParameterMboxSessionId;      ///< The key for an Mbox Session ID.
FOUNDATION_EXPORT NSString *const __nonnull ADBTargetParameterMboxHost;           ///< The key for an Mbox Host.
/** @} */ // end of group ADBTargetParameters

/**
 * 	@class ADBTargetLocationRequest
 *  This class is used to interact with Adobe Target servers.
 */
@interface ADBTargetLocationRequest : NSObject

@property (nonatomic, strong, nullable) NSString *name;                   ///< The name of the target location.
@property (nonatomic, strong, nullable) NSString *defaultContent;         ///< The default content that should be returned if the request fails.
@property (nonatomic, strong, nullable) NSMutableDictionary *parameters;  ///< Optional. The parameters to be attached to the request.

@end

#pragma mark - ADBTargetPrefetchObject
/**
 *  @class ADBTargetPrefetchObject
 *  This class contains the name of the Target location/mbox and a dictionary of mbox parameters to be used in a prefetch
 *  @see targetPrefetchObjectWithName:mboxParameters:
 *  @see targetPrefetchContentForObjects:withProfileParameters:callback:
 */
@interface ADBTargetPrefetchObject : NSObject

@property (nonatomic, strong, nullable) NSString *name;						///< The name of the Target location/mbox
@property (nonatomic, strong, nullable) NSDictionary *mboxParameters;		///< Dictionary containing key-value pairs of mbox parameters
@property (nonatomic, strong, nullable) NSDictionary *productParameters;	///< Dictionary containing key-value pairs of product parameters
@property (nonatomic, strong, nullable) NSDictionary *orderParameters;		///< Dictionary containing key-value pairs of order parameters

@end

#pragma mark - ADBTargetRequestObject
/**
 *  @class ADBTargetRequestObject
 *  This class extends ADBTargetPrefetchObject, adding default content and a function pointer property which will be
 *  used as a callback when requesting content from Target
 *  @see targetRequestObjectWithName:defaultContent:mboxParameters:callback:
 *  @see targetLoadRequests:withProfileParameters
 */
@interface ADBTargetRequestObject : ADBTargetPrefetchObject

@property (nonatomic, strong, nonnull) NSString *defaultContent;                         ///< The default content that will be returned if Target servers are unreachable
@property (nonatomic, strong, nullable) void (^callback)(NSString* __nullable content);  ///< Optional. When batch requesting Target locations, callback will be invoked when content is available for this location.
@property (nonatomic, strong, nullable) NSDictionary *requestLocationParameters;         ///< Dictionary containing key-value pairs of request location parameters

@end

#pragma mark - ADBMediaSettings

/**
 * 	@class ADBMediaSettings
 *  This class represents the configuration of a media item.
 */
@interface ADBMediaSettings : NSObject

@property (readwrite) bool segmentByMilestones;                 ///< Indicates if segment info should be automatically generated for milestones generated or not, the default is NO.
@property (readwrite) bool segmentByOffsetMilestones;           ///< Indicates if segment info should be automatically generated for offset milestones or not, the default is NO.
@property (readwrite) double length;                            ///< The length of the media item in seconds.
@property (nonatomic, strong, nullable) NSString *channel;                ///< The name or ID of the channel.
@property (nonatomic, strong, nullable) NSString *name;                   ///< The name or ID of the media item.
@property (nonatomic, strong, nullable) NSString *playerName;             ///< The name of the media player.
@property (nonatomic, strong, nullable) NSString *playerID;               ///< The ID of the media player.
@property (nonatomic, strong, nullable) NSString *milestones;             ///< A comma-delimited list of intervals (as a percentage) for sending tracking data.
@property (nonatomic, strong, nullable) NSString *offsetMilestones;       ///< A comma-delimited list of intervals (in seconds) for sending tracking data.
@property (nonatomic) NSUInteger trackSeconds;                  ///< The interval at which tracking data should be sent, the default is 0.
@property (nonatomic) NSUInteger completeCloseOffsetThreshold;  ///< The number of second prior to the end of the media that it should be considered complete, the default is 1.

// Media Ad settings
@property (readwrite) bool isMediaAd;               ///< Indicates if the media item is an ad or not.
@property (readwrite) double parentPodPosition;     ///< The position within the pod where the ad is played.
@property (nonatomic, strong, nullable) NSString *CPM;        ///< The CMP or encrypted CPM (prefixed with a "~") for the media item.
@property (nonatomic, strong, nullable) NSString *parentName; ///< The name or ID of the media item that the ad is embedded in.
@property (nonatomic, strong, nullable) NSString *parentPod;  ///< The position in the primary content the ad was played.

@end

#pragma mark - ADBMediaState

/**
 * 	@class ADBMediaState
 *  This class represents the state of a media item.
 */
@interface ADBMediaState : NSObject

@property(readwrite) BOOL ad;                       ///< Indicates if the media item is an ad or not.
@property(readwrite) BOOL clicked;                  ///< Indicates if the media item has been clicked or not.
@property(readwrite) BOOL complete;                 ///< Indicates if media play is complete or not.
@property(readwrite) BOOL eventFirstTime;           ///< Indicates if this was the first time that this media event was called for this video.
@property(readwrite) double length;                 ///< The length of the media item in seconds.
@property(readwrite) double offset;                 ///< The current point in the media item in seconds.
@property(readwrite) double percent;                ///< The current point in the media item as a percentage.
@property(readwrite) double segmentLength;          ///< The length of the current segment.
@property(readwrite) double timePlayed;             ///< The total time played so far in seconds.
@property(readwrite) double timePlayedSinceTrack;   ///< The amount of time played since the last track event occurred in seconds.
@property(readwrite) double timestamp;              ///< The number of seconds since 1970 when this media state was created.
@property(readwrite, copy, nullable) NSDate *openTime;        ///< The date and time of when the media item was opened.
@property(readwrite, copy, nullable) NSString *name;          ///< The name or ID of the media item.
@property(readwrite, copy, nullable) NSString *playerName;    ///< The name or ID of the media player.
@property(readwrite, copy, nullable) NSString *mediaEvent;    ///< The name of the most recent media event.
@property(readwrite, copy, nullable) NSString *segment;       ///< The name of the current segment.
@property(readwrite) NSUInteger milestone;          ///< The most recent milestone.
@property(readwrite) NSUInteger offsetMilestone;    ///< The most recent offset milestone.
@property(readwrite) NSUInteger segmentNum;         ///< The current segment.
@property(readwrite) NSUInteger eventType;          ///< The current event type.

@end
