# Lifecycle metrics

Here are the metrics and dimensions that can be automatically measured by the mobile library after lifecycle is implemented.

## New Adobe Experience Platform Mobile SDK Release

Looking for information and documentation related to the Adobe Experience Platform Mobile SDK? Click [here](https://aep-sdks.gitbook.io/docs/) for our latest documentation.

As of September 2018, we released a new, major version of the SDK. These new Adobe Experience Platform Mobile SDKs are configurable through [Experience Platform Launch](https://www.adobe.com/experience-platform/launch.html).

* To get started, go to [Experience Platform Launch](https://launch.adobe.com/).
* To see what is in the Experience Platform SDK repositories, go to [Github: Adobe Experience Platform SDKs](https://github.com/Adobe-Marketing-Cloud/acp-sdks).


## Lifecycle metrics and dimensions

After lifecycle metrics are configured, the metrics are sent in context data parameters to Analytics, parameters to Target with each mbox call, and as a signal to Audience Manager. Analytics and Target use the same format, while Audience Manager uses a different prefix for each metric.

For Analytics, the context data that is sent with each lifecycle tracking call is automatically captured in and reported by using the metric or dimension that listed in the first column.

> **Tip:** Exceptions are provided in the description.

### Metrics

* **First Launches**

  Triggered at the first run after installation or re-installation.

  * Analytics Context Data/Target parameter: `a.InstallEvent`
  * Audience Manager signal: `c_a_InstallEvent`

* **Upgrades**

  Triggered at the first run after upgrade or anytime the version number changes.

  * Analytics Context Data/Target parameter: `a.UpgradeEvent`
  * Audience Manager signal: `c_a_UpgradeEvent`

* **Daily Engaged Users**

  Triggered when the application is used on a particular day.

  * Analytics Context Data/Target parameter: `a.DailyEngUserEvent`
  * Audience Manager signal: `c_a_DailyEngUserEvent`

* **Monthly Engaged Users**

  Triggered when the application is used during a particular month.

  * Analytics Context Data/Target parameter: `a.MonthlyEngUserEvent`
  * Audience Manager signal: `c_a_MonthlyEngUserEvent`

* **Launches**

  Triggered on every run, including crashes and installs. Also triggered when the app is resumed from the background after the lifecycle session timeout is exceeded.

  * Analytics Context Data/Target parameter: `a.LaunchEvent`
  * Audience Manager signal: `c_a_LaunchEvent`

* **Crashes**

  Triggered when the application is not backgrounded before closing. The event is sent when the application is started again after the crash.  Adobe Mobile crash reporting does not implement a global uncaught exception handler.

  * Analytics Context Data/Target parameter: `a.CrashEvent`
  * Audience Manager signal: `c_a_CrashEvent`

* **Previous Session Length**

  Reports the number of seconds that a previous application session lasted based on how long the application was open and in the foreground.

  * Analytics Context Data/Target parameter: `a.PrevSessionLength`
  * Audience Manager signal: `c_a_PrevSessionLength`

> **Important:**  The *Daily Engaged Users* and *Monthly Engaged Users* metrics are not automatically stored in an Analytics metric. You must create a processing rule that sets a custom event to capture these metrics.

#### Dimensions

* **Install Date**

  Date of first launch after installation.  The date format is `MM/DD/YYYY`.

  * Analytics Context Data/Target: `a.InstallDate`
  * Audience Management: `c_a_InstallDate`

* **App ID**

  Stores the Application name and version in the `[AppName] [BundleVersion]` format. For example, `myapp 1.1`.

  * Analytics Context Data/Target: `a.AppID`
  * Audience Management: `c_a_AppID`

* **Launch Number**

  Number of times the application was launched or brought out of the background.

  * Analytics Context Data/Target: `a.Launches`
  * Audience Management: `c_a_Launches`

* **Days since first use**

  Number of days since first run.

  * Analytics Context Data/Target: `a.DaysSinceFirstUse`
  * Audience Management: `c_a_DaysSinceFirstUse`

* **Days since last use**

  Number of days since last use.

  * Analytics Context Data/Target: `a.DaysSinceLastUse`
  * Audience Management: `c_a_DaysSinceLastUse`

* **Hour of Day**

  Measures the hour the app was launched and uses the 24-hour numerical format. Used for time parting to determine peak usage times.

  * Analytics Context Data/Target: `a.HourOfDay`
  * Audience Management: `c_a_HourOfDay`

* **Day of Week**

  Number of the week day the app was launched.

  * Analytics Context Data/Target: `a.DayOfWeek`
  * Audience Management: `c_a_DayOfWeek`

* **Operating System Version**

  Number of days since the application version number has changed.

  * Analytics Context Data/Target: `a.OSVersion`
  * Audience Management: `c_a_OSVersion|OS version`

* **Days since last upgrade**

  Days since last upgrade.

  * Analytics Context Data/Target: `a.DaysSinceLastUpgrade`
  * Audience Management: `c_a_DaysSinceLastUpgrade`

* **Launches since last upgrade**

  Number of launches since the application version number has changed.

  * Analytics Context Data/Target: `a.LaunchesSinceUpgrade`
  * Audience Management: `c_a_LaunchesSinceUpgrade`

* **Device Name**

  Stores the device name.  Comma-separated two-digit string that identifies the iOS device. The first number typically represents the device generation, and the second number typically versions different members of the device family. For a list of common device names, see  iOS Device Versions.

  * Analytics Context Data/Target: `a.DeviceName`
  * Audience Management: `c_a_DeviceName`

* **Carrier Name**

  Stores the name of the mobile service provider as provided by the device.

  * Analytics Context Data/Target: `a.CarrierName`
  * Audience Management: `c_a_CarrierName`

* **Resolution**

  Width x Height in actual pixels.

  * Analytics Context Data/Target: `a.Resolution`
  * Audience Management: `c_a_Resolution`  

  > **Important:** The *Days since last upgrade*, *Launches since last upgrade*, and the *Carrier Name* dimensions are not automatically stored in an Analytics variable. You must create a processing rule to copy the values to an Analytics variable for reporting.


## Additional mobile metrics and dimensions

The following metrics and dimensions are captured in mobile solution variables by the listed method.

### Metrics

* **Action Time Total**

  Populated by  trackTimedAction methods.

  * Analytics Context Data/Target parameter: `a.action.time.total`
  * Audience Management trait: `c_a_action_time_total`

* **Action Time In App**

  Populated by  trackTimedAction methods.

  * Analytics Context Data/Target parameter: `a.action.time.inapp`
  * Audience Management trait: `c_a_action_time_inapp`

* **Lifetime Value (event)**

  Populated by  trackLifetimeValue methods.

  * Analytics Context Data/Target parameter: `a.ltv.amount`
  * Audience Management trait: `c_a_ltv_amount`


### Dimensions

* **Location (down to 10 km)**

  Populated by `trackLocation` methods.

  * Analytics Context Data/Target parameter: 

    * `a.loc.lat.a`
    * `a.loc.lon.a`

  * Audience Management trait: 

    * `c_a_loc_lat_a`
    * `c_a_loc_lon_a`

* **Location (down to 100 m)**

  Populated by  trackLocation methods.

  * Analytics Context Data/Target parameter: 

    * `a.loc.lat.b`
    * `a.loc.lon.b`

  * Audience Management trait: 

    * `c_a_loc_lat_b`
    * `c_a_loc_lon_b`

* **Location (down to 1 m)**

  Populated by `trackLocation` methods.

  * Analytics Context Data/Target parameter: 

    * `a.loc.lat.c`
    * `a.loc.lon.c`

  * Audience Management trait: 

    * `c_a_loc_lat_c`
    * `c_a_loc_lon_c`

* **Point of Interest Name**

  Populated by  trackLocation methods when device is in a defined POI.

  * Analytics Context Data/Target parameter: `a.loc.poi`
  * Audience Management trait: `c_a_loc_poi`

* **Distance to Point of Interest Center**

  Populated by  trackLocation methods when device is in a defined POI.

  * Analytics Context Data/Target parameter: `a.loc.dist`
  * Audience Management trait: `c_a_loc_dist`

* **Lifetime Value (conversion variable)**

  Populated by  trackLifetimeValue methods.

  * Analytics Context Data/Target parameter: `a.ltv.amount`
  * Audience Management trait: `c_a_ltv_amount`

* **Tracking Code**

  Populated by Mobile App Acquisition. Generated automatically by Adobe mobile services.

  * Analytics Context Data/Target parameter: `a.referrer.campaign.trackingcode`
  * Audience Management trait: `c_a_referrer_campaign_trackingcode`

* **Campaign**

  Name of the campaign, also stored in the  campaign variable. Populated by Mobile App Acquisition.

  * Analytics Context Data/Target parameter: `a.referrer.campaign.name`
  * Audience Management trait: `c_a_referrer_campaign_name`

* **Campaign Content**

  The name or ID of the content that displayed the link. Populated by Mobile App Acquisition.

  * Analytics Context Data/Target parameter: `a.referrer.campaign.content`
  * Audience Management trait: `c_a_referrer_campaign_content`

* **Campaign Medium**

  Marketing medium, such as banner or email. Populated by Mobile App Acquisition.

  * Analytics Context Data/Target parameter: `a.referrer.campaign.medium`
  * Audience Management trait: `c_a_referrer_campaign_medium`

* **Campaign Source**

  Original referrer, such as newsletter or social media network. Populated by Mobile App Acquisition.

  * Analytics Context Data/Target parameter: `a.referrer.campaign.source`
  * Audience Management trait: `c_a_referrer_campaign_source`

* **Campaign Term**

  Paid keywords or other terms you want to track with this acquisition. Populated by Mobile App Acquisition.

  * Analytics Context Data/Target parameter: `a.referrer.campaign.term`
  * Audience Management trait: `c_a_referrer_campaign_term`
