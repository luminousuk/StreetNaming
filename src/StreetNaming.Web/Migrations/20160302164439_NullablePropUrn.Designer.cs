using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using StreetNaming.Web.Models;

namespace StreetNaming.Web.Migrations
{
    [DbContext(typeof(StreetNamingEntities))]
    [Migration("20160302164439_NullablePropUrn")]
    partial class NullablePropUrn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("StreetNaming.Domain.Models.Applicant", b =>
                {
                    b.Property<long>("ApplicantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 400);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "NOW()");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Mobile")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "NOW()");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Telephone")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("ApplicantId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Attachment", b =>
                {
                    b.Property<long>("AttachmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Bytes")
                        .IsRequired();

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

                    b.Property<long>("RequestId");

                    b.HasKey("AttachmentId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Request", b =>
                {
                    b.Property<long>("RequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ApplicantId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "NOW()");

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

                    b.Property<int>("RequestStatus");

                    b.Property<int>("RequestType");

                    b.Property<string>("Signed")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("RequestId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Attachment", b =>
                {
                    b.HasOne("StreetNaming.Domain.Models.Request")
                        .WithMany()
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Request", b =>
                {
                    b.HasOne("StreetNaming.Domain.Models.Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId");
                });
        }
    }
}
