using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreLocation;

namespace Com.Adobe.Mobile {

	// @interface ADBMobile : NSObject
	[BaseType (typeof (NSObject))]
	interface ADBMobile {

		// +(NSString *)version;
		[Static, Export ("version")]
		string Version ();

		// +(ADBMobilePrivacyStatus)privacyStatus;
		[Static, Export ("privacyStatus")]
		ADBMobilePrivacyStatus PrivacyStatus ();

		// +(void)setPrivacyStatus:(ADBMobilePrivacyStatus)status;
		[Static, Export ("setPrivacyStatus:")]
		void SetPrivacyStatus (ADBMobilePrivacyStatus status);

		// +(NSDecimalNumber *)lifetimeValue;
		[Static, Export ("lifetimeValue")]
		NSDecimalNumber LifetimeValue ();

		// +(NSString *)userIdentifier;
		[Static, Export ("userIdentifier")]
		string UserIdentifier ();

		// +(void)setUserIdentifier:(NSString *)identifier;
		[Static, Export ("setUserIdentifier:")]
		void SetUserIdentifier ([NullAllowed] string identifier);

		// +(BOOL)debugLogging;
		[Static, Export ("debugLogging")]
		bool DebugLogging ();

		// +(void)setDebugLogging:(BOOL)debug;
		[Static, Export ("setDebugLogging:")]
		void SetDebugLogging (bool debug);

		// +(void)keepLifecycleSessionAlive;
		[Static, Export ("keepLifecycleSessionAlive")]
		void KeepLifecycleSessionAlive ();

		// +(void)collectLifecycleDataWithAdditionalData:(NSDictionary *)data;
		[Static, Export ("collectLifecycleDataWithAdditionalData:")]
		void collectLifecycleDataWithAdditionalData ([NullAllowed] NSDictionary data);

		// +(void)collectLifecycleData;
		[Static, Export ("collectLifecycleData")]
		void CollectLifecycleData ();

		// +(void)overrideConfigPath:(NSString *)path;
		[Static, Export ("overrideConfigPath:")]
		void OverrideConfigPath ([NullAllowed] string path);

		// +(void)trackState:(NSString *)state data:(NSDictionary *)data;
		[Static, Export ("trackState:data:")]
		void TrackState ([NullAllowed] string state,[NullAllowed] NSDictionary data);

		// +(void)trackAction:(NSString *)action data:(NSDictionary *)data;
		[Static, Export ("trackAction:data:")]
		void TrackAction ([NullAllowed] string action, [NullAllowed] NSDictionary data);

		// +(void)trackActionFromBackground:(NSString *)action data:(NSDictionary *)data;
		[Static, Export ("trackActionFromBackground:data:")]
		void TrackActionFromBackground ([NullAllowed] string action, [NullAllowed] NSDictionary data);

		// +(void)trackLocation:(CLLocation *)location data:(NSDictionary *)data;
		[Static, Export ("trackLocation:data:")]
		void TrackLocation ([NullAllowed] CLLocation location, [NullAllowed] NSDictionary data);

		// +(void)trackBeacon:(CLBeacon *)beacon data:(NSDictionary *)data;
		[Static, Export ("trackBeacon:data:")]
		void TrackBeacon ([NullAllowed] CLBeacon beacon, [NullAllowed] NSDictionary data);

		// +(void)trackingClearCurrentBeacon;
		[Static, Export ("trackingClearCurrentBeacon")]
		void TrackingClearCurrentBeacon ();

		// +(void)trackLifetimeValueIncrease:(NSDecimalNumber *)amount data:(NSDictionary *)data;
		[Static, Export ("trackLifetimeValueIncrease:data:")]
		void TrackLifetimeValueIncrease (NSDecimalNumber amount, [NullAllowed] NSDictionary data);

		// +(void)trackTimedActionStart:(NSString *)action data:(NSDictionary *)data;
		[Static, Export ("trackTimedActionStart:data:")]
		void TrackTimedActionStart ([NullAllowed] string action, [NullAllowed] NSDictionary data);

		// +(void)trackTimedActionUpdate:(NSString *)action data:(NSDictionary *)data;
		[Static, Export ("trackTimedActionUpdate:data:")]
		void TrackTimedActionUpdate ([NullAllowed] string action, [NullAllowed] NSDictionary data);

