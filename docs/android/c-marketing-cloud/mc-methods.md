# Adobe Experience Platform Identity Service methods

Here are the Experience Cloud ID methods that are provided by the Android library.

The SDK currently supports multiple Adobe Experience Cloud Solutions, including Analytics, Target, Audience Manager, and the Adobe Experience Platform Identity Service.

Methods are prefixed according to the solution. For example, Experience Cloud ID methods are prefixed with `visitor`. For more information, see [Experience Cloud ID Configuration](/docs/android/c-marketing-cloud/mcvid.md).

* **public static String appendToURL(final String URL)**

  Appends Adobe visitor data to a URL string for use with the Adobe JavaScript library. You must have Mobile SDK 4.12+ to use this method. For more information, see [appendVisitorIDsTo](https://experienceleague.adobe.com/docs/id-service/using/id-service-api/methods/appendvisitorid.html) in the Adobe Experience Cloud Identity Service documentation.
  
  > **Important:** This method can cause a blocking network call. Do not call this on time-sensitive threads.
  
  * Here is the syntax for this method:

    ```java
    public static String appendToURL(final String URL) 
    ```

    A required URL string to which the visitor information is appended.  

  * Here is the code sample for this method:

    ```java
    String urlSample = "https://example.com";`
            String urlWithAdobeVisitorInfo = Visitor.appendToURL(urlSample);

            Intent(Intent.ACTION_VIEW);
            i.setData(Uri.parse(urlWithAdobeVisitorInfo));
            startActivity(i);
    ```

* **getMarketingCloudId**

  Retrieves the Experience Cloud ID from the visitor ID service.

  * Here is the syntax for this method:

    ```java
    public static String getMarketingCloudId(); 
    ```

  * Here is the code sample for this method:

    ```java
    String = Visitor.getMarketingCloudId();
    ```

    > **Important:** This method can cause a blocking network call and should **not** be called from a UI thread.

* **syncIdentifiers**

  With the Experience Cloud ID, you can set additional customer IDs that can be associated with each visitor. The Visitor API accepts multiple customer IDs for the same visitor, with a customer type identifier to separate the scope of the different customer IDs. This method corresponds to `setCustomerIDs` in the JavaScript library.

  * Here is the syntax for this method:

    ```java
    public static void syncIdentifiers(Map<String, String> identifiers); 
    ```

  * Here is the code sample for this method:

    ```java
    Map<String,String> identifiers = new HashMap<String, String>();
    identifiers.put("idType", "idValue");
    Visitor.syncIdentifiers(identifiers);
    ```

* **syncIdentifier**

  Synchronizes the provided identifier type and value to the Visitor ID service.
  
  Pass in the `authenticationState` as one of the following values:  
  
  * `VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_UNKNOWN` 
  * `VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_AUTHENTICATED` 
  * `VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_LOGGED_OUT`

  * Here is the syntax for this method:

    ```java
    public static void syncIdentifier(final String identifierType, final String identifier, final VisitorID.VisitorIDAuthenticationState authenticationState);
    ```

  * Here is the code sample for this method:

    ```java
    Visitor.syncIdentifier("myIdType", "valueForUser", VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_LOGGED_OUT);
    ```

* **syncIdentifiers**

  Synchronizes the provided identifiers to the ID service.
  
  Pass in the `authenticationState` as one of the following values:
  * `VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_UNKNOWN`
  * `VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_AUTHENTICATED`
  * `VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_LOGGED_OUT`

  * Here is the syntax for this method:

    ```java
    public static void syncIdentifiers(final Map<String String> identifiers, final VisitorID.VisitorIDAuthenticationState authenticationState);
    ```

  * Here is the code sample for this method:

    ```java
    Map<String, String> identifiers = new HashMap<String, String>();
        identifiers.put("myIdType", "valueForUser"); Visitor.syncIdentifiers(identifiers,
    VisitorID.VisitorIDAuthenticationState.VISITOR_ID_AUTHENTICATION_STATE_AUTHENTICATED); 
    ```

* **getIdentifiers**

  Retrieves a list of read-only `ADBVisitorID` objects.

  * Here is the syntax for this method:

    ```java
    public static List<VisitorID> getIdentifiers(); 
    ```

  * Here is the code sample for this method:

    ```java
    List<VisitorID> myVisitorIDs = Visitor.getIdentifiers(); 
    ```

* **getUrlVariablesAsync**

   Introduced in version 4.16.0, this method returns an appropriately formed string that contains Visitor ID Service URL variables. For more information about how this method is used, see [Adobe Experience Platform Identity Service methods](/docs/android/reference/hybrid-app.md).

  * Here is the syntax for this method:

    ```java
    public static void getUrlVariablesAsync(final VisitorCallback callback);
    ```

  * Here is the code sample for this method:

    ```java
    final String urlString = https://www.mydomain.com/index.php; 
    Visitor.getUrlVariablesAsync(new Visitor.VisitorCallback(){ 
      @Override 
      public void call(String urlVariables) { 
          final String urlStringWithVisitorData = String.format("%s?%s", urlString, urlVariables); 
          ...
      } 
    });
    ```

## Public methods

```java
public class VisitorID { 
    public final String idOrigin; 
    public final String idType; 
    public final String id; 
    public VisitorIDAuthenticationState authenticationState; 
 
    public enum VisitorIDAuthenticationState { 
         VISITOR_ID_AUTHENTICATION_STATE_UNKNOWN(0), 
         VISITOR_ID_AUTHENTICATION_STATE_AUTHENTICATED(1), 
         VISITOR_ID_AUTHENTICATION_STATE_LOGGED_OUT(2); 
    } 
}
```
