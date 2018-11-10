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