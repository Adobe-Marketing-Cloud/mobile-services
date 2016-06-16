# ./publish.sh version
! Not tested

echo "Version is $1"

echo "Update the Version number in podspec"
sed -i "" "s/\\(s.version[[:space:]]*=[[:space:]]*\"\\).*\\(\"\\)/\\1$1\\2/g" AdobeMobileSDK.podspec
sed -i "" "s/\\(\"v\).*\\(-cocoapod\"\\)/\\1$1\\2/g" AdobeMobileSDK.podspec

echo "Rename AdobeMobileLibrary"
mv AdobeMobileLibrary/AdobeMobileLibrary.a AdobeMobileLibrary/libAdobeMobile.a
mv AdobeMobileLibrary/AdobeMobileLibrary_Extension.a AdobeMobileLibrary/libAdobeMobile_Extension.a
mv AdobeMobileLibrary/AdobeMobileLibrary_TV.a AdobeMobileLibrary/libAdobeMobile_TV.a
mv AdobeMobileLibrary/AdobeMobileLibrary_Watch.a AdobeMobileLibrary/libAdobeMobile_Watch.a

echo "Commit the changes to git"
git add AdobeMobileLibrary
git add AdobeMobileSDK.podspec
git commit -am "Release $1"
git push origin cocoapod

git tag v$1-cocoapod
git push origin v$1-cocoapod


echo "Push the podspec"
#pod trunk push