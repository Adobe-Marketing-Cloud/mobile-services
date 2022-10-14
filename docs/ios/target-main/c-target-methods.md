# Target methods for iOS

Here is the list of Adobe Target methods that are provided by the iOS library.

The SDK currently has support for multiple Adobe Experience Cloud Solutions, including Analytics, Target, Audience Manager, and the Adobe Experience Platform Identity Service. Methods are prefixed according to the solution. For example, Target methods are prefixed with `target`.

> **Tip:** Lifecycle Metrics are sent as parameters to each mbox load. For more information, see [Lifecycle Metrics](/docs/ios/metrics.md). If you are sending Target requests inside the `didFinishLaunching` delegate method, add a `[ADBMobile trackAction:data:]` or `[ADBMobile trackState:data:]` call before the Target implementation code. This way, the Target requests will contain the complete lifecycle data.

## Class reference : ADBTargetLocationRequest

### Properties

```objective-c
NSString *name; 
NSString *defaultContent; 
NSMutableDictionary *parameters;
```

### String constants

> **Tip:** The following constants are for ease of use when you set keys for custom parameters.

```iOS
NSString *const ADBTargetParameterOrderId; 
NSString *const ADBTargetParameterOrderTotal; 
NSString *const ADBTargetParameterProductPurchasedId; 
NSString *const ADBTargetParameterCategoryId; 
NSString *const ADBTargetParameterMbox3rdPartyId; 
NSString *const ADBTargetParameterMboxPageValue; 
NSString *const ADBTargetParameterMboxPc; 
NSString *const ADBTargetParameterMboxSessionId; 
NSString *const ADBTargetParameterMboxHost;
```

