using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Metadata.Conventions;

public class StorageTableKeyDiscoveryConvention : IEntityTypeAddedConvention
{
    public void ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder, IConventionContext<IConventionEntityTypeBuilder> context)
    {
        var entityType = entityTypeBuilder.Metadata;
        var properties = entityType.ClrType.GetProperties();

        foreach (var property in properties)
        {
            var partitionKeyAttribute = property.GetCustomAttributes(typeof(PartitionKeyAttribute), false);
        }

    }
}