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
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
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
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ExistingAddress = table.Column<string>(nullable: true),
                    IsRegisteredOwner = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProposedAddress1 = table.Column<string>(nullable: true),
                    ProposedAddress2 = table.Column<string>(nullable: true),
                    ProposedAddress3 = table.Column<string>(nullable: true),
                    RequestStatus = table.Column<int>(nullable: false),
                    RequestType = table.Column<int>(nullable: false),
                    Signed = table.Column<string>(nullable: true)
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
            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    AttachmentId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Bytes = table.Column<byte[]>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    MimeType = table.Column<string>(nullable: true),
                    Mod = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    OriginalFileName = table.Column<string>(nullable: true),
                    RequestRequestId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK_Attachment_Request_RequestRequestId",
                        column: x => x.RequestRequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Attachment");
            migrationBuilder.DropTable("Request");
            migrationBuilder.DropTable("Applicant");
        }
    }
}
