using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserRegistrationAPI.Migrations
{
    public partial class DatabaseCreationAndSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Apartanemt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalNumber = table.Column<double>(type: "float", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoSheets_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InfoSheetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_InfoSheets_InfoSheetId",
                        column: x => x.InfoSheetId,
                        principalTable: "InfoSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartanemt", "City", "House", "Street" },
                values: new object[] { new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), 10, "Vilnius", 10, "Neries g." });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartanemt", "City", "House", "Street" },
                values: new object[] { new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"), 20, "Kaunas", 20, "Nemuno g." });

            migrationBuilder.InsertData(
                table: "InfoSheets",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PersonalNumber" },
                values: new object[] { new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), "vardenis@vardenis.lt", "Vardenis", "Pavarednis", 38989521245.0 });

            migrationBuilder.InsertData(
                table: "InfoSheets",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PersonalNumber" },
                values: new object[] { new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"), new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"), "antanas@antanas.lt", "Antanas", "Antanaitis", 38989521245.0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "InfoSheetId", "Password", "Role", "Username" },
                values: new object[] { new Guid("991ff595-0174-4011-87b3-bd968202b075"), new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), "P@ssword1", "User", "Vardenis" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "InfoSheetId", "Password", "Role", "Username" },
                values: new object[] { new Guid("256e4f68-a17b-4a39-ac29-653d977c8883"), new Guid("083a8133-231d-4028-a878-b365ba2f9eb4"), "P@ssword2", "User", "Antanas" });

            migrationBuilder.CreateIndex(
                name: "IX_InfoSheets_AddressId",
                table: "InfoSheets",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InfoSheetId",
                table: "Users",
                column: "InfoSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "InfoSheets");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
