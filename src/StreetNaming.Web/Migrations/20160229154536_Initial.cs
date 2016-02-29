using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace StreetNaming.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    ApplicantId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PostCode = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.ApplicantId);
                });
            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    ApplicantApplicantId = table.Column<long>(nullable: true),
                    ExistingAddress = table.Column<string>(nullable: true),
                    IsRegisteredOwner = table.Column<bool>(nullable: false),
                    ProposedAddress1 = table.Column<string>(nullable: true),
                    ProposedAddress2 = table.Column<string>(nullable: true),
                    ProposedAddress3 = table.Column<string>(nullable: true),
                    RequestType = table.Column<int>(nullable: false),
                    Signed = table.Column<string>(nullable: true),
                    SubmitDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Request_Applicant_ApplicantApplicantId",
                        column: x => x.ApplicantApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Request");
            migrationBuilder.DropTable("Applicant");
        }
    }
}
