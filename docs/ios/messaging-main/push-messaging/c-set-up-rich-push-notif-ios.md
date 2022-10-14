# Receive rich push notifications

You can attach image files to your Apple notifications. Adding visual components can significantly increase your users' engagement with push notifications.

To receive rich push notifications in your iOS app:

1. Implement push messaging for the app by completing the steps in [Push Messaging](/docs/ios/messaging-main/push-messaging/push-messaging.md). 
1. Verify that you can send a text push message to your app. 
1. Add a Notification Service Extension by completing the following steps:

   1. In your Xcode project, select  **File** > **New** > **Target**. 
   1. Select **Notification Service Extension**. 
   1. Verify that the `NotificationService.m` file exists.

1. Open the `NotificationService.m` file and verify that the following delegate methods exist:

   * One method to receive a notification request. 
   * One method to handle the expiration of the service extension.

     To receive rich push notifications, the first method is used: 

     ```objective-c
     (void)didReceiveNotificationRequest:(UNNotificationRequest *)request withContentHandler:(void (^)(UNNotificationContent *contentToDeliver))contentHandler;
     ```

     In this method, you can get the Media URL from `userInfo` by using the `attachment-url` key. After you download the file to a local directory, add the local path to `bestAttemptContent.attachments`.

     Here is an example of the code in this method: 

     ```objective-c
     - (void)didReceiveNotificationRequest:(UNNotificationRequest *)request withContentHandler:(void (^)(UNNotificationContent * _Nonnull))contentHandler {
     self.contentHandler = contentHandler;
     self.bestAttemptContent = [request.content mutableCopy];
        NSDictionary* userInfo = request.content.userInfo;
     if(userInfo[@"attachment-url"]){
        NSURL* url = [[NSURL alloc] initWithString:userInfo[@"attachment-url"]];
        NSURLSessionDownloadTask* task = [[NSURLSession sharedSession] downloadTaskWithURL:url completionHandler:^(NSURL * _Nullable location, NSURLResponse * _Nullable response, NSError * _Nullable error) {
            if(!location){
                return;
            }
            NSString* tmpDirectory = NSTemporaryDirectory();
            NSString* tmpFilePath = [NSString stringWithFormat:@"file://%@%d%d%@", tmpDirectory, arc4random_uniform(100000),
                                   arc4random_uniform(100000), [url lastPathComponent]];
            NSURL* tmpUrl = [[NSURL alloc] initWithString:tmpFilePath];
            NSError * fileError = nil;
            [[NSFileManager defaultManager] moveItemAtURL:location toURL:tmpUrl error:&amp;fileError];
            if(fileError){
                return;
            }
            UNNotificationAttachment* attachment = [UNNotificationAttachment attachmentWithIdentifier:@"video" URL:tmpUrl options:nil error:&amp;fileError];
            if(fileError){
                return;
            }
            self.bestAttemptContent.attachments = @[attachment];
            self.contentHandler(self.bestAttemptContent);
        }];
        [task resume];
      }
     }
     ```


For more information about rich push notifications with iOS, see [UNNotificationAttachment](https://developer.apple.com/documentation/usernotifications/unnotificationattachment).
