using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Metadata.Conventions;

public class StorageTableKeyDiscoveryConvention : IEntityTypeAddedConvention
{
    public void ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder, IConventionContext<IConventionEntityTypeBuilder> context)
    {
        var entityType = entityTypeBuilder.Metadata;
        var partitionKeyProp = entityType.ClrType.GetProperties().FirstOrDefault(p => p.GetCustomAttribute<PartitionKeyAttribute>() != null);
        var rowKeyProp = entityType.ClrType.GetProperties().FirstOrDefault(p => p.GetCustomAttribute<RowKeyAttribute>() != null);
        if (partitionKeyProp != null && rowKeyProp != null)
        {
            entityTypeBuilder.HasKey([entityType.FindProperty(partitionKeyProp.Name)!, entityType.FindProperty(rowKeyProp.Name)!]);
            entityTypeBuilder.PrimaryKey([entityType.FindProperty(partitionKeyProp.Name)!, entityType.FindProperty(rowKeyProp.Name)!]);
        }
    }
}