using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtmApp.API.Migrations
{
    public partial class FaultLogClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustodianName",
                table: "AtmFleet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustodianNumber",
                table: "AtmFleet",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FaultLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AtmFleetId = table.Column<int>(nullable: false),
                    TerminalId = table.Column<string>(nullable: true),
                    TerminalName = table.Column<string>(nullable: true),
                    Vendor = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    NatureOfFault = table.Column<string>(nullable: true),
                    CustodianName = table.Column<string>(nullable: true),
                    CustodianNumber = table.Column<string>(nullable: true),
                    DateLogged = table.Column<DateTime>(nullable: false),
                    DateResolved = table.Column<DateTime>(nullable: false),
                    DefaultDays = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaultLogs_AtmFleet_AtmFleetId",
                        column: x => x.AtmFleetId,
                        principalTable: "AtmFleet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaultLogs_AtmFleetId",
                table: "FaultLogs",
                column: "AtmFleetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaultLogs");

            migrationBuilder.DropColumn(
                name: "CustodianName",
                table: "AtmFleet");

            migrationBuilder.DropColumn(
                name: "CustodianNumber",
                table: "AtmFleet");
        }
    }
}
