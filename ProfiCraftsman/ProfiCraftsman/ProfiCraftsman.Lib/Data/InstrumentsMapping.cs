using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Instruments to entity <see cref="Instruments"/>
    /// </summary>
    internal sealed class InstrumentsMapping: EntityTypeConfiguration<Instruments>
    {
        
        public static readonly InstrumentsMapping Instance = new InstrumentsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="InstrumentsMapping" /> class.
        /// </summary>
        private InstrumentsMapping()
        {

            ToTable("Instruments", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(Instruments.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Name)
                .HasColumnName(Instruments.Fields.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);

            Property(t => t.Number)
                .HasColumnName(Instruments.Fields.Number)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);

            Property(t => t.IsForAuto)
                .HasColumnName(Instruments.Fields.IsForAuto)
                .IsRequired();

            Property(t => t.BoughtFrom)
                .HasColumnName(Instruments.Fields.BoughtFrom)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.BoughtPrice)
                .HasColumnName(Instruments.Fields.BoughtPrice)
                .IsRequired();

            Property(t => t.Comment)
                .HasColumnName(Instruments.Fields.Comment)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.CreateDate)
                .HasColumnName(Instruments.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(Instruments.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(Instruments.Fields.DeleteDate);

            Property(t => t.ProceedsAccountId)
                .HasColumnName(Instruments.Fields.ProceedsAccountId)
                .IsRequired();


            //Relationships
            HasRequired(i => i.ProceedsAccounts)
                .WithMany(p => p.Instruments)
                .HasForeignKey(t => t.ProceedsAccountId);
        }
    }
}
