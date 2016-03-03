using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace StreetNaming.Web.Migrations
{
    public partial class Transaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Attachment_Request_RequestId", table: "Attachment");
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Currency = table.Column<char>(nullable: false),
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
            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Request_RequestId",
                table: "Attachment",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Attachment_Request_RequestId", table: "Attachment");
            migrationBuilder.DropTable("Transaction");
            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Request_RequestId",
                table: "Attachment",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
