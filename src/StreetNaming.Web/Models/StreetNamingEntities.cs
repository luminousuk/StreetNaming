using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using StreetNaming.Domain.Models;

namespace StreetNaming.Web.Models
{
    public sealed class StreetNamingEntities : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Request> Requests { get; set; }

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
                .Property(x => x.Area)
                .HasMaxLength(100);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.Town)
                .HasMaxLength(100);

            modelBuilder.Entity<Applicant>()
                .Property(x => x.PostCode)
                .HasMaxLength(10)
                .IsRequired();

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
             * Request
             */
            modelBuilder.Entity<Request>()
                .HasKey(x => x.RequestId);

            modelBuilder.Entity<Request>()
                .Property(x => x.RequestType)
                .IsRequired();

            modelBuilder.Entity<Request>()
                .Property(x => x.RequestStatus)
                .IsRequired();

            modelBuilder.Entity<Request>()
                .Property(x => x.ProposedAddress1)
                .HasMaxLength(400)
                .IsRequired();

            modelBuilder.Entity<Request>()
                .Property(x => x.ProposedAddress2)
                .HasMaxLength(400);

            modelBuilder.Entity<Request>()
                .Property(x => x.ProposedAddress3)
                .HasMaxLength(400);

            modelBuilder.Entity<Request>()
                .Property(x => x.ExistingPropertyUrn)
                .IsRequired(false);

            modelBuilder.Entity<Request>()
                .Property(x => x.IsRegisteredOwner)
                .IsRequired();

            modelBuilder.Entity<Request>()
                .Property(x => x.Signed)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Request>()
                .Property(x => x.Reference)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Request>()
                .Property(x => x.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            modelBuilder.Entity<Request>()
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
                .HasOne(a => a.Request)
                .WithMany(r => r.Attachments)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(a => a.RequestId)
                .IsRequired();

            modelBuilder.Entity<Request>()
                .HasOne(r => r.Applicant)
                .WithMany(a => a.Requests)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(r => r.ApplicantId)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Request)
                .WithMany(r => r.Transactions)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(t => t.RequestId)
                .IsRequired();


            /*
             * Indexes
             */
            modelBuilder.Entity<Request>()
               .HasIndex(r => r.Reference)
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
