using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreLocation;

namespace Com.Adobe.Mobile
{
    [Static]
    partial interface Constants
    {
        // extern NSString *const _Nonnull ADBConfigKeyCallbackDeepLink;
        [Field("ADBConfigKeyCallbackDeepLink", "__Internal")]
        NSString ADBConfigKeyCallbackDeepLink { get; }

        // extern NSString *const _Nonnull ADBTargetParameterOrderId;
        [Field("ADBTargetParameterOrderId", "__Internal")]
        NSString ADBTargetParameterOrderId { get; }

        // extern NSString *const _Nonnull ADBTargetParameterOrderTotal;
        [Field("ADBTargetParameterOrderTotal", "__Internal")]
        NSString ADBTargetParameterOrderTotal { get; }

        // extern NSString *const _Nonnull ADBTargetParameterProductPurchasedId;
        [Field("ADBTargetParameterProductPurchasedId", "__Internal")]
        NSString ADBTargetParameterProductPurchasedId { get; }

        // extern NSString *const _Nonnull ADBTargetParameterCategoryId;
        [Field("ADBTargetParameterCategoryId", "__Internal")]
        NSString ADBTargetParameterCategoryId { get; }

        // extern NSString *const _Nonnull ADBTargetParameterMbox3rdPartyId;
        [Field("ADBTargetParameterMbox3rdPartyId", "__Internal")]
        NSString ADBTargetParameterMbox3rdPartyId { get; }

        // extern NSString *const _Nonnull ADBTargetParameterMboxPageValue;
        [Field("ADBTargetParameterMboxPageValue", "__Internal")]
        NSString ADBTargetParameterMboxPageValue { get; }

        // extern NSString *const _Nonnull ADBTargetParameterMboxPc;
        [Field("ADBTargetParameterMboxPc", "__Internal")]
        NSString ADBTargetParameterMboxPc { get; }

        // extern NSString *const _Nonnull ADBTargetParameterMboxSessionId;
        [Field("ADBTargetParameterMboxSessionId", "__Internal")]
        NSString ADBTargetParameterMboxSessionId { get; }

        // extern NSString *const _Nonnull ADBTargetParameterMboxHost;
        [Field("ADBTargetParameterMboxHost", "__Internal")]
        NSString ADBTargetParameterMboxHost { get; }
    }

    // @interface ADBMobile : NSObject
    [BaseType(typeof(NSObject))]
    interface ADBMobile
    {
        // +(NSString *)version;
        [Static, Export("version")]
        string Version();

        // +(ADBMobilePrivacyStatus)privacyStatus;
        // +(void)setPrivacyStatus:(ADBMobilePrivacyStatus)status;
        [Static]
        [Export("privacyStatus")]
        ADBMobilePrivacyStatus PrivacyStatus { get; set; }

        // +(NSDecimalNumber * _Nullable)lifetimeValue;
        [Static, Export("lifetimeValue")]
        [return: NullAllowed]
        NSDecimalNumber LifetimeValue();

        // +(NSString * _Nullable)userIdentifier;
        [Static, Export("userIdentifier")]
        [return: NullAllowed]
        string UserIdentifier();

        // +(void)setUserIdentifier:(NSString * _Nullable)identifier;
        [Static, Export("setUserIdentifier:")]
        void SetUserIdentifier([NullAllowed] string identifier);

        // +(void)setAdvertisingIdentifier:(NSString * _Nullable)identifier;
        [Static, Export("setAdvertisingIdentifier:")]
        void SetAdvertisingIdentifier([NullAllowed] string identifier);

        // +(void)setPushIdentifier:(NSData * _Nullable)deviceToken;
        [Static, Export("setPushIdentifier:")]
        void SetPushIdentifier([NullAllowed] NSData deviceToken);

        // +(BOOL)debugLogging;
        [Static, Export("debugLogging")]
        bool DebugLogging();

        // +(void)setDebugLogging:(BOOL)debug;
        [Static, Export("setDebugLogging:")]
        void SetDebugLogging(bool debug);

        // +(void)keepLifecycleSessionAlive;
        [Static, Export("keepLifecycleSessionAlive")]
        void KeepLifecycleSessionAlive();

        // +(void)collectLifecycleData;
        [Static, Export("collectLifecycleData")]
        void CollectLifecycleData();

