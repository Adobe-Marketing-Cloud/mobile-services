# Before you start

Before configuring a report suite and collecting Android app data, complete the following prerequisite tasks:

## Role-specific tasks

Analytics administrators and app developers must complete the following tasks:

### Analytics administrators

To configure a report suite and collect mobile app data:

1. Complete one of the sections in [Log in to the Adobe Mobile Services UI](../getting-started/requirements.md#section_690A2EC4572E47869F183974E932A6A8). 
1. Create an Analytics account for each app developer.

App developers now have access to view the report suite(s) that you created.

> **Important:** To create a new report suite and download the SDKs, you must be an Analytics Administrator.

### App developers

1. Ensure that your Analytics administrator has completed the steps in the *Analytics Administrators* in [Role-Specific Tasks](../getting-started/requirements.md#section_8B9EA1FA189F4C6DB7D829F0B5844FBC).
1. Verify that your Analytics administrator has completed one of the sections in [Log in to the Adobe Mobile Services UI](../getting-started/requirements.md#section_690A2EC4572E47869F183974E932A6A8).
1. After the report suite has been configured, complete steps in the [Download the SDK](../getting-started/requirements.md#section_044C17DF82BC4FD8A3E409C456CE9A46).

For more information about roles and permissions, see [Roles and Permissions](https://experienceleague.adobe.com/docs/mobile-services/using/get-started-ug/c-mob-roles-and-permissions.html).

## Log in to the Adobe Mobile Services UI

Adobe Mobile services is the primary reporting interface for mobile app analytics and targeting. After you complete these steps, you can download a configuration file that is pre-configured with your data collection server, report suite, and many other settings.

You can log in to the Adobe Mobile Services UI in one of the following ways:

### Experience Cloud

  Sign in to the [Experience Cloud](https://experiencecloud.adobe.com) with your Adobe ID. This method assumes that your company has been provisioned in the Experience Cloud, and you have linked your Analytics account. For more information, see [Manage Experience Cloud users and products](https://experienceleague.adobe.com/docs/core-services/interface/administration/admin-getting-started.html) in the Experience Cloud Central Interface Components guide.

  > **Tip:** If you are unsure whether your company has been provisioned in the Experience Cloud, use your existing Adobe Analytics account.

### Adobe Analytics

  Click **Sign in with Analytics** and enter your Analytics company name, your username, and your password.

## Create a report suite

To create a report suite to collect app data and define an app:

1. Log in to [Adobe Mobile Services](https://mobilemarketing.adobe.com).
1. Click **Create an App**.

   If you do not see this button, click **Manage Apps** > **Add**. 

1. In the **Report Suite** drop-down, select **New Report Suite**. 

1. Enter the name of your app and select a report suite type.

   An example of a report suite ID is `mycomobileappdev`. You need to set up separate report suites and apps for the development and production versions, so you can repeat these steps when you are ready to set up the production version. 
1. In **Report Suite ID**, verify that your report suite name is displayed. 
1. In **Copy Settings From**, verify that **Mobile App Template** is selected.

   This template enables timestamps to collect offline data and activates the mobile solution variables to capture lifecycle metrics. 

1. Select your time zone, your currency, and click **Save**.

## Download the SDK

To download the mobile SDK:

1. log in to the Mobile Services UI by typing [https://mobilemarketing.adobe.com/](https://mobilemarketing.adobe.com/) in a browser.
1. In the left pane, click the **All Apps** drop-down list and select your app.
    You can also select your app in the right pane. 

      > **Important:** To see your app displayed on the right pane, you must first create an app. For information about creating an app, see [Add a new app](https://experienceleague.adobe.com/docs/mobile-services/using/manage-apps-ug/t-new-app.html).

1. In your app, in the left pane, click **Manage App Settings**.

    > **Important:** If you do not see the **Manage App Settings** option, ensure that you are logged into Adobe Mobile Services. To verify, click the ![solution switcher](assets/solution-switcher.png) icon in the top right side of the page and ensure that **Adobe Mobile Services** is displayed in the top left side.

1. At the bottom of the Manage App Settings page, in the **App SDK Downloads** section, download the SDK and the sample app for your platform.

> **Tip:** A config file for your app is automatically included in the SDK download, so you do not need to download that file separately. However, if you already downloaded the SDK, and you want to get updated settings, download the config file again.

If you are using Android Studio, you can also add the following to your app's `build.gradle` file:

```java
compile 'com.adobe.mobile:adobeMobileLibrary:4.13.7'
```

Remember the following information:

* Replace the version number in the code sample with the appropriate version of the Android SDKs.
* Download the config file and include it in your project.
