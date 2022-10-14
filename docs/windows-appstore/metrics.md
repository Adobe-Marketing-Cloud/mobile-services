# Lifecycle metrics

Lists the metrics and dimensions that can be measured automatically by the mobile library.

For more information, see [Troubleshoot Lifecycle data](https://helpx.adobe.com/analytics/kb/troubleshoot-lifecycle-data.html).

## Lifecycle metrics and dimensions

When configured, lifecycle metrics are sent in context data parameters to Analytics, in parameters to Target with each mbox call, and as a signal to Audience Manager. Analytics and Target use the same format, and Audience Manager uses a different prefix for each metric.

For Analytics, the context data that is sent with each lifecycle tracking call is automatically captured in and reported on by using the metric or dimension listed below, and exceptions are noted.

### Metrics

* **First Launches**

  Triggered at the first run after installation or re-installation. 

  * Analytics context data/Target parameter: `a.InstallEvent`
  * Audience Manager signal: `c_a_InstallEvent`

* **Upgrades**

  Triggered at the first run after an upgrade or when the version number changes. 

  * Analytics context data/Target parameter: `a.UpgradeEvent`
  * Audience Manager signal: `c_a_UpgradeEvent`

* **Daily Engaged Users**

  Triggered when the application is used on a particular day. 
  
  > **Tip:** This metric is not automatically stored in an Analytics metric. You must create a processing rule that sets a custom event to capture this metric.

  * Analytics context data/Target parameter: `a.DailyEngUserEvent`
  * Audience Manager signal: `c_a_DailyEngUserEvent`  

* **Monthly Engaged Users**

  Triggered when the application is used during a particular month. 
  
  > **Important:** This metric is not automatically stored in an Analytics metric. You must create a processing rule that sets a custom event to capture this metric. 

  * Analytics context data/Target parameter: `a.MonthlyEngUserEvent`
  * Audience Manager signal: `c_a_MonthlyEngUserEvent`

* **Launches**

  Triggered at every run, including crashes and installs. Also triggered on a resume from the background when the lifecycle session timeout has been exceeded. 

  * Analytics context data/Target parameter: `a.LaunchEvent`
  * Audience Manager signal: `c_a_LaunchEvent`

* **Crashes**

  Triggered when the application is not backgrounded before being closed. The event is sent when the application is started after the crash. Adobe Mobile crash reporting does not implement a global uncaught exception handler.

  * Analytics context data/Target parameter: `a.CrashEvent`
  * Audience Manager signal: `c_a_CrashEvent`

* **Previous Session Length**

  Reports the number of seconds that a previous application session lasted, based on how long the application was open and in the foreground. 

  * Analytics context data/Target parameter: `a.PrevSessionLength`
  * Audience Manager signal: `c_a_PrevSessionLength` 

### Dimensions

* **Install Date**

  Date of first launch after installation. The date format is `MM/DD/YYYY`.

  * Analytics context data/Target: `a.InstallDate`
  * Audience Manager: `c_a_InstallDate`

* **App ID**

  Stores the application name and version in the `[AppName] [BundleVersion]` format. An example of this format is `myapp 1.1`. 

  * Analytics context data/Target: `a.AppID`
  * Audience Manager: `c_a_AppID`

* **Launch Number**

  Number of times the application was launched or brought out of the background. 

  * Analytics context data/Target: `a.Launches`
  * Audience Manager: `c_a_Launches`  

* **Days since first use**

  Number of days since the first run.

  * Analytics context data/Target: `a.DaysSinceFirstUse`
  * Audience Manager: `c_a_DaysSinceFirstUse`

* **Days since last use**

  Number of days since the last use. 

  * Analytics context data/Target: `a.DaysSinceLastUse`
  * Audience Manager: `c_a_DaysSinceLastUse`

* **Hour of Day**

  Measures the hour that the app was launched. This metric uses the 24-hour numerical format and is used for time parting to determine peak usage times. 

  * Analytics context data/Target: `a.HourOfDay`
  * Audience Manager: `c_a_HourOfDay`

* **Day of Week**

  Number of the day in a week when the app was launched. 

  * Analytics context data/Target: `a.DayOfWeek`
  * Audience Manager: `c_a_DayOfWeek`

* **Operating System Version**

  The OS version. 

  * Analytics context data/Target: `a.OSVersion`
  * Audience Manager: `c_a_OSVersion`

* **Days since last upgrade**

  Number of days since the application version number has changed. 
  
  > **Important:** This metric is not automatically stored in an Analytics variable. You must create a processing rule to copy this value to an Analytics variable for reporting.

  * Analytics context data/Target: `a.DaysSinceLastUpgrade`
  * Audience Manager: `c_a_DaysSinceLastUpgrade`

* **Launches since last upgrade**

  Number of launches since the application version number has changed. 
  
  > **Important:** This metric is not automatically stored in an Analytics variable. You must create a processing rule to copy this value to an Analytics variable for reporting. 

  * Analytics context data/Target: `a.LaunchesSinceUpgrade`
  * Audience Manager: `c_a_LaunchesSinceUpgrade`

* **Device Name**

  Stores the device name. 

  * Analytics context data/Target: `a.DeviceName`
  * Audience Manager: `c_a_DeviceName`

* **Carrier Name**

  Stores the name of the mobile service provider as provided by the device. 
  
  > **Important:** This metric is not automatically stored in an Analytics variable. You must create a processing rule to copy this value to an Analytics variable for reporting.

  * Analytics context data/Target: `a.CarrierName`
  * Audience Manager: `c_a_CarrierName`

* **Resolution**

   Width x Height in actual pixels.

  * Analytics context data/Target: `a.Resolution`
  * Audience Manager: `c_a_Resolution`
  

## Additional mobile metrics and dimensions

The following metrics and dimensions are captured in mobile solution variables by the methods listed in the description.

### Metrics

* **Action Time Total**

  Populated by `trackTimedAction` methods.

  * Analytics context data/Target parameter: `a.action.time.total`
  * Audience Manager trait: `c_a_action_time_total`

* **Action Time In App**

  Populated by `trackTimedAction` methods. 

  * Analytics context data/Target parameter: `a.action.time.inapp`
  * Audience Manager trait: `c_a_action_time_inapp`

* **Lifetime Value (event)**

  Populated by `trackLifetimeValue` methods.

  * Analytics context data/Target parameter: `a.ltv.amount`
  * Audience Manager trait: `c_a_ltv_amount`

## Dimensions

* **Location (down to 10 km)**

  Populated by `trackLocation` methods.

  * Analytics context data/Target parameter: 

    * `a.loc.lat.a`
    * `a.loc.lon.a`

  * Audience Manager trait: 

    * `c_a_loc_lat_a`
    * `c_a_loc_lon_a`

* **Location (down to 100 m)**

  Populated by `trackLocation` methods.

  * Analytics context data/Target parameter: 

    * `a.loc.lat.b`
    * `a.loc.lon.b`

  * Audience Manager trait: 

    * `c_a_loc_lat_b`
    * `c_a_loc_lon_b`

* **Location (down to 1 m)**

  Populated by `trackLocation` methods. 

  * Analytics context data/Target parameter: 

    * `a.loc.lat.c`
    * `a.loc.lon.c`

  * Audience Manager trait: 

    * `c_a_loc_lat_c`
    * `c_a_loc_lon_c`

* **Point of Interest Name**

  Populated by `trackLocation` methods when device is within a defined POI. 

  * Analytics context data/Target parameter: `a.loc.poi`
  * Audience Manager trait: `c_a_loc_poi`

* **Distance to Point of Interest Center**

  Populated by `trackLocation` methods when device is within a defined POI. 

  * Analytics context data/Target parameter: `a.loc.dist`
  * Audience Manager trait: `c_a_loc_dist`

* **Lifetime Value (conversion variable)**

  Populated by `trackLifetimeValue` methods. 

  * Analytics context data/Target parameter: `a.ltv.amount`
  * Audience Manager trait: `c_a_ltv_amount`
