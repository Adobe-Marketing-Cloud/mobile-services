# Audience Manager configuration

You can send signals and retrieve visitor segments from Audience Manager.

## Set the application context

**(Required)** The `setContext()` method must be called once in the `onCreate()` method of your main activity.

Here is the code sample for this method:

```java
@Override 
public void onCreate(Bundle savedInstanceState) { 
  super.onCreate(savedInstanceState); 
  setContentView(R.layout.main); 
  Config.setContext(this.getApplicationContext()); 
}
```

If you added this method call when you implemented Analytics or Target, you do not need to add it again.
