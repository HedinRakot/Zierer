using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Absences to entity <see cref="Absences"/>
    /// </summary>
    internal sealed class AbsencesMapping: EntityTypeConfiguration<Absences>
    {
        
        public static readonly AbsencesMapping Instance = new AbsencesMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="AbsencesMapping" /> class.
        /// </summary>
        private AbsencesMapping()
        {

            ToTable("Absences", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(Absences.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.EmployeeId)
                .HasColumnName(Absences.Fields.EmployeeId)
                .IsRequired();

            Property(t => t.Description)
                .HasColumnName(Absences.Fields.Description)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(256);

            Property(t => t.FromDate)
                .HasColumnName(Absences.Fields.FromDate)
                .IsRequired();

            Property(t => t.ToDate)
                .HasColumnName(Absences.Fields.ToDate)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(Absences.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(Absences.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(Absences.Fields.DeleteDate);


            //Relationships
            HasRequired(a => a.Employees)
                .WithMany(e => e.Absences)
                .HasForeignKey(t => t.EmployeeId);
        }
    }
}
