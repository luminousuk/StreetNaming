using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using StreetNaming.Web.Models;

namespace StreetNaming.Web.Migrations
{
    [DbContext(typeof(StreetNamingEntities))]
    [Migration("20160301103735_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("StreetNaming.Domain.Models.Applicant", b =>
                {
                    b.Property<long>("ApplicantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("Mobile");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PostCode");

                    b.Property<string>("Telephone");

                    b.Property<string>("Title");

                    b.HasKey("ApplicantId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Attachment", b =>
                {
                    b.Property<long>("AttachmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Bytes");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("MimeType");

                    b.Property<DateTime>("Mod");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("OriginalFileName");

                    b.Property<long?>("RequestRequestId");

                    b.HasKey("AttachmentId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Request", b =>
                {
                    b.Property<long>("RequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ApplicantApplicantId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ExistingAddress");

                    b.Property<bool>("IsRegisteredOwner");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ProposedAddress1");

                    b.Property<string>("ProposedAddress2");

                    b.Property<string>("ProposedAddress3");

                    b.Property<int>("RequestStatus");

                    b.Property<int>("RequestType");

                    b.Property<string>("Signed");

                    b.HasKey("RequestId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Attachment", b =>
                {
                    b.HasOne("StreetNaming.Domain.Models.Request")
                        .WithMany()
                        .HasForeignKey("RequestRequestId");
                });

            modelBuilder.Entity("StreetNaming.Domain.Models.Request", b =>
                {
                    b.HasOne("StreetNaming.Domain.Models.Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantApplicantId");
                });
        }
    }
}
