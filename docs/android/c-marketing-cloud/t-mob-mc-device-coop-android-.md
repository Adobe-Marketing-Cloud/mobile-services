# Experience Cloud Device Co-op

To start using the Experience Cloud Device Co-op, contact your Adobe representative.

To enable your mobile apps for the Experience Cloud Device Co-op, complete the following steps for the Experience Cloud Android SDKs:

> **Important:** This functionality requires Android SDK version 4.8.3 or later.

Starting in SDK version 4.16.1, Device Co-op members can opt their mobile device data out of the Experience Cloud Device Co-op. For more information see [ADBMobile JSON Config](/docs/android/configuration/json-config/json-config.md) and the `visitorAPI.js` method for [isCoopSafe](https://experienceleague.adobe.com/docs/id-service/using/id-service-api/configurations/coopsafe.html).

1. Implement the Adobe Mobile SDK.

   For more information, see [Core Implementation and Lifecycle](/docs/android/getting-started/dev-qs.md).
1. Enable your Experience Cloud ID.

   For more information, see [Experience Cloud ID Configuration](/docs/android/c-marketing-cloud/mcvid.md).
1. Pass authenticated identities such as CRM IDs or hashed emails, by using one of the sync methods.

   For more information, see [Adobe Experience Platform Identity Service Methods](/docs/android/c-marketing-cloud/mc-methods.md). 

## `coopUnsafe` flag

Here is some additional information about the `coopUnsafe` flag:

* Minimum SDK version:  4.16.1
* The Boolean property of the `marketingCloud` object that, when set to `true`, causes the device to be opted-out of the Experience Cloud's Device Co-Op. 
* Default value is `false`. 
* This setting is used **only** for Device Co-op provisioned customers.  

For Device Co-op members who require this value set to `true`, you need to work with the Co-op team to request a blocklist flag on your Device Co-op account. There is no self-service path to enabling these flags.

Remember the following information: 

* When `coopUnsafe` is set to `true`, `coop_unsafe=1` will always be appended to Audience Manager and Visitor ID hits.
* If you enable Analytics server-side forwarding to Audience Manager, you will also see `coop_unsafe=1` Analytics hits.
