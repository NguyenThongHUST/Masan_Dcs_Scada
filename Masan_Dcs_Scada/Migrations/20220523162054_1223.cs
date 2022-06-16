using Microsoft.EntityFrameworkCore.Migrations;

namespace Masan_Dcs_Scada.Migrations
{
    public partial class _1223 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeadShifts",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    FullName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadShifts", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeadShifts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
