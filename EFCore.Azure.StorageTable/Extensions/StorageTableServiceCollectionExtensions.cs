using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using SoBrian.EntityFrameworkCore.Azure.StorageTable.Diagnostics.Internal;
using SoBrian.EntityFrameworkCore.Azure.StorageTable.Infrastructure.Internal;
using SoBrian.EntityFrameworkCore.Azure.StorageTable.Metadata.Conventions.Internal;
using SoBrian.EntityFrameworkCore.Azure.StorageTable.Query.Internal;
using SoBrian.EntityFrameworkCore.Azure.StorageTable.Storage.Internal;

namespace Microsoft.Extensions.DependencyInjection;

public static class StorageTableServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkStorageTable(this IServiceCollection services)
    {
        var builder = new EntityFrameworkServicesBuilder(services);
        builder.TryAdd<LoggingDefinitions, StorageTableLoggingDefinitions>();
        builder.TryAdd<IDatabaseProvider, DatabaseProvider<StorageTableOptionsExtension>>();
        builder.TryAdd<IQueryContextFactory, StorageTableQueryContextFactory>();
        builder.TryAdd<IDatabase, StorageTableDatabaseWrapper>();
        builder.TryAdd<ITypeMappingSource, StorageTableTypeMappingSource>();
        builder.TryAdd<IQueryableMethodTranslatingExpressionVisitorFactory, StorageTableQueryableMethodTranslatingExpressionVisitorFactory>();
        builder.TryAdd<IShapedQueryCompilingExpressionVisitorFactory, StorageTableShapedQueryCompilingExpressionVisitorFactory>();
        // builder.TryAdd<IModelValidator, StorageTableModelValidator>();
        builder.TryAdd<IProviderConventionSetBuilder, StorageTableConventionSetBuilder>();
        builder.TryAddCoreServices();

        return services;
    }
}