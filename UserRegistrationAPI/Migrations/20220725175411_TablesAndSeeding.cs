using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserRegistrationAPI.Migrations
{
    public partial class TablesAndSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNumber = table.Column<double>(type: "float", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Apartament = table.Column<int>(type: "int", nullable: false),
                    DataSheetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_DataSheets_DataSheetId",
                        column: x => x.DataSheetId,
                        principalTable: "DataSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSheetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_DataSheets_DataSheetId",
                        column: x => x.DataSheetId,
                        principalTable: "DataSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartament", "City", "DataSheetId", "House", "Street" },
                values: new object[] { new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), 10, "Vilnius", null, 10, "Neries g." });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartament", "City", "DataSheetId", "House", "Street" },
                values: new object[] { new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"), 20, "Kaunas", null, 20, "Nemuno g." });

            migrationBuilder.InsertData(
                table: "DataSheets",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PersonalNumber", "UserId" },
                values: new object[] { new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), "vardenis@vardenis.lt", "Vardenis", "Pavarednis", 38989521245.0, null });

            migrationBuilder.InsertData(
                table: "DataSheets",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PersonalNumber", "UserId" },
                values: new object[] { new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"), new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"), "antanas@antanas.lt", "Antanas", "Antanaitis", 38989521245.0, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DataSheetId", "Password", "Role", "Username" },
                values: new object[] { new Guid("fa556208-e140-403e-9c9a-f4e644e1d319"), new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), "P@ssword1", "User", "Vardenis" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DataSheetId", "Password", "Role", "Username" },
                values: new object[] { new Guid("a53df72d-6769-4b1f-ae18-824a3fdf7f99"), new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"), "P@ssword2", "User", "Antanas" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DataSheetId",
                table: "Addresses",
                column: "DataSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSheets_AddressId",
                table: "DataSheets",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSheets_UserId",
                table: "DataSheets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DataSheetId",
                table: "Users",
                column: "DataSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataSheets_Addresses_AddressId",
                table: "DataSheets",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataSheets_Users_UserId",
                table: "DataSheets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_DataSheets_DataSheetId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_DataSheets_DataSheetId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DataSheets");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
