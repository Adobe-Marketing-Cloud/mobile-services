#!/usr/bin/env node
/*************************************************************************
 *
 * ADOBE CONFIDENTIAL
 * ___________________
 *
 *  Copyright 2016 Adobe Systems Incorporated
 *  All Rights Reserved.
 *
 * NOTICE:  All information contained herein is, and remains
 * the property of Adobe Systems Incorporated and its suppliers,
 * if any.  The intellectual and technical concepts contained
 * herein are proprietary to Adobe Systems Incorporated and its
 * suppliers and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from Adobe Systems Incorporated.
 *
 **************************************************************************/


var fs = require('fs');
var path = require('path');

var projectName = "";

if (fs.existsSync('platforms/ios')) {
    var iosfiles = fs.readdirSync('platforms/ios');
    var suffix = ".xcodeproj";

    for (var i in iosfiles) {
        if (iosfiles[i].indexOf(suffix, iosfiles[i].length - suffix.length) !== -1) {
            projectName = iosfiles[i].substring(0, iosfiles[i].length - suffix.length);
            break;
        }
    }
}

var filestocopy = {
///////////////////////////
//          iOS
///////////////////////////
    ios : [
        {
            "plugins/com.adobe.ADBMobile/sdks/iOS/AdobeMobileLibrary/ADBMobileConfig.json":
                "platforms/ios/" + projectName + "/Resources/ADBMobileConfig.json"
        }
    ],
///////////////////////////
//          ANDROID
///////////////////////////
    android: [
        {
            "plugins/com.adobe.ADBMobile/sdks/Android/AdobeMobileLibrary/ADBMobileConfig.json" :
                "platforms/android/assets/ADBMobileConfig.json"
        }
    ]
};

// no need to configure below
var platforms = fs.readdirSync('platforms');

for(var i in platforms) {
    var platform = platforms[i];

    if (filestocopy[platform] == undefined) {
        continue;
    }

    filestocopy[platform].forEach(function(obj) {
        Object.keys(obj).forEach(function(srcfile) {
            var destfile = obj[srcfile];

            console.log('Copying ' + srcfile + ' to ' + destfile);

            var destdir = path.dirname(destfile);
            if (fs.existsSync(srcfile) && fs.existsSync(destdir)) {
                fs.createReadStream(srcfile).pipe(
                    fs.createWriteStream(destfile));
            }
        });
    });
};