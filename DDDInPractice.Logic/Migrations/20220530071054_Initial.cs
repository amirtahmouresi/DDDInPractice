using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDInPractice.Logic.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SnackMachine",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OneCentCount = table.Column<int>(type: "int", nullable: false),
                    TenCentCount = table.Column<int>(type: "int", nullable: false),
                    QuarterCount = table.Column<int>(type: "int", nullable: false),
                    OneDollarCount = table.Column<int>(type: "int", nullable: false),
                    FiveDollarCount = table.Column<int>(type: "int", nullable: false),
                    TwentyDollarCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackMachine", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SnackMachine");
        }
    }
}
