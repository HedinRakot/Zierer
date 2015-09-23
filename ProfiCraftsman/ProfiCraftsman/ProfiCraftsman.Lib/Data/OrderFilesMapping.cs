using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.OrderFiles to entity <see cref="OrderFiles"/>
    /// </summary>
    internal sealed class OrderFilesMapping: EntityTypeConfiguration<OrderFiles>
    {
        
        public static readonly OrderFilesMapping Instance = new OrderFilesMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="OrderFilesMapping" /> class.
        /// </summary>
        private OrderFilesMapping()
        {

            ToTable("OrderFiles", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(OrderFiles.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.OrderId)
                .HasColumnName(OrderFiles.Fields.OrderId)
                .IsRequired();

            Property(t => t.FileName)
                .HasColumnName(OrderFiles.Fields.FileName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(256);

            Property(t => t.Comment)
                .HasColumnName(OrderFiles.Fields.Comment)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.CreateDate)
                .HasColumnName(OrderFiles.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(OrderFiles.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(OrderFiles.Fields.DeleteDate);


            //Relationships
            HasRequired(o => o.Orders)
                .WithMany(o => o.OrderFiles)
                .HasForeignKey(t => t.OrderId);
        }
    }
}
