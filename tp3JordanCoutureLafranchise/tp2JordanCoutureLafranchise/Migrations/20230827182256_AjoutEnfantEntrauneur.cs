using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp3JordanCoutureLafranchise.Migrations
{
    public partial class AjoutEnfantEntrauneur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnfantEntraineur_Enfants_JoueursId",
                table: "EnfantEntraineur");

            migrationBuilder.DropForeignKey(
                name: "FK_EnfantEntraineur_Entraineur_EntraineursId",
                table: "EnfantEntraineur");

            migrationBuilder.DropTable(
                name: "EnfantEntraineurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnfantEntraineur",
                table: "EnfantEntraineur");

            migrationBuilder.RenameColumn(
                name: "JoueursId",
                table: "EnfantEntraineur",
                newName: "EntraineurId");

            migrationBuilder.RenameColumn(
                name: "EntraineursId",
                table: "EnfantEntraineur",
                newName: "EnfantId");

            migrationBuilder.RenameIndex(
                name: "IX_EnfantEntraineur_JoueursId",
                table: "EnfantEntraineur",
                newName: "IX_EnfantEntraineur_EntraineurId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EnfantEntraineur",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnfantEntraineur",
                table: "EnfantEntraineur",
                column: "Id");

            migrationBuilder.InsertData(
                table: "EnfantEntraineur",
                columns: new[] { "Id", "EnfantId", "EntraineurId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnfantEntraineur_EnfantId",
                table: "EnfantEntraineur",
                column: "EnfantId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnfantEntraineur_Enfants_EnfantId",
                table: "EnfantEntraineur",
                column: "EnfantId",
                principalTable: "Enfants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnfantEntraineur_Entraineur_EntraineurId",
                table: "EnfantEntraineur",
                column: "EntraineurId",
                principalTable: "Entraineur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnfantEntraineur_Enfants_EnfantId",
                table: "EnfantEntraineur");

            migrationBuilder.DropForeignKey(
                name: "FK_EnfantEntraineur_Entraineur_EntraineurId",
                table: "EnfantEntraineur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnfantEntraineur",
                table: "EnfantEntraineur");

            migrationBuilder.DropIndex(
                name: "IX_EnfantEntraineur_EnfantId",
                table: "EnfantEntraineur");

            migrationBuilder.DeleteData(
                table: "EnfantEntraineur",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EnfantEntraineur",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EnfantEntraineur",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EnfantEntraineur",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EnfantEntraineur",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EnfantEntraineur",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EnfantEntraineur",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EnfantEntraineur",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EnfantEntraineur",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EnfantEntraineur",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EnfantEntraineur");

            migrationBuilder.RenameColumn(
                name: "EntraineurId",
                table: "EnfantEntraineur",
                newName: "JoueursId");

            migrationBuilder.RenameColumn(
                name: "EnfantId",
                table: "EnfantEntraineur",
                newName: "EntraineursId");

            migrationBuilder.RenameIndex(
                name: "IX_EnfantEntraineur_EntraineurId",
                table: "EnfantEntraineur",
                newName: "IX_EnfantEntraineur_JoueursId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnfantEntraineur",
                table: "EnfantEntraineur",
                columns: new[] { "EntraineursId", "JoueursId" });

            migrationBuilder.CreateTable(
                name: "EnfantEntraineurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnfantId = table.Column<int>(type: "int", nullable: false),
                    EntraineurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfantEntraineurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnfantEntraineurs_Enfants_EnfantId",
                        column: x => x.EnfantId,
                        principalTable: "Enfants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnfantEntraineurs_Entraineur_EntraineurId",
                        column: x => x.EntraineurId,
                        principalTable: "Entraineur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EnfantEntraineurs",
                columns: new[] { "Id", "EnfantId", "EntraineurId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnfantEntraineurs_EnfantId",
                table: "EnfantEntraineurs",
                column: "EnfantId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfantEntraineurs_EntraineurId",
                table: "EnfantEntraineurs",
                column: "EntraineurId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnfantEntraineur_Enfants_JoueursId",
                table: "EnfantEntraineur",
                column: "JoueursId",
                principalTable: "Enfants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnfantEntraineur_Entraineur_EntraineursId",
                table: "EnfantEntraineur",
                column: "EntraineursId",
                principalTable: "Entraineur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
