# Adobe Target for TVML/TVJS

You can leverage Adobe Target in your TVML/TVJS apps by making direct replacements to your .xml files. Designate areas of your page to be replaced by Target content by using the custom ADBTarget XML element.

> **Important:** Before using the `ADBTarget` element in your TVML pages, you must configure your TVML/TVJS app to use the tvOS SDK. For more information, see [Apple TV Implementation with tvOS](/docs/ios/apple-tv-implementation-tvos/apple-tv-implementation-tvos.md).

## Getting started

1. Identify the `.xml` file in which you want to use your Target location. 
1. Add an `ADBTarget` element to the file as a child of the `<document>` element.
1. If Target fails to find your Mbox location, or it times out, the value between your `<ADBTarget>` and `</ADBTarget>` tags is used as default content.

## Configure your mbox in Target

The returned content from Target replaces all content between `<ADBTarget>` and `</ADBTarget>`, including both `ADBTarget` tags.

> **Tip:** You should plan what you want to replace accordingly.

Your use case might be as simple as replacing a string value in a label or as complex as replacing an entire page.

## Configure your ADBTarget element

In the `ADBTarget` element, you must provide the Mbox name in the `mbox` property. You can optionally add custom properties to your request in the `customParameterName="customParameterValue"` format.

* **`mbox`**

  Name of your Mbox location.

  * Property type: String
  * This property is required.

* **`id`**

  The Order ID.

  * Property type: String
  * This property is **not** required.

* **`total`**

  The order total.

  * Property type: String
  * This property is **not** required.

* **`purchasedProductIds`**

  A comma-separated list of purchased product IDs for this order. 
  
  * Here is the code sample for this property:


    ```objective-c
    purchasedProductIds="product1,product2,product3" 
    ```

  * Property type: String
  * This property is **not** required.

* **`mboxParameters`**

  A list of key-value pairs for `mboxParameters`. Each entry in this string is separated by a semicolon, and key-values are separated by a colon. 
  
  * Here is the code sample for this property:

    ```objective-c
    mboxParameters="mboxparameterKey:mboxParameterValue;mboxParameterKey1:mboxParameterValue1;mboxParameterKey2:mboxParameterValue2"
    ```

  * Property type: String
  * This property is **not** required.

* **`customParameterName`**

  The value of this property is `customParameterValue`.

  * Property type: String
  * This property is **not** required.  


## Examples

### Example 1

The following example uses an `ADBTarget` element in the `LandingPage.xml.js` page to replace the contents of an alert:

#### Configure Target

Assume that you have an Mbox location named `landingPage` and the offer content is set to be the following:

```objective-c
<title>My cool landing page</title> 
<description>Thanks for coming to my page</description> 
```

#### Configure landingPage.xml.js

* Here is the configuration for landingPage.xml.js: 

  ```js
  <alertTemplate> 
      <ADBTarget mbox="landingPage">  
          <title>TargetTestPage</title> 
          <description>Load fail or timeout (defaultContent)</description> 
      </ADBTarget>  
  </alertTemplate> 
  ```

* If the request to Target is successful, and your offer content is returned, your page will result with:

  ```objective-c
  <alertTemplate> 
      <title>My cool landing page</title> 
      <description>Thanks for coming to my page</description> 
  </alertTemplate>
  ```

* If the Target server cannot be reached or the request times out, your page will result with:

  ```objective-c
  <alertTemplate> 
      <title>TargetTestPage</title> 
      <description>Load fail or timeout (defaultContent)</description> 
  </alertTemplate>
  ```

### Example 2

The following example illustrates how to add custom data to your `ADBTarget` element. This method lets you create conditional experiences and offer content for this Mbox location in Target: 

```objective-c
<alertTemplate> 
    <ADBTarget mbox="landingPage" customData="custom data" moreCustomData="more custom data"> 
        <title>TargetTestPage</title> 
        <description>Load fail or timeout (defaultContent)</description> 
    </ADBTarget>  
</alertTemplate>
```
