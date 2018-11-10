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
Non-indexed, default options, 100 workers, 1000 batch size completed in 4935ms
Non-indexed, default options, 100 workers, 5000 batch size completed in 4386ms
Non-indexed, default options, 100 workers, 100000 batch size completed in 4890ms
Non-indexed, .TableLock, 100 workers, 1000 batch size completed in 2399ms
Non-indexed, .TableLock, 100 workers, 5000 batch size completed in 2382ms
Non-indexed, .TableLock, 100 workers, 1000000 batch size completed in 1372ms
Non-indexed, .UseInternalTransaction, 100 workers, 1000 batch size completed in 7232ms
Non-indexed, .UseInternalTransaction, 100 workers, 5000 batch size completed in 5355ms
Non-indexed, .UseInternalTransaction, 100 workers, 100000 batch size completed in 5670ms
Non-indexed, .TableLock | .UseInternalTransaction, 100 workers, 1000 batch size completed in 3233ms
Non-indexed, .TableLock | .UseInternalTransaction, 100 workers, 5000 batch size completed in 4097ms
Non-indexed, .TableLock | .UseInternalTransaction, 100 workers, 100000 batch size completed in 4066ms
Non-indexed, external transaction, default options, 100 workers, 1000 batch size completed in 8751ms
Non-indexed, external transaction, default options, 100 workers, 5000 batch size completed in 8042ms
Non-indexed, external transaction, default options, 100 workers, 1000000 batch size completed in 10139ms
Non-indexed, external transaction, .TableLock, 100 workers, 1000 batch size completed in 3674ms
Non-indexed, external transaction, .TableLock, 100 workers, 5000 batch size completed in 4113ms
Non-indexed, external transaction, .TableLock, 100 workers, 1000000 batch size completed in 4311ms
Indexed, default options, 100 workers, 1000 batch size completed in 19733ms
Indexed, default options, 100 workers, 5000 batch size completed in 20653ms
Indexed, default options, 100 workers, 100000 batch size completed in 22884ms
Indexed, .TableLock, 100 workers, 1000 batch size completed in 10227ms
Indexed, .TableLock, 100 workers, 5000 batch size completed in 6796ms
Indexed, .TableLock, 100 workers, 1000000 batch size completed in 6831ms
Indexed, .UseInternalTransaction, 100 workers, 1000 batch size completed in 27043ms
Indexed, .UseInternalTransaction, 100 workers, 5000 batch size completed in 24380ms
Indexed, .UseInternalTransaction, 100 workers, 100000 batch size completed in 25459ms
Indexed, .TableLock | .UseInternalTransaction, 100 workers, 1000 batch size completed in 6775ms
Indexed, .TableLock | .UseInternalTransaction, 100 workers, 5000 batch size completed in 6751ms
Indexed, .TableLock | .UseInternalTransaction, 100 workers, 100000 batch size completed in 6750ms
Indexed, external transaction, default options, 100 workers, 1000 batch size completed in 26406ms
Indexed, external transaction, default options, 100 workers, 5000 batch size completed in 25831ms
Indexed, external transaction, default options, 100 workers, 1000000 batch size completed in 26235ms
Indexed, external transaction, .TableLock, 100 workers, 1000 batch size completed in 6364ms
Indexed, external transaction, .TableLock, 100 workers, 5000 batch size completed in 7961ms
Indexed, external transaction, .TableLock, 100 workers, 1000000 batch size completed in 12495ms
```

```
$ dotnet run                                                                                           
Creating datatable                                                                                     
Filling datatable with 10000 rows...                                                                   
Datatable filled.                                                                                      
Non-indexed, default options, 100 workers, 1000 batch size completed in 4718ms                         
Non-indexed, default options, 100 workers, 5000 batch size completed in 4197ms                         
Non-indexed, default options, 100 workers, 100000 batch size completed in 5381ms                       
Non-indexed, .TableLock, 100 workers, 1000 batch size completed in 1928ms                              
Non-indexed, .TableLock, 100 workers, 5000 batch size completed in 1734ms                              
Non-indexed, .TableLock, 100 workers, 1000000 batch size completed in 3803ms                           
Non-indexed, .UseInternalTransaction, 100 workers, 1000 batch size completed in 11196ms                
Non-indexed, .UseInternalTransaction, 100 workers, 5000 batch size completed in 10121ms                
Non-indexed, .UseInternalTransaction, 100 workers, 100000 batch size completed in 10136ms              
Non-indexed, .TableLock | .UseInternalTransaction, 100 workers, 1000 batch size completed in 4413ms    
Non-indexed, .TableLock | .UseInternalTransaction, 100 workers, 5000 batch size completed in 3714ms    
Non-indexed, .TableLock | .UseInternalTransaction, 100 workers, 100000 batch size completed in 5145ms  
Non-indexed, external transaction, default options, 100 workers, 1000 batch size completed in 11310ms  
Non-indexed, external transaction, default options, 100 workers, 5000 batch size completed in 9643ms   
Non-indexed, external transaction, default options, 100 workers, 1000000 batch size completed in 9009ms
Non-indexed, external transaction, .TableLock, 100 workers, 1000 batch size completed in 4646ms        
Non-indexed, external transaction, .TableLock, 100 workers, 5000 batch size completed in 4124ms        
Non-indexed, external transaction, .TableLock, 100 workers, 1000000 batch size completed in 4298ms     
Indexed, default options, 100 workers, 1000 batch size completed in 17130ms                            
Indexed, default options, 100 workers, 5000 batch size completed in 16368ms                            
Indexed, default options, 100 workers, 100000 batch size completed in 16988ms                          
Indexed, .TableLock, 100 workers, 1000 batch size completed in 21088ms                                 
Indexed, .TableLock, 100 workers, 5000 batch size completed in 8666ms                                  
Indexed, .TableLock, 100 workers, 1000000 batch size completed in 8022ms                               
Indexed, .UseInternalTransaction, 100 workers, 1000 batch size completed in 17280ms                    
Indexed, .UseInternalTransaction, 100 workers, 5000 batch size completed in 16613ms                    
Indexed, .UseInternalTransaction, 100 workers, 100000 batch size completed in 17783ms                  
Indexed, .TableLock | .UseInternalTransaction, 100 workers, 1000 batch size completed in 9953ms        
Indexed, .TableLock | .UseInternalTransaction, 100 workers, 5000 batch size completed in 8001ms        
Indexed, .TableLock | .UseInternalTransaction, 100 workers, 100000 batch size completed in 7587ms      
Indexed, external transaction, default options, 100 workers, 1000 batch size completed in 17863ms      
Indexed, external transaction, default options, 100 workers, 5000 batch size completed in 19470ms      
Indexed, external transaction, default options, 100 workers, 1000000 batch size completed in 21532ms   
Indexed, external transaction, .TableLock, 100 workers, 1000 batch size completed in 7779ms            
Indexed, external transaction, .TableLock, 100 workers, 5000 batch size completed in 6640ms            
Indexed, external transaction, .TableLock, 100 workers, 1000000 batch size completed in 7212ms         
```