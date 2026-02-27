using Microsoft.EntityFrameworkCore.Query;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Query.Internal;

public class StorageTableQueryContext : QueryContext
{
    public StorageTableQueryContext(QueryContextDependencies dependencies) : base(dependencies)
    {
    }
}