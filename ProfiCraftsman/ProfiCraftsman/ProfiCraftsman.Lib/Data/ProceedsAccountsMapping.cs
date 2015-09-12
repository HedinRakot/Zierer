using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.ProceedsAccounts to entity <see cref="ProceedsAccounts"/>
    /// </summary>
    internal sealed class ProceedsAccountsMapping: EntityTypeConfiguration<ProceedsAccounts>
    {
        
        public static readonly ProceedsAccountsMapping Instance = new ProceedsAccountsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ProceedsAccountsMapping" /> class.
        /// </summary>
        private ProceedsAccountsMapping()
        {

            ToTable("ProceedsAccounts", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(ProceedsAccounts.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Value)
                .HasColumnName(ProceedsAccounts.Fields.Value)
                .IsRequired();

            Property(t => t.CreateDate)
                .HasColumnName(ProceedsAccounts.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(ProceedsAccounts.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(ProceedsAccounts.Fields.DeleteDate);


            //Relationships
        }
    }
}
