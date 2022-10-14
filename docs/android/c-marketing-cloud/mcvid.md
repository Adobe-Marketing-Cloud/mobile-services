# Experience Cloud ID configuration

The Adobe Experience Platform Identity Service provides a universal visitor ID across Experience Cloud solutions. The ID service is required by Analytics for Target, video heartbeat, and future Experience Cloud integrations.

> **Tip:** You do not need to populate this ID unless you are using the Adobe Experience Platform Identity Service. For more information, see [Adobe Experience Platform Identity Service](https://experienceleague.adobe.com/docs/id-service/using/home.html).

> **Important:** This functionality requires SDK version 4.3 or later.

To enable the Experience Cloud ID:

1. Add the library to your project and implement lifecycle.

   For more information, see *Add the SDK and Config File to your IntelliJ IDEA or Eclipse Project* in [Core implementation and lifecycle](/docs/android/getting-started/dev-qs.md). 

1. Import the library: 

   ```java
   import com.adobe.mobile.*;
   ```

1. Verify that the `ADBMobileConfig.json` file contains the `marketingCloudorg`: 

   ```js
   "marketingCloud" : { 
     "org": "YOUR-MCORG-ID" 
   }
   ```

   Experience Cloud organization IDs uniquely identify each client company in the Adobe Experience Cloud and are similar to the following value:  

   ```js
   016D5C175213CCA80A490D05@AdobeOrg`
   ```

   > **Important:** You must include `@AdobeOrg`.

   If these IDs are not configured, download an updated `ADBMobileConfig.json` file from Adobe Mobile services. For more information, see [Before You Start](/docs/android/getting-started/requirements.md).

After the configuration is complete, a Experience Cloud ID is generated and is included on all hits. Other IDs, such as custom and automatically-generated IDs, continue to be sent with each hit.
