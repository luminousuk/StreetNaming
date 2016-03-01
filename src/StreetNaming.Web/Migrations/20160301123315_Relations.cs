using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace StreetNaming.Web.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "MimeType", table: "Attachment");
            migrationBuilder.DropColumn(name: "Mod", table: "Attachment");
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Attachment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "ContentType", table: "Attachment");
            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "Attachment",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "Mod",
                table: "Attachment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
