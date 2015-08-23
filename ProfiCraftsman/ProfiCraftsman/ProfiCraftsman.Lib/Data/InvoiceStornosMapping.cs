using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.InvoiceStornos to entity <see cref="InvoiceStornos"/>
    /// </summary>
    internal sealed class InvoiceStornosMapping: EntityTypeConfiguration<InvoiceStornos>
    {
        
        public static readonly InvoiceStornosMapping Instance = new InvoiceStornosMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="InvoiceStornosMapping" /> class.
        /// </summary>
        private InvoiceStornosMapping()
        {

            ToTable("InvoiceStornos", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(InvoiceStornos.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.InvoiceId)
                .HasColumnName(InvoiceStornos.Fields.InvoiceId)
                .IsRequired();

            Property(t => t.ProceedsAccount)
                .HasColumnName(InvoiceStornos.Fields.ProceedsAccount)
                .IsRequired();

            Property(t => t.Price)
                .HasColumnName(InvoiceStornos.Fields.Price)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(InvoiceStornos.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(InvoiceStornos.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(InvoiceStornos.Fields.DeleteDate);

            Property(t => t.DateVExportDate)
                .HasColumnName(InvoiceStornos.Fields.DateVExportDate);

            Property(t => t.DateVExportFile)
                .HasColumnName(InvoiceStornos.Fields.DateVExportFile)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.FreeText)
                .HasColumnName(InvoiceStornos.Fields.FreeText)
                .IsUnicode()
                .HasMaxLength(512);


            //Relationships
            HasRequired(i => i.Invoices)
                .WithMany(i => i.InvoiceStornos)
                .HasForeignKey(t => t.InvoiceId);
        }
    }
}
