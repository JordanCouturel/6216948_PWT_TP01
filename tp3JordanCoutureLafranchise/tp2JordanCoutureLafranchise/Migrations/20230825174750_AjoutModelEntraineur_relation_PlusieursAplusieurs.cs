using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp3JordanCoutureLafranchise.Migrations
{
    public partial class AjoutModelEntraineur_relation_PlusieursAplusieurs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entraineur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entraineur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnfantEntraineur",
                columns: table => new
                {
                    EntraineursId = table.Column<int>(type: "int", nullable: false),
                    JoueursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfantEntraineur", x => new { x.EntraineursId, x.JoueursId });
                    table.ForeignKey(
                        name: "FK_EnfantEntraineur_Enfants_JoueursId",
                        column: x => x.JoueursId,
                        principalTable: "Enfants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnfantEntraineur_Entraineur_EntraineursId",
                        column: x => x.EntraineursId,
                        principalTable: "Entraineur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Entraineur",
                columns: new[] { "Id", "NomComplet", "Specialite" },
                values: new object[,]
                {
                    { 1, "Claude Julien", "Stratégie de jeu" },
                    { 2, "Mike Babcock", "Développement des joueurs" },
                    { 3, "Joel Quenneville", "Gestion des effectifs" },
                    { 4, "Barry Trotz", "Défense et système défensif" },
                    { 5, "Bruce Cassidy", "Attaque et jeu de puissance" },
                    { 6, "Alain Vigneault", "Gestion des ressources humaines" },
                    { 7, "Peter DeBoer", "Gestion des gardiens de but" },
                    { 8, "John Tortorella", "Leadership et motivation" },
                    { 9, "Paul Maurice", "Gestion du vestiaire" },
                    { 10, "Travis Green", "Développement des jeunes joueurs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnfantEntraineur_JoueursId",
                table: "EnfantEntraineur",
                column: "JoueursId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnfantEntraineur");

            migrationBuilder.DropTable(
                name: "Entraineur");
        }
    }
}
