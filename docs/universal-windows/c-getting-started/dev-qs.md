# Developer quick start

Here is some information about how to implement the Universal Windows Platform library.

> **Important:** To implement the SDK, you need Visual Studio 2013 or later.

## Get the SDK

After you unzip the [SDK download](https://github.com/Adobe-Marketing-Cloud/mobile-services/releases) file, you will have a separate folder for each supported architecture and platform combination. You will also have an `ADBMobileConfig.json` file. For more information about this file, see [ADBMobileConfig.json config file](/docs/universal-windows/c-configuration/c.json.md).

## Select the correct version

Different `.dll/.winmd` files are provided for each supported architecture (x86, x64, ARM).

> **Important:** The version of `ADBMobile.winmd` does not reflect the version of the library. The `.winmd` file contains only metadata and has a version number of `255.255.255.255`, which is accepted behavior according to Microsoft. For more information, see [How do I add assembly information for a WinRT C++ / CX component dll?](https://social.msdn.microsoft.com/Forums/windowsapps/en-US/6bcccaee-aa53-4770-bd5b-1205977f1ca7/how-do-i-add-assembly-information-for-a-winrt-c-cx-component-dll?forum=winappswithnativecode). To check the version of the library you are using, check the version of the underlying `ADBMobile.dll` file.

## Syntax Differences

The Universal Windows Platform library can be used in several programming languages. The examples in this guide are in WinJS (JavaScript), if you are using a different language, might need to be modified. When you consume winmd methods from winJS, all methods automatically have their first letter lowercased.

The main difference between the implementations is the data structure used for context data. Additionally, when using the SDK in a WinJS project, use an empty string ( `""` or `''`) instead of `null` for empty string values.

## Add the library and config File to your project - C#

1. Launch Visual Studio and open your solution. 
1. In the **Solution Explorer**, right-click **References** and select **Add Reference**. 

1. Select the correct version  of the library and browse to the associated ADBMobile.winmd file.

    For more information, see *Select the correct version* section on this page.

1. Click **Add**. 

1. Verify that the ADBMobile.winmd file is checked in the **Reference Manager** window and click **OK**. 

1. In the **Solution Explorer**, right-click **References** and select **Add Reference**. 

    If you also have a C++ project in your solution, skip this step.

1. In the **Windows** tab on the left, select **Extensions**, select and add **Visual C++ 2015 Runtime for Universal Windows Platform Apps**. 

1. Add the following line to your class: 

   ```csharp
   using ADBMobile;
   ```

1. Right-click your project and click **Add** > **Existing Item**. 

1. Browse to the `ADBMobileConfig.json` file and click **Add**. 

1. Right-click on the `ADBMobileConfig.json` file in your solution and select **Properties**. 

1. Change **Build Action** to **Content**.

## Add the library and config file to your project - C++

1. Launch Visual Studio and open your solution. 
1. In the **Solution Explorer**, right-click your project and select **Add** > **References**. 

1. Select the correct version  of the library and add a reference to the associated ADBMobile.winmd file.

    For more information, see *Select the correct version* section on this page. 

1. Click **Add**. 

1. Verify that `ADBMobile.winmd` is checked in the **Reference Manager** window and click **OK**. 

1. Add the following line to your class: 

   ```c++
   using namespace ADBMobile;
   ```

1. Right-click your project and select **Add** > **Existing Item**. 

1. Browse to `ADBMobileConfig.json` file and click **Add**. 

1. Right-click the `ADBMobileConfig.json` file in your solution and select **Properties**. 

1. On the **General** tab, change **Content** to **Yes** and click **OK**.

## Add the library and config file to your project - WinJS

1. Launch Visual Studio and open your solution. 

1. In the **Solution Explorer**, right-click **References** and select **Add Reference**. 

1. Select the correct version of the library and browse to the associated ADBMobile.winmd file. 

1. Click **Add**. 

1. Verify that the ADBMobile.winmd file is checked in the **Reference Manager** window and click **OK**. 

1. In the **Solution Explorer**, right-click **References** and select **Add Reference**. 

    If you also have a C++ project in your solution, skip this step.

1. In the **Windows** tab on the left, select **Extensions** and select and add **Visual C++ 2015 Runtime for Universal Windows Platform Apps**. 

1. Right-click your project and select **Add** > **Existing Item**. 

1. Browse to the `ADBMobileConfig.json` file and click **Add**. 

1. Right-click the `ADBMobileConfig.json` file in your solution and select **Properties**. 

1. With **File Properties** selected, ensure **Package Action** is set to **Content**.

    For JavaScript projects, the file is set to Content by default.

## Update The ADBMobileConfig.json config file

The `ADBMobileConfig.json` file contains global SDK settings and is located at your project root after you complete the steps in the *Add the library and config file to your project* section. If your `ADBMobileConfig.json` file was not pre-configured by Adobe Mobile Services, you need to update a few values to get started.

Here is an example of an `ADBMobileConfig.json` file:

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

At a minimum, update the following values for the solutions you are using:

* **Adobe Analytics**: `rsids` and `server` 

* **Adobe Target**: `clientCode` 

* **Adobe Audience Manager**: `server`

For more information, see [SDK methods](/docs/universal-windows/c-configuration/methods.md).

## Debugging

To enable debugging for the SDK, call `ADBMobile.Config.setDebugLogging(true);`.

For C Sharp and JavaScript apps, you need to enable native code debugging by completing the following steps (native code debugging is the default setting for C++ apps):

### C Sharp

1. Right-click the project, click  **Properties** > **Debug tab**. 

1. Change the debugger type drop down to **Native Only**.

### JavaScript

1. Right-click the project, click **Properties** > **Configuration Properties** > **Debug tab**. 

1. Change the debugger type drop down to **Native Only**.

That's it! You're now ready to implement Analytics, Target, and Audience Management in your Universal Windows Platform app.
