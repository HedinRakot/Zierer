using ProfiCraftsman.Contracts.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     Mappping table dbo.Terms to entity <see cref="Terms"/>
    /// </summary>
    internal sealed class TermsMapping: EntityTypeConfiguration<Terms>
    {
        
        public static readonly TermsMapping Instance = new TermsMapping();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="TermsMapping" /> class.
        /// </summary>
        private TermsMapping()
        {

            ToTable("Terms", "dbo");
            // Primary Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Id)
                .HasColumnName(Terms.Fields.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Date)
                .HasColumnName(Terms.Fields.Date)
                .IsRequired();

            Property(t => t.EmployeeId)
                .HasColumnName(Terms.Fields.EmployeeId)
                .IsRequired();

            Property(t => t.AutoId)
                .HasColumnName(Terms.Fields.AutoId)
                .IsRequired();

            Property(t => t.Comment)
                .HasColumnName(Terms.Fields.Comment)
                .IsUnicode()
                .HasMaxLength(128);

            Property(t => t.CreateDate)
                .HasColumnName(Terms.Fields.CreateDate)
                .IsRequired();

            Property(t => t.ChangeDate)
                .HasColumnName(Terms.Fields.ChangeDate)
                .IsRequired();

            Property(t => t.DeleteDate)
                .HasColumnName(Terms.Fields.DeleteDate);

            Property(t => t.Status)
                .HasColumnName(Terms.Fields.Status)
                .IsRequired();

            Property(t => t.OrderId)
                .HasColumnName(Terms.Fields.OrderId)
                .IsRequired();

            Property(t => t.BeginTrip)
                .HasColumnName(Terms.Fields.BeginTrip);

            Property(t => t.EndTrip)
                .HasColumnName(Terms.Fields.EndTrip);

            Property(t => t.BeginWork)
                .HasColumnName(Terms.Fields.BeginWork);

            Property(t => t.EndWork)
                .HasColumnName(Terms.Fields.EndWork);

            Property(t => t.BeginReturnTrip)
                .HasColumnName(Terms.Fields.BeginReturnTrip);

            Property(t => t.EndReturnTrip)
                .HasColumnName(Terms.Fields.EndReturnTrip);

            Property(t => t.Duration)
                .HasColumnName(Terms.Fields.Duration)
                .IsRequired();

            Property(t => t.UserId)
                .HasColumnName(Terms.Fields.UserId);

            Property(t => t.BeginTripFromOffice)
                .HasColumnName(Terms.Fields.BeginTripFromOffice);


            //Relationships
            HasOptional(t => t.User)
                .WithMany(u => u.Terms)
                .HasForeignKey(t => t.UserId);
            HasRequired(t => t.Autos)
                .WithMany(a => a.Terms)
                .HasForeignKey(t => t.AutoId);
            HasRequired(t => t.Employees)
                .WithMany(e => e.Terms)
                .HasForeignKey(t => t.EmployeeId);
            HasRequired(t => t.Orders)
                .WithMany(o => o.Terms)
                .HasForeignKey(t => t.OrderId);
        }
    }
}
