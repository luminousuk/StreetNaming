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
                    Address = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    PostCode = table.Column<string>(nullable: false),
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
                    ApplicantId = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ExistingPropertyUrn = table.Column<long>(nullable: true),
                    IsRegisteredOwner = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ProposedAddress1 = table.Column<string>(nullable: false),
                    ProposedAddress2 = table.Column<string>(nullable: true),
                    ProposedAddress3 = table.Column<string>(nullable: true),
                    Reference = table.Column<Guid>(nullable: false),
                    RequestStatus = table.Column<int>(nullable: false),
                    RequestType = table.Column<int>(nullable: false),
                    Signed = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Request_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
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
                    Bytes = table.Column<byte[]>(nullable: false),
                    ContentType = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    OriginalFileName = table.Column<string>(nullable: false),
                    RequestId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK_Attachment_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Currency = table.Column<string>(nullable: false),
                    Provider = table.Column<string>(nullable: false),
                    Reference = table.Column<Guid>(nullable: false),
                    RequestId = table.Column<long>(nullable: false),
                    ResponseCode = table.Column<int>(nullable: true),
                    ResponseDate = table.Column<DateTime>(nullable: true),
                    ResponseDescription = table.Column<string>(nullable: true),
                    TransactionStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "IX_Request_Reference",
                table: "Request",
                column: "Reference",
                unique: true);
            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Reference",
                table: "Transaction",
                column: "Reference",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Attachment");
            migrationBuilder.DropTable("Transaction");
            migrationBuilder.DropTable("Request");
            migrationBuilder.DropTable("Applicant");
        }
    }
}
