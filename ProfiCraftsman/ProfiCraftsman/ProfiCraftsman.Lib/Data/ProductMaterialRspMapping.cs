using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Product_Material_Rsp to entity <see cref="ProductMaterialRsp"/>
    /// </summary>
    internal sealed class ProductMaterialRspMapping: EntityTypeConfiguration<ProductMaterialRsp>
    {
        
        public static readonly ProductMaterialRspMapping Instance = new ProductMaterialRspMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ProductMaterialRspMapping" /> class.
        /// </summary>
        private ProductMaterialRspMapping()
        {

            ToTable("Product_Material_Rsp", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(ProductMaterialRsp.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.ProductId)
                .HasColumnName(ProductMaterialRsp.Fields.ProductId)
                .IsRequired();

            Property(t => t.MaterialId)
                .HasColumnName(ProductMaterialRsp.Fields.MaterialId)
                .IsRequired();

            Property(t => t.Amount)
                .HasColumnName(ProductMaterialRsp.Fields.Amount);

            Property(t => t.CreateDate)
                .HasColumnName(ProductMaterialRsp.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(ProductMaterialRsp.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(ProductMaterialRsp.Fields.DeleteDate);


            //Relationships
            HasRequired(p => p.Materials)
                .WithMany(m => m.ProductMaterialRsps)
                .HasForeignKey(t => t.MaterialId);
            HasRequired(p => p.Products)
                .WithMany(p => p.ProductMaterialRsps)
                .HasForeignKey(t => t.ProductId);
        }
    }
}
