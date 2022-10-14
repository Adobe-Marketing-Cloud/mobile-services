# Implement Lifecycle

For more information about the metrics and dimensions that can be measured automatically by the mobile library after lifecycle is implemented, see [Lifecycle Metrics in Android](/docs/android/metrics.md) or [Lifecycle in iOS](/docs/ios/metrics.md).

## iOS

Lifecycle metrics are automatically collected in iOS.

## Android

In your Unity script, you set the application context for the Android SDK. Add the following code to the `Awake()` function of your FIRST scene:

```java
void Awake()
 {
  ...
  ADBMobile.SetContext();
  ...
 }
```

To collect lifecycle metrics, add the following code to all of your scene scripts:

```java
void OnEnable()
 {
  ...
  ADBMobile.CollectLifecycleData (); 
  ...
 }
 
 void OnDisable()
 {
  ...
  ADBMobile.PauseCollectingLifecycleData (); 
  ...
 }
  
 void OnApplicationPause(bool isPaused) 
 {
  ...
  if (isPaused) {
   ADBMobile.PauseCollectingLifecycleData (); 
  }  
  else {
   ADBMobile.CollectLifecycleData(); 
  }
  ...
 }

```
