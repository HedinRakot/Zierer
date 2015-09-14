using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.ForeignProducts to entity <see cref="ForeignProducts"/>
    /// </summary>
    internal sealed class ForeignProductsMapping: EntityTypeConfiguration<ForeignProducts>
    {
        
        public static readonly ForeignProductsMapping Instance = new ForeignProductsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ForeignProductsMapping" /> class.
        /// </summary>
        private ForeignProductsMapping()
        {

            ToTable("ForeignProducts", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(ForeignProducts.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Description)
                .HasColumnName(ForeignProducts.Fields.Description)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(256);

            Property(t => t.Price)
                .HasColumnName(ForeignProducts.Fields.Price)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(ForeignProducts.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(ForeignProducts.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(ForeignProducts.Fields.DeleteDate);

            Property(t => t.FromDate)
                .HasColumnName(ForeignProducts.Fields.FromDate)
                .IsRequired();

            Property(t => t.ToDate)
                .HasColumnName(ForeignProducts.Fields.ToDate);

            Property(t => t.ProceedsAccountId)
                .HasColumnName(ForeignProducts.Fields.ProceedsAccountId)
                .IsRequired();


            //Relationships
            HasRequired(f => f.ProceedsAccounts)
                .WithMany(p => p.ForeignProducts)
                .HasForeignKey(t => t.ProceedsAccountId);
        }
    }
}
