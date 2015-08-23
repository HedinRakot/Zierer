using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Auto_Material_Rsp to entity <see cref="AutoMaterialRsp"/>
    /// </summary>
    internal sealed class AutoMaterialRspMapping: EntityTypeConfiguration<AutoMaterialRsp>
    {
        
        public static readonly AutoMaterialRspMapping Instance = new AutoMaterialRspMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="AutoMaterialRspMapping" /> class.
        /// </summary>
        private AutoMaterialRspMapping()
        {

            ToTable("Auto_Material_Rsp", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(AutoMaterialRsp.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.AutoId)
                .HasColumnName(AutoMaterialRsp.Fields.AutoId)
                .IsRequired();

            Property(t => t.MaterialId)
                .HasColumnName(AutoMaterialRsp.Fields.MaterialId)
                .IsRequired();

            Property(t => t.Amount)
                .HasColumnName(AutoMaterialRsp.Fields.Amount)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(AutoMaterialRsp.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(AutoMaterialRsp.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(AutoMaterialRsp.Fields.DeleteDate);


            //Relationships
            HasRequired(a => a.Materials)
                .WithMany(m => m.AutoMaterialRsps)
                .HasForeignKey(t => t.MaterialId);
            HasRequired(a => a.Autos)
                .WithMany(a => a.AutoMaterialRsps)
                .HasForeignKey(t => t.AutoId);
        }
    }
}
