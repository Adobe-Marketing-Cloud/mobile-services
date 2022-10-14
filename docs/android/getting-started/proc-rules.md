# Processing rules and context data

Processing rules are used to copy the data that you send in context data variables to eVars, props, and other variables for reporting. For more information, see [Processing Rules](https://experienceleague.adobe.com/docs/analytics/admin/admin-tools/processing-rules/processing-rules.html).

When working with processing rules, remember the following information:

* Group your context data variables by using namespaces, because it helps you maintain a logical ordering. For example, to collect information about a product, you might define the following variables:

  ```js
  "product.type":"hat" 
  "product.team":"mariners" 
  "product.color":"blue"
  ```

* Context data variables are sorted alphabetically in the processing rules interface, which allows you to quickly see which variables are in the same namespace.

  Avoid naming context data keys by using the eVar or prop number:

  ```js
  "eVar1":"jimbo"
  ```

  This might make it *slightly* easier when you complete the one-time mapping in processing rules, but you lose readability during debugging and future code updates, which can be more difficult. Instead, we strongly recommend that you use descriptive names for keys and values:

  ```js
  "username":"jimbo"
  ```

* Context variables that define counter events should be set to 1:

  ```js
  "logon":"1"
  ```

* Context data variables that define incrementor events can have the event as the key, and the amount to increment as the value:

  ```js
  "levels completed":"6"
  ```

> **Tip:** Adobe reserves the namespace `"a."`. To avoid collisions, the only other requirement is that context data variables are unique in your login company.
