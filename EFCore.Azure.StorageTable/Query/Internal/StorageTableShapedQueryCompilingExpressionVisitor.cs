using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Query.Internal;

public class StorageTableShapedQueryCompilingExpressionVisitor : ShapedQueryCompilingExpressionVisitor
{
    public StorageTableShapedQueryCompilingExpressionVisitor(ShapedQueryCompilingExpressionVisitorDependencies dependencies, QueryCompilationContext queryCompilationContext) : base(dependencies, queryCompilationContext)
    {
    }

    protected override Expression VisitShapedQuery(ShapedQueryExpression shapedQueryExpression)
    {
        throw new NotImplementedException();
    }
}