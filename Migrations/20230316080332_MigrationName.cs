using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIII.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustId);
                });

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    GuideNum = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.GuideNum);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Startlocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    MaxGroupSize = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Season = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "GuideTrip",
                columns: table => new
                {
                    GuidesGuideNum = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    TripsTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideTrip", x => new { x.GuidesGuideNum, x.TripsTripId });
                    table.ForeignKey(
                        name: "FK_GuideTrip_Guides_GuidesGuideNum",
                        column: x => x.GuidesGuideNum,
                        principalTable: "Guides",
                        principalColumn: "GuideNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuideTrip_Trips_TripsTripId",
                        column: x => x.TripsTripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuideTrip_TripsTripId",
                table: "GuideTrip",
                column: "TripsTripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "GuideTrip");

            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
