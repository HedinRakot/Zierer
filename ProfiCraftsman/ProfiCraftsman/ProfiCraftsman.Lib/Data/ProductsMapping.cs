using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Products to entity <see cref="Products"/>
    /// </summary>
    internal sealed class ProductsMapping: EntityTypeConfiguration<Products>
    {
        
        public static readonly ProductsMapping Instance = new ProductsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ProductsMapping" /> class.
        /// </summary>
        private ProductsMapping()
        {

            ToTable("Products", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(Products.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Number)
                .HasColumnName(Products.Fields.Number)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);

            Property(t => t.ProductTypeId)
                .HasColumnName(Products.Fields.ProductTypeId);

            Property(t => t.Price)
                .HasColumnName(Products.Fields.Price)
                .IsRequired();

            Property(t => t.ProceedsAccount)
                .HasColumnName(Products.Fields.ProceedsAccount)
                .IsRequired();

            Property(t => t.Comment)
                .HasColumnName(Products.Fields.Comment)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.CreateDate)
                .HasColumnName(Products.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(Products.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(Products.Fields.DeleteDate);

            Property(t => t.Name)
                .HasColumnName(Products.Fields.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);

            Property(t => t.ProductAmountType)
                .HasColumnName(Products.Fields.ProductAmountType)
                .IsRequired();


            //Relationships
            HasOptional(p => p.ProductTypes)
                .WithMany(p => p.Products)
                .HasForeignKey(t => t.ProductTypeId);
        }
    }
}