        // +(void)collectLifecycleDataWithAdditionalData:(NSDictionary * _Nullable)data;
        [Static, Export("collectLifecycleDataWithAdditionalData:")]
        void CollectLifecycleDataWithAdditionalData([NullAllowed] NSDictionary data);

        // +(void)overrideConfigPath:(NSString * _Nullable)path;
        [Static, Export("overrideConfigPath:")]
        void OverrideConfigPath([NullAllowed] string path);

        // +(void)setAppGroup:(NSString * _Nullable)appGroup;
        [Static, Export("setAppGroup:")]
        void SetAppGroup([NullAllowed] string appGroup);

        // +(BOOL)syncSettings:(NSDictionary * _Nullable)settings;
        [Static, Export("syncSettings:")]
        bool SyncSettings([NullAllowed] NSDictionary settings);

        // +(void)initializeWatch;
        [Static, Export("initializeWatch")]
        void InitializeWatch();

#if __TVOS__
        // +(void)installTVMLHooks:(TVApplicationController * _Nullable)tvController;
        [Static, Export("installTVMLHooks:")]
        void InstallTVMLHooks([NullAllowed] TVApplicationController tvController);
#endif

        // +(void)registerAdobeDataCallback:(void (^ _Nullable)(ADBMobileDataEvent, NSDictionary * _Nullable))callback;
        [Static, Export("registerAdobeDataCallback:")]
        void RegisterAdobeDataCallback([NullAllowed] Action<ADBMobileDataEvent, NSDictionary> callback);

        // +(void)trackState:(NSString * _Nullable)state data:(NSDictionary * _Nullable)data;
        [Static, Export("trackState:data:")]
        void TrackState([NullAllowed] string state, [NullAllowed] NSDictionary data);

        // +(void)trackAction:(NSString * _Nullable)action data:(NSDictionary * _Nullable)data;
        [Static, Export("trackAction:data:")]
        void TrackAction([NullAllowed] string action, [NullAllowed] NSDictionary data);

        // +(void)trackActionFromBackground:(NSString * _Nullable)action data:(NSDictionary * _Nullable)data;
        [Static, Export("trackActionFromBackground:data:")]
        void TrackActionFromBackground([NullAllowed] string action, [NullAllowed] NSDictionary data);

        // +(void)trackLocation:(CLLocation * _Nullable)location data:(NSDictionary * _Nullable)data;
        [Static, Export("trackLocation:data:")]
        void TrackLocation([NullAllowed] CLLocation location, [NullAllowed] NSDictionary data);

        // +(void)trackBeacon:(CLBeacon * _Nullable)beacon data:(NSDictionary * _Nullable)data;
        [Static, Export("trackBeacon:data:")]
        void TrackBeacon([NullAllowed] CLBeacon beacon, [NullAllowed] NSDictionary data);

        // +(void)trackingClearCurrentBeacon;
        [Static, Export("trackingClearCurrentBeacon")]
        void TrackingClearCurrentBeacon();

        // +(void)trackPushMessageClickThrough:(NSDictionary * _Nullable)userInfo;
        [Static, Export("trackPushMessageClickThrough:")]
        void TrackPushMessageClickThrough([NullAllowed] NSDictionary userInfo);

        // +(void)trackLocalNotificationClickThrough:(NSDictionary * _Nullable)userInfo;
        [Static, Export("trackLocalNotificationClickThrough:")]
        void TrackLocalNotificationClickThrough([NullAllowed] NSDictionary userInfo);

        // +(void)trackAdobeDeepLink:(NSURL * _Nullable)url;
        [Static, Export("trackAdobeDeepLink:")]
        void TrackAdobeDeepLink([NullAllowed] NSUrl url);

        // +(void)trackLifetimeValueIncrease:(NSDecimalNumber * _Nullable)amount data:(NSDictionary * _Nullable)data;
        [Static, Export("trackLifetimeValueIncrease:data:")]
        void TrackLifetimeValueIncrease([NullAllowed] NSDecimalNumber amount, [NullAllowed] NSDictionary data);

        // +(void)trackTimedActionStart:(NSString * _Nullable)action data:(NSDictionary * _Nullable)data;
        [Static, Export("trackTimedActionStart:data:")]
        void TrackTimedActionStart([NullAllowed] string action, [NullAllowed] NSDictionary data);

        // +(void)trackTimedActionUpdate:(NSString * _Nullable)action data:(NSDictionary * _Nullable)data;
        [Static, Export("trackTimedActionUpdate:data:")]
        void TrackTimedActionUpdate([NullAllowed] string action, [NullAllowed] NSDictionary data);

