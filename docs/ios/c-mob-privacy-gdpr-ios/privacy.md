# Setting the user's opt status

This information helps you with a GDPR data deletion request.

> **Important:** Starting with Experience Cloud iOS SDKs 4.15, setting the privacy status to `unknown` holds Audience Manager and Experience Cloud ID hits.

You can control whether Analytics, Target, and Audience Manager activity is allowed on a device by using the following settings:

* `privacyDefault` in [ADBMobile JSON Config](/docs/ios/configuration/json-config/json-config.md).

  This setting controls the initial setting that persists until it is changed in code. 

* `setPrivacyStatus` method.

  After the privacy setting is changed by using this method, the change is permanent until it is changed again by using this method, or when you uninstall and install the app again.

  For more information about the methods, see [Configuration Methods](/docs/ios/configuration/json-config/json-config.md).

Here is information about each privacy status:

* **Opt in**

  * Analytics: Hits are sent. 
  * Target: Mbox requests are sent.  
  * Audience Manager: Signals and ID syncs are sent.
  * Value in the JSON config file: `optedin`
  * Value in `setPrivacyStatus`: `ADBMobilePrivacyStatusOptIn`

* **Opt out**

  * Analytics: Hits are discarded. 
  * Target: Mbox requests are not allowed.  
  * Audience Manager: Signals and ID syncs are not allowed.
  * Value in the JSON config file: `optedout`
  * Value in `setPrivacyStatus`: `ADBMobilePrivacyStatusOptOut`

* **Unknown**

  * Analytics: If offline tracking **is** enabled, hits are saved until the privacy status changes to opt-in (hits are sent) or opt-out (hits are discarded). 
  
    If offline tracking **is not** enabled, hits are discarded until the privacy status changes to opt-in.  

  * Target: Mbox requests are sent.
  * Audience Manager: Signals and ID syncs are sent.
  * Value in the JSON config file: `optunknown`
  * Value in `setPrivacyStatus`: `ADBMobilePrivacyStatusUnknown`

## Examples

```objective-c
- (IBAction) setPrivacyOptIn { 
 [ADBMobile setPrivacyStatus:ADBMobilePrivacyStatusOptIn]; 
} 
- (IBAction) setPrivacyOptOut { 
 [ADBMobile setPrivacyStatus:ADBMobilePrivacyStatusOptOut]; 
} 
- (IBAction) setPrivacyOptUnknown { 
 [ADBMobile setPrivacyStatus:ADBMobilePrivacyStatusUnknown]; 
}
```
