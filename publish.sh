
echo "Commit the changes to git"
git add *
git commit -am "Release $1"
git push origin cocoapod

git tag v$1-cocoapod
git push origin v$1-cocoapod
