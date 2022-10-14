# Postbacks overview

Postbacks allow you to send data that is collected by the SDK to a third-party server. By leveraging the same triggers and traits that you use to display an in-app message, you can configure the SDK to send customized data to a third-party destination.

> **Important:** This functionality requires SDK version 4.6.0 or later.

Postback messages are queued and follow all existing online/offline rules that govern analytics data collection. When a message matches (like shown-messages do), postback messages do not cancel the rest of the messages. This allows for multiple postbacks to occur on the same analytics hit. For the definition, see the *postbacks* row in [ADBMobile JSON Config](/docs/ios/configuration/json-config/json-config.md).

## Template expansions

Template expansions are available in both the `templateurl` and `templatebody` properties. Template items take the form of `{key}`, where `key` is a context-data key, or traditional data key. The values available for template expansion are limited to the [standard Lifecycle variables list](/docs/ios/metrics.md), in addition to any custom data attached to the hit that triggers the message. No historical-based or segment-based data is available at this time.

There are also specific, reserved templates that the SDK will replace for you automatically with internal data known to the SDK.

This list includes: 

| Token Name | Token Description |
|--- |--- |
|`{%sdkver%}`|Returns SDK version.|
|`{%cachebust%}`|Resolves to a random number between 1 and 100000000.|
|`{%adid%}`|Returns IDFA. This token only works if you used  `setAdvertisingIdentifier`.|
|`{%pushid%}`|Returns the Push Identifier token. This token only works if you used `setPushIdentifier`.|
|`{%timestampu%}`|Returns current timestamp in epoch time.|
|`{%timestampz%}`|Returns current timestamp in JavaScript (ISO 8601) format.|
