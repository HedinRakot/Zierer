using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.NotProductiveWorkHours to entity <see cref="NotProductiveWorkHours"/>
    /// </summary>
    internal sealed class NotProductiveWorkHoursMapping: EntityTypeConfiguration<NotProductiveWorkHours>
    {
        
        public static readonly NotProductiveWorkHoursMapping Instance = new NotProductiveWorkHoursMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="NotProductiveWorkHoursMapping" /> class.
        /// </summary>
        private NotProductiveWorkHoursMapping()
        {

            ToTable("NotProductiveWorkHours", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(NotProductiveWorkHours.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.EmployeeId)
                .HasColumnName(NotProductiveWorkHours.Fields.EmployeeId)
                .IsRequired();

            Property(t => t.Description)
                .HasColumnName(NotProductiveWorkHours.Fields.Description)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(256);

            Property(t => t.FromDate)
                .HasColumnName(NotProductiveWorkHours.Fields.FromDate)
                .IsRequired();

            Property(t => t.ToDate)
                .HasColumnName(NotProductiveWorkHours.Fields.ToDate)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(NotProductiveWorkHours.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(NotProductiveWorkHours.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(NotProductiveWorkHours.Fields.DeleteDate);


            //Relationships
            HasRequired(n => n.Employees)
                .WithMany(e => e.NotProductiveWorkHours)
                .HasForeignKey(t => t.EmployeeId);
        }
    }
}
