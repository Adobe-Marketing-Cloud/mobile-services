===================================
== appleWatchExample Application ==
===================================
The appleWatchExample application is being provided by Adobe to demonstrate how to track your Apple Watch applications using the Adobe Marketing Cloud SDK.  This tutorial assumes that you have an Apple ID that is a linked to a paid iOS Developer Program account, that your user is an Admin user for that account, and that your AppleID is linked in Xcode.


## Build Requirements ##
- Xcode 6.3 or newer
- iOS 8.2 SDK or newer
- App Groups–enabled provisioning profile


## Getting Started ##
Because this app supports App Groups, the appleWatchExample Xcode project requires a small amount of setup before it can be built and run. It also requires a paid iOS Developer Program account.  Please complete the following steps to properly set the bundle identifier and set up your app groups:

- Change the bundle identifier
	1.  In the Xcode Project Navigator window, select the "appleWatchExample" project
	2.  Select the Target named "appleWatchExample"
	3.  Select the General tab
	4.  In the Identity section, change the Bundle Identifier to use the reverse DNS string for your company
		- e.g. change "com.adobe.appleWatchExample" to "com.mycompany.appleWatchExample", where "mycompany" is your company name
	5.  In the Identity section, select your team from the "Team" dropdown
		- If you do not have a team to select, click "Add an Account..." in the dropdown and follow its instructions
	6.  If you get an alert below the "Team" dropdown indicating that there are no matching provisioning profiles found, please click the "Fix Issue" button
	7.  Select the Target named "appleWatchExample WatchKit Extension" and repeat steps 3-6
	8.  Select the Target named "appleWatchExample WatchKit App" and repeat steps 3-6
	9.  In the Xcode Project Navigator window, select appleWatchExample > appleWatchExample WatchKit Extension > Supporting Files > Info.plist
	10. Change the property in Information Property List > NSExtension > NSExtensionAttributes > WKAppBundleIdentifier to "com.mycompany.appleWatchExample.watchkitapp", where "mycompany" is your company name
	11. In the Xcode Project Navigator window, select appleWatchExample > appleWatchExample WatchKit App > Supporting Files > Info.plist
	12. Change the property in Information Property List > WKCompanionAppBundleIdentifier to "com.mycompany.appleWatchExample", where "mycompany" is your company name
	
- Add app groups
	1.  In the Xcode Project Navigator window, select the "appleWatchExample" project
	2.  Select the Target named "appleWatchExample"
	3.  Select the Capabilities tab
	4.  Under the App Groups section, click the "+" button and add a new App Group named "group.mycompany.appleWatchExample" (or select it if it is already created), where "mycompany" is your company name
		- The new group should appear in the list and be selected by default
	5.  Press the "Fix Issue" button if necessary
	6.  Select the Target named "appleWatchExample WatchKit Extension" and repeat steps 3-5
	
- Set new app groups in your source files
	1.  Select appleWatchExample > appleWatchExample > AppDelegate.m
	2.  Edit the line [ADBMobile setAppGroup:@"group.adb.appleWatchExample"]; to use the app group name you created above
	3.  Select appleWatchExample > appleWatchExample WatchKit Extension > InterfaceController.m
	4.  Edit the line [ADBMobile setAppGroup:@"group.adb.appleWatchExample"]; to use the app group name you created above

## Building the App ##
In order for the ADBMobile SDK to run properly in the watch app, the containing app must first be launched.  Ensure that the "appleWatchExample" scheme is selected, and run the project.  To run the watch app, select the "appleWatchExample WatchKit App" and run the project.  

** Note that to get the Apple Watch Simulator running you need to manually open it from the iOS Simulator app via Hardware > External Displays > Apple Watch - 42 mm

By default, the ADBMobileConfig.json file is set to send hits to "localhost:50000".  You will be able to see hits from both the containing app and the watch app in Bloodhound.