# Before you start

Complete these steps to configure a report suite to collect iOS app data.

## Role-specific tasks

Analytics administrators and app developers must complete the following tasks:

### Analytics administrators

To configure a report suite and collect mobile app data:

1. Complete one of the sections in [Log in to the Adobe Mobile Services UI](/docs/ios/getting-started/getting-started.md).
1. Create an Analytics account for each app developer.

App developers now have access to view the report suite(s) that you created.

> **Important:** To create a new report suite and download the SDKs, you must be an Analytics Administrator.

### App developers

1. Ensure that your Analytics administrator has completed the steps in the *Analytics Administrators* section above.

1. Verify that your Analytics administrator has completed one of the sections in the *Log in to the Adobe Mobile Services UI* below.
1. After the report suite has been configured, complete steps in the *Download the SDK* section below.

For more information about roles and permissions, see [Roles and Permissions](https://experienceleague.adobe.com/docs/mobile-services/using/get-started-ug/c-mob-roles-and-permissions.html).

## Log in to the Adobe Mobile Services UI

Adobe Mobile services is the primary reporting interface for mobile app analytics and targeting. After you complete these steps you can download a configuration file that is pre-configured with your data collection server, report suite, and many other settings.

You can log in to the Adobe Mobile Services in one of the following ways:

* **Experience Cloud**

  Sign in to the [Experience Cloud](https://experience.adobe.com) with your Adobe ID.
  
  This method assumes that your company has been provisioned and you have linked your Analytics account. For more information about provisioning, see [Manage Experience Cloud users and products](https://experienceleague.adobe.com/docs/core-services/interface/administration/admin-getting-started.html) in the Experience Cloud Central Interface Components guide. For more information about linking your account, see [Organizations in the Experience Cloud](https://experienceleague.adobe.com/docs/core-services/interface/administration/organizations.html).

  > **Tip:** If you are unsure whether your company has been provisioned in the Experience Cloud, use your existing Adobe Analytics account.

* **Adobe Analytics**

  Click **Sign in with Analytics** and enter your Analytics company name, your username, and your password.

## Create a report suite

To create a report suite to collect app data and define an app:

1. Click **Create New App**.

   If you do not see this button, click **Manage Apps** > **Add**.

1. In the **Report Suite** drop-down, select **New Report Suite**.

1. Enter the name of your app and select a unique report suite ID.

   An example of a report suite ID is `mycomobileappdev`. You need to set up separate report suites and apps for the development and production versions. When you are ready to set up the production version, repeat these steps.
1. Leave **Mobile App Template** selected.

   This template enables timestamps to collect offline data and activates the mobile solution variables to capture lifecycle metrics.

1. Select your **Timezone**, your **Currency**, and click **Save**.

## Download the SDK

To download the mobile SDK:

1. Log in to Mobile Services and open your app in one of the following ways:

    * In the **All Apps** drop-down list, select your app.
    * On the right pane, find your app, and open it.

1. Click **Manage App Settings**.
1. In the **App SDK Downloads** section, scroll to the **App SDK Downloads** section.

1. Download the SDK and the sample app for your platform.

> **Tip:** A config file for your app is automatically included in the SDK download, so you do not need to download that file separately. However, if you already downloaded the SDK, and you want to get updated settings, download the config file again.
