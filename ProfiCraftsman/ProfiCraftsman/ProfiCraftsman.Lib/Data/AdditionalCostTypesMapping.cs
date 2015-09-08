using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.AdditionalCostTypes to entity <see cref="AdditionalCostTypes"/>
    /// </summary>
    internal sealed class AdditionalCostTypesMapping: EntityTypeConfiguration<AdditionalCostTypes>
    {
        
        public static readonly AdditionalCostTypesMapping Instance = new AdditionalCostTypesMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdditionalCostTypesMapping" /> class.
        /// </summary>
        private AdditionalCostTypesMapping()
        {

            ToTable("AdditionalCostTypes", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(AdditionalCostTypes.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Name)
                .HasColumnName(AdditionalCostTypes.Fields.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.CreateDate)
                .HasColumnName(AdditionalCostTypes.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(AdditionalCostTypes.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(AdditionalCostTypes.Fields.DeleteDate);


            //Relationships
        }
    }
}
