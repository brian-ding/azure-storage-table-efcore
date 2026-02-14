using Microsoft.EntityFrameworkCore.Infrastructure;
using SoBrian.EntityFrameworkCore.Azure.StorageTable.Infrastructure.Internal;

namespace Microsoft.EntityFrameworkCore;

public static class StorageTableDbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder UseStorageTable(
        this DbContextOptionsBuilder optionsBuilder,
        string connectionString)
    {
        var extension = optionsBuilder.Options.FindExtension<StorageTableOptionsExtension>()
            ?? new StorageTableOptionsExtension();
        extension.ConnectionString = connectionString;

        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

        return optionsBuilder;
    }
}