> **Important:** * If you are using SDKs **before** version 4.14.0, see [Input Parameters](https://developers.adobetarget.com/api/#input-parameters) for parameters limitations.
>
>* If you are using SDKs version 4.14.0 **or after**, see [Batch Input Parameters](https://developers.adobetarget.com/api/#batch-input-parameters) for parameters limitations.

### Methods

* **targetLoadRequest:​callback**

  Sends request to your configured Target server and returns the string value of the offer that is generated in a block `callback`.

  * Here is the syntax for this method:

    ```objective-c
    + (void) targetLoadRequest:(ADBTargetLocationRequest *)request
                      callback:(void (^)(NSString *content))callback;
    ```
  
  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile targetLoadRequest:myRequest
                        callback:^(NSString *content) {
                          // do something with content
                        }];
    ```

* **targetLoadRequestWithName:defaultContent:profileParameters:orderParameters:mboxParameters:requestLocationParameters:callback:**

  Sends a request to your configured Target server and returns the string value of the offer that is generated in a block callback.

  * Here is the syntax for this method:

    ```objective-c
    + (void) targetLoadRequestWithName:(nullable NSString *)name
                        defaultContent:(nullable NSString *)defaultContent
                    profileParameters:(nullable NSDictionary *)profileParameters
                      orderParameters:(nullable NSDictionary *)orderParameters
                       mboxParameters:(nullable NSDictionary *)mboxParameters
              requestLocationParameters:(nullable NSDictionary *)requestLocationParameters
                               callback:(nullable void (^)(NSString
                               * __nullable content))callback;
    ```

  * Returns: N/A

  * Here are the parameters for this method:

    * **`name`**

      Name of the Target mbox/location that you want to retrieve.

      * **Type**: NSString*

    * **`defaultContent`**

      Value returned in the callback if the Target server is unreachable, or the user does not qualify for the campaign.

      * **Type**: NSString*

    * **`profileParameters`**

      Values in this dictionary will go in the "profileParameters" object in the request to Target.

      * **Type**: NSDictionary*

    * **`orderParameters`**

      Values in this dictionary will go in the "order" object in the request to Target.

      * **Type**: NSDictionary

    * **`mboxParameters`**

      Values in this dictionary will go in the "mboxParameters" object in the request to Target.

      * **Type**: NSDictionary*

    * **`requestLocationParameters`**

      Values in this dictionary will go in the "requestLocation" object in the request to Target.

      **Type**: NSDictionary*

    * **`callback`**

      This method will be called with the content of the offer from the Target server. If the Target server is unreachable, or the user does not qualify for the campaign, defaultContent will be returned.

    **Type**: Function

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile targetLoadRequestWithName:@"myHeroBanner"
                          defaultContent:@"defaultHeroBanner.png"
                      profileParameters:@{@"age":@"20-29"}
                        orderParameters:nil
                         mboxParameters:@{@"customParam":@"customValue"}
              requestLocationParameters:@{@"host":@"my.hostname.com"}
                               callback:^(NSString *content){
                                 // do something with content
                                 myImageView.image = [UIImage imageNamed:content];
                               }];
    ```

    For more information about the underlying Target API, see the [Target API reference](https://aep-sdks.gitbook.io/docs/using-mobile-extensions/adobe-target/target-api-reference-deprecated).

* **targetLoadRequestWithName:defaultContent:profileParameters:orderParameters:mboxParameters:callback**

  Sends request to your configured Target server and returns the string value of the offer generated in a block callback.

  * Here is the syntax for this method:

    ```objective-c
    + (void) targetLoadRequestWithName:(nullable NSString *)name
                        defaultContent:(nullable NSString *)defaultContent
                    profileParameters:(nullable NSDictionary *)profileParameters
                      orderParameters:(nullable NSDictionary *)orderParameters
                       mboxParameters:(nullable NSDictionary *)mboxParameters
                             callback:(nullable void (^)(NSString * __nullable content))callback;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile targetLoadRequestWithName:@"mboxName"
                          defaultContent:@"defaultContent"
                       profileParameters:{@"profile-parameter-key": @"profile-parameter-value"}
                         orderParameters:@{@"order-parameter-key": @"order-parameter-value"}
                          mboxParameters:@{@"mbox-parameter-key": @"mbox-parameter-value"}
                                 callback:^(NSString * content) {
                                         //do something with content 
                               }
                             }];
    ```

* **targetCreateOrder​ConfirmRequestWithName:​orderId:​orderTotal:​productPurchasedId:​parameters**

  Creates an `ADBTargetLocationRequest`.

  * Here is the syntax for this method:

    ```objective-c
    + (ADBTargetLocationRequest *)
    targetCreateOrderConfirmRequestWithName:(NSString *)name
                                    orderId:(NSString *)orderId
                                orderTotal:(NSString *)orderTotal
                        productPurchasedId:(NSString *)productPurchasedId
                            parameters:(NSDictionary *)parameters;
    ```

* **targetCreateRequestWithName:​​defaultContent:​parameters**

   Convenience constructor to create an ADBTargetLocationRequest object with the given parameters.

  * Here is the syntax for this method:

    ```objective-c
    + (ADBTargetLocationRequest *)
    targetCreateRequestWithName:(NSString *)name
                         defaultContent:(NSString *)defaultContent
                             parameters:(NSDictionary *)parameters;
    ```

  * Here is the code sample for this method:
  
    ```objective-c
    ADBTargetLocationRequest *myRequest =  
    [ADBMobile targetCreateRequestWithName:@"heroBanner"
                            defaultContent:@"default.png"
                                parameters:nil];
    ```

* **targetThirdPartyID**

  Returns the third-party ID.

  * Here is the syntax for this method:

    ```objective-c
    + (nullable NSString *) targetThirdPartyID;
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSString *thirdPartyId = [ADBMobile targetThirdPartyID];
    ```

* **targetSetThirdPartyID**

  Sets the third-party ID.

  * Here is the syntax for this method:

    ```objective-c
    + (void) targetSetThirdPartyID:(nullable NSString *)thirdPartyID;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile targetSetThirdPartyID:@"thirdPartyID"];
    ```

* **targetClearCookies**

  Clears any target cookies from your app.

  > **Tip:** Since version 4.10.0 of the SDK, Target no longer uses cookies. This method resets the thirdPartyID and sessionID.

  * Here is the syntax for this method:

    ```objective-c
    + (void) targetClearCookies;
    ```

  * Here is the code sample for this method:
  
    ```objective-c
    [ADBMobile targetClearCookies];
    ```

* **targetPcID**

  Returns the PcID.

  * Here is the syntax for this method:

    ```objective-c
    + (nullable NSString *) targetPcID;
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSString *myTargetPcID = [ADBMobile targetPcID];
    ```

* **targetSessionID**

  Returns the SessionID.

  * Here is the syntax for this method:

    ```objective-c
    + (nullable NSString *) targetPcID;
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSString *myTargetSessionID = [ADBMobile targetSessionID];
    ```

### Example

```objective-c
// make your request 
ADBTargetLocationRequest *myRequest =  
 [ADBMobile targetCreateRequestWithName:@"heroBanner"  
                         defaultContent:@"default.png"  
                          parameters:nil]; 
// load your request 
[ADBMobile targetLoadRequest:myRequest  
                    callback:^(NSString *content) { 
                        // do something with content 
                        heroImage.image = [UIImage imageNamed:content];
                    }];
```
