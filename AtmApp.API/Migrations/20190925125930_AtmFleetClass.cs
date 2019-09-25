using Microsoft.EntityFrameworkCore.Migrations;

namespace AtmApp.API.Migrations
{
    public partial class AtmFleetClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtmFleet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TerminalId = table.Column<string>(nullable: true),
                    TerminalName = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    Gateway = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Vendor = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    BranchCode = table.Column<string>(nullable: true),
                    RegionalPersonnel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtmFleet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtmFleet");
        }
    }
}
