# App Transport Security

This information helps you work with App Transport Security (ATS), which is a new set of security requirements for iOS 9.

Starting with iOS 9, Apple introduced App Transport Security, a set of requirements that conforms to best practices for secure connections. For more information, see *NSAppTransportSecurity* in [Information Property List Key Reference](https://developer.apple.com/library/prerelease/ios/technotes/App-Transport-Security-Technote/). 

For the Adobe Mobile SDK version 4.7 or later to work seamlessly with ATS, use the enable SSL option in the Manage App Settings page. For more information, see [Manage App Settings](https://experienceleague.adobe.com/docs/mobile-services/using/manage-app-settings-ug/c-manage-app-settings.html) or [ADBMobile JSON Config](/docs/ios/configuration/json-config/json-config.md).

In Adobe Mobile Services, by selecting the **Use HTTPS** option in the Manage App Settings page, all hits from Analytics, Audience Manager, Target, and Adobe Experience Platform Identity Services are sent via HTTPS.

As an alternative, you may place the following servers in your 'allowed' list:

| Product | Instructions |
|--- |--- |
|Analytics|To allow your Analytics server, add your tracking server domain to your info.plist file as an exception domain for ATS.  The tracking server domain can be found in the  Analytics section of the  `ADBMobileConfig.json` file or in the  Analytics section in the Manage App Settings page.|
|Audience Manager|Your  Audience Manager domain is found in the server property of the  audienceManager object in your `ADBMobileConfig.json` file.  If you are using  Audience Manager in your app, and SSL is not enabled, add this server as an exception domain for ATS in your  `Info.plist` file|
|Target|You can add your  Target endpoint to your  Info.plist file as an exception domain for ATS.  To find your  Target endpoint, find the `clientCodeproperty` in the target object of your `ADBMobileConfig.json` file. Your endpoint will be `https://{clientCode}.tt.omtrdc.net`.  For example, if your `clientCodeproperty` is `"myCompany"`, your endpoint will be `https://myCompany.tt.omtrdc.net`.|
|Adobe Experience Platform Identity Service|You can add the  Experience Cloud server as an exception domain for ATS in your  `Info.plist` file. This domain is `dpm.demdex.net`.|
|Mobile Services: Acquisition|Allow the Acquisition server as an exception domain for ATS in your  `Info.plist` file. This domain is `c00.adobe.com`.|
|Mobile Services: In-App Messages|If you are using in-app messages, you might need to add entries into the exception domain for ATS for each URL you use that is not HTTPS. This list includes hosted images and any URL embedded into your custom full screen message HTML.  For more detail on setting up exceptions domain in an `info.plist` file, see the *NSExceptionDomains* row in *Table 2: App Transport Security dictionary primary keys*. Also see *Table 3  Exception domains dictionary keys* in [Information Property List Key Reference](https://developer.apple.com/library/prerelease/ios/technotes/App-Transport-Security-Technote/).|

> **Tip:** These considerations affect the connections that are made by the Adobe Mobile SDK and do not impact web view or other connections that are made by your app.
