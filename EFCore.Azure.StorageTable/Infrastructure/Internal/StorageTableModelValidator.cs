using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Infrastructure.Internal;

public class StorageTableModelValidator : IModelValidator
{
    public void Validate(IModel model, IDiagnosticsLogger<DbLoggerCategory.Model.Validation> logger)
    {
        foreach (var entityType in model.GetEntityTypes())
        {
            // if (entityType.IsOwned())
            // {
            //     throw new InvalidOperationException(
            //         $"The entity type '{entityType.DisplayName()}' is configured as owned, which is not supported by Azure Storage Table.");
            // }

            // if (entityType.GetKeys().Count() == 0)
            // {
            //     throw new InvalidOperationException(
            //         $"The entity type '{entityType.DisplayName()}' does not have a key defined, which is required by Azure Storage Table.");
            // }
        }

    }
}