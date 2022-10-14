# Target methods for Android

Here is the list of Adobe Target methods that are provided by the Android library.

The SDK currently supports multiple Adobe Experience Cloud Solutions, including Analytics, Target, Audience Manager, and the Adobe Experience Platform Identity Service. Methods are prefixed according to the solution. For example, Experience Cloud ID methods are prefixed with `target`.

> **Tip:** [Lifecycle Metrics](/docs/android/metrics.md) are sent as parameters to each mbox load.

## Class reference : TargetLocationRequest

**Properties:**

```java
public String name; 
public String defaultContent; 
public HashMap<String, Object> parameters;
```

**String constants**

> **Tip:** The following constants are for ease of use when you set keys for custom parameters.

```java
public static final String TARGET_PARAMETER_ORDER_ID   = "orderId"; 
public static final String TARGET_PARAMETER_ORDER_TOTAL         = "orderTotal"; 
public static final String TARGET_PARAMETER_PRODUCT_PURCHASE_ID = "productPurchasedId"; 
public static final String TARGET_PARAMETER_CATEGORY_ID         = "categoryId"; 
public static final String TARGET_PARAMETER_MBOX_3RDPARTY_ID    = "mbox3rdPartyId"; 
public static final String TARGET_PARAMETER_MBOX_PAGE_VALUE     = "mboxPageValue"; 
public static final String TARGET_PARAMETER_MBOX_PC             = "mboxPC"; // pcId in cookie 
public static final String TARGET_PARAMETER_MBOX_SESSION_ID     = "mboxSession"; // sessionId in cookie 
public static final String TARGET_PARAMETER_MBOX_HOST           = "mboxHost";
```

