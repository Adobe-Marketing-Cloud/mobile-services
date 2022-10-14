# Audience Manager methods

Here is a list of the Audience Manager methods that are provided by the iOS library.

 The SDK currently supports multiple Adobe Experience Cloud Solutions, including Analytics, Target, Audience Manager, and the Adobe Experience Platform Identity Service. Methods are prefixed according to the solution, and Audience Manager methods are prefixed with " `audience`."

If Audience Manager is configured in your JSON file, a signal that contains lifecycle metrics is sent with `application:didFinishLaunchingWithOptions:`. 

* **audienceVisitorProfile**

  Returns the visitor profile that was most recently obtained and, if no signal has been submitted, returns `null`. The visitor profile is saved in `NSUserDefaults` for easy access across multiple launches of your app.

  * Here is the syntax for this method:

    ```objective-c
    + (NSDictionary *) audienceVisitorProfile;
    ```

  * Here is the code sample for this menu:

    ```objective-c
    NSDictionary *profile = [ADBMobile audienceVisitorProfile]; 
    ```

* **audienceDpid**

  Returns the current DPID.

  * Here is the syntax for this method:

    ```objective-c
    +(NSString *) audience Dpid;
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSString *currentDpid = [ADBMobileaudience Dpid]; 
    ``` 

* **audienceDpuuid**

  Returns the current DPUUID.

  * Here is the syntax for this method:

    ```objective-c
    +(NSString *) audienceDpuuid;
    ```

  * Here is the code sample for this method:

    ```objective-c
    NSString *currentDpuuid = [ADBMobileaudience Dpuuid]; 
    ```

* **audienceSetDpid:​dpuuid:**

  Sets the DPID and DPUUID. When set, both will be appended to each signal.
 
  * The **Data Provider ID (DPID)** is the data partner ID that is assigned by Audience Manager.  
  * The **Data Provider Unique User ID (DPUUID)** is the data provider's unique ID for the user. 

    > **Important:** Before version 4.13.x, DPUUID was not automatically encoded. Starting in version 4.13.x, the SDK first un-encodes the value that was passed in and then re-encodes this value. This process ensures that the SDK does not break backwards compatibility. 

  * Here is the syntax for this method:

    ```objective-c
    + (void) audienceSetDpid: (NSString*)   
                    dpiddpuuid:(NSString*)dpuuid;
    ```

  * Here is the code sample for this method:

    ```objective-
    [ADBMobile audienceSetDpid:@"290"
                      dpuuid:@"99301393920493"];
    ```

* **audienceReset**

  Resets the Audience Manager UUID and purges the current visitor profile. 

  * Here is the syntax for this method:

    ```objective-c
    +(void) audienceReset;
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile audienceReset]; 
    ```

* **audienceSignalWithData::​callback:**

  Sends audience management a signal with traits and gets the matching segments that are returned in a block callback.

  * Here is the syntax for this method:

    ```objective-c
    + (void) audienceSignalWithData:(NSDictionary*)data
                          callback:(void(^)(NSDictionary
    *response))callback; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile audienceSignalWithData:traits
                             callback:^(NSDictionary*response){
                               //do something with returned segments
                             }];
    ```

## Example

```objective-c
// setup your traits dictionary 
NSDictionary *traits = @{@"trait":@"b"}; 
// submit your signal and take action on results 
[ADBMobile audienceSignalWithData:traits  
                         callback:^(NSDictionary *response) { 
                             // do something with visitor segments here 
                             if ([response[@"gender"] isEqualToString:@"male"]) { 
                             // do something with gender  
                             } 
                         }];
```
