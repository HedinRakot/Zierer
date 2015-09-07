using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.SearchPositionView to entity <see cref="SearchPositionView"/>
    /// </summary>
    internal sealed class SearchPositionViewMapping: EntityTypeConfiguration<SearchPositionView>
    {
        
        public static readonly SearchPositionViewMapping Instance = new SearchPositionViewMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="SearchPositionViewMapping" /> class.
        /// </summary>
        private SearchPositionViewMapping()
        {

            ToTable("SearchPositionView", "dbo");

            //Properties
            Property(t => t.Id)
                .HasColumnName(SearchPositionView.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.OrderId)
                .HasColumnName(SearchPositionView.Fields.OrderId)
                .IsRequired();

            Property(t => t.IsMaterialPosition)
                .HasColumnName(SearchPositionView.Fields.IsMaterialPosition)
                .IsRequired();

            Property(t => t.ProductId)
                .HasColumnName(SearchPositionView.Fields.ProductId);

            Property(t => t.MaterialId)
                .HasColumnName(SearchPositionView.Fields.MaterialId);

            Property(t => t.Price)
                .HasColumnName(SearchPositionView.Fields.Price)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(SearchPositionView.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(SearchPositionView.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(SearchPositionView.Fields.DeleteDate);

            Property(t => t.Amount)
                .HasColumnName(SearchPositionView.Fields.Amount)
                .IsRequired();

            Property(t => t.IsAlternative)
                .HasColumnName(SearchPositionView.Fields.IsAlternative)
                .IsRequired();

            Property(t => t.PaymentType)
                .HasColumnName(SearchPositionView.Fields.PaymentType)
                .IsRequired();

            Property(t => t.Description)
                .HasColumnName(SearchPositionView.Fields.Description)
                .IsUnicode()
                .HasMaxLength(250);

            Property(t => t.ParentId)
                .HasColumnName(SearchPositionView.Fields.ParentId);

            Property(t => t.RestAmount)
                .HasColumnName(SearchPositionView.Fields.RestAmount);

            Property(t => t.Number)
                .HasColumnName(SearchPositionView.Fields.Number)
                .IsUnicode()
                .HasMaxLength(20);

            Property(t => t.ProductAmountType)
                .HasColumnName(SearchPositionView.Fields.ProductAmountType);


            //Relationships
        }
    }
}
