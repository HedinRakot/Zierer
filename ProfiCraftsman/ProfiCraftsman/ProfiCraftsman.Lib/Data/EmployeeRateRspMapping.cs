using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Employee_Rate_Rsp to entity <see cref="EmployeeRateRsp"/>
    /// </summary>
    internal sealed class EmployeeRateRspMapping: EntityTypeConfiguration<EmployeeRateRsp>
    {
        
        public static readonly EmployeeRateRspMapping Instance = new EmployeeRateRspMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmployeeRateRspMapping" /> class.
        /// </summary>
        private EmployeeRateRspMapping()
        {

            ToTable("Employee_Rate_Rsp", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(EmployeeRateRsp.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.EmployeeId)
                .HasColumnName(EmployeeRateRsp.Fields.EmployeeId)
                .IsRequired();

            Property(t => t.JobPositionId)
                .HasColumnName(EmployeeRateRsp.Fields.JobPositionId)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(EmployeeRateRsp.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(EmployeeRateRsp.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(EmployeeRateRsp.Fields.DeleteDate);

            Property(t => t.FromDate)
                .HasColumnName(EmployeeRateRsp.Fields.FromDate)
                .IsRequired();

            Property(t => t.ToDate)
                .HasColumnName(EmployeeRateRsp.Fields.ToDate)
                .IsRequired();

            Property(t => t.SalaryType)
                .HasColumnName(EmployeeRateRsp.Fields.SalaryType)
                .IsRequired();

            Property(t => t.Salary)
                .HasColumnName(EmployeeRateRsp.Fields.Salary)
                .IsRequired();


            //Relationships
            HasRequired(e => e.JobPositions)
                .WithMany(j => j.EmployeeRateRsps)
                .HasForeignKey(t => t.JobPositionId);
            HasRequired(e => e.Employees)
                .WithMany(e => e.EmployeeRateRsps)
                .HasForeignKey(t => t.EmployeeId);
        }
    }
}
