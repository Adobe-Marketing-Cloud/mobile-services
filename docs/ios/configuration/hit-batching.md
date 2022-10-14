# Hit batching

Hit batching allows applications that have offline tracking enabled to hold hits from being sent until the number of hits in the queue pass a configurable limit.

> **Important:** Hit batching requires SDK version 4.1 or later.

To enable hit batching, update your `ADBMobileConfig.json` file and specify a value for `batchLimit`:

```js
"analytics": {
    "batchLimit": 5,
    ...
}
```

When set to a number higher than 0, the SDK queues the number of hits equal to *`batchLimit`*. After this threshold is passed, all hits in the queue are sent.

The following methods are used with hit batching:

* `trackingGetQueueSize()` returns an `NSUInteger` with the number of hits currently in the hit batching queue.
* `trackingSendQueuedHits()` forces the library to send all hits in the queue no matter how many are currently queued.
* `trackingClearQueue()` clears all hits from the queue without sending them.

> **Caution:** Offline tracking must be enabled to use hit batching.
