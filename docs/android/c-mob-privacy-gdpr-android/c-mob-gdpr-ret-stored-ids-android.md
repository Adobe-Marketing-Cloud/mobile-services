# Retrieving stored identifiers

This information helps you retrieve locally stored, SDK identities from your Android app and with GDPR data access requests.

> **Important:** The `getAllIdentifiersAsync` method retrieves identities stored in the SDK. You must call this method **before** the user opts-out.

SDK identities (as applicable) are locally stored and returned in a JSON string, which might contain:

* Company Context - IMS Org IDs 
* User IDs 
* Experience Cloud iD (MID), formerly known as Marketing Cloud ID 
* Integration Codes (ADID, Push ID) 
* Data Source IDs (DPID, DPUUID) 
* Analytics IDs (AVID, AID, VID, and associated RSIDs) 
* Target Legacy IDs (TNTID, TNT3rdpartyID) 
* Audience Manager ID (UUID)

Here is an example of the `ADBMobile getAllIdentifiersAsync` method in Android:

```java
Config.getAllIdentifiersAsync(new ConfigCallback<String>() { 
     @Override 
     public void call(String identitiesJson) {                 
         Log.d("ADBMobile Identities", identitiesJson); 
     } 
});
```
