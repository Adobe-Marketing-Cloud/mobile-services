Pod::Spec.new do |s|
  s.name         = "AdobeMobileSDK"
  s.version      = "4.21.0"
  s.summary      = "Adobe Mobile Services SDK. Written and Supported by Adobe and is the only official Adobe Pod for the Adobe Mobile Services SDK."
  s.description  = <<-DESC
                   The Adobe Experience Cloud Mobile libraries allow you to capture native app activity (user, usage, behavior, gestures, etc.) and forward that data to Adobe collection servers for use in Analytics reporting. Many of the libraries also include Test&Target mbox capability for A/B and multivariate testing within your mobile app, and audience measurement capabilities through Adobe AudienceManager.
                   DESC

  s.homepage     = "https://github.com/Adobe-Marketing-Cloud/mobile-services/releases"

  s.license      = {:type => "Commercial", :text => "Adobe Systems Incorporated All Rights Reserved"}
  s.author       = "Adobe Mobile SDK Team"
  s.source       = { :git => 'https://github.com/Adobe-Marketing-Cloud/mobile-services.git', :tag => "v4.20.0-cocoapod" }

  s.cocoapods_version = ">= 1.10"
  s.default_subspec = "iOS"
  
  s.subspec "iOS" do |ios|
    ios.platform = :ios, "10.0"
    ios.source_files = "AdobeMobileLibrary/ADBMobile.h", "AdobeMobileLibrary/Empty.m"
    ios.vendored_frameworks = "AdobeMobileLibrary/AdobeMobile.xcframework"
    ios.frameworks = "UIKit", "SystemConfiguration", "WebKit"
    ios.libraries = "sqlite3.0"
  end

  s.subspec "Extension" do |extension|
    extension.platform = :ios, "10.0"
    extension.source_files = "AdobeMobileLibrary/ADBMobile.h", "AdobeMobileLibrary/Empty.m"
    extension.vendored_frameworks = "AdobeMobileLibrary/AdobeMobileExtension.xcframework"
    extension.frameworks = "UIKit", "SystemConfiguration", "WebKit"
    extension.libraries = "sqlite3.0"
  end

  s.subspec "WatchOS2" do |watchos2|
    watchos2.platform  = :watchos, "2.0"
    watchos2.source_files = "AdobeMobileLibrary/ADBMobile.h", "AdobeMobileLibrary/Empty.m"
    watchos2.vendored_frameworks = "AdobeMobileLibrary/AdobeMobileWatch.xcframework"
    watchos2.libraries = "sqlite3.0"
  end

  s.subspec "TVOS" do |tvos|
    tvos.platform  = :tvos, "10.0"
    tvos.source_files = "AdobeMobileLibrary/ADBMobile.h", "AdobeMobileLibrary/Empty.m"
    tvos.vendored_frameworks = "AdobeMobileLibrary/AdobeMobileTV.xcframework"
    tvos.frameworks = "UIKit", "SystemConfiguration"
    tvos.libraries = "sqlite3.0"
  end

end
