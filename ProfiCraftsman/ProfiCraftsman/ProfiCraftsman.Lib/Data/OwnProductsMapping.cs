using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.OwnProducts to entity <see cref="OwnProducts"/>
    /// </summary>
    internal sealed class OwnProductsMapping: EntityTypeConfiguration<OwnProducts>
    {
        
        public static readonly OwnProductsMapping Instance = new OwnProductsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="OwnProductsMapping" /> class.
        /// </summary>
        private OwnProductsMapping()
        {

            ToTable("OwnProducts", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(OwnProducts.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Description)
                .HasColumnName(OwnProducts.Fields.Description)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(256);

            Property(t => t.Price)
                .HasColumnName(OwnProducts.Fields.Price)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(OwnProducts.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(OwnProducts.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(OwnProducts.Fields.DeleteDate);

            Property(t => t.FromDate)
                .HasColumnName(OwnProducts.Fields.FromDate)
                .IsRequired();

            Property(t => t.ToDate)
                .HasColumnName(OwnProducts.Fields.ToDate);

            Property(t => t.ProceedsAccountId)
                .HasColumnName(OwnProducts.Fields.ProceedsAccountId)
                .IsRequired();


            //Relationships
            HasRequired(o => o.ProceedsAccounts)
                .WithMany(p => p.OwnProducts)
                .HasForeignKey(t => t.ProceedsAccountId);
        }
    }
}
