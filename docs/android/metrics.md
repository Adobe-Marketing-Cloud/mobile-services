# Lifecycle metrics

This section provides information about the metrics and dimensions that can be measured automatically by the mobile library, after lifecycle is implemented, and a link to troubleshoot Lifecycle data. For more information about troubleshooting, go to [Troubleshoot Lifecycle data](https://helpx.adobe.com/analytics/kb/troubleshoot-lifecycle-data.html).

## New Adobe Experience Platform Mobile SDK Release

Looking for information and documentation related to the Adobe Experience Platform Mobile SDK? Click [here](https://aep-sdks.gitbook.io/docs/) for our latest documentation.

As of September 2018, we released a new, major version of the SDK. These new Adobe Experience Platform Mobile SDKs are configurable through [Experience Platform Launch](https://www.adobe.com/experience-platform/launch.html).

* To get started, go to Adobe Experience Platform Launch.
* To see what is in the Experience Platform SDK repositories, go to [Github: Adobe Experience Platform SDKs](https://github.com/Adobe-Marketing-Cloud/acp-sdks).

## Lifecycle metrics and dimensions

When configured, lifecycle metrics are sent in context data parameters to Analytics, in parameters to Target with each mbox call, and as a signal to audience management. Analytics and Target use the same format, while audience management uses a different prefix for each metric.

For Analytics, the context data that is sent with each lifecycle tracking call is automatically captured in and reported on by using the metric or dimension, and the exceptions are noted.

### Metrics

* **First Launches**

  Triggered at the first run after installation or re-installation.

  * Analytics Context Data/Target Parameter: `a.InstallEvent`
  * Audience Manager Signal: `c_a_InstallEvent`

* **Upgrades**

  Triggered at the first run after an upgrade or when the version number changes.

  * Analytics Context Data/Target Parameter: `a.UpgradeEvent`
  * Audience Manager Signal: `c_a_UpgradeEvent`

* **Daily Engaged Users**

  Triggered when the application is used on a particular day.  
  
  > **Important:** This metric is not automatically stored in an Analytics metric. You must create a processing rule that sets a custom event to capture this metric.

  * Analytics Context Data/Target Parameter: `a.DailyEngUserEvent`
  * Audience Manager Signal: `c_a_DailyEngUserEvent`

* **Monthly Engaged Users**

  Triggered when the application is used during a particular month.
  
  > **Important:** This metric is not automatically stored in an Analytics metric. You must create a processing rule that sets a custom event to capture this metric.

  * Analytics Context Data/Target Parameter: `a.MonthlyEngUserEvent`
  * Audience Manager Signal: `c_a_MonthlyEngUserEvent`

* **Launches**

  Triggered at every run, including crashes and installs. Also triggered on a resume from the background when the lifecycle session timeout has been exceeded.
  
  > **Important:** This metric is not automatically stored in an Analytics metric. You must create a processing rule that sets a custom event to capture this metric.

  * Analytics Context Data/Target Parameter: `a.LaunchEvent`
  * Audience Manager Signal: `c_a_LaunchEvent`

* **Crashes**

  Triggered when the application is not backgrounded before being closed. The event is sent when the application is started after the crash.  Adobe Mobile crash reporting does not implement a global uncaught exception handler.

  * Analytics Context Data/Target Parameter: `a.CrashEvent`
  * Audience Manager Signal: `c_a_CrashEvent`

* **Previous Session Length**

  Reports the number of seconds that a previous application session lasted, based on how long the application was open and in the foreground.

  * Analytics Context Data/Target Parameter: `a.PrevSessionLength`
  * Audience Manager Signal: `c_a_PrevSessionLength`


### Dimensions

* **Install Date**

  Date of first launch after installation. The date format is  MM/DD/YYYY.

  * Analytics Context Data/Target Parameter: `a.InstallDate`
  * Audience Manager: `c_a_InstallDate`

* **App ID**

  Stores the application name and version in the `[AppName] [BundleVersion]` format. An example of this format is `myapp 1.1`.

  * Analytics Context Data/Target Parameter: `a.AppID`
  * Audience Manager: `c_a_AppID`

* **Launch Number**

  Number of times the application was launched or brought out of the background.

  * Analytics Context Data/Target Parameter: `a.Launches`
  * Audience Manager: `c_a_Launches`

* **Days since first use**

  Number of days since the first run.

  * Analytics Context Data/Target Parameter: `a.DaysSinceFirstUse`
  * Audience Manager: `c_a_DaysSinceFirstUse`

* **Days since last use**

  Number of days since the last use.

  * Analytics Context Data/Target Parameter: `a.DaysSinceLastUse`
  * Audience Manager: `c_a_DaysSinceLastUse`

* **Hour of Day**

  Measures the hour that the app was launched.  This metric uses the 24-hour numerical format and is used for time parting to determine peak usage times.

  * Analytics Context Data/Target Parameter: `a.HourOfDay`
  * Audience Manager: `c_a_HourOfDay`

* **Day of Week**

  Number of the day in a week when the app was launched.

  * Analytics Context Data/Target Parameter: `a.DayOfWeek`
  * Audience Manager: `c_a_DayOfWeek`

* **Operating System Version**

  The OS version.

  * Analytics Context Data/Target Parameter: `a.OSVersion`
  * Audience Manager: `c_a_OSVersion`

* **Days since last upgrade**

  Number of days since the application version number has changed.  
  
  > **Important:** This metric is not automatically stored in an Analytics variable. You must create a processing rule to copy this value to an Analytics variable for reporting.

  * Analytics Context Data/Target Parameter: `a.DaysSinceLastUpgrade`
  * Audience Manager: `c_a_DaysSinceLastUpgrade`

* **Launches since last upgrade**

  Number of launches since the application version number has changed.
  
  > **Important:** This metric is not automatically stored in an Analytics variable. You must create a processing rule to copy this value to an Analytics variable for reporting.

  * Analytics Context Data/Target Parameter: `a.LaunchesSinceUpgrade`
  * Audience Manager: `c_a_LaunchesSinceUpgrade`

* **Device Name**

  Stores the device name.

  * Analytics Context Data/Target Parameter: `a.DeviceName`
  * Audience Manager: `c_a_DeviceName`

* **Carrier Name**

  Stores the name of the mobile service provider as provided by the device.  Important:  This metric is not automatically stored in an Analytics variable. You must create a processing rule to copy this value to an Analytics variable for reporting.
  
  > **Important:** This metric is not automatically stored in an Analytics variable. You must create a processing rule to copy this value to an Analytics variable for reporting.

  * Analytics Context Data/Target Parameter: `a.CarrierName`
  * Audience Manager: `c_a_CarrierName`

* **Resolution**

  Width x Height in actual pixels.

  * Analytics Context Data/Target Parameter: `a.Resolution`
  * Audience Manager: `c_a_Resolution`

## Additional mobile metrics and dimensions

The following metrics and dimensions are captured in mobile solution variables by the method listed in the **Description** column.

### Metrics

* **Action Time Total**

  Populated by `trackTimedAction` methods.

  * Analytics Context Data/Target Parameter: `a.action.time.total`
  * Audience Manager Trait: `c_a_action_time_total`

* **Action Time In App**

  Populated by `trackTimedAction` methods.

  * Analytics Context Data/Target Parameter: `a.action.time.inapp`
  * Audience Manager Trait: `c_a_action_time_inapp`

* **Lifetime Value (event)**

  Populated by `trackLifetimeValue` methods.

  * Analytics Context Data/Target Parameter: `a.ltv.amount`
  * Audience Manager Trait: `c_a_ltv_amount`

### Dimensions

* **Location (down to 10 km)**

  Populated by `trackLocation` methods.

  * Analytics Context Data/Target Parameters: 
  
    * `a.loc.lat.a`
    * `a.loc.lon.a`

  * Audience Manager Traits: 

    * `c_a_loc_lat_a`
    * `c_a_loc_lon_a`

* **Location (down to 100 m)**

  Populated by  trackLocation methods.

  * Analytics Context Data/Target Parameters: 
  
    * `a.loc.lat.b`
    * `a.loc.lon.b`

  * Audience Manager Traits: 

    * `c_a_loc_lat_b`
    * `c_a_loc_lon_b`

* **Location (down to 1 m)**

  Populated by  trackLocation methods.

  * Analytics Context Data/Target Parameters: 
  
    * `a.loc.lat.c`
    * `a.loc.lon.c`

  * Audience Manager Traits: 

    * `c_a_loc_lat_c`
    * `c_a_loc_lon_c`

* **Point of Interest Name**

  Populated by  trackLocation methods when device is within a defined POI.

  * Analytics Context Data/Target Parameters: `a.loc.poi`
  * Audience Manager Trait: `c_a_loc_poi`

* **Distance to Point of Interest Center**

  Populated by  trackLocation methods when device is within a defined POI.

  * Analytics Context Data/Target Parameters: `a.loc.dist`
  * Audience Manager Trait: `c_a_loc_dist`

* **Lifetime Value (conversion variable)**

  Populated by  trackLifetimeValue methods.

  * Analytics Context Data/Target Parameters: `a.ltv.amount`
  * Audience Manager Trait: `c_a_ltv_amount`

* **Tracking Code**

  Populated by Mobile App Acquisition and automatically generated by Adobe mobile services.

  * Analytics Context Data/Target Parameters: `a.referrer.campaign.trackingcode`
  * Audience Manager Trait: `c_a_referrer_campaign_trackingcode`

* **Campaign**

  Name of the campaign, also stored in the  campaign variable. Populated by Mobile App Acquisition.

  * Analytics Context Data/Target Parameters: `a.referrer.campaign.name`
  * Audience Manager Trait: `c_a_referrer_campaign_name`

* **Campaign Content**

  The name or ID of the content that displayed the link. Populated by Mobile App Acquisition.

  * Analytics Context Data/Target Parameters: `a.referrer.campaign.content`
  * Audience Manager Trait: `c_a_referrer_campaign_content`

* **Campaign Medium**

  Marketing medium, such as a banner or email. Populated by Mobile App Acquisition.

  * Analytics Context Data/Target Parameters: `a.referrer.campaign.medium`
  * Audience Manager Trait: `c_a_referrer_campaign_medium`

* **Campaign Source**

  Original referrer, such as a newsletter or a social media network. Populated by Mobile App Acquisition.

  * Analytics Context Data/Target Parameters: `a.referrer.campaign.source`
  * Audience Manager Trait: `c_a_referrer_campaign_source`

* **Campaign Term**

  Paid keywords or other terms that you want to track with this acquisition. Populated by Mobile App Acquisition.

  * Analytics Context Data/Target Parameters: `a.referrer.campaign.term`
  * Audience Manager Trait: `c_a_referrer_campaign_term`
