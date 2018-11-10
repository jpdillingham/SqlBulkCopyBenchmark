# SqlBulkCopyBenchamrk

.NET Core console application for testing performance aspects of SqlBulkCopy against indexed and non-indexed tables

Tested against Microsoft SQL Server.

# Tables

```sql
CREATE TABLE [dbo].[Guids](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[value] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

CREATE TABLE [dbo].[Guids_IDX](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[value] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

CREATE CLUSTERED INDEX [ClusteredIndex-20181110-054144] ON [dbo].[Guids_IDX]
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
```

# Results

```
$ dotnet run
Creating datatable
Filling datatable with 10000 rows...
Datatable filled.
Non-indexed, default options, 100 workers, 1000 batch size completed in 8393ms
Non-indexed, default options, 100 workers, 5000 batch size completed in 5130ms
Non-indexed, default options, 100 workers, 100000 batch size completed in 5485ms
Non-indexed, .TableLock, 100 workers, 1000 batch size completed in 1880ms
Non-indexed, .TableLock, 100 workers, 5000 batch size completed in 2199ms
Non-indexed, .TableLock, 100 workers, 1000000 batch size completed in 2590ms
Non-indexed, .UseInternalTransaction, 100 workers, 5000 batch size completed in 7497ms
Non-indexed, .TableLock | .UseInternalTransaction, 100 workers, 5000 batch size completed in 4232ms
Non-indexed, external transaction, default options, 100 workers, 1000 batch size completed in 9322ms
Non-indexed, external transaction, default options, 100 workers, 5000 batch size completed in 8423ms
Non-indexed, external transaction, default options, 100 workers, 1000000 batch size completed in 9686ms
Non-indexed, external transaction, .TableLock, 100 workers, 1000 batch size completed in 3747ms
Non-indexed, external transaction, .TableLock, 100 workers, 5000 batch size completed in 3663ms
Non-indexed, external transaction, .TableLock, 100 workers, 1000000 batch size completed in 5031ms
Indexed, default options, 100 workers, 1000 batch size completed in 19450ms
Indexed, default options, 100 workers, 5000 batch size completed in 18500ms
Indexed, default options, 100 workers, 100000 batch size completed in 19162ms
Indexed, .TableLock, 100 workers, 1000 batch size completed in 10713ms
Indexed, .TableLock, 100 workers, 5000 batch size completed in 10060ms
Indexed, .TableLock, 100 workers, 1000000 batch size completed in 6695ms
Indexed, .UseInternalTransaction, 100 workers, 5000 batch size completed in 18305ms
Indexed, .TableLock | .UseInternalTransaction, 100 workers, 5000 batch size completed in 6584ms
Indexed, external transaction, default options, 100 workers, 1000 batch size completed in 18949ms
Indexed, external transaction, default options, 100 workers, 5000 batch size completed in 22995ms
Indexed, external transaction, default options, 100 workers, 1000000 batch size completed in 25706ms
Indexed, external transaction, .TableLock, 100 workers, 1000 batch size completed in 6935ms
Indexed, external transaction, .TableLock, 100 workers, 5000 batch size completed in 6509ms
Indexed, external transaction, .TableLock, 100 workers, 1000000 batch size completed in 6948ms
```