# Postbacks

Postbacks allow you to send data that is collected by the SDK to a third-party server. By leveraging the same triggers and traits that you use to display an in-app message, you can configure the SDK to send customized data to a third-party destination.

> **Important:** This functionality requires SDK version 4.6.0 or later.

Postback messages are queued and follow all existing online/offline rules that govern analytics data collection. When a message matches (like shown-messages do), postback messages do not cancel the rest of the messages. This allows for multiple postbacks to occur on the same analytics hit. For the definition, see the *postbacks* row in [ADBMobile JSON Config](/docs/android/configuration/json-config/json-config.md).

## Template expansions

Template expansions are available in the `templateurl` and `templatebody` properties. Template items take the form of `{key}`, where `key` is a context data key or traditional data key. The values that are available for template expansion are limited to the [Lifecycle metrics](/docs/android/metrics.md), in addition to any custom data that is attached to the hit that triggers the message. No historical- or segment-based data is available at this time.

There are also specific, reserved templates that the SDK will automatically replace with internal data that is known to the SDK.

This list includes: 

| Token Name | Token Description |
|--- |--- |
|{%sdkver%}|Returns the SDK version.|
|{%cachebust%}|Resolves to a random number between 1 and 100000000.|
|{%adid%}|Returns Advertiser ID for Android. Note, this only works if you have used `submitAdvertisingIdentifierTask`.|
|{%pushid%}|Returns the Push Identifier token. Note, this only works if you have used `setPushIdentifier`.|
|{%timestampu%}|Returns current timestamp in epoch time.|
|{%timestampz%}|Returns current timestamp in JavaScript (ISO 8601) format.|
