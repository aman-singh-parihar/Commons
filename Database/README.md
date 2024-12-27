## SELECT FOR UPDATE

`SELECT FOR UPDATE` is a SQL command that’s useful in the context of transactional workloads. 

It allows you to `lock` the rows returned by a `SELECT` query until the entire transaction that query is part of has been committed. 

Other transactions attempting to access those rows are placed into a time-based queue to wait, and are executed chronologically after the first transaction is completed

Suppose we’re working with a database that includes the following table kv:

K | V
--|--|
1|5
2|10
3|15

A complete transaction that uses SELECT FOR UPDATE on that table could look like this:
```
BEGIN;
SELECT * FROM kv WHERE k = 1 FOR UPDATE;
UPDATE kv SET v = v + 5 WHERE k = 1;
COMMIT;
```

SELECT .. FOR UPDATE on line 2 locked the row for the trascation to be updated. If any other transacation attempting to operate on the same row, it will be added to the queue, rather than beginning to execute, fail and having to retry. Once the previous transaction completes then it will start.

Another common parameter is NOWAIT, which returns an error immediately if a transaction is not able to immediately lock a row.
```
SELECT * FROM kv WHERE k = 1 FOR UPDATE NOWAIT;
```
`SKIP LOCKED` is also a parameter supported by some databases that allows waiting transactions to skip locked rows temporarily so that the hold on those rows doesn’t slow the processing of elements of the transaction impacting non-locked rows.

```
SELECT * FROM kv WHERE k = 1 FOR UPDATE SKIP LOCKED;
```
