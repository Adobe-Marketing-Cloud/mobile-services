
>>>>>  4.6.0 UPDATE  <<<<<

==========================================
Apple Watch Implementation with WatchOS 2
==========================================

Starting with WatchOS 2, your WatchKit Extensions will run on Apple Watch device.  Applications running in this environment require using the WatchConnectivity framework to share data with their containing iOS app.  Beginning with AdobeMobileLibrary v4.6.0, support for WatchConnectivity is available.

++++ Getting Started ++++

The following steps are to be performed in your Xcode project.  This guide is written assuming your project has at least three (3) targets; one target is the containing app, one target is the WatchKit App, and the last is the WatchKit Extension.  For more information on developing WatchKit Apps, please go to https://developer.apple.com/library/ios/documentation/General/Conceptual/WatchKitProgrammingGuide/DesigningaWatchKitApp.html#//apple_ref/doc/uid/TP40014969-CH3-SW1


** Configuring the Containing App **

1. Drag the folder named “AdobeMobileLibrary” into your project
2. Ensure that ADBMobileConfig.json is a member of the Containing App’s target
3. In the Build Phases tab of your Containing App’s target, expand the “Link Binary with Libraries” section and add the following libraries:
   - AdobeMobileLibrary.a
   - libsqlite3.tbd
   - SystemConfiguration.framework
4. In your class that implements the UIApplicationDelegate protocol, add the WCSessionDelegate protocol
	#import <WatchConnectivity/WatchConnectivity.h>
	@interface AppDelegate : UIResponder <UIApplicationDelegate, WCSessionDelegate>
5. In the implementation file of your app delegate class, import the AdobeMobileLibrary.
	#import “ADBMobile.h”
6. In application:didFinishLaunchingWithOptions: of your app delegate, configure your WCSession BEFORE making any calls to the ADBMobile library
	
	// check for session availability
	if ([WCSession isSupported]) {
		WCSession *session = [WCSession defaultSession];	
		session.delegate = self;
		[session activateSession];
	}	

7. In your app delegate, implement the session:didReceiveMessage: and session:didReceiveUserInfo: methods.  In these methods, we will call syncSettings: in the ADBMobile library, which returns a bool indicating if the dictionary was meant for consumption by the ADBMobile library.  If it returns NO, the message was not initiated from the Adobe SDK.
	
	- (void) session:(WCSession *)session didReceiveMessage:(NSDictionary<NSString *,id> *)message {
		// pass message to ADBMobile
		if (![ADBMobile syncSettings:message]) {
			// handle your own custom messages
		}
	}

	- (void) session:(WCSession *)session didReceiveUserInfo:(NSDictionary<NSString *,id> *)userInfo {
		// pass userInfo to ADBMobile
		if (![ADBMobile syncSettings:userInfo]) {
			// handle your own custom messages
		}
	}


** Configuring the WatchKit Extension **

1. Ensure that ADBMobileConfig.json is a member of you WatchKit Extension’s target
2. In the Build Phases tab of your WatchKit Extension’s target, expand the “Link Binary with Libraries” section and add the following libraries:
   - AdobeMobileLibrary_Watch.a
   - libsqlite3.tbd
3. In your class that implements the WKExtensionDelegate protocol, import WatchConnectivity and add the WCSessionDelegate protocol
	#import <WatchConnectivity/WatchConnectivity.h>
	@interface ExtensionDelegate : NSObject <WKExtensionDelegate, WCSessionDelegate>
4. In the implementation file of your extension delegate class, import the AdobeMobileLibrary.
	#import “ADBMobile.h”
5. In applicationDidFinishLaunching of your extension delegate, configure your WCSession BEFORE making any calls to the ADBMobile library
	
	// check for session availability
	if ([WCSession isSupported]) {
		WCSession *session = [WCSession defaultSession];	
		session.delegate = self;
		[session activateSession];
	}	

6. In applicationDidFinishLaunching of your extension delegate, initialize the watch app for the SDK
	
	[ADBMobile initializeWatch];

