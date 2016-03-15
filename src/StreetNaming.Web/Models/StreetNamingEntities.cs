using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using StreetNaming.Domain.Models;

namespace StreetNaming.Web.Models
{
    public sealed class StreetNamingEntities : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Case> Cases { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * Applicant
             */
            modelBuilder.Entity<Applicant>()
                .HasKey(x => x.ApplicantId);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.Title)
                .HasMaxLength(20);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Applicant>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Applicant>()
                .Property(x => x.HouseNumber);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.HouseName)
                .HasMaxLength(50);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.Street)
                .HasMaxLength(50);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.Town)
                .HasMaxLength(100);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.PostCode)
                .HasMaxLength(10);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.Telephone)
                .HasMaxLength(20);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.Mobile)
                .HasMaxLength(20);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.Email)
                .HasMaxLength(100);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            modelBuilder.Entity<Applicant>()
                .Property(x => x.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("NOW()")
                .IsRequired();


            /*
             * Attachment
             */
            modelBuilder.Entity<Attachment>()
                .HasKey(x => x.AttachmentId);

            modelBuilder.Entity<Attachment>()
                .Property(x => x.OriginalFileName)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Attachment>()
                .Property(x => x.ContentType)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Attachment>()
                .Property(x => x.Bytes)
                .IsRequired();

            modelBuilder.Entity<Attachment>()
                .Property(x => x.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            modelBuilder.Entity<Attachment>()
                .Property(x => x.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("NOW()")
                .IsRequired();


            /*
             * Case
             */
            modelBuilder.Entity<Case>()
                .HasKey(x => x.CaseId);

            modelBuilder.Entity<Case>()
                .Property(x => x.CaseType)
                .IsRequired();

            modelBuilder.Entity<Case>()
                .Property(x => x.CaseStatus)
                .IsRequired();

            modelBuilder.Entity<Case>()
                .Property(x => x.ProposedAddress1)
                .HasMaxLength(400)
                .IsRequired();

            modelBuilder.Entity<Case>()
                .Property(x => x.ProposedAddress2)
                .HasMaxLength(400);

            modelBuilder.Entity<Case>()
                .Property(x => x.ProposedAddress3)
                .HasMaxLength(400);

            modelBuilder.Entity<Case>()
                .Property(x => x.ExistingPropertyUrn)
                .IsRequired(false);

            modelBuilder.Entity<Case>()
                .Property(x => x.IsRegisteredOwner)
                .IsRequired();

            modelBuilder.Entity<Case>()
                .Property(x => x.Signed)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Case>()
                .Property(x => x.Reference)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Case>()
                .Property(x => x.Reference)
                .HasMaxLength(20)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Case>()
                .Property(x => x.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            modelBuilder.Entity<Case>()
                .Property(x => x.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("NOW()")
                .IsRequired();


            /*
             * Transaction
             */
            modelBuilder.Entity<Transaction>()
                .HasKey(x => x.TransactionId);

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Provider)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Reference)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Amount)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Currency)
                .HasMaxLength(3)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(x => x.ResponseCode)
                .IsRequired(false);

            modelBuilder.Entity<Transaction>()
                .Property(x => x.ResponseDescription)
                .HasMaxLength(500)
                .IsRequired(false);

            modelBuilder.Entity<Transaction>()
                .Property(x => x.ResponseDate)
                .IsRequired(false);

            modelBuilder.Entity<Transaction>()
                .Property(x => x.TransactionStatus)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(x => x.CreatedDate)
                .HasDefaultValueSql("NOW()")
                .IsRequired();


            /*
             * Relationships
             */
            modelBuilder.Entity<Attachment>()
                .HasOne(a => a.Case)
                .WithMany(r => r.Attachments)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(a => a.CaseId)
                .IsRequired();

            modelBuilder.Entity<Case>()
                .HasOne(r => r.Applicant)
                .WithMany(a => a.Cases)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(r => r.ApplicantId)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Case)
                .WithMany(r => r.Transactions)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(t => t.CaseId)
                .IsRequired();


            /*
             * Indexes
             */
            modelBuilder.Entity<Case>()
                .HasIndex(r => r.Reference)
                .IsUnique();

            modelBuilder.Entity<Case>()
                .HasIndex(r => r.CustomerReference)
                .IsUnique();

            modelBuilder.Entity<Transaction>()
                .HasIndex(t => t.Reference)
                .IsUnique();

            modelBuilder.Entity<Applicant>()
                .HasIndex(a => new {a.FirstName, a.LastName, a.Email})
                .IsUnique();
        }
    }
}