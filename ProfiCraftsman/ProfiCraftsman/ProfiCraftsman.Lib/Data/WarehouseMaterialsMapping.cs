using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.WarehouseMaterials to entity <see cref="WarehouseMaterials"/>
    /// </summary>
    internal sealed class WarehouseMaterialsMapping: EntityTypeConfiguration<WarehouseMaterials>
    {
        
        public static readonly WarehouseMaterialsMapping Instance = new WarehouseMaterialsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="WarehouseMaterialsMapping" /> class.
        /// </summary>
        private WarehouseMaterialsMapping()
        {

            ToTable("WarehouseMaterials", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(WarehouseMaterials.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.MaterialId)
                .HasColumnName(WarehouseMaterials.Fields.MaterialId)
                .IsRequired();

            Property(t => t.IsAmount)
                .HasColumnName(WarehouseMaterials.Fields.IsAmount)
                .IsRequired();

            Property(t => t.MustAmount)
                .HasColumnName(WarehouseMaterials.Fields.MustAmount)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(WarehouseMaterials.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(WarehouseMaterials.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(WarehouseMaterials.Fields.DeleteDate);


            //Relationships
            HasRequired(w => w.Materials)
                .WithMany(m => m.WarehouseMaterials)
                .HasForeignKey(t => t.MaterialId);
        }
    }
}