7. In your extension delegate, implement the session:didReceiveMessage: and session:didReceiveUserInfo: methods.  In these methods, we will call syncSettings: in the ADBMobile library, which returns a bool indicating if the dictionary was meant for consumption by the ADBMobile library.  If it returns NO, the message was not initiated from the Adobe SDK.
	
	- (void) session:(WCSession *)session didReceiveMessage:(NSDictionary<NSString *,id> *)message {
		// pass message to ADBMobile
		if (![ADBMobile syncSettings:message]) {
			// handle your own custom messages
		}
	}

	- (void) session:(WCSession *)session didReceiveUserInfo:(NSDictionary<NSString *,id> *)userInfo {
		// pass userInfo to ADBMobile
		if (![ADBMobile syncSettings:userInfo]) {
			// handle your own custom messages
		}
	}



==========================================
iOS Extensions Implementation
==========================================

Starting in iOS SDK version 4.5.0, extension are supported.  This allows you to collect usage data from your Apple Watch Apps, Today Widgets, Photo Editing widgets, and all the other iOS extension apps.

++++ Getting Started ++++

The following steps are to be performed in your Xcode project.  This guide is written assuming you have a project with at least two (2) targets in it; one for the containing app, and one for the extension. (Note, if you are working on a WatchKit App, you should have a third target for it)  For more information on developing for Apple Watch, please go to https://developer.apple.com/library/ios/documentation/General/Conceptual/WatchKitProgrammingGuide/index.html#//apple_ref/doc/uid/TP40014969-CH8-SW1.

** Configuring the Containing App **
1. Drag the folder named "AdobeMobileLibrary" into your project
2. Ensure that ADBMobileConfig.json it is a member of the Containing App's target
3. In the Build Phases tab of your Containing App's target, expand the Link Binary with Libraries section and add the following libraries:
   - AdobeMobileLibrary.a
   - libsqlite3.dylib
   - SystemConfiguration.framework
4. Open the Capabilities tab of the Containing App's target, turn on the "App Groups" capability, and add a new App Group (e.g. - group.com.adobe.testApp)
5. In your application delegate, set the App Group in application:didFinishLaunchingWithOptions before making any other interactions with the Adobe Mobile library:
   - [ADBMobile setAppGroup:@"group.com.adobe.testApp"];
6. Confirm that your app builds without unexpected errors


** Configuring the Extension **
1. Ensure that ADBMobileConfig.json it is a member of the Extension's target
2. In the Build Phases tab of your Extension’s target, expand the Link Binary with Libraries section and add the following libraries:
   - AdobeMobileLibrary_Extension.a 
   - libsqlite3.dylib
   - SystemConfiguration.framework
3. Open the Capabilities tab of the Extension's target, turn on the "App Groups" capability, and select the App Group you added in step 4 of "Configuring the Containing App"
4. In your InterfaceController, set the App Group in awakeWithContext: before making any other interactions with the Adobe Mobile library:
   - [ADBMobile setAppGroup:@"group.com.adobe.testApp"];
5. Confirm that your app builds without unexpected errors.


Once you have configured your targets, you can use the SDK as normal.  For full documentation on how to use the iOS 4.x SDK, please visit https://marketing.adobe.com/resources/help/en_US/mobile/ios/


++++ Additional Notes ++++

1. There is an additional context data value, "a.RunMode", added to indicate whether the data comes from your Containing App or your Extension.
   - a.RunMode = Application (the hit came from the Containing App)
   - a.RunMode = Extension (the hit came from the Extension)
2. If you upgrade from a old version of SDK, we will automatically migrate all the user defaults and cached files from the Containing App's folder to the App Group's shared folder when the containing app first get launched
3. Hits from the Extension will be discarded if the containing app has never been launched
4. The Version number and Build number must be the same between your Containing App and any Extension App
5. Currently, for Apple Watch apps, all of your project's targets must have "iOS Deployment Target" equal to iOS 8.2
