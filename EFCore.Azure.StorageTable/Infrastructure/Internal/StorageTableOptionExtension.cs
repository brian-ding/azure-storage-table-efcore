using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Infrastructure.Internal;

public class StorageTableOptionsExtension : IDbContextOptionsExtension
{
    public string? ConnectionString { get; internal set; }

    public DbContextOptionsExtensionInfo Info => throw new NotImplementedException();

    public void ApplyServices(IServiceCollection services)
    {
        services.AddEntityFrameworkStorageTable();
    }

    public void Validate(IDbContextOptions options) { }
}