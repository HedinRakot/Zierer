using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Rates to entity <see cref="Rates"/>
    /// </summary>
    internal sealed class RatesMapping: EntityTypeConfiguration<Rates>
    {
        
        public static readonly RatesMapping Instance = new RatesMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="RatesMapping" /> class.
        /// </summary>
        private RatesMapping()
        {

            ToTable("Rates", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(Rates.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.JobPositionId)
                .HasColumnName(Rates.Fields.JobPositionId)
                .IsRequired();

            Property(t => t.Price)
                .HasColumnName(Rates.Fields.Price)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(Rates.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(Rates.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(Rates.Fields.DeleteDate);

            Property(t => t.FromDate)
                .HasColumnName(Rates.Fields.FromDate)
                .IsRequired();

            Property(t => t.ToDate)
                .HasColumnName(Rates.Fields.ToDate)
                .IsRequired();


            //Relationships
            HasRequired(r => r.JobPositions)
                .WithMany(j => j.Rates)
                .HasForeignKey(t => t.JobPositionId);
        }
    }
}
