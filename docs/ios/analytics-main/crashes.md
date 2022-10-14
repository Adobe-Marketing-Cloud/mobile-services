# Track app crashes

This information helps you understand how crashes are tracked and the best practices to handle false crashes.

> **Important:** You should upgrade to iOS SDK version 4.8.6, which contains critical changes that prevent false crashes from being reported.

## When does Adobe report a crash?

If your application is terminated without having first been backgrounded, the SDK reports a crash the next time your app is launched.

## How does crash reporting work?

iOS uses system notifications that allow developers to track and respond to different states and events in the application lifecycle.

The AdobeMobile iOS SDK has a notification handler that responds to the `UIApplicationDidEnterBackgroundNotification` notification. In this code, a value is set that indicates that the user has backgrounded the app. On a subsequent launch, if that value cannot be found, a crash is reported.

## Why does Adobe measure crashes this way?

This approach of measuring crashes provides a high-level answer to the question, *Did the user exit my app intentionally?*

Crash reporting libraries provided by companies like Apteligent (formerly Crittercism) use a global `NSException` handler to provide more detailed crash reporting. Your app is not allowed to have more than one of these kind of handlers. Adobe decided to not implement a global `NSException` handler to prevent build errors, knowing that our customers might be using other crash reporting providers.

## What can cause a false crash to be reported?

The following scenarios are known to falsely cause a crash to be reported by the SDK:

* If you are debugging using Xcode, launching the app again while it is in the foreground, causes a crash.

   > **Tip:** You can avoid a crash in this scenario by backgrounding the app before launching the app again from Xcode.

* If your app is in the background and sends Analytics hits through a call other than `trackActionFromBackground`, `trackLocation`, or `trackBeacon`, and the app is terminated (manually or by the OS) while in the background, and the next launch will be a crash.

   > **Tip:** Background activity that occurs beyond the `lifecycleTimeout` threshold might also result in an additional false launch.

* If your app is launched in the background because of a background fetch, location update, and so on, and is terminated by the OS without coming to the foreground, the next launch (background or foreground) results in a crash. 
* If you programmatically delete Adobe’s pause flag from `NSUserDefaults`, while the app is in the background, the next launch or resume causes a crash.

## How can I prevent false crashes from being reported?

The following practices can help you prevent false crashes from being reported:

* In iOS SDK 4.8.6, code was added to better determine whether a new lifecycle session is actually wanted.

  This code fixes false crashes #2 and #3 in the previous section. 

* Ensure that you perform your development against non-production report suites, which should prevent false crash #1 from occurring. 
* Do not delete or modify any values that the AdobeMobile SDK puts in `NSUserDefaults`.

  If these values are modified outside the SDK, the reported data will be invalid.
