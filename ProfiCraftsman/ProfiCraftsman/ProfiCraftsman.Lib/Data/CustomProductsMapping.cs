using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.CustomProducts to entity <see cref="CustomProducts"/>
    /// </summary>
    internal sealed class CustomProductsMapping: EntityTypeConfiguration<CustomProducts>
    {
        
        public static readonly CustomProductsMapping Instance = new CustomProductsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomProductsMapping" /> class.
        /// </summary>
        private CustomProductsMapping()
        {

            ToTable("CustomProducts", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(CustomProducts.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Name)
                .HasColumnName(CustomProducts.Fields.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(256);

            Property(t => t.Price)
                .HasColumnName(CustomProducts.Fields.Price)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(CustomProducts.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(CustomProducts.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(CustomProducts.Fields.DeleteDate);

            Property(t => t.Auto)
                .HasColumnName(CustomProducts.Fields.Auto)
                .IsRequired();

            Property(t => t.ProceedsAccountId)
                .HasColumnName(CustomProducts.Fields.ProceedsAccountId)
                .IsRequired();


            //Relationships
            HasRequired(c => c.ProceedsAccounts)
                .WithMany(p => p.CustomProducts)
                .HasForeignKey(t => t.ProceedsAccountId);
        }
    }
}