        // +(void)trackTimedActionEnd:(NSString * _Nullable)action logic:(BOOL (^ _Nullable)(NSTimeInterval, NSTimeInterval, NSMutableDictionary * _Nullable))block;
        [Static, Export("trackTimedActionEnd:logic:")]
        void TrackTimedActionEnd([NullAllowed] string action, [NullAllowed] Func<double, double, NSMutableDictionary, bool> block);

        // +(BOOL)trackingTimedActionExists:(NSString * _Nullable)action;
        [Static, Export("trackingTimedActionExists:")]
        bool TrackingTimedActionExists([NullAllowed] string action);

        // +(NSString * _Nullable)trackingIdentifier;
        [Static, Export("trackingIdentifier")]
        [return: NullAllowed]
        string TrackingIdentifier();

        // +(void)trackingSendQueuedHits;
        [Static, Export("trackingSendQueuedHits")]
        void TrackingSendQueuedHits();

        // +(void)trackingClearQueue;
        [Static, Export("trackingClearQueue")]
        void TrackingClearQueue();

        // +(NSUInteger)trackingGetQueueSize;
        [Static, Export("trackingGetQueueSize")]
        nuint TrackingGetQueueSize();

        // +(void)acquisitionCampaignStartForApp:(NSString * _Nullable)appId data:(NSDictionary * _Nullable)data;
        [Static, Export("acquisitionCampaignStartForApp:data:")]
        void AcquisitionCampaignStartForApp([NullAllowed] string appId, [NullAllowed] NSDictionary data);

        // +(ADBMediaSettings * _Nonnull)mediaCreateSettingsWithName:(NSString * _Nullable)name length:(double)length playerName:(NSString * _Nullable)playerName playerID:(NSString * _Nullable)playerID;
        [Static, Export("mediaCreateSettingsWithName:length:playerName:playerID:")]
        ADBMediaSettings MediaCreateSettings([NullAllowed] string name, double length, [NullAllowed] string playerName, [NullAllowed] string playerID);

        // +(ADBMediaSettings * _Nonnull)mediaAdCreateSettingsWithName:(NSString * _Nullable)name length:(double)length playerName:(NSString * _Nullable)playerName parentName:(NSString * _Nullable)parentName parentPod:(NSString * _Nullable)parentPod parentPodPosition:(double)parentPodPosition CPM:(NSString * _Nullable)CPM;
        [Static, Export("mediaAdCreateSettingsWithName:length:playerName:parentName:parentPod:parentPodPosition:CPM:")]
        ADBMediaSettings MediaAdCreateSettings([NullAllowed] string name, double length, [NullAllowed] string playerName, [NullAllowed] string parentName, [NullAllowed] string parentPod, double parentPodPosition, [NullAllowed] string CPM);

        // +(void)mediaOpenWithSettings:(ADBMediaSettings * _Nullable)settings callback:(void (^ _Nullable)(ADBMediaState * _Nullable))callback;
        [Static, Export("mediaOpenWithSettings:callback:")]
        void MediaOpenWithSettings([NullAllowed] ADBMediaSettings settings, [NullAllowed] Action<ADBMediaState> callback);

        // +(void)mediaClose:(NSString * _Nullable)name;
        [Static, Export("mediaClose:")]
        void MediaClose([NullAllowed] string name);

        // +(void)mediaPlay:(NSString * _Nullable)name offset:(double)offset;
        [Static, Export("mediaPlay:offset:")]
        void MediaPlay([NullAllowed] string name, double offset);

        // +(void)mediaComplete:(NSString * _Nullable)name offset:(double)offset;
        [Static, Export("mediaComplete:offset:")]
        void MediaComplete([NullAllowed] string name, double offset);

        // +(void)mediaStop:(NSString * _Nullable)name offset:(double)offset;
        [Static, Export("mediaStop:offset:")]
        void MediaStop([NullAllowed] string name, double offset);

        // +(void)mediaClick:(NSString * _Nullable)name offset:(double)offset;
        [Static, Export("mediaClick:offset:")]
        void MediaClick([NullAllowed] string name, double offset);

        // +(void)mediaTrack:(NSString * _Nullable)name data:(NSDictionary * _Nullable)data;
        [Static, Export("mediaTrack:data:")]
        void MediaTrack([NullAllowed] string name, [NullAllowed] NSDictionary data);

