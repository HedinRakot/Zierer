using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.TermPositions to entity <see cref="TermPositions"/>
    /// </summary>
    internal sealed class TermPositionsMapping: EntityTypeConfiguration<TermPositions>
    {
        
        public static readonly TermPositionsMapping Instance = new TermPositionsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="TermPositionsMapping" /> class.
        /// </summary>
        private TermPositionsMapping()
        {

            ToTable("TermPositions", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(TermPositions.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.TermId)
                .HasColumnName(TermPositions.Fields.TermId)
                .IsRequired();

            Property(t => t.PositionId)
                .HasColumnName(TermPositions.Fields.PositionId)
                .IsRequired();

            Property(t => t.Amount)
                .HasColumnName(TermPositions.Fields.Amount)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(TermPositions.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(TermPositions.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(TermPositions.Fields.DeleteDate);

            Property(t => t.ProccessedAmount)
                .HasColumnName(TermPositions.Fields.ProccessedAmount);


            //Relationships
            HasRequired(t => t.Terms)
                .WithMany(t => t.TermPositions)
                .HasForeignKey(t => t.TermId);
            HasRequired(t => t.Positions)
                .WithMany(p => p.TermPositions)
                .HasForeignKey(t => t.PositionId);
        }
    }
}
