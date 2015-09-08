using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Positions to entity <see cref="Positions"/>
    /// </summary>
    internal sealed class PositionsMapping: EntityTypeConfiguration<Positions>
    {
        
        public static readonly PositionsMapping Instance = new PositionsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="PositionsMapping" /> class.
        /// </summary>
        private PositionsMapping()
        {

            ToTable("Positions", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(Positions.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.OrderId)
                .HasColumnName(Positions.Fields.OrderId)
                .IsRequired();

            Property(t => t.IsMaterialPosition)
                .HasColumnName(Positions.Fields.IsMaterialPosition)
                .IsRequired();

            Property(t => t.ProductId)
                .HasColumnName(Positions.Fields.ProductId);

            Property(t => t.MaterialId)
                .HasColumnName(Positions.Fields.MaterialId);

            Property(t => t.Price)
                .HasColumnName(Positions.Fields.Price)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(Positions.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(Positions.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(Positions.Fields.DeleteDate);

            Property(t => t.Amount)
                .HasColumnName(Positions.Fields.Amount)
                .IsRequired();

            Property(t => t.IsAlternative)
                .HasColumnName(Positions.Fields.IsAlternative)
                .IsRequired();

            Property(t => t.PaymentType)
                .HasColumnName(Positions.Fields.PaymentType)
                .IsRequired();

            Property(t => t.Description)
                .HasColumnName(Positions.Fields.Description)
                .IsUnicode()
                .HasMaxLength(250);

            Property(t => t.ParentId)
                .HasColumnName(Positions.Fields.ParentId);

            Property(t => t.TermId)
                .HasColumnName(Positions.Fields.TermId);


            //Relationships
            HasRequired(p => p.Orders)
                .WithMany(o => o.Positions)
                .HasForeignKey(t => t.OrderId);
            HasOptional(p => p.Terms)
                .WithMany(t => t.Positions)
                .HasForeignKey(t => t.TermId);
            HasOptional(p => p.Products)
                .WithMany(p => p.Positions)
                .HasForeignKey(t => t.ProductId);
            HasOptional(p => p.Materials)
                .WithMany(m => m.Positions)
                .HasForeignKey(t => t.MaterialId);
        }
    }
}
