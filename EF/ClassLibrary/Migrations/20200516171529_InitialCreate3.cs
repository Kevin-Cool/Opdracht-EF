using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Stamnummer = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(maxLength: 64, nullable: false),
                    Bijnaam = table.Column<string>(nullable: true),
                    Trainer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Stamnummer);
                });

            migrationBuilder.CreateTable(
                name: "Spelers",
                columns: table => new
                {
                    SpelerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 64, nullable: false),
                    Rugnummer = table.Column<int>(nullable: false),
                    Waarde = table.Column<double>(nullable: false),
                    _TeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spelers", x => x.SpelerID);
                    table.ForeignKey(
                        name: "FK_Spelers_Teams__TeamID",
                        column: x => x._TeamID,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    TransferID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _spelerID = table.Column<int>(nullable: false),
                    Transferprijs = table.Column<double>(nullable: false),
                    TeamIDOud = table.Column<int>(nullable: false),
                    TeamIDONieuw = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.TransferID);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_TeamIDONieuw",
                        column: x => x.TeamIDONieuw,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer");
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_TeamIDOud",
                        column: x => x.TeamIDOud,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer");
                    table.ForeignKey(
                        name: "FK_Transfers_Spelers__spelerID",
                        column: x => x._spelerID,
                        principalTable: "Spelers",
                        principalColumn: "SpelerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spelers__TeamID",
                table: "Spelers",
                column: "_TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_TeamIDONieuw",
                table: "Transfers",
                column: "TeamIDONieuw",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_TeamIDOud",
                table: "Transfers",
                column: "TeamIDOud",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers__spelerID",
                table: "Transfers",
                column: "_spelerID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Spelers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
