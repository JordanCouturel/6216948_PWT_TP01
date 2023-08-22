using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp3JordanCoutureLafranchise.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentId);
                });

            migrationBuilder.CreateTable(
                name: "Enfants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(299)", maxLength: 299, nullable: false),
                    NumeroDeChandail = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salaire = table.Column<int>(type: "int", nullable: false),
                    Equipe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnVedette = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Favoris = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfants_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "ParentId");
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentId", "Description", "ImageURL", "Nom" },
                values: new object[] { 1, "Équipe de hockey sur glace de la LNH basée à Pittsburgh", "/Images/pittsburgh.png", "Penguins de Pittsburgh" });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentId", "Description", "ImageURL", "Nom" },
                values: new object[] { 2, "Équipe de hockey sur glace de la LNH basée à Montréal", "/Images/Mon_projet_1.png", "Canadiens de Montréal" });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentId", "Description", "ImageURL", "Nom" },
                values: new object[] { 3, "Équipe de hockey sur glace de la LNH basée à Washington", "/Images/capitals.png", "Capitals de Washington" });

            migrationBuilder.InsertData(
                table: "Enfants",
                columns: new[] { "Id", "Age", "Description", "EnVedette", "Equipe", "Favoris", "ImageURL", "Nom", "NumeroDeChandail", "ParentId", "Position", "Salaire" },
                values: new object[,]
                {
                    { 1, "23 ans", "Nick Suzuki est un joueur de hockey canadien talentueux. Il est connu pour sa vision du jeu, ses habiletés de patinage et sa précision de tir. Suzuki est un atout précieux pour son équipe, apportant constamment une énergie et une créativité exceptionnelles sur la glace.", "Oui", "Canadiens de Montréal", false, "/Images/niskcsuzuki-removebg-preview.png", "Nick Suzuki", 14, 2, "C", 8 },
                    { 2, "22 ans", "Cole Caufield est une étoile montante du hockey américain. Malgré sa petite stature, il possède un tir redoutable et une grande agilité. Son instinct de buteur et sa vitesse font de lui un joueur à surveiller de près.", "Oui", "Canadiens de Montréal", false, "/Images/8481540_3x-removebg-preview.png", "Cole Caufield", 22, 2, "AD", 5 },
                    { 3, "32 ans", "Jake Allen est un gardien de but canadien fiable et expérimenté. Son calme et sa position solide font de lui un dernier rempart redoutable. Il excelle dans les arrêts difficiles et inspire confiance à son équipe.", "Non", "Canadiens de Montréal", false, "/Images/8474596_3x-removebg-preview.png", "Jake Allen", 34, 2, "G", 4 },
                    { 4, "30 ans", "Joel Armia est un joueur de hockey finlandais polyvalent. Sa taille imposante et sa force lui confèrent un avantage physique. Il est habile dans les situations défensives et peut contribuer offensivement avec sa précision de tir.", "Oui", "Canadiens de Montréal", false, "/Images/8476469_3x-removebg-preview.png", "Joel Armia", 40, 2, "AD", 3 },
                    { 5, "36 ans", "TJ Oshie est un attaquant américain talentueux et charismatique. Son patinage rapide, son habileté au niveau des passes et son jeu physique font de lui un joueur complet et apprécié de ses coéquipiers et des partisans.", "Non", "Capitals de Washington", false, "/Images/8471698_3x-removebg-preview.png", "T.J. Oshie", 77, 3, "AD", 5 },
                    { 6, "35 ans", "Matt Irwin est un défenseur de hockey canadien fiable et solide. Il excelle dans la lecture du jeu et le positionnement défensif. Son tir puissant et précis lui permet de contribuer offensivement de temps en temps.", "Non", "Capitals de Washington", false, "/Images/8475625_3x-removebg-preview.png", "Matt Irwin", 52, 3, "D", 1 },
                    { 7, "37 ans", "Alex Ovechkin, surnommé Ovi, est une légende russe du hockey sur glace. Puissant et talentueux, il est considéré comme l'un des meilleurs buteurs de tous les temps. Son style de jeu spectaculaire et sa détermination ont captivé les fans du monde entier.", "Non", "Capitals de Washington", false, "/Images/8471214_3x__1_-removebg-preview.png", "Alex Ovechkin", 8, 3, "AG", 9 },
                    { 8, "32 ans", "Nick Jensen est un défenseur de hockey américain intelligent et discipliné. Il possède de bonnes aptitudes défensives et est efficace dans les transitions de jeu. Son jeu calme et fiable fait de lui un atout précieux pour son équipe.", "Non", "Capitals de Washington", false, "/Images/8475324_3x-removebg-preview_1.png", "Nick Jensen", 3, 3, "D", 3 },
                    { 9, "35 ans", "Jeff Petry est un défenseur de hockey américain de premier plan. Il est reconnu pour sa mobilité, son jeu physique et son habileté à générer des points. Un défenseur polyvalent et fiable.", "Oui", "Penguins de Pittsburgh", false, "/Images/8473507_3x-removebg-preview.png", "Jeff Petry", 26, 1, "D", 4 },
                    { 10, "32 ans", "Jan Rutta est un défenseur tchèque talentueux. Sa grande taille et sa force physique lui permettent d'être un excellent défenseur défensif. Il possède également une bonne vision du jeu et contribue offensivement avec son tir précis.", "Oui", "Penguins de Pittsburgh", false, "/Images/8480172_3x-removebg-preview.png", "Jan Rutta", 44, 1, "D", 3 },
                    { 11, "31 ans", "Bryan Rust est un attaquant polyvalent et dynamique. Sa vitesse, son tir précis et sa détermination en font un joueur redoutable en attaque. Il est également solide en jeu défensif et contribue régulièrement aux succès de son équipe", "Oui", "Penguins de Pittsburgh", false, "/Images/ç-removebg-preview.png", "Bryan Rust", 17, 1, "AD", 6 },
                    { 12, "38 ans", "Jeff Carter est un vétéran du hockey canadien. Son expérience et son talent en font un attaquant redoutable. Son tir puissant et sa présence physique lui permettent de marquer des buts importants.", "Oui", "Penguins de Pittsburgh", false, "/Images/8470604_3x-removebg-preview.png", "Jeff Carter", 77, 1, "C", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_ParentId",
                table: "Enfants",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfants");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
