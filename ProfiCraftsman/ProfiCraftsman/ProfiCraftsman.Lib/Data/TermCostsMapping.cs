using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.TermCosts to entity <see cref="TermCosts"/>
    /// </summary>
    internal sealed class TermCostsMapping: EntityTypeConfiguration<TermCosts>
    {
        
        public static readonly TermCostsMapping Instance = new TermCostsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="TermCostsMapping" /> class.
        /// </summary>
        private TermCostsMapping()
        {

            ToTable("TermCosts", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(TermCosts.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.TermId)
                .HasColumnName(TermCosts.Fields.TermId)
                .IsRequired();

            Property(t => t.Price)
                .HasColumnName(TermCosts.Fields.Price)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(TermCosts.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(TermCosts.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(TermCosts.Fields.DeleteDate);

            Property(t => t.Name)
                .HasColumnName(TermCosts.Fields.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(256);

            Property(t => t.ProceedsAccountId)
                .HasColumnName(TermCosts.Fields.ProceedsAccountId)
                .IsRequired();


            //Relationships
            HasRequired(t => t.Terms)
                .WithMany(t => t.TermCosts)
                .HasForeignKey(t => t.TermId);
            HasRequired(t => t.ProceedsAccounts)
                .WithMany(p => p.TermCosts)
                .HasForeignKey(t => t.ProceedsAccountId);
        }
    }
}
