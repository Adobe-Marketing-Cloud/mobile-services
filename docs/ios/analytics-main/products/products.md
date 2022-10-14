# Products variable

The products variable cannot be set by using processing rules. In the iOS 4.x SDK, you must use a special syntax in the context data parameter to set products directly on the server call.

To set the *`products`* variable, set a context data key to `"&&products"`, and set the value by using the syntax that is defined for the *`products`* variable:

```objective-c
[contextData setObject:@"Category;Product;Quantity;Price[,Category;Product;Quantity;Price]" forKey:@"&&products"];
```

For example:

```objective-c
//create a context data dictionary 
NSMutableDictionary *contextData = [NSMutableDictionary dictionary]; 
 
// add products, a purchase id, a purchase context data key, and any other data you want to collect. 
// Note the special syntax for products 
[contextData setObject:@";Running Shoes;1;69.95,;Running Socks;10;29.99" forKey:@"&&products"]; 
[contextData setObject:@"1234567890" forKey:@"m.purchaseid"]; 
[contextData setObject:@"1" forKey:@"m.purchase"]; 
 
// send the tracking call - use either a trackAction or TrackState call. 
// trackAction example: 
[ADBMobile trackAction:@"purchase" data:contextData]; 
// trackState example: 
[ADBMobile trackState:@"Order Confirmation" data:contextData]; 

```

*`products`* is set directly on the image request, and the other variables are set as context data. All context data variables must be mapped by using processing rules: 

![](assets/map-products.png)

You do not need to map the *`products`* variable using processing rules because it is set directly on the image request by the SDK.
