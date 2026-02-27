using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using SoBrian.EntityFrameworkCore.Azure.StorageTable.Infrastructure.Internal;

namespace Microsoft.Extensions.DependencyInjection;

public static class StorageTableServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkStorageTable(this IServiceCollection services)
    {
        var builder = new EntityFrameworkServicesBuilder(services);
        builder.TryAdd<IDatabaseProvider, DatabaseProvider<StorageTableOptionsExtension>>();
        builder.TryAddCoreServices();

        return services;
    }
}