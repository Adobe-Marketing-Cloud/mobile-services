# Target configuration

You can deliver targeted content in Android applications.

## Set the application context

**(Required)** The `setContext()` method must be called once in the `onCreate()` method of your main activity.

For example:

```java
@Override 
public void onCreate(Bundle savedInstanceState) { 
  super.onCreate(savedInstanceState); 
  setContentView(R.layout.main); 
  Config.setContext(this.getApplicationContext()); 
}
```

If you already added this method call when you implemented Analytics or Audience Management, you do not need to add it again.
