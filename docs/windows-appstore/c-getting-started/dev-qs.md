# Developer quick start

You'll need Visual Studio 2013 or later to implement the SDK.

## Get the SDK

After you unzip the [SDK download](https://github.com/Adobe-Marketing-Cloud/mobile-services/releases), you'll have a separate folder for each supported architecture and platform combination. You will also have an `ADBMobileConfig.json` file that is explained later in this guide.

## Select the correct version

Different `.dll`/ `.winmd` files are provided for each target platform (Windows 8.1, Windows Phone 8.1), and supported architecture (x86, x64, ARM). The files are separated into a folder structure according to the following: 

![](assets/folder-structure.png)

> **Important:** The version of `ADBMobile.winmd` does not reflect the version of the library. The `.winmd` file contains metadata only, and as such will have a version number of `255.255.255.255` which is accepted behavior according to Microsoft (see [How do I add assembly information for a WinRT C++ / CX component dll?](https://social.msdn.microsoft.com/Forums/windowsapps/en-US/6bcccaee-aa53-4770-bd5b-1205977f1ca7/how-do-i-add-assembly-information-for-a-winrt-c-cx-component-dll?forum=winappswithnativecode)). To check the version of the library you are using, check the version of the underlying `ADBMobile.dll` file.

## Syntax differences

The Windows 8.1 Universal App Store library can be used in several programming languages. The examples in this guide are in WinJS (JavaScript), and might need to be modified if you are using a different language. Note that when you consume winmd methods from winJS (JavaScript), all methods automatically have their first letter lowercased.

The main difference between the implementations is the data structure used for context data.

Additionally, when using the SDK in a WinJS project, use an empty string ( `""` or `''`) instead of `null` for empty string values.

## Add the library and config file to your project - C Sharp

1. Launch Visual Studio and open your solution. 
1. In the **Solution Explorer**, right-click **References** and select **Add Reference**. 

1. Select the correct version of the library and browse to the associated `ADBMobile.winmd` file. 

    For more information, see the *Select the correct version* section below.

1. Click **Add**. 

1. Verify that `ADBMobile.winmd` is selected in the **Reference Manager** window and click **OK**. 

   > **Note:** When adding a reference to a Windows Phone app, to select `ADBMobile.winmd`, change the default file filter from **Component Files** to **All Files**.

1. In the **Solution Explorer**, right-click **References** and select **Add Reference**. 

    Skip this step if you also have a C++ project in your solution.

1. In the **Windows** tab on the left, select **Extensions**, then select and add **Microsoft Visual C++ 2013 Runtime Package for Windows**. 

1. Add the following line to your class: 

   ```
   using ADBMobile;
   ```

1. Right-click you your project and select **Add** > **Existing Item**. 

1. Browse to your `ADBMobileConfig.json` file and click **Add**. 

1. Right-click the `ADBMobileConfig.json` file in your solution and select **Properties**. 

1. Change **Build Action** to **Content**.

## Add the library and config file to your project - C++

1. Launch Visual Studio and open your solution. 
1. In the **Solution Explorer**, right-click your project and select **Add** > **References**. 

1. Select the correct version of the library and then add a reference to the associated `ADBMobile.winmd` file. 

    For more information, see the *Select the Correct Version* section below.

1. Click **Add**. 

1. In the **Reference Manager** window, verify that `ADBMobile.winmd` is selected and click **OK**. 

   > **Tip:** When adding a reference to a Windows Phone app, to select `ADBMobile.winmd`, change the default file filter from **Component Files** to **All Files**.

1. Add the following line to your class: 

   ```
   using namespace ADMS::Measurement;
   ```

1. Right-click you your project and select **Add** > **Existing Item**. 

1. Browse to the `ADBMobileConfig.json` file and click **Add**. 

1. Right-click the `ADBMobileConfig.json` file in your solution and select **Properties**. 

1. On the **General** tab, change **Content** to **Yes**, and click **OK**.

## Add the library and config file to your project - WinJS

1. Launch Visual Studio and open your solution. 
1. In the **Solution Explorer**, right-click **References** and select **Add Reference**.

    For more information, see *Select the Correct Version* section below.

1. Select the correct version of the library and then browse to the associated `ADBMobile.winmd` file. 

1. Click **Add**.

1. Verify that `ADBMobile.winmd` is checked in the **Reference Manager** window and click **OK**. 

   > **Tip:** When adding a reference to a Windows Phone app, to select `ADBMobile.winmd`, change the default file filter from **Component Files** to **All Files**.

1. In the **Solution Explorer**, right-click **References** and select **Add Reference**. 

    Skip this step if you also have a C++ project in your solution.

1. In the **Windows** tab on the left, select **Extensions** and select and add **Microsoft Visual C++ 2013 Runtime Package for Windows**. 

1. Right-click your project and select **Add** > **Existing Item**. 

1. Browse to the `ADBMobileConfig.json` file and click **Add**. 

1. Right-click the `ADBMobileConfig.json]` file in your solution and select **Properties**. 

1. With **File Properties** selected, ensure **Package Action** is set to **Content**.

    For JavaScript projects, the file is set to **Content** by default.

## Update the ADBMobileConfig.json config file

The `ADBMobileConfig.json` file contains global SDK settings, and is located at your project root after you complete the steps in the *Add the Library and Config File to your Project* section. If your `ADBMobileConfig.json` file was not pre-configured by Adobe Mobile Services, you need to update a few values to get started.

The following is an example of an `ADBMobileConfig.json` file:

```js
{ 
    "version" : "1.0", 
    "analytics" : { 
        "rsids" : "coolApp", 
        "server" : "my.CoolApp.com", 
        "charset" : "UTF-8", 
        "ssl" : true, 
        "offlineEnabled" : true, 
        "lifecycleTimeout" : 300, 
        "privacyDefault" : "optedin", 
        "poi" : [ 
                    ["san francisco",37.757144,-122.44812,7000], 
                    ["santa cruz",36.972935,-122.01725,600] 
                ] 
    }, 
 "target" : { 
  "clientCode" : "myTargetClientCode", 
  "timeout" : 1 
 }, 
 "audienceManager" : { 
  "server" : "myServer.demdex.com" 
 } 
}
```

At a minimum, update the following values for the Solutions you are using:

* **Analytics**: `rsids` and `server` 
* **Target**: `clientCode` 
* **Audience Management**: `server`

For more details, see [ADBMobileConfig.json config](/docs/windows-appstore/c-configuration/methods.md).

## Debugging

When you want to enable debugging for the SDK, you have to call `ADBMobile.Config.setDebugLogging(true);`.

For C Sharp and JS apps, you have to enable native code debugging by completing the following steps (native code debugging is the default setting for C++ apps):

### C Sharp

Right-click the project, select **Properties** > **Debug tab**. In the debugger drop-down, select **Native Only**.

### JS

Right-click the project, select  **Properties** > **Configuration Properties** > **Debug tab**. Change the debugger type drop down to **Native Only**.

That's it! You're now ready to implement Analytics, Target, and Audience Management in your Windows 8.1 Universal App Store app.
