using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.TermPosition_Material_Rsp to entity <see cref="TermPositionMaterialRsp"/>
    /// </summary>
    internal sealed class TermPositionMaterialRspMapping: EntityTypeConfiguration<TermPositionMaterialRsp>
    {
        
        public static readonly TermPositionMaterialRspMapping Instance = new TermPositionMaterialRspMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="TermPositionMaterialRspMapping" /> class.
        /// </summary>
        private TermPositionMaterialRspMapping()
        {

            ToTable("TermPosition_Material_Rsp", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(TermPositionMaterialRsp.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.TermPositionId)
                .HasColumnName(TermPositionMaterialRsp.Fields.TermPositionId)
                .IsRequired();

            Property(t => t.MaterialId)
                .HasColumnName(TermPositionMaterialRsp.Fields.MaterialId)
                .IsRequired();

            Property(t => t.Amount)
                .HasColumnName(TermPositionMaterialRsp.Fields.Amount);

            Property(t => t.CreateDate)
                .HasColumnName(TermPositionMaterialRsp.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(TermPositionMaterialRsp.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(TermPositionMaterialRsp.Fields.DeleteDate);


            //Relationships
            HasRequired(t => t.Materials)
                .WithMany(m => m.TermPositionMaterialRsps)
                .HasForeignKey(t => t.MaterialId);
            HasRequired(t => t.TermPositions)
                .WithMany(t => t.TermPositionMaterialRsps)
                .HasForeignKey(t => t.TermPositionId);
        }
    }
}
