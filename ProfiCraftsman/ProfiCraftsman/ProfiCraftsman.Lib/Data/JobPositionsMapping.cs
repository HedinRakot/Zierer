using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.JobPositions to entity <see cref="JobPositions"/>
    /// </summary>
    internal sealed class JobPositionsMapping: EntityTypeConfiguration<JobPositions>
    {
        
        public static readonly JobPositionsMapping Instance = new JobPositionsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="JobPositionsMapping" /> class.
        /// </summary>
        private JobPositionsMapping()
        {

            ToTable("JobPositions", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(JobPositions.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Name)
                .HasColumnName(JobPositions.Fields.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.Comment)
                .HasColumnName(JobPositions.Fields.Comment)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.CreateDate)
                .HasColumnName(JobPositions.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(JobPositions.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(JobPositions.Fields.DeleteDate);


            //Relationships
        }
    }
}