		// +(void)trackTimedActionEnd:(NSString *)action logic:(BOOL (^)(NSTimeInterval, NSTimeInterval, NSMutableDictionary *))block;
		[Static, Export ("trackTimedActionEnd:logic:")]
		void TrackTimedActionEnd ([NullAllowed] string action, [NullAllowed] Func<double, double, NSMutableDictionary, bool> block);

		// +(BOOL)trackingTimedActionExists:(NSString *)action;
		[Static, Export ("trackingTimedActionExists:")]
		bool TrackingTimedActionExists ([NullAllowed] string action);

		// +(NSString *)trackingIdentifier;
		[Static, Export ("trackingIdentifier")]
		string TrackingIdentifier ();

		// +(void)trackingSendQueuedHits;
		[Static, Export ("trackingSendQueuedHits")]
		void TrackingSendQueuedHits ();

		// +(void)trackingClearQueue;
		[Static, Export ("trackingClearQueue")]
		void TrackingClearQueue ();

		// +(NSUInteger)trackingGetQueueSize;
		[Static, Export ("trackingGetQueueSize")]
		nuint TrackingGetQueueSize ();

		// +(ADBMediaSettings *)mediaCreateSettingsWithName:(NSString *)name length:(double)length playerName:(NSString *)playerName playerID:(NSString *)playerID;
		[Static, Export ("mediaCreateSettingsWithName:length:playerName:playerID:")]
		ADBMediaSettings MediaCreateSettings ([NullAllowed] string name, [NullAllowed] double length, [NullAllowed] string playerName, [NullAllowed] string playerID);

		// +(ADBMediaSettings *)mediaAdCreateSettingsWithName:(NSString *)name length:(double)length playerName:(NSString *)playerName parentName:(NSString *)parentName parentPod:(NSString *)parentPod parentPodPosition:(double)parentPodPosition CPM:(NSString *)CPM;
		[Static, Export ("mediaAdCreateSettingsWithName:length:playerName:parentName:parentPod:parentPodPosition:CPM:")]
		ADBMediaSettings MediaAdCreateSettings ([NullAllowed] string name, [NullAllowed] double length, [NullAllowed] string playerName, [NullAllowed] string parentName, [NullAllowed] string parentPod, [NullAllowed] double parentPodPosition, [NullAllowed] string CPM);

		// +(void)mediaOpenWithSettings:(ADBMediaSettings *)settings callback:(void (^)(ADBMediaState *))callback;
		[Static, Export ("mediaOpenWithSettings:callback:")]
		void MediaOpenWithSettings ([NullAllowed] ADBMediaSettings settings, [NullAllowed] Action<ADBMediaState> callback);

		// +(void)mediaClose:(NSString *)name;
		[Static, Export ("mediaClose:")]
		void MediaClose ([NullAllowed] string name);

		// +(void)mediaPlay:(NSString *)name offset:(double)offset;
		[Static, Export ("mediaPlay:offset:")]
		void MediaPlay ([NullAllowed] string name, double offset);

		// +(void)mediaComplete:(NSString *)name offset:(double)offset;
		[Static, Export ("mediaComplete:offset:")]
		void MediaComplete ([NullAllowed] string name, double offset);

		// +(void)mediaStop:(NSString *)name offset:(double)offset;
		[Static, Export ("mediaStop:offset:")]
		void MediaStop ([NullAllowed] string name, double offset);

		// +(void)mediaClick:(NSString *)name offset:(double)offset;
		[Static, Export ("mediaClick:offset:")]
		void MediaClick ([NullAllowed] string name, double offset);

		// +(void)mediaTrack:(NSString *)name data:(NSDictionary *)data;
		[Static, Export ("mediaTrack:data:")]
		void MediaTrack ([NullAllowed] string name, [NullAllowed] NSDictionary data);

		// +(void)targetLoadRequest:(ADBTargetLocationRequest *)request callback:(void (^)(NSString *))callback;
		[Static, Export ("targetLoadRequest:callback:")]
		void TargetLoadRequest ([NullAllowed] ADBTargetLocationRequest request, [NullAllowed] Action<NSString> callback);

