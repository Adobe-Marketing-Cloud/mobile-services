# Troubleshoot in-app messaging

This information helps you troubleshoot in-app messaging.

 If you have completed all the requirements for In-App Messaging, but messages do not display, check the following items: 

## Are you putting the new configuration and new SDK in the app?
  
Ensure that you have an [In-App Messaging](/docs/android/messaging-main/messaging/messaging.md) section in your configuration (downloaded JSON file) or have a Messages remote endpoint, so that it can be retrieved from dynamic tag management. 

## My full screen message in Android is not showing up. I am using the correct SDK, configuration, and my triggers are being met.

Did you update your manifest file to define the full screen activity?

## My local notification message in Android is not working.

Ensure that the local notification broadcast receiver is declared in your manifest. For more information, see step 2 in *Enabling In-App Messaging* in [In-App Messaging](/docs/android/messaging-main/messaging/messaging.md). 

## Is the message live?

To verify whether your message is live, on the Manage In-App Message page, in the **Status** column, check the list of messages. 

## Look at *show once*, *show always*, *show offline*  settings on the Audience tab.

Verify that these settings are set the way you want. On the **Audience** tab, review your **Trigger** options, which allow you to specify how often the message is shown. 

## If using a launch event as the trigger...

Launch only fires on a new session. For more information about when a session begins, see the `lifecycleTimeout` row in [JSON Config](/docs/android/configuration/json-config/json-config.md).

## I updated my message remotely, but my app is still showing the old message.

Remember the following information:

* Dynamic tag management can take a few minutes to update its endpoint with your new definition. Wait for some time and try again. 
* The config will only update on a new launch. If the app was restarted during the life cycle session timeout, your new config might not have been downloaded. 

For more information, see [Lifecycle Metrics](/docs/android/metrics.md). 

## My image does not fit exactly into the space provided by the template.

The In-App Message full-screen template supports displaying an image from a remote server (Image URL) or from the app bundle (Bundled Image). The image should be in a standard image format, such as JPG, GIF or PNG. Because device screens have many different dimensions, the image will most likely not fit exactly into the space provided by the template. The template focuses on showing the center of the image and, if the image does not fit, crops (portrait) or fades (landscape)the sides. 
  
Here is the exact placement and sizing rules for each orientation: 

* **Portrait** 
  * A height of 195px for phones. 
  * A height of 529px for tablets. 
  * Centered if the image width is smaller than the device width.  
  * Cropped if the image width is greater than the device width.  

* **Landscape** 
  * The image scaled to 100% of the height of the device.  
  * The width is 75% of the device, with a fade out on the right.
  
  If you have issues with the full-screen template, you can download and use the Custom HTML template. This template provides more flexibility for images and allows full control of the template.
