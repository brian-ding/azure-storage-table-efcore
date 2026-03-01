using Microsoft.EntityFrameworkCore.Storage;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Storage.Internal;

public class StorageTableTypeMappingSource : TypeMappingSource
{
    public StorageTableTypeMappingSource(TypeMappingSourceDependencies dependencies) : base(dependencies)
    {
    }

    protected override CoreTypeMapping? FindMapping(in TypeMappingInfo mappingInfo)
    {
        var clrType = mappingInfo.ClrType;

        if (clrType == typeof(int)
        || clrType == typeof(string))
        {
            return new StorageTableTypeMapping(clrType);
        }

        return base.FindMapping(mappingInfo);
    }
}