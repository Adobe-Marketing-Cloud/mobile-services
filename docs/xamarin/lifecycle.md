# Implement lifecycle

This information helps you implement Lifecycle metrics for Android. 

> **Tip:** Lifecycle metrics are automatically collected for iOS.

For the metrics and dimensions that can be measured automatically by the mobile library after lifecycle is implemented, see [Lifecycle Metrics](/docs/ios/metrics.md).

## iOS

In iOS, lifecycle metrics are automatically collected.

## Android

In your main activity, set the application context for the Android SDK.

```java
protected override void OnCreate (Bundle bundle) 
{
    ... 
    Config.SetContext (Application.Context); 
    ... 
}
```

In every activity, implement lifecycle calls.

```java
protected override void OnResume()
{
    ...
    Config.CollectLifecycleData (this);
    ...
}
protected override void OnPause() 
{
    ...
    Config.PauseCollectingLifecycleData ();
    ...
}
```
