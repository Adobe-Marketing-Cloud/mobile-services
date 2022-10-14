# Audience Manager methods

List of Audience Manager methods provided by the Universal Windows Platform library.

The SDK currently has support for multiple Adobe Experience Cloud Solutions, including Analytics, Target, and Audience Manager. Methods are prefixed according to the solution. Audience Manager methods are prefixed with `AudienceManager`.

> **Tip:** When you consume `winmd` methods from winJS (JavaScript), all methods automatically have their first letter lowercased.

If audience manager is configured in your JSON file, a signal that contains lifecycle metrics is sent in with your lifecycle hit. 

* **GetVisitorProfile (winJS: getVisitorProfile)**

  Returns the visitor profile that was most recently obtained. Returns `null` if no signal has been submitted yet. Visitor profile is saved in `SharedPreferences` for easy access across multiple launches of your app.

  * Here is the syntax for this method:

    ```csharp
    static Windows::Foundation::Collections::IMap<Platform::String^,Platform::Object^> ^GetVisitorProfile();
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile; 
    var profile = ADB.AudienceManager.getVisitorProfile();
    ```

* **GetDpid (winJS: getDpid)**

  Returns the current DPID.

  * Here is the syntax for this method:

    ```csharp
    static Platform::String ^GetDpid();
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile;
    var dpid = ADB.AudienceManager.getDpid(); 
    ```

* **GetDpuuid (winJS: getDpuuid)**

  Returns the current DPUUID. 

  * Here is the syntax for this method:

    ```csharp
    static Platform::String ^GetDpuuid();
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile; 
    var dpuuid = ADB.AudienceManager.getDpuuid();
    ```

* **SetDpidAndDpuuid (winJS: setDpidAndDpuuid)**

  Sets the DPID and DPUUID. If DPID and DPUUID are set, they will be sent with each signal. 

  * Here is the syntax for this method:

    ```csharp
    static void SetDpidAndDpuuid(Platform::String ^dpid, Platform::String ^dpuuid);
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile; 
    ADB.AudienceManager.setDpidAndDpuuid("newDpid", "newDpuuid");
    ```

* **SignalWithData (winJS: signalWithData)**

  Sends audience management a signal with traits and get the matching segments returned in a block callback. 

  * Here is the syntax for this method:

    ```csharp
    static 
    Windows::Foundation::IAsyncOperation<Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object^> ^> ^SignalWithData(Windows::Foundation::Collections::IMap<Platform::String^,Platform::Object> ^data);
    ```

  * Here is the code sample for this method:

    ```js
    var ADB = ADBMobile;
    var traits = new Windows.Foundation.Collections.PropertySet(); 
    traits["trait"] = "b";
    ADB.AudienceManager.signalWithData(traits).then(function (visitorProfile) { 
      // segments come back here in "visitorProfile", normally found in the "segs" object of your json 
    });
    ```
