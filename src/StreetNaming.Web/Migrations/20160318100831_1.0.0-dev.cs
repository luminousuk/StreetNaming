using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace StreetNaming.Web.Migrations
{
    public partial class _100dev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    County = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    FullAddress = table.Column<string>(nullable: true),
                    HouseName = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    PostCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.ApplicantId);
                });
            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    CaseId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    ApplicantId = table.Column<int>(nullable: false),
                    CaseStatus = table.Column<int>(nullable: false),
                    CaseType = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    CustomerReference = table.Column<string>(nullable: true),
                    EffectiveDate = table.Column<DateTime>(nullable: true),
                    ExistingPropertyUrn = table.Column<int>(nullable: true),
                    IsRegisteredOwner = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ProposedAddress1 = table.Column<string>(nullable: false),
                    ProposedAddress2 = table.Column<string>(nullable: true),
                    ProposedAddress3 = table.Column<string>(nullable: true),
                    Reference = table.Column<Guid>(nullable: false),
                    Signed = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_Case_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Bytes = table.Column<byte[]>(nullable: false),
                    CaseId = table.Column<int>(nullable: false),
                    ContentType = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    OriginalFileName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK_Attachment_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Amount = table.Column<decimal>(nullable: false),
                    CaseId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Currency = table.Column<string>(nullable: false),
                    Provider = table.Column<string>(nullable: false),
                    Reference = table.Column<Guid>(nullable: false),
                    ResponseCode = table.Column<int>(nullable: true),
                    ResponseDate = table.Column<DateTime>(nullable: true),
                    ResponseDescription = table.Column<string>(nullable: true),
                    TransactionStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "IX_Applicant_FirstName_LastName_Email",
                table: "Applicant",
                columns: new[] { "FirstName", "LastName", "Email" },
                unique: true);
            migrationBuilder.CreateIndex(
                name: "IX_Case_CustomerReference",
                table: "Case",
                column: "CustomerReference",
                unique: true);
            migrationBuilder.CreateIndex(
                name: "IX_Case_Reference",
                table: "Case",
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
            migrationBuilder.DropTable("Case");
            migrationBuilder.DropTable("Applicant");
        }
    }
}
