using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SqlBulkCopyBenchmark
{
    class Program
    {
        private static readonly string connString = "Server=SQL;Database=MyDb;Integrated Security=SSPI;";
        private static readonly Action<string> log = (s) => Console.WriteLine(s);

        static void Main(string[] args)
        {
            var count = 10000;

            log($"Creating datatable");

            var dt = new DataTable();
            dt.Columns.Add("value", typeof(Guid));

            log($"Filling datatable with {count} rows...");

            for (var i = 1; i < count; i++)
                dt.Rows.Add(Guid.NewGuid());

            log($"Datatable filled.");

            // fails with 'The instance of the SQL Server Database Engine cannot obtain a LOCK resource at this time.'
            //Run("Non-indexed, default options, 100 workers, 1000000 batch size", "Guids", dt, SqlBulkCopyOptions.Default, workers: 100, batchSize: 1000000);
            //Run("Indexed, default options, 100 workers, 1000000 batch size", "Guids_IDX", dt, SqlBulkCopyOptions.Default, workers: 100, batchSize: 1000000);

            //Run("Non-indexed, default options, 100 workers, 1000 batch size", "Guids", dt, SqlBulkCopyOptions.Default, workers: 100, batchSize: 1000);
            //Run("Non-indexed, default options, 100 workers, 5000 batch size", "Guids", dt, SqlBulkCopyOptions.Default, workers: 100, batchSize: 5000);
            //Run("Non-indexed, default options, 100 workers, 100000 batch size", "Guids", dt, SqlBulkCopyOptions.Default, workers: 100, batchSize: 100000);

            //Run("Non-indexed, .TableLock, 100 workers, 5000 batch size", "Guids", dt, SqlBulkCopyOptions.TableLock, workers: 100, batchSize: 5000);
            //Run("Non-indexed, .TableLock, 100 workers, 1000 batch size", "Guids", dt, SqlBulkCopyOptions.TableLock, workers: 100, batchSize: 1000);
            //Run("Non-indexed, .TableLock, 100 workers, 1000000 batch size", "Guids", dt, SqlBulkCopyOptions.TableLock, workers: 100, batchSize: 100000);

            //Run("Non-indexed, .UseInternalTransaction, 100 workers, 5000 batch size", "Guids", dt, SqlBulkCopyOptions.UseInternalTransaction, workers: 100, batchSize: 5000);
            //Run("Non-indexed, .TableLock | .UseInternalTransaction, 100 workers, 5000 batch size", "Guids", dt, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.UseInternalTransaction, workers: 100, batchSize: 5000);

            //Run("Indexed, default options, 100 workers, 1000 batch size", "Guids_IDX", dt, SqlBulkCopyOptions.Default, workers: 100, batchSize: 1000);
            //Run("Indexed, default options, 100 workers, 5000 batch size", "Guids_IDX", dt, SqlBulkCopyOptions.Default, workers: 100, batchSize: 5000);
            //Run("Indexed, default options, 100 workers, 100000 batch size", "Guids_IDX", dt, SqlBulkCopyOptions.Default, workers: 100, batchSize: 100000);

            Run("Indexed, .TableLock, 100 workers, 5000 batch size", "Guids_IDX", dt, SqlBulkCopyOptions.TableLock, workers: 100, batchSize: 5000);
            Run("Indexed, .TableLock, 100 workers, 1000 batch size", "Guids_IDX", dt, SqlBulkCopyOptions.TableLock, workers: 100, batchSize: 1000);
            Run("Indexed, .TableLock, 100 workers, 1000000 batch size", "Guids_IDX", dt, SqlBulkCopyOptions.TableLock, workers: 100, batchSize: 100000);

            Run("Indexed, .UseInternalTransaction, 100 workers, 5000 batch size", "Guids_IDX", dt, SqlBulkCopyOptions.UseInternalTransaction, workers: 100, batchSize: 5000);
            Run("Indexed, .TableLock | .UseInternalTransaction, 100 workers, 5000 batch size", "Guids_IDX", dt, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.UseInternalTransaction, workers: 100, batchSize: 5000);
        }

        static void Run(string desc, string table, DataTable dt, SqlBulkCopyOptions options, int workers, int batchSize = 5000)
        {
            var sw = new Stopwatch();
            sw.Start();

            Parallel.For(0, workers, (i) =>
            {
                using (var sqlBulk = new SqlBulkCopy(connString, options))
                {
                    sqlBulk.DestinationTableName = table;
                    sqlBulk.BulkCopyTimeout = 500;
                    sqlBulk.BatchSize = batchSize;
                    sqlBulk.ColumnMappings.Add("value", "value");
                    sqlBulk.WriteToServer(dt);
                }
            });

            sw.Stop();
            log($"{desc} completed in {sw.ElapsedMilliseconds}ms");
        }
    }
}
