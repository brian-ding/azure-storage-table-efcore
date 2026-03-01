using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace SoBrian.EntityFrameworkCore.Azure.StorageTable.Metadata.Conventions.Internal;

public class StorageTableConventionSetBuilder : ProviderConventionSetBuilder
{
    public StorageTableConventionSetBuilder(
        ProviderConventionSetBuilderDependencies dependencies)
        : base(dependencies)
    {
    }

    public override ConventionSet CreateConventionSet()
    {
        // 1. Get all the standard EF conventions (Discovery, etc.)
        var conventionSet = base.CreateConventionSet();

        // 2. Add your custom convention to the existing list
        conventionSet.EntityTypeAddedConventions.Add(new StorageTableKeyDiscoveryConvention());

        return conventionSet;
    }
}