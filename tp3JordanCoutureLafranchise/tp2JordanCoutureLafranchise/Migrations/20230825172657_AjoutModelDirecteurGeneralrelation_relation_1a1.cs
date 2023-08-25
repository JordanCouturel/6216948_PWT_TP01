using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp3JordanCoutureLafranchise.Migrations
{
    public partial class AjoutModelDirecteurGeneralrelation_relation_1a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prénom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DG_Parents_EquipeID",
                        column: x => x.EquipeID,
                        principalTable: "Parents",
                        principalColumn: "ParentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DG",
                columns: new[] { "Id", "EquipeID", "Nom", "Prénom" },
                values: new object[] { 1, 1, "Dubas", "Kyle" });

            migrationBuilder.InsertData(
                table: "DG",
                columns: new[] { "Id", "EquipeID", "Nom", "Prénom" },
                values: new object[] { 2, 2, "Hughes", "Kent" });

            migrationBuilder.InsertData(
                table: "DG",
                columns: new[] { "Id", "EquipeID", "Nom", "Prénom" },
                values: new object[] { 3, 3, "MacLellan", "Brian" });

            migrationBuilder.CreateIndex(
                name: "IX_DG_EquipeID",
                table: "DG",
                column: "EquipeID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DG");
        }
    }
}
