# Analytics

After you add the library to your project, you can make any of the Analytics method calls anywhere in your app.

> **Tip:** Ensure that you import `ADBMobile.h` to your class.

## Enable mobile application reports in Analytics

Before you add code, have your Analytics Administrator complete the following to enable Mobile App Lifecycle tracking. This ensures that your report suite is ready to capture metrics as you begin development.

1. Open **Admin Tools** > **Report Suites** and select your mobile report suite(s).
1. Click **Edit Settings** > **Mobile Management** > **Mobile Application Reporting**.

   ![Mobile settings](assets/mobile-settings.png)

1. Click **Enable Latest App Reports**.

   Optionally, you can also click **Enable Mobile Location Tracking** and **Enable Legacy Reporting and Attribution for background hits**.

   ![Enable lifecycle](assets/enable-lifecycle.png)

Lifecycle metrics are now ready to be captured, and Mobile Application Reports appear in the **Reports** menu in the marketing reports interface.

### New Versions

Periodically, new versions of mobile application reporting are released. New versions are not applied to your report suite automatically, you must repeat these steps to perform the upgrade. Each time you add new Experience Cloud functionality to your app, we recommend repeating these steps to ensure you have the latest configuration.

## Lifecycle metrics

To collect lifecycle metrics in your app, add calls to when the application is activated as shown in the following examples.

### WinJS in default.js

```js
app.onactivated = function (args) { 
  if (args.detail.kind === activation.ActivationKind.launch) { 
   ... 
   // launched and resumed stuff  
   ADBMobile.Config.collectLifecycleData(); 
  } 
}; 
app.oncheckpoint = function (args) { 
  ADBMobile.Config.pauseCollectingLifecycleData(); 
}
```

### C# in App.xaml.cs

```csharp
public App() 
{ 
    this.InitializeComponent(); 
    this.Resuming *= OnResuming; 
    this.Suspending *= OnSuspending; 
} 
protected override void OnLaunched(LaunchActivatedEventArgs e) 
{ 
    ... 
    ADBMobile.Config.CollectLifecycleData(); 
    ... 
} 
private void OnResuming(object sender, object e) 
{ 
    ... 
    ADBMobile.Config.CollectLifecycleData(); 
    ... 
} 
private void OnSuspending(object sender, SuspendingEventArgs e) 
{ 
    ... 
    ADBMobile.Config.PauseCollectingLifecycleData(); 
    ... 
}
```

### C/CX in App.xaml.cpp

```c
App::App() 
{ 
 InitializeComponent(); 
 Resuming *= ref new EventHandler<Object ^>(this, &App::OnResuming); 
 Suspending *= ref new SuspendingEventHandler(this, &App::OnSuspending); 
} 
void App::OnResuming(Object ^sender, Object ^args) 
{ 
 ... 
 ADBMobile::Config::CollectLifecycleData(); 
 ... 
} 
void App::OnSuspending(Object^ sender, SuspendingEventArgs^ e) 
{ 
 ... 
 ADBMobile::Config::PauseCollectingLifecycleData(); 
 ... 
} 
void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ e) 
{ 
 ... 
 ADBMobile::Config::CollectLifecycleData(); 
 ... 
}
```

If `CollectLifecycleData()` is called twice in the same session, then your application will report a crash on every call after the first. The SDK sets a flag when the application is shutdown that indicates a successful exit. If this flag is not set, `CollectLifecyleData()` reports a crash.

## Events, props, and eVars

If you've looked at the [ADBMobile Class and Method Reference](/docs/windows-appstore/c-configuration/methods.md), you are probably wondering where to set events, eVars, props, heirs, and lists. In version 4, you can no longer assign those types of variables directly in your app. Instead, the SDK uses context data and processing rules to map your app data to Analytics variables for reporting.

Processing rules provide you several advantages:

* You can change your data mapping without submitting an update to the App Store. 
* You can use meaningful names for data instead of setting variables that are specific to a report suite. 
* There is little impact to sending in extra data. These values won’t appear in reports until they are mapped using processing rules.

Any values that you were assigning directly to variables should be added to context data instead.

## Processing rules

Processing rules are used to copy the data you send in context data variables to eVars, props, and other variables for reporting.

