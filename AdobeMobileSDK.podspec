Pod::Spec.new do |s|
  s.name         = "AdobeMobileSDK"
  s.version      = "4.7.1"
  s.summary      = "Adobe Mobile Services SDK. Written and Supported by Adobe and is the only official Adobe Pod for the Adobe Mobile Services SDK."
  s.description  = <<-DESC
                   The Adobe Marketing Cloud Mobile libraries allow you to capture native app activity (user, usage, behavior, gestures, etc.) and forward that data to Adobe collection servers for use in Analytics reporting. Many of the libraries also include Test&Target mbox capability for A/B and multivariate testing within your mobile app, and audience measurement capabilities through Adobe AudienceManager.
                   DESC

  s.homepage     = "https://github.com/Adobe-Marketing-Cloud/mobile-services/releases"

  s.license      = {:type => "Commercial", :text => "Adobe Systems Incorporated All Rights Reserved"}
  s.author       = "Adobe Mobile SDK Team"
  s.source       = { :git => 'https://github.com/Adobe-Marketing-Cloud/mobile-services.git', :tag => "v#{s.version}-cocoapod" }
  s.platform     = :ios, '5.0'

  s.default_subspec = 'iOS'
  
  s.subspec 'iOS' do |ios|
    ios.source_files  = "AdobeMobileLibrary/*.h", "AdobeMobileLibrary/Empty.m"  
    ios.frameworks = "UIKit", "SystemConfiguration"
    ios.libraries = "sqlite3.0"
    ios.vendored_libraries = "AdobeMobileLibrary/libAdobeMobile.a"
  end

  s.subspec 'Extension' do |extension|
    extension.platform     = :ios, '5.0'
    extension.source_files  = "AdobeMobileLibrary/*.h", "AdobeMobileLibrary/Empty.m"  
    extension.frameworks = "UIKit", "SystemConfiguration"
    extension.libraries = "sqlite3.0"
    extension.vendored_libraries = "AdobeMobileLibrary/libAdobeMobile_extension.a"
  end

  s.subspec 'WatchOS2' do |watchos2|
    watchos2.platform  = :watchos, '2.0'
    watchos2.source_files  = "AdobeMobileLibrary/*.h", "AdobeMobileLibrary/Empty.m"  
    watchos2.libraries = "sqlite3.0"
    watchos2.vendored_libraries = "AdobeMobileLibrary/libAdobeMobile_watch.a"
  end

  s.subspec 'TVOS' do |tvos|
    tvos.platform  = :tvos, '9.0'
    tvos.tvos.deployment_target = '9.0'
    tvos.source_files  = "AdobeMobileLibrary/*.h", "AdobeMobileLibrary/Empty.m"  
    tvos.frameworks = "UIKit", "SystemConfiguration"
    tvos.libraries = "sqlite3.0"
    tvos.vendored_libraries = "AdobeMobileLibrary/libAdobeMobile_TV.a"
  end

end
