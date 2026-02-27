using Microsoft.EntityFrameworkCore.Storage;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Storage.Internal;

public class StorageTableTypeMappingSource : TypeMappingSource
{
    public StorageTableTypeMappingSource(TypeMappingSourceDependencies dependencies) : base(dependencies)
    {
    }
}