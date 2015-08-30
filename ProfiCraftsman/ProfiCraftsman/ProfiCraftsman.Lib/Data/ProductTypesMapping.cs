using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.ProductTypes to entity <see cref="ProductTypes"/>
    /// </summary>
    internal sealed class ProductTypesMapping: EntityTypeConfiguration<ProductTypes>
    {
        
        public static readonly ProductTypesMapping Instance = new ProductTypesMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ProductTypesMapping" /> class.
        /// </summary>
        private ProductTypesMapping()
        {

            ToTable("ProductTypes", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(ProductTypes.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Name)
                .HasColumnName(ProductTypes.Fields.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.Comment)
                .HasColumnName(ProductTypes.Fields.Comment)
                .IsUnicode()
                .HasMaxLength(256);

            Property(t => t.CreateDate)
                .HasColumnName(ProductTypes.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(ProductTypes.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(ProductTypes.Fields.DeleteDate);


            //Relationships
        }
    }
}
