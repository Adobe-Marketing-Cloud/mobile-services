#Adobe Mobile Services cordova plugin

##Getting Started:

###Create and add plugin
1. Create a cordova plugin
	ex. cordova create sampleApp com.sample.test HelloWorld
2. Navigate to the root of the recently created project
	ex. cd sampleApp/
3. Add Platforms
	ex. cordova platform add android
4. Add MobileServices plugin
	ex. cordova plugin add adobe-mobile-services

###Android 
1. Open the project
2. Replace or update ADBMobileConfig.json
	- Replace ADBMobileConfig.json located in the `assets/www` directory with your ADBMobileConfig.json downloaded from Adobe Mobile Services  
	or  
	- Update ADBMobileConfig.json located in the `assets/www` directory with your settings
3. Setup is complete. The Adobe library is now accessable within the index.html file via "window.ADB"
	```html
	<button style="height:200px; width:600px" onclick = "window.ADB.trackState('login page', {'user':'john','remember':'true'});">sampleHit</button>
	```

###iOS
1. Open the project
2. Replace or update ADBMobileConfig.json
	- Replace ADBMobileConfig.json located in the `www` directory with your ADBMobileConfig.json downloaded from Adobe Mobile Services  
	or  
	- Update ADBMobileConfig.json located in the `www` directory with your settings.
3. Setup is complete. The Adobe library is now accessable within the index.html file via "window.ADB"
	
	```html
	<button style="height:200px; width:600px" onclick = "window.ADB.trackState('login page', {'user':'john','remember':'true'});">sampleHit</button>
	```
