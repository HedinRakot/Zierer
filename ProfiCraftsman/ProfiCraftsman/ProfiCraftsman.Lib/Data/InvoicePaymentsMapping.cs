using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.InvoicePayments to entity <see cref="InvoicePayments"/>
    /// </summary>
    internal sealed class InvoicePaymentsMapping: EntityTypeConfiguration<InvoicePayments>
    {
        
        public static readonly InvoicePaymentsMapping Instance = new InvoicePaymentsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="InvoicePaymentsMapping" /> class.
        /// </summary>
        private InvoicePaymentsMapping()
        {

            ToTable("InvoicePayments", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(InvoicePayments.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.InvoiceId)
                .HasColumnName(InvoicePayments.Fields.InvoiceId)
                .IsRequired();

            Property(t => t.Amount)
                .HasColumnName(InvoicePayments.Fields.Amount)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(InvoicePayments.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(InvoicePayments.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(InvoicePayments.Fields.DeleteDate);


            //Relationships
            HasRequired(i => i.Invoices)
                .WithMany(i => i.InvoicePayments)
                .HasForeignKey(t => t.InvoiceId);
        }
    }
}
