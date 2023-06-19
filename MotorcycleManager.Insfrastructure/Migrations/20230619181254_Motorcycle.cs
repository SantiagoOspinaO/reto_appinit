using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorcycleManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Motorcycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorcycle",
                columns: table => new
                {
                    MotorcycleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycle", x => x.MotorcycleId);
                });

            migrationBuilder.CreateTable(
                name: "MotorcycleCross",
                columns: table => new
                {
                    MotorcycleId = table.Column<int>(type: "int", nullable: false),
                    SeatHeight = table.Column<int>(type: "int", nullable: false),
                    HasRearSuspension = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcycleCross", x => x.MotorcycleId);
                    table.ForeignKey(
                        name: "FK_MotorcycleCross_Motorcycle_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycle",
                        principalColumn: "MotorcycleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotorcycleSports",
                columns: table => new
                {
                    MotorcycleId = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    HasAleron = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcycleSports", x => x.MotorcycleId);
                    table.ForeignKey(
                        name: "FK_MotorcycleSports_Motorcycle_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycle",
                        principalColumn: "MotorcycleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotorcycleTourism",
                columns: table => new
                {
                    MotorcycleId = table.Column<int>(type: "int", nullable: false),
                    TankCapacity = table.Column<int>(type: "int", nullable: false),
                    HasSideCases = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcycleTourism", x => x.MotorcycleId);
                    table.ForeignKey(
                        name: "FK_MotorcycleTourism_Motorcycle_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycle",
                        principalColumn: "MotorcycleId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotorcycleCross");

            migrationBuilder.DropTable(
                name: "MotorcycleSports");

            migrationBuilder.DropTable(
                name: "MotorcycleTourism");

            migrationBuilder.DropTable(
                name: "Motorcycle");
        }
    }
}
