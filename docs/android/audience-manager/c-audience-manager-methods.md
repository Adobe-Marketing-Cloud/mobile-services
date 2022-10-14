# Audience Manager methods

Here is a list of the Audience Manager methods that are provided by the Android library.

The SDK currently supports multiple Adobe Experience Cloud Solutions, including Analytics, Target, Audience Manager, and the Adobe Experience Platform Identity Service. Methods are prefixed according to the solution. For example, Experience Cloud ID methods are prefixed with `audience manager`.

If Audience Manager is configured in your JSON file, a signal that contains lifecycle metrics is sent with your lifecycle hit. 

* **getVisitorProfile**

  Returns the visitor profile that was most recently obtained and, if no signal has been submitted, returns `null`. The visitor profile is saved in `SharedPreferences` for easy access across multiple launches of your app.

  * Here is the syntax for this method:

    ```java
    public static HashMap<String, Object> getVisitorProfile(); 
    ```

  * Here is the code sample for this method:

    ```java
    HashMap<String, Object> visitorProfile = AudienceManager.getVisitorProfile(); 
    ```

* **getDpid**

  Returns the current DPID. 

  * Here is the syntax for this method:

    ```java
    public static void getDpid(); 
    ```

  * Here is the code sample for this method:

    ```java
    String dpid = AudienceManager.getDpid(); 
    ```

* **getDpuuid**
 
  Returns the current DPUUID. 

  * Here is the syntax for this method:

    ```java
    public static void getDpuuid(); 
    ``` 

  * Here is the code sample for this method:

     ```java
     String dpuuid = AudienceManager.getDpuuid(); 
     ```

* **setDpidAndDpuuid**
  
  Sets the DPID and DPUUID, and these values are sent with each signal. 

  If the DPUUID value that is passed to this method contains characters that are not URL-safe, customers must encode the parameter before passing it to the SDK. 

  * Here is the syntax for this method:

    ```java
    public static void setDpidAndDpuuid(String dpid, String dpuuid); 
    ```

  * Here is the code sample for this method:

    ```java
    AudienceManager.setDpidAndDpuuid("myDpid", "myDpuuid"); 
    ```

* **signalWithData**

  Sends audience management a signal with traits and gets the matching segments returned in a block callback. 

  * Here is the syntax for this method:

    ```java
    public static void signalWithData(Map<String, Object> data, AudienceManagerCallback<Map<String, Object>> callback);
    ```

  * Here is the code sample for this method:

    ```java
    HashMap Traits = new HashMap<String, Object>();
    aamTraits.put("trait", "b");
    AudienceManager.signalWithData(aamTraits, new AudienceManager.AudienceManagerCallback<Map<String, Object>> () {
      @Override
       public void call(Map<String, Object> item) { 
            // segments come back here normally found in the segs object of your json 
       }
    });
    ```
