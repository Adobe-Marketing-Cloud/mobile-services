# ./publish.sh version
! Not tested

echo "Version is $1"

echo "Update the Version number in podspec"
sed -i "" "s/\\(s.version[[:space:]]*=[[:space:]]*\"\\).*\\(\"\\)/\\1$1\\2/g" AdobeMobileSDK.podspec
sed -i "" "s/\\(\"v\).*\\(-cocoapod\"\\)/\\1$1\\2/g" AdobeMobileSDK.podspec

echo "Rename AdobeMobileLibrary"
mv AdobeMobileLibrary/AdobeMobileLibrary.a AdobeMobileLibrary/libMobileLibrary.a

echo "Commit the changes to git"
git add *
git commit -am "Release $1"
git push origin cocoapod

git tag v$1-cocoapod
git push origin v$1-cocoapod


echo "Push the podspec"
pod trunk push