		// +(ADBTargetLocationRequest *)targetCreateRequestWithName:(NSString *)name defaultContent:(NSString *)defaultContent parameters:(NSDictionary *)parameters;
		[Static, Export ("targetCreateRequestWithName:defaultContent:parameters:")]
		ADBTargetLocationRequest TargetCreateRequest ([NullAllowed] string name, [NullAllowed] string defaultContent, [NullAllowed] NSDictionary parameters);

		// +(ADBTargetLocationRequest *)targetCreateOrderConfirmRequestWithName:(NSString *)name orderId:(NSString *)orderId orderTotal:(NSString *)orderTotal productPurchasedId:(NSString *)productPurchasedId parameters:(NSDictionary *)parameters;
		[Static, Export ("targetCreateOrderConfirmRequestWithName:orderId:orderTotal:productPurchasedId:parameters:")]
		ADBTargetLocationRequest TargetCreateOrderConfirmRequest ([NullAllowed] string name, [NullAllowed] string orderId, [NullAllowed] string orderTotal, [NullAllowed] string productPurchasedId, [NullAllowed] NSDictionary parameters);

		// +(void)targetClearCookies;
		[Static, Export ("targetClearCookies")]
		void TargetClearCookies ();

		// +(NSDictionary *)audienceVisitorProfile;
		[Static, Export ("audienceVisitorProfile")]
		NSDictionary AudienceVisitorProfile ();

		// +(NSString *)audienceDpid;
		[Static, Export ("audienceDpid")]
		string AudienceDpid ();

		// +(NSString *)audienceDpuuid;
		[Static, Export ("audienceDpuuid")]
		string AudienceDpuuid ();

		// +(void)audienceSetDpid:(NSString *)dpid dpuuid:(NSString *)dpuuid;
		[Static, Export ("audienceSetDpid:dpuuid:")]
		void AudienceSetDpidAndDpuuid ([NullAllowed] string dpid, [NullAllowed] string dpuuid);

		// +(void)audienceSignalWithData:(NSDictionary *)data callback:(void (^)(NSDictionary *))callback;
		[Static, Export ("audienceSignalWithData:callback:")]
		void AudienceSignalWithData ([NullAllowed] NSDictionary data, [NullAllowed] Action<NSDictionary> callback);

		// +(void)audienceReset;
		[Static, Export ("audienceReset")]
		void AudienceReset ();

		// +(NSString *)visitorMarketingCloudID;
		[Static, Export ("visitorMarketingCloudID")]
		string VisitorMarketingCloudID ();

		// +(void)visitorSyncIdentifiers:(NSDictionary *)identifiers;
		[Static, Export ("visitorSyncIdentifiers:")]
		void VisitorSyncIdentifiers ([NullAllowed] NSDictionary identifiers);
	}

	// @interface ADBTargetLocationRequest : NSObject
	[BaseType (typeof (NSObject))]
	interface ADBTargetLocationRequest {

		// @property (nonatomic, strong) NSString * name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; set; }

		// @property (nonatomic, strong) NSString * defaultContent;
		[Export ("defaultContent", ArgumentSemantic.Retain)]
		string DefaultContent { get; set; }

		// @property (nonatomic, strong) NSMutableDictionary * parameters;
		[Export ("parameters", ArgumentSemantic.Retain)]
		NSMutableDictionary Parameters { get; set; }
	}

	// @interface ADBMediaSettings : NSObject
	[BaseType (typeof (NSObject))]
	interface ADBMediaSettings {

		// @property (readwrite) _Bool segmentByMilestones;
		[Export ("segmentByMilestones")]
		bool SegmentByMilestones { get; set; }

		// @property (readwrite) _Bool segmentByOffsetMilestones;
		[Export ("segmentByOffsetMilestones")]
		bool SegmentByOffsetMilestones { get; set; }

		// @property (readwrite) double length;
		[Export ("length")]
		double Length { get; set; }

		// @property (nonatomic, strong) NSString * channel;
		[Export ("channel", ArgumentSemantic.Retain)]
		string Channel { get; set; }

		// @property (nonatomic, strong) NSString * name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; set; }

