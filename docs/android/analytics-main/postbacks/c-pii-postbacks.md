# PII postbacks

You can use the Adobe SDK to collect personally identifiable information (PII) and send it to a third-party endpoint.

When you want to use the Adobe SDK to collect PII, you should send a track PII call. Although using this call enables collection of PII data, the SDK does not automatically send the data to an Adobe endpoint. A PII type postback needs to be configured with the appropriate endpoint.

> **Tip:** An endpoint that supports HTTPS is required to use the PII postback type.

## Tracking PII postbacks

1. Add the library to your project and implement lifecycle. 

    For more information, see *Add the SDK and Config File to your IntelliJ IDEA or Eclipse Project* in [Core implementation and lifecycle](/docs/android/getting-started/dev-qs.md). 

1. Import the library: 

   ```java
   #import "ADBMobile.h"
   ```

1. When you are ready to capture PII, call `trackPII` to send a hit for this action, event, or view: 

   ```java
   Config.collectPII(new HashMap<String, Object>(){{
     put("key","value");
   }});
   ```
