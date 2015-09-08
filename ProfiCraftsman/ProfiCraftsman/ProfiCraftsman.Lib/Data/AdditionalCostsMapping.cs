using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.AdditionalCosts to entity <see cref="AdditionalCosts"/>
    /// </summary>
    internal sealed class AdditionalCostsMapping: EntityTypeConfiguration<AdditionalCosts>
    {
        
        public static readonly AdditionalCostsMapping Instance = new AdditionalCostsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdditionalCostsMapping" /> class.
        /// </summary>
        private AdditionalCostsMapping()
        {

            ToTable("AdditionalCosts", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(AdditionalCosts.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Description)
                .HasColumnName(AdditionalCosts.Fields.Description)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.Price)
                .HasColumnName(AdditionalCosts.Fields.Price)
                .IsRequired();

            Property(t => t.Automatic)
                .HasColumnName(AdditionalCosts.Fields.Automatic)
                .IsRequired();

            Property(t => t.ProceedsAccount)
                .HasColumnName(AdditionalCosts.Fields.ProceedsAccount)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(AdditionalCosts.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(AdditionalCosts.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(AdditionalCosts.Fields.DeleteDate);

            Property(t => t.FromDate)
                .HasColumnName(AdditionalCosts.Fields.FromDate)
                .IsRequired();

            Property(t => t.ToDate)
                .HasColumnName(AdditionalCosts.Fields.ToDate)
                .IsRequired();

            Property(t => t.AdditionalCostTypeId)
                .HasColumnName(AdditionalCosts.Fields.AdditionalCostTypeId)
                .IsRequired();


            //Relationships
            HasRequired(a => a.AdditionalCostTypes)
                .WithMany(a => a.AdditionalCosts)
                .HasForeignKey(t => t.AdditionalCostTypeId);
        }
    }
}
