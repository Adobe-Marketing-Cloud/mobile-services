# Target methods

List of Target methods provided by the Universal Windows Platform library.

The SDK currently has support for multiple Adobe Experience Cloud Solutions, including Analytics, Target, and Audience Manager.

[Lifecycle metrics](/docs/universal-windows/metrics.md) are sent as parameters to each mbox load.

> **Tip:** When you consume `winmd` methods from winJS (JavaScript), all methods automatically have their first letter lowercased.

## Class Reference: TargetLocationRequest

## Properties

```
property Platform::String ^name; 
property Platform::String ^defaultContent; 
property Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object^> ^parameters;
```

## String Constants

This information helps you set keys for custom parameters.

```
static property Platform::String ^TARGET_PARAMETER_ORDER_ID { 
  Platform::String ^get() { return L"orderId"; } 
} 
static property Platform::String ^TARGET_PARAMETER_ORDER_TOTAL { 
  Platform::String ^get() { return L"orderTotal"; } 
} 
static property Platform::String ^TARGET_PARAMETER_PRODUCT_PURCHASE_ID { 
  Platform::String ^get() { return L"productPurchasedId"; } 
} 
static property Platform::String ^TARGET_PARAMETER_CATEGORY_ID { 
  Platform::String ^get() { return L"categoryId"; } 
} 
static property Platform::String ^TARGET_PARAMETER_MBOX_3RDPARTY_ID { 
  Platform::String ^get() { return L"mbox3rdPartyId"; } 
} 
static property Platform::String ^TARGET_PARAMETER_MBOX_PAGE_VALUE { 
  Platform::String ^get() { return L"mboxPageValue"; } 
} 
static property Platform::String ^TARGET_PARAMETER_MBOX_PC { 
  Platform::String ^get() { return L"mboxPC"; } 
} 
static property Platform::String ^TARGET_PARAMETER_MBOX_SESSION_ID { 
  Platform::String ^get() { return L"mboxSession"; } 
} 
static property Platform::String ^TARGET_PARAMETER_MBOX_HOST { 
  Platform::String ^get() { return L"mboxHost"; } 
}
```

* **LoadRequest (winJS: loadRequest)**

  Sends `request` to your configured Target server and returns the string value of the offer generated in a block `callback`.

  * Here is the syntax for this method:

    ```csharp
    static Windows::Foundation::IAsyncOperation<Platform::String ^> ^LoadRequest(TargetLocationRequest ^request);
    ```

  * Here is the code sample for this method:

    ```js
    var fADB = ADBMobile; 
     ADB.Target.loadRequest(heroBannerRequest).then(function(content){ 
        //do something with content returned from target server 
     });
    ```

* **CreateRequest (winJS: createRequest)**

  Creates a `TargetLocationRequest` object with the given parameters.

  * Here is the syntax for this method:

    ```csharp
    static TargetLocationRequest ^CreateRequest(Platform::String ^name, Platform::String ^defaultContent,Windows::Foundation::Collections::IMap<Platform::String^,Platform::Object^> ^parameters); 
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile;
    var heroBannerRequest = ADB.Target.createRequest("heroBanner","default.png", null); 
    ```

* **CreateOrder​ConfirmRequest (winJS: createOrder​ConfirmRequest)**

  Creates a `TargetLocationRequest` object with the given parameters.

  * Here is the syntax for this method:

    ```csharp
    static TargetLocationRequest ^CreateOrderConfirmRequest(Platform::String ^name, Platform::String ^orderId,Platform::String ^orderTotal,Platform::String ^productPurchasedId,Windows::Foundation::Collections::IMap<Platform::String^,Platform::Object^> ^parameters); 
    ```

  * Here is the code sample for this method:

    ```js
    varADB = ADBMobile;
    var orderConfirm = ADB.Target.createOrderConfirmRequest("orderConfirm","order","47.88","3722",null);
    ```

* **ClearCookies (winJS: clearCookies)**

  Clears Target cookies for the application on current device.

  * Here is the syntax for this method:

    ```csharp
    static void ClearCookies();
    ```

  * Here is the code sample for this method:

    ```js
    ADBMobile.Target.clearCookies();
    ```

* **GetPcId (winJS: getPcId)**

  Returns the PC ID cookie for the current device.

  * Here is the syntax for this method:

    ```csharp
    staticPlatform::String ^GetPcId();
    ```

  * Here is the code sample for this method:

    ```js
    autopcId = ADBMobile.Target.getPcId();
    ```

* **GetSessionId (winJS: getSessionId)**

  Returns the Session ID cookie for the current device.

  * Here is the syntax for this method:

    ```csharp
    staticPlatform::String ^GetSessionId();
    ```

  * Here is the code sample for this method:

    ```js
     autosessionId=ADBMobile.Target.getSessionId(); 
    ```