> **Important:** * If you are using SDKs **before** version 4.14.0, see [https://developers.adobetarget.com/api/#input-parameters](https://developers.adobetarget.com/api/#input-parameters) for parameters limitations. 
>
>* If you are using SDKs version 4.14.0 **or later**, see [https://developers.adobetarget.com/api/#batch-input-parameters](https://developers.adobetarget.com/api/#batch-input-parameters) for parameters limitations. 

* **loadRequest**

  Sends request to your configured Target server and returns the string value of the offer that is generated in a block callback.

  * Here is the syntax for this method: 

    ```java
    public static void loadRequest(TargetLocationRequest request, TargetCallback<String> callback);
    ```

  * Here is the code sample for this method: 

    ```java
    Target.loadRequest(heroBannerRequest, new Target.TargetCallback<String>() {  @Override  public void call(String item) {   // do something with item  } });
    ```

* **loadRequest**

  Sends request to your configured Target server and returns the string value of the offer that is generated in a block callback.

  * Here is the syntax for this method:

    ```java
    public static void loadRequest(final String name final String defaultContent, final Map `<String, Object>` profileParameters, 
                                   final Map `<String, Object>` orderParameters,final Map `<String Object>` mboxParameters, final TargetCallback<String> callback)
    ```

  * Here is the code sample for this method:

    ```java
    Map `<String, Object>` profileParameters = new HashMap `<String, Object>`(); profileParameters.put("profile-parameter-key", "profile-parameter-value"); 
    Map `<String, Object>` orderParameters = new HashMap `<String, Object>`(); orderParameters.put("order-parameter-key", "order-parameter-value");
    Map `<String, Object>` mboxParameters = new HashMap `<String, Object>`(); 
    mboxParameters.put("mbox-parameter-key", "mbox-parameter-value"); 
    Target.loadRequest("mboxName", "defaultContent", profileParameters, orderParameters, mboxParameters
    new TargetCallback<String>() {
        @Override
        public void call (String item) {
           Log.d("Target Content", item); 
        }
    });
    ```

* **loadRequest**

  Sends a request to your configured Target server and returns the string value of the offer that is generated in a TargetCallback.

  * Here is the syntax for this method: 

    ```java
    public static void loadRequest(final String name, final String defaultContent, final Map<String, Object> profileParameters, final Map<String, Object> orderParameters, final Map<String, Object> mboxParameters, final Map<String, Object> requestLocationParameters, final TargetCallback<String> callback);
    ```

  * **Returns:** N/A

  * **Parameters:**

    Here are the parameters for this method:

    * **name**

      Name of the Target mbox/location that you want to retrieve.

      * **Type:** String

    * **defaultContent**

      Value returned in the callback if the Target server is unreachable, or the user does not qualify for the campaign.

      * **Type:** String

    * **profileParameters**

      Values in this dictionary will go in the "profileParameters" object in the request to Target.

      * **Type:** Map `<String, Object>`

    * **orderParameters**

      Values in this dictionary will go in the "order" object in the request to Target.

      * **Type:** Map `<String, Object>`

    * **mboxParameters**

      Values in this dictionary will go in the request to Target.

      * **Type:** Map `<String, Object>`

    * **requestLocationParameters**

      Values in this dictionary will go in the "requestLocation" object in the request to Target.

      * **Type:** Map `<String, Object>`

    * **callback**

      This method will be called with the content of the offer from the Target server. If the Target server is unreachable or the user does not qualify for the campaign, defaultContent will be returned.

      * **Type:** TargetCallback `<String>`

  * Here is sample code for this method: 

    ```java
    Map `<String, Object>` profileParameters = new HashMap `<String, Object>`(); profileParameters.put("profile-parameter-key", "profile-parameter-value"); 
    Map `<String, Object>` orderParameters = new HashMap `<String, Object>`(); orderParameters.put("order-parameter-key", "order-parameter-value"); 
    Map `<String, Object>` mboxParameters = new HashMap `<String, Object>`(); mboxParameters.put("mbox-parameter-key", "mbox-parameter-value"); 
    Map `<String, Object>` requestLocationParameters = new HashMap `<String, Object>`(); requestLocationParameters.put("request-location-parameter-key", "request-location-parameter-value"); 

    Target.loadRequest("mboxName", "defaultContent", profileParameters, orderParameters, mboxParameters, requestLocationParameters,new TargetCallback<String>() {
       @Override
       public void call (String item) { 
          Log.d("Target Content", item);
       } 
    });
    ```

    For more information about the underlying Target API, see [Load Target requests](https://aep-sdks.gitbook.io/docs/using-mobile-extensions/adobe-target/target-api-reference-deprecated#load-target-requests) in the Target API reference.

* **createOrder​ConfirmRequest**

  Creates a TargetLocationRequest object with the given parameters.

  * Here is the syntax for this method: 

    ```java
    public static TargetLocationRequest createOrderConfirmRequest(String name, String orderId, String orderTotal, String productPurchasedId, Map<String, Object> parameters);
    ```

  * Here is the code sample for this method: 

    ```java
    TargetLocationRequest orderConfirm = Target.createOrderConfirmRequest("orderConfirm", "order", "47.88", "3722", null);
    ```

* **createRequest**

  Creates a TargetLocationRequest object with the given parameters.

  * Here is the syntax for this method:

    ```java
    public static TargetLocationRequest createRequest(String name, String defaultContent, Map<String, Object> parameters);
    ```

  * Here is the code sample for this method: 

    ```java
    TargetLocationRequest heroBannerRequest = Target.createRequest("heroBanner", "default.png", null);
    ```

* **clearCookies**

  Clears any target cookies from your app.

  * Here is the syntax for this method: 

    ```java
    public static void clearCookies();
    ```

  * Here is the code sample for this method: 

    ```java
    Target.clearCookies();
    ```

* **getPcID**

  Returns the pcID.

  * Here is the syntax for this method:

    ```java
    public static String getPcID();
    ```

  * Here is the code sample for this method: 

    ```java
    Target.getPcID();
    ```

* **getSessionID**

  Returns the session ID.

  * Here is the syntax for this method:

    ```java
    public static String getSessionID();
    ```

  * Here is the code sample for this method:

    ```java
    Target.getSessionID();
    ```

* **setThirdPartyID**

  Sets the third-party ID.

  * Here is the syntax for this method:

    ```java
    public static String setThirdPartyID(final String thirdPartyId);
    ```

  * Here is the code sample for this method:

    ```java
    Target.setThirdPartyID("third-party-id");
    ```

* **getThirdPartyID**

  Returns the third-party ID.

  * Here is the syntax for this method:

    ```java
    public static String getThirdPartyID();
    ```

  * Here is the code sample for this method:

    ```java
    String thirdPartyId = Target.getThirdPartyID();
    ```
