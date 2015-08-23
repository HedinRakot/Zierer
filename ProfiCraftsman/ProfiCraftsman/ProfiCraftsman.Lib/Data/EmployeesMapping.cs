using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Employees to entity <see cref="Employees"/>
    /// </summary>
    internal sealed class EmployeesMapping: EntityTypeConfiguration<Employees>
    {
        
        public static readonly EmployeesMapping Instance = new EmployeesMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmployeesMapping" /> class.
        /// </summary>
        private EmployeesMapping()
        {

            ToTable("Employees", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(Employees.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Number)
                .HasColumnName(Employees.Fields.Number)
                .IsRequired();

            Property(t => t.JobPositionId)
                .HasColumnName(Employees.Fields.JobPositionId)
                .IsRequired();

            Property(t => t.AutoId)
                .HasColumnName(Employees.Fields.AutoId)
                .IsRequired();

            Property(t => t.Name)
                .HasColumnName(Employees.Fields.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.FirstName)
                .HasColumnName(Employees.Fields.FirstName)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.Street)
                .HasColumnName(Employees.Fields.Street)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.Zip)
                .HasColumnName(Employees.Fields.Zip)
                .IsUnicode()
                .HasMaxLength(10);

            Property(t => t.City)
                .HasColumnName(Employees.Fields.City)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.Country)
                .HasColumnName(Employees.Fields.Country)
                .IsUnicode()
                .HasMaxLength(50);

            Property(t => t.Phone)
                .HasColumnName(Employees.Fields.Phone)
                .IsUnicode()
                .HasMaxLength(20);

            Property(t => t.Mobile)
                .HasColumnName(Employees.Fields.Mobile)
                .IsUnicode()
                .HasMaxLength(20);

            Property(t => t.Fax)
                .HasColumnName(Employees.Fields.Fax)
                .IsUnicode()
                .HasMaxLength(20);

            Property(t => t.Email)
                .HasColumnName(Employees.Fields.Email)
                .IsUnicode()
                .HasMaxLength(50);

            Property(t => t.Comment)
                .HasColumnName(Employees.Fields.Comment)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.CreateDate)
                .HasColumnName(Employees.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(Employees.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(Employees.Fields.DeleteDate);


            //Relationships
            HasRequired(e => e.JobPositions)
                .WithMany(j => j.Employees)
                .HasForeignKey(t => t.JobPositionId);
            HasRequired(e => e.Autos)
                .WithMany(a => a.Employees)
                .HasForeignKey(t => t.AutoId);
        }
    }
}
