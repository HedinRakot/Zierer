using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.DeliveryNoteSignatures to entity <see cref="DeliveryNoteSignatures"/>
    /// </summary>
    internal sealed class DeliveryNoteSignaturesMapping: EntityTypeConfiguration<DeliveryNoteSignatures>
    {
        
        public static readonly DeliveryNoteSignaturesMapping Instance = new DeliveryNoteSignaturesMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="DeliveryNoteSignaturesMapping" /> class.
        /// </summary>
        private DeliveryNoteSignaturesMapping()
        {

            ToTable("DeliveryNoteSignatures", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(DeliveryNoteSignatures.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.TermId)
                .HasColumnName(DeliveryNoteSignatures.Fields.TermId)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(DeliveryNoteSignatures.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(DeliveryNoteSignatures.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(DeliveryNoteSignatures.Fields.DeleteDate);

            Property(t => t.Signature)
                .HasColumnName(DeliveryNoteSignatures.Fields.Signature)
                .IsUnicode();


            //Relationships
            HasRequired(d => d.Terms)
                .WithMany(t => t.DeliveryNoteSignatures)
                .HasForeignKey(t => t.TermId);
        }
    }
}
