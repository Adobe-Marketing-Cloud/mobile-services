# Adobe Experience Platform Identity Service methods

Here are the Adobe Experience Platform Identity Service methods that are provided by the iOS library.

The SDK currently supports multiple Adobe Experience Cloud Solutions, including Analytics, Target, Audience Manager, and the Experience Cloud Visitor ID service.

Methods are prefixed according to the solution, and Experience Cloud ID methods are prefixed with `visitor`. For more information, see [Enabling the Experience Cloud ID](/docs/ios/marketing-cloud/mcvid.md).

* **`+` (nullable NSURL `*`)visitorAppendToURL:(nullable NSURL `*`)url;**

  Appends Adobe visitor data to a URL string for use with the Adobe JavaScript library. To use this method, you must have Mobile SDK version 4.12 or higher. For more information, see [appendVisitorIDsTo](https://experienceleague.adobe.com/docs/id-service/using/id-service-api/methods/appendvisitorid.html) in the Adobe Experience Cloud Identity Service documentation.
  
  > **Important:** This method can cause a blocking network call. Do not call this on time-sensitive threads.

  * Input: `URL<NSURL>`
    A required URL string that the visitor information will be appended to.
  * `URL<NSURL>`
    String with the visitor info appended.

  * Here is the code sample for this method:

    ```objective-c
     NSURL *url = [NSURL URLWithString:@"https://www.example.com"];  
     NSURL *decoratedURL = [ADBMobile visitorAppendToURL: url];  
     [[UIApplication sharedApplication] openURL: decoratedURL];  
    ```

* **visitorMarketingCloudID**

  Retrieves the Experience Cloud ID from the ID service.

  * Here is the syntax for this method:

    ```objective-c
    + (NSString  *)  visitorMarketingCloudID;
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSString *mcid = [ADBMobile visitorMarketingCloudID]; 
    ```

    > **Important:** This method can cause a blocking network call and should **not** be called from a UI thread.

* **visitorSyncIdentifiers:**

  With the Experience Cloud ID, you can set additional customer IDs that can be associated with each visitor. The Visitor API accepts multiple Customer IDs for the same visitor, with a customer type identifier to separate the scope of the different customer IDs. This method corresponds to `setCustomerIDs` in the JavaScript library.

  * Here is the syntax for this method:

    ```objective-c
    +  (void)  visitorSyncIdentifiers:(NSDictionary  *)identifiers;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile visitorSyncIdentifiers:@{@"idType":@"idValue"}];
    ```

* **visitorSyncIdentifiers:authenticationState:**

  Synchronizes the provided identifiers to the ID service. Pass in the `authState` as one of the following values:

  * `ADBMobileVisitorAuthenticationStateUnknown`
  * `ADBMobileVisitorAuthenticationStateAuthenticated`
  * `ADBMobileVisitorAuthenticationStateLoggedOut`

  * Here is the syntax for this method:

    ```objective-c
    +  (void) visitorSyncIdentifiers:(nullable NSDictionary  *)identifiers  authenticationState:(ADBMobileVisitorAuthenticationState)authState; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile visitorSyncIdentifiers:@{@"myIdType":@"valueForUser"}  authenticationState:ADBMobileVisitorAuthenticationStateAuthenticated]; 
    ```

* **visitorSyncIdentifierWithType:identifier:authenticationState:**

  Synchronizes the provided identifier type and value to the ID service. Pass in the `authState` one of the following values:

  * `ADBMobileVisitorAuthenticationStateUnknown`
  * `ADBMobileVisitorAuthenticationStateAuthenticated`  
  * `ADBMobileVisitorAuthenticationStateLoggedOut`

  * Here is the syntax for this method:

    ```objective-c
    + (void) visitorSyncIdentifierWithType:(nullable NSString *)identifierType  
    identifier:(nullable NSString *)identifier authenticationState:
    (ADBMobileVisitorAuthenticationState)authState; 
    ```

  * Here is the syntax for this method:

    ```objective-c
    [ADBMobile visitorSyncIdentifierWithType:@"myIdType" identifier:@"valueForUser"  
    authenticationState:ADBMobileVisitorAuthenticationStateLoggedOut]; 
    ```

* **visitorGetIDs**

   Retrieves an array of read-only `ADBVisitorID` objects.

  * Here is the syntax for this method:

    ```objective-c
    +  (nullable NSArray *) visitorGetIDs;
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSArray *myVisitorIDs = [ADBMobile visitorGetIDs];
    ```

* **visitorgetUrlVariablesAsync**

  Introduced in version 4.16.0, this method returns an appropriately formed string that contains Visitor ID Service URL variables. For more information about how this method is used, see [Adobe Experience Platform Identity Service methods](/docs/ios/reference/hybrid-app.md).

  * Here is the syntax for this method:

    ```objectivec
    + (void) visitorGetUrlVariablesAsync:(nullable void (^)(NSString* __nullable urlVariables))callback;
    ```

  * Here is the code sample for this method:

    ```objectivec
    NSString *urlString = @"https://www.mydomain.com/index.php"; 
    [ADBMobile visitorGetUrlVariablesAsync:^(NSString * _Nullable urlVariables) { 
      NSString *urlStringWithVisitorData = [NSString stringWithFormat:@"%@?%@", urlString, urlVariables]; 
      // use urlStringWithVisitorData 
    }];
    ```

## ADBVisitorID interface

**Public Methods:**

```objective-c
- (nullable NSString *) idType; 
- (nullable NSString *) identifier; 
- (ADBMobileVisitorAuthenticationState) authenticationState; 

```

## ADBMobileVisitorAuthenticationState enum

```objective-c
ADBMobileVisitorAuthenticationStateUnknown, 
ADBMobileVisitorAuthenticationStateAuthenticated, 
ADBMobileVisitorAuthenticationStateLoggedOut
```