        // +(void)targetLoadRequest:(ADBTargetLocationRequest * _Nullable)request callback:(void (^ _Nullable)(NSString * _Nullable))callback;
        [Static, Export("targetLoadRequest:callback:")]
        void TargetLoadRequest([NullAllowed] ADBTargetLocationRequest request, [NullAllowed] Action<NSString> callback);

        // +(void)targetLoadRequestWithName:(NSString * _Nullable)name defaultContent:(NSString * _Nullable)defaultContent profileParameters:(NSDictionary * _Nullable)profileParameters orderParameters:(NSDictionary * _Nullable)orderParameters mboxParameters:(NSDictionary * _Nullable)mboxParameters callback:(void (^ _Nullable)(NSString * _Nullable))callback;
        [Static, Export("targetLoadRequestWithName:defaultContent:profileParameters:orderParameters:mboxParameters:callback:")]
        void TargetLoadRequest([NullAllowed] string name, [NullAllowed] string defaultContent, [NullAllowed] NSDictionary profileParameters, [NullAllowed] NSDictionary orderParameters, [NullAllowed] NSDictionary mboxParameters, [NullAllowed] Action<NSString> callback);

        // +(void)targetLoadRequestWithName:(NSString * _Nullable)name defaultContent:(NSString * _Nullable)defaultContent profileParameters:(NSDictionary * _Nullable)profileParameters orderParameters:(NSDictionary * _Nullable)orderParameters mboxParameters:(NSDictionary * _Nullable)mboxParameters requestLocationParameters:(NSDictionary * _Nullable)requestLocationParameters callback:(void (^ _Nullable)(NSString * _Nullable))callback;
        [Static, Export("targetLoadRequestWithName:defaultContent:profileParameters:orderParameters:mboxParameters:requestLocationParameters:callback:")]
        void TargetLoadRequest([NullAllowed] string name, [NullAllowed] string defaultContent, [NullAllowed] NSDictionary profileParameters, [NullAllowed] NSDictionary orderParameters, [NullAllowed] NSDictionary mboxParameters, [NullAllowed] NSDictionary requestLocationParameters, [NullAllowed] Action<NSString> callback);

        // +(ADBTargetLocationRequest * _Nullable)targetCreateRequestWithName:(NSString * _Nullable)name defaultContent:(NSString * _Nullable)defaultContent parameters:(NSDictionary * _Nullable)parameters;
        [Static, Export("targetCreateRequestWithName:defaultContent:parameters:")]
        [return: NullAllowed]
        ADBTargetLocationRequest TargetCreateRequest([NullAllowed] string name, [NullAllowed] string defaultContent, [NullAllowed] NSDictionary parameters);

        // +(ADBTargetLocationRequest * _Nullable)targetCreateOrderConfirmRequestWithName:(NSString * _Nullable)name orderId:(NSString * _Nullable)orderId orderTotal:(NSString * _Nullable)orderTotal productPurchasedId:(NSString * _Nullable)productPurchasedId parameters:(NSDictionary * _Nullable)parameters;
        [Static, Export("targetCreateOrderConfirmRequestWithName:orderId:orderTotal:productPurchasedId:parameters:")]
        [return: NullAllowed]
        ADBTargetLocationRequest TargetCreateOrderConfirmRequest([NullAllowed] string name, [NullAllowed] string orderId, [NullAllowed] string orderTotal, [NullAllowed] string productPurchasedId, [NullAllowed] NSDictionary parameters);

        // +(NSString * _Nullable)targetThirdPartyID;
        [Static, Export("targetThirdPartyID")]
        [return: NullAllowed]
        string TargetThirdPartyID();

        // +(void)targetSetThirdPartyID:(NSString * _Nullable)thirdPartyID;
        [Static, Export("targetSetThirdPartyID:")]
        void TargetSetThirdPartyID([NullAllowed] string thirdPartyID);

        // +(void)targetClearCookies;
        [Static, Export("targetClearCookies")]
        void TargetClearCookies();

        // +(NSString * _Nullable)targetPcID;
        [Static, Export("targetPcID")]
        [return: NullAllowed]
        string TargetPcID();

        // +(NSString * _Nonnull)targetSessionID;
        [Static, Export("targetSessionID")]
        string TargetSessionID();

        // +(NSDictionary * _Nullable)audienceVisitorProfile;
        [Static, Export("audienceVisitorProfile")]
        [return: NullAllowed]
        NSDictionary AudienceVisitorProfile();