		// @property (nonatomic, strong) NSString * playerName;
		[Export ("playerName", ArgumentSemantic.Retain)]
		string PlayerName { get; set; }

		// @property (nonatomic, strong) NSString * playerID;
		[Export ("playerID", ArgumentSemantic.Retain)]
		string PlayerID { get; set; }

		// @property (nonatomic, strong) NSString * milestones;
		[Export ("milestones", ArgumentSemantic.Retain)]
		string Milestones { get; set; }

		// @property (nonatomic, strong) NSString * offsetMilestones;
		[Export ("offsetMilestones", ArgumentSemantic.Retain)]
		string OffsetMilestones { get; set; }

		// @property (nonatomic) NSUInteger trackSeconds;
		[Export ("trackSeconds")]
		nuint TrackSeconds { get; set; }

		// @property (nonatomic) NSUInteger completeCloseOffsetThreshold;
		[Export ("completeCloseOffsetThreshold")]
		nuint CompleteCloseOffsetThreshold { get; set; }

		// @property (readwrite) _Bool isMediaAd;
		[Export ("isMediaAd")]
		bool IsMediaAd { get; set; }

		// @property (readwrite) double parentPodPosition;
		[Export ("parentPodPosition")]
		double ParentPodPosition { get; set; }

		// @property (nonatomic, strong) NSString * CPM;
		[Export ("CPM", ArgumentSemantic.Retain)]
		string CPM { get; set; }

		// @property (nonatomic, strong) NSString * parentName;
		[Export ("parentName", ArgumentSemantic.Retain)]
		string ParentName { get; set; }

		// @property (nonatomic, strong) NSString * parentPod;
		[Export ("parentPod", ArgumentSemantic.Retain)]
		string ParentPod { get; set; }
	}

	// @interface ADBMediaState : NSObject
	[BaseType (typeof (NSObject))]
	interface ADBMediaState {

		// @property (readwrite) BOOL ad;
		[Export ("ad")]
		bool Ad { get; set; }

		// @property (readwrite) BOOL clicked;
		[Export ("clicked")]
		bool Clicked { get; set; }

		// @property (readwrite) BOOL complete;
		[Export ("complete")]
		bool Complete { get; set; }

		// @property (readwrite) BOOL eventFirstTime;
		[Export ("eventFirstTime")]
		bool EventFirstTime { get; set; }

		// @property (readwrite) double length;
		[Export ("length")]
		double Length { get; set; }

		// @property (readwrite) double offset;
		[Export ("offset")]
		double Offset { get; set; }

		// @property (readwrite) double percent;
		[Export ("percent")]
		double Percent { get; set; }

		// @property (readwrite) double segmentLength;
		[Export ("segmentLength")]
		double SegmentLength { get; set; }

		// @property (readwrite) double timePlayed;
		[Export ("timePlayed")]
		double TimePlayed { get; set; }

		// @property (readwrite) double timePlayedSinceTrack;
		[Export ("timePlayedSinceTrack")]
		double TimePlayedSinceTrack { get; set; }

		// @property (readwrite) double timestamp;
		[Export ("timestamp")]
		double Timestamp { get; set; }

		// @property (readwrite, copy) NSDate * openTime;
		[Export ("openTime", ArgumentSemantic.Copy)]
		NSDate OpenTime { get; set; }

		// @property (readwrite, copy) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// @property (readwrite, copy) NSString * playerName;
		[Export ("playerName")]
		string PlayerName { get; set; }

		// @property (readwrite, copy) NSString * mediaEvent;
		[Export ("mediaEvent")]
		string MediaEvent { get; set; }

		// @property (readwrite, copy) NSString * segment;
		[Export ("segment")]
		string Segment { get; set; }

		// @property (readwrite) NSUInteger milestone;
		[Export ("milestone")]
		nuint Milestone { get; set; }

		// @property (readwrite) NSUInteger offsetMilestone;
		[Export ("offsetMilestone")]
		nuint OffsetMilestone { get; set; }

		// @property (readwrite) NSUInteger segmentNum;
		[Export ("segmentNum")]
		nuint SegmentNum { get; set; }

		// @property (readwrite) NSUInteger eventType;
		[Export ("eventType")]
		nuint EventType { get; set; }
	}
}
