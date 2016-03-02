using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace StreetNaming.Web.Migrations
{
    public partial class NullablePropUrn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Attachment_Request_RequestId", table: "Attachment");
            migrationBuilder.AlterColumn<long>(
                name: "ExistingPropertyUrn",
                table: "Request",
                nullable: true);
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
            migrationBuilder.AlterColumn<long>(
                name: "ExistingPropertyUrn",
                table: "Request",
                nullable: false);
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