        // +(NSString * _Nullable)audienceDpid;
        [Static, Export("audienceDpid")]
        [return: NullAllowed]
        string AudienceDpid();

        // +(NSString * _Nullable)audienceDpuuid;
        [Static, Export("audienceDpuuid")]
        [return: NullAllowed]
        string AudienceDpuuid();

        // +(void)audienceSetDpid:(NSString * _Nullable)dpid dpuuid:(NSString * _Nullable)dpuuid;
        [Static, Export("audienceSetDpid:dpuuid:")]
        void AudienceSetDpid([NullAllowed] string dpid, [NullAllowed] string dpuuid);

        // +(void)audienceSignalWithData:(NSDictionary * _Nullable)data callback:(void (^ _Nullable)(NSDictionary * _Nullable))callback;
        [Static, Export("audienceSignalWithData:callback:")]
        void AudienceSignal([NullAllowed] NSDictionary data, [NullAllowed] Action<NSDictionary> callback);

        // +(void)audienceReset;
        [Static, Export("audienceReset")]
        void AudienceReset();

        // +(NSString * _Nullable)visitorMarketingCloudID;
        [Static, Export("visitorMarketingCloudID")]
        [return: NullAllowed]
        string VisitorMarketingCloudID();

        // +(void)visitorSyncIdentifiers:(NSDictionary * _Nullable)identifiers;
        [Static, Export("visitorSyncIdentifiers:")]
        void VisitorSyncIdentifiers([NullAllowed] NSDictionary identifiers);

        // +(void)visitorSyncIdentifiers:(NSDictionary * _Nullable)identifiers authenticationState:(ADBMobileVisitorAuthenticationState)authState;
        [Static, Export("visitorSyncIdentifiers:authenticationState:")]
        void VisitorSyncIdentifiers([NullAllowed] NSDictionary identifiers, ADBMobileVisitorAuthenticationState authState);

        // +(void)visitorSyncIdentifierWithType:(NSString * _Nullable)identifierType identifier:(NSString * _Nullable)identifier authenticationState:(ADBMobileVisitorAuthenticationState)authState;
        [Static, Export("visitorSyncIdentifierWithType:identifier:authenticationState:")]
        void VisitorSyncIdentifier([NullAllowed] string identifierType, [NullAllowed] string identifier, ADBMobileVisitorAuthenticationState authState);

        // +(NSArray * _Nullable)visitorGetIDs;
        [Static, Export("visitorGetIDs")]
        [return: NullAllowed]
        ADBVisitorID[] VisitorGetIDs();

        // +(void)collectPII:(NSDictionary<NSString *,NSString *> * _Nullable)data;
        [Static, Export("collectPII:")]
        void CollectPII([NullAllowed] NSDictionary<NSString, NSString> data);
    }

    // @interface ADBVisitorID : NSObject
    [BaseType(typeof(NSObject))]
    interface ADBVisitorID
    {
        // -(NSString * _Nullable)idType;
        [NullAllowed, Export("idType")]
        string IdType { get; }

        // -(NSString * _Nullable)identifier;
        [NullAllowed, Export("identifier")]
        string Identifier { get; }

        // -(ADBMobileVisitorAuthenticationState)authenticationState;
        [Export("authenticationState")]
        ADBMobileVisitorAuthenticationState AuthenticationState { get; }
    }

    // @interface ADBTargetLocationRequest : NSObject
    [BaseType(typeof(NSObject))]
    interface ADBTargetLocationRequest
    {
        // @property (nonatomic, strong) NSString * _Nullable name;
        [NullAllowed, Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable defaultContent;
        [NullAllowed, Export("defaultContent", ArgumentSemantic.Strong)]
        string DefaultContent { get; set; }

        // @property (nonatomic, strong) NSMutableDictionary * _Nullable parameters;
        [NullAllowed, Export("parameters", ArgumentSemantic.Strong)]
        NSMutableDictionary Parameters { get; set; }
    }

    // @interface ADBMediaSettings : NSObject
    [BaseType(typeof(NSObject))]
    interface ADBMediaSettings
    {
        // @property (readwrite) _Bool segmentByMilestones;
        [Export("segmentByMilestones")]
        bool SegmentByMilestones { get; set; }

        // @property (readwrite) _Bool segmentByOffsetMilestones;
        [Export("segmentByOffsetMilestones")]
        bool SegmentByOffsetMilestones { get; set; }

