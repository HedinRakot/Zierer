using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Interests to entity <see cref="Interests"/>
    /// </summary>
    internal sealed class InterestsMapping: EntityTypeConfiguration<Interests>
    {
        
        public static readonly InterestsMapping Instance = new InterestsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="InterestsMapping" /> class.
        /// </summary>
        private InterestsMapping()
        {

            ToTable("Interests", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(Interests.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Description)
                .HasColumnName(Interests.Fields.Description)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(256);

            Property(t => t.Price)
                .HasColumnName(Interests.Fields.Price)
                .IsRequired();

            Property(t => t.ProceedsAccountId)
                .HasColumnName(Interests.Fields.ProceedsAccountId)
                .IsRequired();

            Property(t => t.FromDate)
                .HasColumnName(Interests.Fields.FromDate)
                .IsRequired();

            Property(t => t.ToDate)
                .HasColumnName(Interests.Fields.ToDate);

            Property(t => t.CreateDate)
                .HasColumnName(Interests.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(Interests.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(Interests.Fields.DeleteDate);


            //Relationships
            HasRequired(i => i.ProceedsAccounts)
                .WithMany(p => p.Interests)
                .HasForeignKey(t => t.ProceedsAccountId);
        }
    }
}
