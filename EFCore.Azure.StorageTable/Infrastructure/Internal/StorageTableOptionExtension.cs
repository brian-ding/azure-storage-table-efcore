using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Infrastructure.Internal;

public class StorageTableOptionsExtension : IDbContextOptionsExtension
{
    private DbContextOptionsExtensionInfo? _info;

    public string? ConnectionString { get; internal set; }

    public DbContextOptionsExtensionInfo Info
    => _info ??= new ExtensionInfo(this);

    public void ApplyServices(IServiceCollection services)
    {
        services.AddEntityFrameworkStorageTable();
    }

    public void Validate(IDbContextOptions options) { }
}

public class ExtensionInfo : DbContextOptionsExtensionInfo
{
    public ExtensionInfo(IDbContextOptionsExtension extension) : base(extension) { }

    public override bool IsDatabaseProvider => true;

    public override string LogFragment => "azure storage table log fragment";

    public override int GetServiceProviderHashCode()
    {
        return 0;
    }

    public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
    {
        debugInfo["AzureStorageTable"] = "1";
    }

    public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other)
    {
        return other is ExtensionInfo;
    }
}