        // @property (readwrite) double length;
        [Export("length")]
        double Length { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable channel;
        [NullAllowed, Export("channel", ArgumentSemantic.Strong)]
        string Channel { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable name;
        [NullAllowed, Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable playerName;
        [NullAllowed, Export("playerName", ArgumentSemantic.Strong)]
        string PlayerName { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable playerID;
        [NullAllowed, Export("playerID", ArgumentSemantic.Strong)]
        string PlayerID { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable milestones;
        [NullAllowed, Export("milestones", ArgumentSemantic.Strong)]
        string Milestones { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable offsetMilestones;
        [NullAllowed, Export("offsetMilestones", ArgumentSemantic.Strong)]
        string OffsetMilestones { get; set; }

        // @property (nonatomic) NSUInteger trackSeconds;
        [Export("trackSeconds")]
        nuint TrackSeconds { get; set; }

        // @property (nonatomic) NSUInteger completeCloseOffsetThreshold;
        [Export("completeCloseOffsetThreshold")]
        nuint CompleteCloseOffsetThreshold { get; set; }

        // @property (readwrite) _Bool isMediaAd;
        [Export("isMediaAd")]
        bool IsMediaAd { get; set; }

        // @property (readwrite) double parentPodPosition;
        [Export("parentPodPosition")]
        double ParentPodPosition { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable CPM;
        [NullAllowed, Export("CPM", ArgumentSemantic.Strong)]
        string CPM { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable parentName;
        [NullAllowed, Export("parentName", ArgumentSemantic.Strong)]
        string ParentName { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable parentPod;
        [NullAllowed, Export("parentPod", ArgumentSemantic.Strong)]
        string ParentPod { get; set; }
    }

    // @interface ADBMediaState : NSObject
    [BaseType(typeof(NSObject))]
    interface ADBMediaState
    {
        // @property (readwrite) BOOL ad;
        [Export("ad")]
        bool Ad { get; set; }

        // @property (readwrite) BOOL clicked;
        [Export("clicked")]
        bool Clicked { get; set; }

        // @property (readwrite) BOOL complete;
        [Export("complete")]
        bool Complete { get; set; }

        // @property (readwrite) BOOL eventFirstTime;
        [Export("eventFirstTime")]
        bool EventFirstTime { get; set; }

        // @property (readwrite) double length;
        [Export("length")]
        double Length { get; set; }

        // @property (readwrite) double offset;
        [Export("offset")]
        double Offset { get; set; }

        // @property (readwrite) double percent;
        [Export("percent")]
        double Percent { get; set; }

        // @property (readwrite) double segmentLength;
        [Export("segmentLength")]
        double SegmentLength { get; set; }

        // @property (readwrite) double timePlayed;
        [Export("timePlayed")]
        double TimePlayed { get; set; }

        // @property (readwrite) double timePlayedSinceTrack;
        [Export("timePlayedSinceTrack")]
        double TimePlayedSinceTrack { get; set; }

        // @property (readwrite) double timestamp;
        [Export("timestamp")]
        double Timestamp { get; set; }

        // @property (readwrite, copy) NSDate * _Nullable openTime;
        [NullAllowed, Export("openTime", ArgumentSemantic.Copy)]
        NSDate OpenTime { get; set; }

        // @property (readwrite, copy) NSString * _Nullable name;
        [NullAllowed, Export("name")]
        string Name { get; set; }

        // @property (readwrite, copy) NSString * _Nullable playerName;
        [NullAllowed, Export("playerName")]
        string PlayerName { get; set; }

        // @property (readwrite, copy) NSString * _Nullable mediaEvent;
        [NullAllowed, Export("mediaEvent")]
        string MediaEvent { get; set; }

        // @property (readwrite, copy) NSString * _Nullable segment;
        [NullAllowed, Export("segment")]
        string Segment { get; set; }

        // @property (readwrite) NSUInteger milestone;
        [Export("milestone")]
        nuint Milestone { get; set; }

        // @property (readwrite) NSUInteger offsetMilestone;
        [Export("offsetMilestone")]
        nuint OffsetMilestone { get; set; }

        // @property (readwrite) NSUInteger segmentNum;
        [Export("segmentNum")]
        nuint SegmentNum { get; set; }

        // @property (readwrite) NSUInteger eventType;
        [Export("eventType")]
        nuint EventType { get; set; }
    }
}
