# Experience Cloud ID

The Adobe Experience Platform Identity Service provides a universal visitor ID across Experience Cloud solutions. The ID service is required by Analytics for Target, video heartbeat, and future Experience Cloud integrations.

> **Tip:** You do not need to populate the Experience Cloud ID unless you are using the Adobe Experience Platform Identity Service. For more information, see the [Adobe Experience Platform Identity Service](https://experienceleague.adobe.com/docs/id-service/using/home.html) documentation.

## Enable the Experience Cloud ID

These steps require an SDK version 4.3 or later.

1. Add the library to your project and implement lifecycle.

   For more information, see *Add the SDK and Config File to your Project* in [Core Implementation and Lifecycle](/docs/ios/getting-started/dev-qs.md).
1. Import the library:

   ```objective-c
   #import "ADBMobile.h"
   ```

1. Verify that the `ADBMobileConfig.json` files contains the `marketingCloud` `org`:

   ```js
   "marketingCloud" : { 
     "org": "YOUR-MCORG-ID" 
   }
   ```

   Experience Cloud organization IDs uniquely identify each client company in the Adobe Experience Cloud and are similar to the following value: `016D5C175213CCA80A490D05@AdobeOrg`.

   > **Important:** You must include `@AdobeOrg`.

   If these values are not present, download an updated `ADBMobileConfig.json` file from Adobe Mobile services. For more information, see [ADBMobile JSON config](/docs/ios/getting-started/requirements.md).

After the configuration, a Experience Cloud ID is generated and is included on all hits. Other visitor IDs, such as custom and automatically-generated, will continue to be sent with each hit.
