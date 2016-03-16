using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace StreetNaming.Web.Migrations
{
    public partial class _100dev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Attachment_Case_CaseId", table: "Attachment");
            migrationBuilder.DropForeignKey(name: "FK_Transaction_Case_CaseId", table: "Transaction");
            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveDate",
                table: "Case",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Case_CaseId",
                table: "Attachment",
                column: "CaseId",
                principalTable: "Case",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Case_CaseId",
                table: "Transaction",
                column: "CaseId",
                principalTable: "Case",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Attachment_Case_CaseId", table: "Attachment");
            migrationBuilder.DropForeignKey(name: "FK_Transaction_Case_CaseId", table: "Transaction");
            migrationBuilder.DropColumn(name: "EffectiveDate", table: "Case");
            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Case_CaseId",
                table: "Attachment",
                column: "CaseId",
                principalTable: "Case",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Case_CaseId",
                table: "Transaction",
                column: "CaseId",
                principalTable: "Case",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
