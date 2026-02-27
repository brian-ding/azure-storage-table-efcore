using Microsoft.EntityFrameworkCore.Query;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Query.Internal;

public class StorageTableShapedQueryCompilingExpressionVisitorFactory : IShapedQueryCompilingExpressionVisitorFactory
{
    private readonly ShapedQueryCompilingExpressionVisitorDependencies _dependencies;

    public StorageTableShapedQueryCompilingExpressionVisitorFactory(ShapedQueryCompilingExpressionVisitorDependencies dependencies)
    {
        _dependencies = dependencies;
    }

    public ShapedQueryCompilingExpressionVisitor Create(QueryCompilationContext queryCompilationContext)
    {
        var visitor = new StorageTableShapedQueryCompilingExpressionVisitor(_dependencies, queryCompilationContext);

        return visitor;
    }
}