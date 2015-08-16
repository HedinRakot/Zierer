using MetadataLoader.Contracts.Database;
using MetadataLoader.EntityFramework.Extractors;

namespace ProfiCraftsman.Generation
{
    public sealed class EntityRelationshipExtractor : EntityRelationshipExtractor<ITable<TableContent, ColumnContent>, TableContent, IColumn<ColumnContent>, ColumnContent>
    {
    }
}