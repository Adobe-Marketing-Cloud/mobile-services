# Acquisition methods

The following Acquisition method is provided by the Android library:

* **campaignStartForApp**

  Allows developers to start an app acquisition campaign as if the user clicked a link. This is helpful for creating manual acquisition links and handling the app store redirect yourself. 

  * Here is the syntax for this method:

    ```java
    public static void campaignStartForApp(final String appId final Map<String Object> data); 
    ```

  * Here is the code sample for this method:

    ```java
    Acquisition.campaignStartForApp("0652024f-adcd-49f9-9bd7-2552a4564d2f" new 
    HashMap<String Object (){{
         put("custom.key" "value");
    }}); 
    ```
