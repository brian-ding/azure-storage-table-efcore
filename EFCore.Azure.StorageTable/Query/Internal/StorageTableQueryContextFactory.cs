using Microsoft.EntityFrameworkCore.Query;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Query.Internal;

public class StorageTableQueryContextFactory : IQueryContextFactory
{
    private readonly QueryContextDependencies _dependencies;

    public StorageTableQueryContextFactory(QueryContextDependencies dependencies)
    {
        _dependencies = dependencies;
    }

    public QueryContext Create()
    {
        var context = new StorageTableQueryContext(_dependencies);

        return context;
    }
}