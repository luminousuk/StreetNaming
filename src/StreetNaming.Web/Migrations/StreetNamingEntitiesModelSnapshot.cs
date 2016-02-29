using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using StreetNaming.Web.Models;

namespace StreetNaming.Web.Migrations
{
    [DbContext(typeof(StreetNamingEntities))]
    partial class StreetNamingEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("StreetNaming.Domain.Models.Applicant", b =>
                {
                    b.Property<long>("ApplicantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Mobile");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PostCode");

                    b.Property<string>("Telephone");

                    b.Property<string>("Title");

                    b.HasKey("ApplicantId");
                });
        }
    }
}