[Processing rules overview](https://experienceleague.adobe.com/docs/analytics/admin/admin-tools/processing-rules/processing-rules.html)

Adobe recommends grouping your context data variables using "namespaces", as it helps you keep logical ordering. For example, if you want to collect info about a product, you might define the following variables:

```js
"product.type":"hat";
"product.team":"mariners";
"product.color":"blue";
```

Context data variables are sorted alphabetically in the processing rules interface, so namespaces let you quickly see variables that are in the same namespace.

Also, we have heard that some of you are naming context data keys using the eVar or prop number:

```js
"eVar1":"jimbo";
```

This might make it *slightly* easier when you perform the one time mapping in processing rules, but you lose readability during debugging and future code updates can be more difficult. Instead, we strongly recommend using descriptive names for keys and values:

```js
"username":"jimbo";
```

Set context variables that define counter events to a value of "1":

```js
"logon":"1";
```

Context data variables that define incrementor events can have the value to increment:

```js
"levels completed":"6";
```

> **Note:** Adobe reserves the namespace `a.`. Aside from that small restriction, context data variables just need to be unique in your login company to avoid collisions.

## Products variable

To set *`products`* in the mobile SDK, you must use a special syntax. See [Products Variable](/docs/windows-appstore/analytics/products/products.md).

## (Optional) Enable offline tracking

To store hits when the device is offline, you can enable offline tracking in the [ADBMobileConfig.json config](/docs/windows-appstore/c-configuration/methods.md). Before you enable offline tracking, Pay attention to the timestamp requirements described in the config file reference.

## Geo-location and points of interest

Geo-location lets you measure location data (latitude/longitude) and pre-defined points of interest. Each `TrackLocation` call sends:

* Latitude/Longitude, and POI (if within a POI defined in the `ADBMobileConfig.json` config file). These are passed to mobile solution variables for automatic reporting. 
* Distance from center & accuracy passed as context data. Capture using a processing rule.

To track a location:

```js
var ADB = ADBMobile; 
ADB.Analytics.trackLocation(37.75345, -122.33207, null);
```

If the following POI is defined in the `ADBMobileConfig.json` config file:

```js
"poi" : [ 
            ["San Francisco",37.757144,-122.44812,7000], 
        ]
```

When the device location is determined to be within a 7000 meter radius of the defined point, an `a.loc.poi` context data variable with the value "San Francisco" is sent in with the `TrackLocation` hit. An `a.loc.dist` context variable is sent with the distance in meters from the defined coordinates.

## Lifetime value

Lifetime value lets you measure and target on a lifetime value for each user. Each time you send in a value with `TrackLifetimeValueIncrease`, the value is added to the existing value. Lifetime value is stored on device and can be retrieved at any time by calling `GetLifetimeValue`. This can be used to store lifetime purchases, ad views, video completes, social shares, photo uploads, and so on.

```js
// Lifetime Value Example 
var ADB = ADBMobile; 
var purchasePrice = 39.95; 
var cdata = new Windows.Foundation.Collections.PropertySet(); 
cdata["ItemPurchaseEvent"] = "ItemPurchaseEvent"; 
cdata["PurchaseItem"] = "Item453"; 
cdata["PurchasePrice"] = purchasePrice; 
ADB.Analytics.trackLifetimeValueIncrease(purchasePrice, cdata);
```

## Timed actions

Timed actions let you measure in-app time and total time between the start and end of an action. The SDK calculates the amount of time in session and the total time (cross-session) it takes for the action to be completed. This can be used to define segments to compare on time to purchase, pass level, checkout flow, and so on.

* Total # of seconds in app between start and end - cross sessions 
* Total # of seconds between start and end (clock time)

```js
// Timed Action Start Example 
var ADB = ADBMobile; 
var cdata = new Windows.Foundation.Collections.PropertySet(); 
cdata["ExperienceName"] = experience; 
ADB.Analytics.trackTimedActionStart("TimeUntilPurchase", cdata);
```

```js
// Timed Action Update Example 
var ADB = ADBMobile; 
var cdataUpdate = new Windows.Foundation.Collections.PropertySet(); 
cdataUpdate["ImageLiked"] = imageName; 
ADB.Analytics.trackTimedActionStart("TimeUntilPurchase", cdata); 

```

```js
// Timed Action End Example 
var ADB = ADBMobile; 
ADB.Analytics.trackTimedActionEnd("TimeUntilPurchase");
```
