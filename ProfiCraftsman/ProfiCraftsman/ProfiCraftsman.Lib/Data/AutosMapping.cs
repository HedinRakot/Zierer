using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Autos to entity <see cref="Autos"/>
    /// </summary>
    internal sealed class AutosMapping: EntityTypeConfiguration<Autos>
    {
        
        public static readonly AutosMapping Instance = new AutosMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="AutosMapping" /> class.
        /// </summary>
        private AutosMapping()
        {

            ToTable("Autos", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(Autos.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Number)
                .HasColumnName(Autos.Fields.Number)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);

            Property(t => t.Comment)
                .HasColumnName(Autos.Fields.Comment)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.LastInspectionDate)
                .HasColumnName(Autos.Fields.LastInspectionDate);

            Property(t => t.CreateDate)
                .HasColumnName(Autos.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(Autos.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(Autos.Fields.DeleteDate);


            //Relationships
        }
    }
}
