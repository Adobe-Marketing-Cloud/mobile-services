# Troubleshooting push messaging

This information helps you troubleshoot push messaging.

## Why are there sometimes delays sending push messages?

The following types of delays might be associated with push messages for Mobile Services:

* **Waiting for Analytics Hits**

  Every report suite has a setting to determine when to process incoming Analytics hits. The default is 1 hour on the hour. The actual processing of Analytics hits might take up to 30 minutes but is typically 15-20 minutes.
  
  For example, a report suite processes hits every hour. If you factor in the processing time of a maximum of 30 minutes, it could take up to 90 minutes for an incoming hit to be available for a push message. If a user launched the app at 9:01 AM, the hit would show up in the Mobile Services UI as a new unique user between 10:15 to 10:30 AM.

* **Waiting for Push Service**
  
  The push service (APNS or GCM) might not immediately send out the message. Although uncommon, we have seen a delay of 5-10 minutes. On the Messages page, you can verify that the push message has been sent to the push service by clicking the View link for the message. In the report, the number of successful sends to the push service is listed in the Published column.

  > **Tip:** The push services do not guarantee that a message will be sent. For more information about the reliability of services, see the appropriate documentation:
  >
  >* **APNS**: [Quality of Service](https://developer.apple.com/library/content/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/APNSOverview.html#//apple_ref/doc/uid/TP40008194-CH8-SW5)
  >* **FCM**: [Lifetime of a Message](https://firebase.google.com/docs/cloud-messaging/concept-options#lifetime)

## How do I renew my Apple Push Service Certificate?

Sending push messages requires a valid Push Service Certificate. Mobile Services will notify you when your certificate is close to expiring or has expired. If you receive this notification, complete the following steps to renew your certificate:

  1. Click **Manage App Settings**.
  2. To delete the current certificate, scroll to **Push Services** and click **Delete**.
  3. Configure and test a new certificate.

     For more information, see [Prerequisites to Enable Push Messaging](https://experienceleague.adobe.com/docs/mobile-services/using/manage-app-settings-ug/configuring-app/prerequisites-push-messaging.html)

  4. Click **Save**.

## Why can't I see my push messages in an iOS simulator?

  iOS simulators do not support push messaging.
