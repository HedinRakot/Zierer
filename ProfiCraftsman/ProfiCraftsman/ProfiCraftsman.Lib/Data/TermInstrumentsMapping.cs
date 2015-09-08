using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.TermInstruments to entity <see cref="TermInstruments"/>
    /// </summary>
    internal sealed class TermInstrumentsMapping: EntityTypeConfiguration<TermInstruments>
    {
        
        public static readonly TermInstrumentsMapping Instance = new TermInstrumentsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="TermInstrumentsMapping" /> class.
        /// </summary>
        private TermInstrumentsMapping()
        {

            ToTable("TermInstruments", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(TermInstruments.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.TermId)
                .HasColumnName(TermInstruments.Fields.TermId)
                .IsRequired();

            Property(t => t.InstrumentId)
                .HasColumnName(TermInstruments.Fields.InstrumentId)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(TermInstruments.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(TermInstruments.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(TermInstruments.Fields.DeleteDate);

            Property(t => t.EmployeeId)
                .HasColumnName(TermInstruments.Fields.EmployeeId)
                .IsRequired();


            //Relationships
            HasRequired(t => t.Employees)
                .WithMany(e => e.TermInstruments)
                .HasForeignKey(t => t.EmployeeId);
            HasRequired(t => t.Terms)
                .WithMany(t => t.TermInstruments)
                .HasForeignKey(t => t.TermId);
            HasRequired(t => t.Instruments)
                .WithMany(i => i.TermInstruments)
                .HasForeignKey(t => t.InstrumentId);
        }
    }
}
