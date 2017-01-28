using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlexanderTsema.Storage.Concretes.Migrations
{
    public partial class Certificate_props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Authority",
                table: "Certificate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Certificate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecieveDate",
                table: "Certificate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authority",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "RecieveDate",
                table: "Certificate");
        }
    }
}
