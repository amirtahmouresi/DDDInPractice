using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDInPractice.Logic.Migrations
{
    public partial class CreateSnackAndSlotTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snack",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snack", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SnackPile_SnackId = table.Column<long>(type: "bigint", nullable: false),
                    SnackMachineId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Slot_Snack_SnackPile_SnackId",
                        column: x => x.SnackPile_SnackId,
                        principalTable: "Snack",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slot_SnackMachine_SnackMachineId",
                        column: x => x.SnackMachineId,
                        principalTable: "SnackMachine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slot_SnackMachineId",
                table: "Slot",
                column: "SnackMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_SnackPile_SnackId",
                table: "Slot",
                column: "SnackPile_SnackId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "Snack");
        }
    }
}
