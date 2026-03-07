using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using SoBrian.EntityFrameworkCore.Azure.StorageTable.Infrastructure.Internal;
using Azure.Data.Tables;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Storage.Internal;

public class StorageTableDatabaseWrapper : Database
{
    private readonly string? _connectionString;

    public StorageTableDatabaseWrapper(DatabaseDependencies dependencies, IDbContextOptions options) : base(dependencies)
    {
        _connectionString = options.FindExtension<StorageTableOptionsExtension>()?.ConnectionString;
    }

    public override int SaveChanges(IList<IUpdateEntry> entries)
    {
        int rowsAffected = 0;

        foreach (var entry in entries)
        {
            if (entry.EntityState == EntityState.Added)
            {
                var primaryKey = entry.EntityType.FindPrimaryKey();
                var partitionKey = entry.GetCurrentValue<string>(primaryKey!.Properties[0]);
                var rowKey = entry.GetCurrentValue<string>(primaryKey.Properties[1]);


                var tableName = "efcore";
                var tableClient = new TableClient(_connectionString, tableName);
                tableClient.CreateIfNotExists();

                var tableEntity = new TableEntity(partitionKey, rowKey);
                foreach (var property in entry.EntityType.GetProperties().Where(p => !p.IsPrimaryKey()))
                {
                    tableEntity[property.Name] = entry.GetCurrentValue(property);
                }
                tableClient.AddEntity(tableEntity);

                rowsAffected++;
            }
        }

        return rowsAffected;
    }

    public override Task<int> SaveChangesAsync(IList<IUpdateEntry> entries, CancellationToken cancellationToken = default)
    {
        var result = SaveChanges(entries);

        return Task.FromResult(result);
    }
}