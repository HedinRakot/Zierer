using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Position_Material_Rsp to entity <see cref="PositionMaterialRsp"/>
    /// </summary>
    internal sealed class PositionMaterialRspMapping: EntityTypeConfiguration<PositionMaterialRsp>
    {
        
        public static readonly PositionMaterialRspMapping Instance = new PositionMaterialRspMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="PositionMaterialRspMapping" /> class.
        /// </summary>
        private PositionMaterialRspMapping()
        {

            ToTable("Position_Material_Rsp", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(PositionMaterialRsp.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.PositionId)
                .HasColumnName(PositionMaterialRsp.Fields.PositionId)
                .IsRequired();

            Property(t => t.MaterialId)
                .HasColumnName(PositionMaterialRsp.Fields.MaterialId)
                .IsRequired();

            Property(t => t.Amount)
                .HasColumnName(PositionMaterialRsp.Fields.Amount)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(PositionMaterialRsp.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(PositionMaterialRsp.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(PositionMaterialRsp.Fields.DeleteDate);


            //Relationships
            HasRequired(p => p.Materials)
                .WithMany(m => m.PositionMaterialRsps)
                .HasForeignKey(t => t.MaterialId);
            HasRequired(p => p.Positions)
                .WithMany(p => p.PositionMaterialRsps)
                .HasForeignKey(t => t.PositionId);
        }
    }
}
