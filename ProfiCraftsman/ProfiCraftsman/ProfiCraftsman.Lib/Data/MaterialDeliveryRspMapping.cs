using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Material_Delivery_Rsp to entity <see cref="MaterialDeliveryRsp"/>
    /// </summary>
    internal sealed class MaterialDeliveryRspMapping: EntityTypeConfiguration<MaterialDeliveryRsp>
    {
        
        public static readonly MaterialDeliveryRspMapping Instance = new MaterialDeliveryRspMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="MaterialDeliveryRspMapping" /> class.
        /// </summary>
        private MaterialDeliveryRspMapping()
        {

            ToTable("Material_Delivery_Rsp", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(MaterialDeliveryRsp.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.MaterialId)
                .HasColumnName(MaterialDeliveryRsp.Fields.MaterialId)
                .IsRequired();

            Property(t => t.Amount)
                .HasColumnName(MaterialDeliveryRsp.Fields.Amount)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(MaterialDeliveryRsp.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(MaterialDeliveryRsp.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(MaterialDeliveryRsp.Fields.DeleteDate);


            //Relationships
            HasRequired(m => m.Materials)
                .WithMany(m => m.MaterialDeliveryRsps)
                .HasForeignKey(t => t.MaterialId);
        }
    }
}
