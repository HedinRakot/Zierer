using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.TermEmployees to entity <see cref="TermEmployees"/>
    /// </summary>
    internal sealed class TermEmployeesMapping: EntityTypeConfiguration<TermEmployees>
    {
        
        public static readonly TermEmployeesMapping Instance = new TermEmployeesMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="TermEmployeesMapping" /> class.
        /// </summary>
        private TermEmployeesMapping()
        {

            ToTable("TermEmployees", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(TermEmployees.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.TermId)
                .HasColumnName(TermEmployees.Fields.TermId)
                .IsRequired();

            Property(t => t.EmployeeId)
                .HasColumnName(TermEmployees.Fields.EmployeeId)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(TermEmployees.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(TermEmployees.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(TermEmployees.Fields.DeleteDate);


            //Relationships
            HasRequired(t => t.Employees)
                .WithMany(e => e.TermEmployees)
                .HasForeignKey(t => t.EmployeeId);
            HasRequired(t => t.Terms)
                .WithMany(t => t.TermEmployees)
                .HasForeignKey(t => t.TermId);
        }
    }
}
