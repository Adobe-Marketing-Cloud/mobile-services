#Adobe Mobile Services Cordova Plugin

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

###Configuration
1. Place the ADBMobileConfig.json file downloaded from Adobe Mobile Services in the `www` directory
2. Setup is complete. The Adobe library is now accessible within the index.html file via "window.ADB"
	
	```html
	<button style="height:200px; width:600px" onclick = "window.ADB.trackState('login page', {'user':'john','remember':'true'});">sampleHit</button>
	```