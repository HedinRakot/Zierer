using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Materials to entity <see cref="Materials"/>
    /// </summary>
    internal sealed class MaterialsMapping: EntityTypeConfiguration<Materials>
    {
        
        public static readonly MaterialsMapping Instance = new MaterialsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="MaterialsMapping" /> class.
        /// </summary>
        private MaterialsMapping()
        {

            ToTable("Materials", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(Materials.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Name)
                .HasColumnName(Materials.Fields.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);

            Property(t => t.Number)
                .HasColumnName(Materials.Fields.Number)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);

            Property(t => t.Length)
                .HasColumnName(Materials.Fields.Length);

            Property(t => t.Width)
                .HasColumnName(Materials.Fields.Width);

            Property(t => t.Height)
                .HasColumnName(Materials.Fields.Height);

            Property(t => t.Color)
                .HasColumnName(Materials.Fields.Color)
                .IsUnicode()
                .HasMaxLength(50);

            Property(t => t.Price)
                .HasColumnName(Materials.Fields.Price)
                .IsRequired();

            Property(t => t.IsVirtual)
                .HasColumnName(Materials.Fields.IsVirtual)
                .IsRequired();

            Property(t => t.BoughtFrom)
                .HasColumnName(Materials.Fields.BoughtFrom)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.BoughtPrice)
                .HasColumnName(Materials.Fields.BoughtPrice)
                .IsRequired();

            Property(t => t.Comment)
                .HasColumnName(Materials.Fields.Comment)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.CreateDate)
                .HasColumnName(Materials.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(Materials.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(Materials.Fields.DeleteDate);

            Property(t => t.MaterialAmountType)
                .HasColumnName(Materials.Fields.MaterialAmountType)
                .IsRequired();

            Property(t => t.IsForAuto)
                .HasColumnName(Materials.Fields.IsForAuto)
                .IsRequired();

            Property(t => t.MustCount)
                .HasColumnName(Materials.Fields.MustCount)
                .IsRequired();

            Property(t => t.ProceedsAccountId)
                .HasColumnName(Materials.Fields.ProceedsAccountId)
                .IsRequired();


            //Relationships
            HasRequired(m => m.ProceedsAccounts)
                .WithMany(p => p.Materials)
                .HasForeignKey(t => t.ProceedsAccountId);
        }
    }
}
