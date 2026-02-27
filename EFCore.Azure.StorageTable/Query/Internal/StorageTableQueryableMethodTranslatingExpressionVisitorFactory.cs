using Microsoft.EntityFrameworkCore.Query;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Query.Internal;

public class StorageTableQueryableMethodTranslatingExpressionVisitorFactory : IQueryableMethodTranslatingExpressionVisitorFactory
{
    private readonly QueryableMethodTranslatingExpressionVisitorDependencies _dependencies;

    public StorageTableQueryableMethodTranslatingExpressionVisitorFactory(QueryableMethodTranslatingExpressionVisitorDependencies dependencies)
    {
        _dependencies = dependencies;
    }

    public QueryableMethodTranslatingExpressionVisitor Create(QueryCompilationContext queryCompilationContext)
    {
        var visitor = new StorageTableQueryableMethodTranslatingExpressionVisitor(_dependencies, queryCompilationContext, false);

        return visitor;
    }
}