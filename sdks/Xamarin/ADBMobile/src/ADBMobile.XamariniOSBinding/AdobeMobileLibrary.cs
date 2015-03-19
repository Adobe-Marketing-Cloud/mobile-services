namespace AdobeMobileLibrary {

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
		void SetUserIdentifier (string identifier);

		// +(BOOL)debugLogging;
		[Static, Export ("debugLogging")]
		bool DebugLogging ();

		// +(void)setDebugLogging:(BOOL)debug;
		[Static, Export ("setDebugLogging:")]
		void SetDebugLogging (bool debug);

		// +(void)keepLifecycleSessionAlive;
		[Static, Export ("keepLifecycleSessionAlive")]
		void KeepLifecycleSessionAlive ();

		// +(void)collectLifecycleData;
		[Static, Export ("collectLifecycleData")]
		void CollectLifecycleData ();

		// +(void)overrideConfigPath:(NSString *)path;
		[Static, Export ("overrideConfigPath:")]
		void OverrideConfigPath (string path);

		// +(void)trackState:(NSString *)state data:(NSDictionary *)data;
		[Static, Export ("trackState:data:")]
		void TrackState (string state, NSDictionary data);

		// +(void)trackAction:(NSString *)action data:(NSDictionary *)data;
		[Static, Export ("trackAction:data:")]
		void TrackAction (string action, NSDictionary data);

		// +(void)trackActionFromBackground:(NSString *)action data:(NSDictionary *)data;
		[Static, Export ("trackActionFromBackground:data:")]
		void TrackActionFromBackground (string action, NSDictionary data);

		// +(void)trackLocation:(CLLocation *)location data:(NSDictionary *)data;
		[Static, Export ("trackLocation:data:")]
		void TrackLocation (CLLocation location, NSDictionary data);

		// +(void)trackBeacon:(CLBeacon *)beacon data:(NSDictionary *)data;
		[Static, Export ("trackBeacon:data:")]
		void TrackBeacon (CLBeacon beacon, NSDictionary data);

		// +(void)trackingClearCurrentBeacon;
		[Static, Export ("trackingClearCurrentBeacon")]
		void TrackingClearCurrentBeacon ();

		// +(void)trackLifetimeValueIncrease:(NSDecimalNumber *)amount data:(NSDictionary *)data;
		[Static, Export ("trackLifetimeValueIncrease:data:")]
		void TrackLifetimeValueIncrease (NSDecimalNumber amount, NSDictionary data);

		// +(void)trackTimedActionStart:(NSString *)action data:(NSDictionary *)data;
		[Static, Export ("trackTimedActionStart:data:")]
		void TrackTimedActionStart (string action, NSDictionary data);

		// +(void)trackTimedActionUpdate:(NSString *)action data:(NSDictionary *)data;
		[Static, Export ("trackTimedActionUpdate:data:")]
		void TrackTimedActionUpdate (string action, NSDictionary data);

		// +(void)trackTimedActionEnd:(NSString *)action logic:(BOOL (^)(NSTimeInterval, NSTimeInterval, NSMutableDictionary *))block;
		[Static, Export ("trackTimedActionEnd:logic:")]
		void TrackTimedActionEnd (string action, Func<double, double, NSMutableDictionary, sbyte> block);

		// +(BOOL)trackingTimedActionExists:(NSString *)action;
		[Static, Export ("trackingTimedActionExists:")]
		bool TrackingTimedActionExists (string action);

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
		ADBMediaSettings MediaCreateSettingsWithName (string name, double length, string playerName, string playerID);

		// +(ADBMediaSettings *)mediaAdCreateSettingsWithName:(NSString *)name length:(double)length playerName:(NSString *)playerName parentName:(NSString *)parentName parentPod:(NSString *)parentPod parentPodPosition:(double)parentPodPosition CPM:(NSString *)CPM;
		[Static, Export ("mediaAdCreateSettingsWithName:length:playerName:parentName:parentPod:parentPodPosition:CPM:")]
		ADBMediaSettings MediaAdCreateSettingsWithName (string name, double length, string playerName, string parentName, string parentPod, double parentPodPosition, string CPM);

		// +(void)mediaOpenWithSettings:(ADBMediaSettings *)settings callback:(void (^)(ADBMediaState *))callback;
		[Static, Export ("mediaOpenWithSettings:callback:")]
		void MediaOpenWithSettings (ADBMediaSettings settings, Action<ADBMediaState> callback);

		// +(void)mediaClose:(NSString *)name;
		[Static, Export ("mediaClose:")]
		void MediaClose (string name);

		// +(void)mediaPlay:(NSString *)name offset:(double)offset;
		[Static, Export ("mediaPlay:offset:")]
		void MediaPlay (string name, double offset);

		// +(void)mediaComplete:(NSString *)name offset:(double)offset;
		[Static, Export ("mediaComplete:offset:")]
		void MediaComplete (string name, double offset);

		// +(void)mediaStop:(NSString *)name offset:(double)offset;
		[Static, Export ("mediaStop:offset:")]
		void MediaStop (string name, double offset);

		// +(void)mediaClick:(NSString *)name offset:(double)offset;
		[Static, Export ("mediaClick:offset:")]
		void MediaClick (string name, double offset);

		// +(void)mediaTrack:(NSString *)name data:(NSDictionary *)data;
		[Static, Export ("mediaTrack:data:")]
		void MediaTrack (string name, NSDictionary data);

		// +(void)targetLoadRequest:(ADBTargetLocationRequest *)request callback:(void (^)(NSString *))callback;
		[Static, Export ("targetLoadRequest:callback:")]
		void TargetLoadRequest (ADBTargetLocationRequest request, Action<NSString> callback);

		// +(ADBTargetLocationRequest *)targetCreateRequestWithName:(NSString *)name defaultContent:(NSString *)defaultContent parameters:(NSDictionary *)parameters;
		[Static, Export ("targetCreateRequestWithName:defaultContent:parameters:")]
		ADBTargetLocationRequest TargetCreateRequestWithName (string name, string defaultContent, NSDictionary parameters);

		// +(ADBTargetLocationRequest *)targetCreateOrderConfirmRequestWithName:(NSString *)name orderId:(NSString *)orderId orderTotal:(NSString *)orderTotal productPurchasedId:(NSString *)productPurchasedId parameters:(NSDictionary *)parameters;
		[Static, Export ("targetCreateOrderConfirmRequestWithName:orderId:orderTotal:productPurchasedId:parameters:")]
		ADBTargetLocationRequest TargetCreateOrderConfirmRequestWithName (string name, string orderId, string orderTotal, string productPurchasedId, NSDictionary parameters);

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
		void AudienceSetDpid (string dpid, string dpuuid);

		// +(void)audienceSignalWithData:(NSDictionary *)data callback:(void (^)(NSDictionary *))callback;
		[Static, Export ("audienceSignalWithData:callback:")]
		void AudienceSignalWithData (NSDictionary data, Action<NSDictionary> callback);

		// +(void)audienceReset;
		[Static, Export ("audienceReset")]
		void AudienceReset ();

		// +(NSString *)visitorMarketingCloudID;
		[Static, Export ("visitorMarketingCloudID")]
		string VisitorMarketingCloudID ();

		// +(void)visitorSyncIdentifiers:(NSDictionary *)identifiers;
		[Static, Export ("visitorSyncIdentifiers:")]
		void VisitorSyncIdentifiers (NSDictionary identifiers);
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
