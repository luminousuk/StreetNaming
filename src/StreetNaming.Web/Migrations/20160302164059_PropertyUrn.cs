using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace StreetNaming.Web.Migrations
{
    public partial class PropertyUrn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Attachment_Request_RequestId", table: "Attachment");
            migrationBuilder.DropColumn(name: "ExistingAddress", table: "Request");
            migrationBuilder.AddColumn<long>(
                name: "ExistingPropertyUrn",
                table: "Request",
                nullable: false,
                defaultValue: 0L);
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
            migrationBuilder.DropColumn(name: "ExistingPropertyUrn", table: "Request");
            migrationBuilder.AddColumn<string>(
                name: "ExistingAddress",
                table: "Request",
                nullable: true);
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
