using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.SocialTaxes to entity <see cref="SocialTaxes"/>
    /// </summary>
    internal sealed class SocialTaxesMapping: EntityTypeConfiguration<SocialTaxes>
    {
        
        public static readonly SocialTaxesMapping Instance = new SocialTaxesMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="SocialTaxesMapping" /> class.
        /// </summary>
        private SocialTaxesMapping()
        {

            ToTable("SocialTaxes", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(SocialTaxes.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.EmployeeId)
                .HasColumnName(SocialTaxes.Fields.EmployeeId)
                .IsRequired();

            Property(t => t.Description)
                .HasColumnName(SocialTaxes.Fields.Description)
                .IsUnicode()
                .HasMaxLength(256);

            Property(t => t.Price)
                .HasColumnName(SocialTaxes.Fields.Price)
                .IsRequired();

            Property(t => t.ProceedsAccountId)
                .HasColumnName(SocialTaxes.Fields.ProceedsAccountId)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(SocialTaxes.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(SocialTaxes.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(SocialTaxes.Fields.DeleteDate);

            Property(t => t.FromDate)
                .HasColumnName(SocialTaxes.Fields.FromDate)
                .IsRequired();

            Property(t => t.ToDate)
                .HasColumnName(SocialTaxes.Fields.ToDate);


            //Relationships
            HasRequired(s => s.ProceedsAccounts)
                .WithMany(p => p.SocialTaxes)
                .HasForeignKey(t => t.ProceedsAccountId);
            HasRequired(s => s.Employees)
                .WithMany(e => e.SocialTaxes)
                .HasForeignKey(t => t.EmployeeId);
        }
    }
}
