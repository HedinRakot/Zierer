using MetadataLoader.Contracts.Database;
using MetadataLoader.EntityFramework;
using MetadataLoader.EntityFramework.Extractors;

namespace ProfiCraftsman.Generation
{
    public sealed class EntityPropertyExtractor : EntityPropertyExtractor<ITable<TableContent, ColumnContent>, TableContent, IColumn<ColumnContent>, ColumnContent>
    {
    }
}