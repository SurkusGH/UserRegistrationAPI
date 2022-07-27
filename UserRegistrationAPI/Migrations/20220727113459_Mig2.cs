using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserRegistrationAPI.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_DataSheets_DataSheetId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DataSheetId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90786b94-e42c-4443-ab05-9e497b106631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7bc5726-0d97-4c06-ba75-f22ff7194587");

            migrationBuilder.DropColumn(
                name: "DataSheetId",
                table: "Addresses");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "DataSheets",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78f368bc-3f17-4df7-b419-71c58fcdad69", "14281f87-8e45-4b76-97f4-5fb376d43637", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f066e3a-a22c-4d30-96d8-8c29e1680d60", "6ef4e5d4-4d87-49f1-be01-0713e40bfd35", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f066e3a-a22c-4d30-96d8-8c29e1680d60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78f368bc-3f17-4df7-b419-71c58fcdad69");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "DataSheets");

            migrationBuilder.AddColumn<string>(
                name: "DataSheetId",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7bc5726-0d97-4c06-ba75-f22ff7194587", "5ca4f2ed-96f6-452e-b5bb-3ea2144aa327", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90786b94-e42c-4443-ab05-9e497b106631", "c91f379d-2ec7-48a2-ad7d-45d8467f124e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DataSheetId",
                table: "Addresses",
                column: "DataSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_DataSheets_DataSheetId",
                table: "Addresses",
                column: "DataSheetId",
                principalTable: "DataSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
