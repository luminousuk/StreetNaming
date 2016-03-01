using Microsoft.Data.Entity;
using StreetNaming.Domain.Models;

namespace StreetNaming.Web.Models
{
    public sealed class StreetNamingEntities : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
                .Property(x => x.Name)
                .IsRequired();
        }
    }
}
