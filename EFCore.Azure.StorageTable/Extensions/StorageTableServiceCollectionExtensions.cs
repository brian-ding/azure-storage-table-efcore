using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SoBrian.EntityFrameworkCore.Azure.StorageTable.Diagnostics.Internal;
using SoBrian.EntityFrameworkCore.Azure.StorageTable.Infrastructure.Internal;

namespace Microsoft.Extensions.DependencyInjection;

public static class StorageTableServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkStorageTable(this IServiceCollection services)
    {
        var builder = new EntityFrameworkServicesBuilder(services);
        builder.TryAdd<LoggingDefinitions, StorageTableLoggingDefinitions>();
        builder.TryAdd<IDatabaseProvider, DatabaseProvider<StorageTableOptionsExtension>>();
        builder.TryAddCoreServices();

        return services;
    }
}