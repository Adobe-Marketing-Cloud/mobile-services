Pod::Spec.new do |s|

  s.name         = "AdobeMobileSDK"
  s.version      = "4.3.0"
  s.summary      = "Adobe Mobile SDK"
  s.description  = <<-DESC
                   The Adobe Marketing Cloud Mobile libraries allow you to capture native app activity (user, usage, behavior, gestures, etc.) and forward that data to Adobe collection servers for use in Analytics reporting. Many of the libraries also include Test&Target mbox capability for A/B and multivariate testing within your mobile app, and audience measurement capabilities through Adobe AudienceManager.
                   DESC

  s.homepage     = "https://github.com/Adobe-Marketing-Cloud/mobile-services/releases"

  s.license      = {:type => "Commercial", :text => "Adobe Systems Incorporated All Rights Reserved"}
  s.author       = "Adobe Mobile SDK Team"
  s.source       = { :git => "https://github.com/Adobe-Marketing-Cloud/mobile-services.git", :tag => "v4.3.0-cocoapod" }

  s.source_files  = "AdobeMobileLibrary/*.h"
  s.resource  = "AdobeMobileLibrary/ADBMobileConfig.json"
  s.preserve_paths = "AdobeMobileLibrary/libAdobeMobileLibrary.a", "AdobeMobileLibrary/ADBMobileConfig.json"
  s.frameworks = "UIKit", "SystemConfiguration"
  s.libraries = "AdobeMobileLibrary","sqlite3.0"
  s.requires_arc = false
  s.xcconfig = { "LIBRARY_SEARCH_PATHS" => "\"$(PODS_ROOT)/AdobeMobileSDK/AdobeMobileLibrary\"" }
end
