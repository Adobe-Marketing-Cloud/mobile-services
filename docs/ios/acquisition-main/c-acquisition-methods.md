# Acquisition methods

The following Acquisition methods are provided by the iOS library:

The following method is supported:

* **acquisitionCampaignStartForApp:data:**

  Allows developers to start an app acquisition campaign as if the user had clicked a link. This is helpful for creating manual acquisition links and handling the app store redirect yourself, such as with an `SKStoreView`.

  * Here is the syntax for this method:

    ```objective-c
    + (void)acquisitionCampaignStartForApp:(NSString *) appId data:(NSDictionary *)data; 
    ```

  * Here is the code sample for this method:

    ```objective-c
    [ADBMobile acquisitionCampaignStartForApp:@"0652024f-adcd-49f9-9bd7-2552a4564d2f" data:@{@"custom.key":@"value"}]; 
    ```
