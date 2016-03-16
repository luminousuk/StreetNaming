using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using StreetNaming.Web.Models;

namespace StreetNaming.Web.Migrations
{
    [DbContext(typeof(StreetNamingEntities))]
    [Migration("20160316162041_1.0.0-dev")]
    partial class _100dev
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("StreetNaming.Domain.Models.Applicant", b =>
                {
                    b.Property<long>("ApplicantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("County");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "NOW()");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("FullAddress")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("HouseName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("HouseNumber");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Mobile")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "NOW()");

                    b.Property<string>("PostCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Street")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Telephone")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Town")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("ApplicantId");

                    b.HasIndex("FirstName", "LastName", "Email")
                        .IsUnique();
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Attachment", b =>
                {
                    b.Property<long>("AttachmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Bytes")
                        .IsRequired();

                    b.Property<long>("CaseId");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "NOW()");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "NOW()");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.HasKey("AttachmentId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Case", b =>
                {
                    b.Property<long>("CaseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInformation")
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<long>("ApplicantId");

                    b.Property<int>("CaseStatus");

                    b.Property<int>("CaseType");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "NOW()");

                    b.Property<string>("CustomerReference")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime?>("EffectiveDate");

                    b.Property<long?>("ExistingPropertyUrn");

                    b.Property<bool>("IsRegisteredOwner");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "NOW()");

                    b.Property<string>("ProposedAddress1")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 400);

                    b.Property<string>("ProposedAddress2")
                        .HasAnnotation("MaxLength", 400);

                    b.Property<string>("ProposedAddress3")
                        .HasAnnotation("MaxLength", 400);

                    b.Property<Guid>("Reference")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Signed")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("CaseId");

                    b.HasIndex("CustomerReference")
                        .IsUnique();

                    b.HasIndex("Reference")
                        .IsUnique();
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Transaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<long>("CaseId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "NOW()");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 3);

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("Reference")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ResponseCode");

                    b.Property<DateTime?>("ResponseDate");

                    b.Property<string>("ResponseDescription")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<int>("TransactionStatus");

                    b.HasKey("TransactionId");

                    b.HasIndex("Reference")
                        .IsUnique();
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Attachment", b =>
                {
                    b.HasOne("StreetNaming.Domain.Models.Case")
                        .WithMany()
                        .HasForeignKey("CaseId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Case", b =>
                {
                    b.HasOne("StreetNaming.Domain.Models.Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Transaction", b =>
                {
                    b.HasOne("StreetNaming.Domain.Models.Case")
                        .WithMany()
                        .HasForeignKey("CaseId");
                });
        }
    }
}
