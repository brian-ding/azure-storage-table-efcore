using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Storage.Internal;

public class StorageTableDatabaseWrapper : Database
{
    public StorageTableDatabaseWrapper(DatabaseDependencies dependencies) : base(dependencies)
    {
    }

    public override int SaveChanges(IList<IUpdateEntry> entries)
    {
        Console.WriteLine("StorageTableDatabaseWrapper.SaveChanges called with entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine($"- Entity: {entry.EntityType.GetType().Name}, State: {entry.EntityState}");
        }

        return 0;
    }

    public override Task<int> SaveChangesAsync(IList<IUpdateEntry> entries, CancellationToken cancellationToken = default)
    {
        var result = SaveChanges(entries);

        return Task.FromResult(result);
    }
}