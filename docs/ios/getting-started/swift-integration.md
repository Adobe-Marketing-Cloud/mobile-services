# Swift integration

The iOS Adobe Mobile SDK can be seamlessly integrated in a Swift project by using the Mix and Match feature in the iOS Developer Library.

For more information, see [Language Interoperability](https://developer.apple.com/documentation/swift#2984801.html).

For example, by using the bridging header method as described in the documentation, you can import the Adobe Mobile iOS SDK header file:

```
#import "ADBMobile.h"
```

To access methods from the SDK in your Swift files, use the following format:

```
ADBMobile.{methodname}
```
