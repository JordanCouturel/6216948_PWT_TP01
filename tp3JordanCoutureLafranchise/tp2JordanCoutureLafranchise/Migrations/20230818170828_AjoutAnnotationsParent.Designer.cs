﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tp2JordanCoutureLafranchise.Models.Data;

#nullable disable

namespace tp3JordanCoutureLafranchise.Migrations
{
    [DbContext(typeof(HockeyRebelsDBContext))]
    [Migration("20230818170828_AjoutAnnotationsParent")]
    partial class AjoutAnnotationsParent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("tp2JordanCoutureLafranchise.Models.Enfant", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(299)
                        .HasColumnType("nvarchar(299)");

                    b.Property<string>("EnVedette")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Favoris")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("NumeroDeChandail")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salaire")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Enfants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = "23 ans",
                            Description = "Nick Suzuki est un joueur de hockey canadien talentueux. Il est connu pour sa vision du jeu, ses habiletés de patinage et sa précision de tir. Suzuki est un atout précieux pour son équipe, apportant constamment une énergie et une créativité exceptionnelles sur la glace.",
                            EnVedette = "Oui",
                            Equipe = "Canadiens de Montréal",
                            Favoris = false,
                            ImageURL = "/Images/niskcsuzuki-removebg-preview.png",
                            Nom = "Nick Suzuki",
                            NumeroDeChandail = 14,
                            ParentId = 2,
                            Position = "C",
                            Salaire = 8
                        },
                        new
                        {
                            Id = 2,
                            Age = "22 ans",
                            Description = "Cole Caufield est une étoile montante du hockey américain. Malgré sa petite stature, il possède un tir redoutable et une grande agilité. Son instinct de buteur et sa vitesse font de lui un joueur à surveiller de près.",
                            EnVedette = "Oui",
                            Equipe = "Canadiens de Montréal",
                            Favoris = false,
                            ImageURL = "/Images/8481540_3x-removebg-preview.png",
                            Nom = "Cole Caufield",
                            NumeroDeChandail = 22,
                            ParentId = 2,
                            Position = "AD",
                            Salaire = 5
                        },
                        new
                        {
                            Id = 3,
                            Age = "32 ans",
                            Description = "Jake Allen est un gardien de but canadien fiable et expérimenté. Son calme et sa position solide font de lui un dernier rempart redoutable. Il excelle dans les arrêts difficiles et inspire confiance à son équipe.",
                            EnVedette = "Non",
                            Equipe = "Canadiens de Montréal",
                            Favoris = false,
                            ImageURL = "/Images/8474596_3x-removebg-preview.png",
                            Nom = "Jake Allen",
                            NumeroDeChandail = 34,
                            ParentId = 2,
                            Position = "G",
                            Salaire = 4
                        },
                        new
                        {
                            Id = 4,
                            Age = "30 ans",
                            Description = "Joel Armia est un joueur de hockey finlandais polyvalent. Sa taille imposante et sa force lui confèrent un avantage physique. Il est habile dans les situations défensives et peut contribuer offensivement avec sa précision de tir.",
                            EnVedette = "Oui",
                            Equipe = "Canadiens de Montréal",
                            Favoris = false,
                            ImageURL = "/Images/8476469_3x-removebg-preview.png",
                            Nom = "Joel Armia",
                            NumeroDeChandail = 40,
                            ParentId = 2,
                            Position = "AD",
                            Salaire = 3
                        },
                        new
                        {
                            Id = 5,
                            Age = "36 ans",
                            Description = "TJ Oshie est un attaquant américain talentueux et charismatique. Son patinage rapide, son habileté au niveau des passes et son jeu physique font de lui un joueur complet et apprécié de ses coéquipiers et des partisans.",
                            EnVedette = "Non",
                            Equipe = "Capitals de Washington",
                            Favoris = false,
                            ImageURL = "/Images/8471698_3x-removebg-preview.png",
                            Nom = "T.J. Oshie",
                            NumeroDeChandail = 77,
                            ParentId = 3,
                            Position = "AD",
                            Salaire = 5
                        },
                        new
                        {
                            Id = 6,
                            Age = "35 ans",
                            Description = "Matt Irwin est un défenseur de hockey canadien fiable et solide. Il excelle dans la lecture du jeu et le positionnement défensif. Son tir puissant et précis lui permet de contribuer offensivement de temps en temps.",
                            EnVedette = "Non",
                            Equipe = "Capitals de Washington",
                            Favoris = false,
                            ImageURL = "/Images/8475625_3x-removebg-preview.png",
                            Nom = "Matt Irwin",
                            NumeroDeChandail = 52,
                            ParentId = 3,
                            Position = "D",
                            Salaire = 1
                        },
                        new
                        {
                            Id = 7,
                            Age = "37 ans",
                            Description = "Alex Ovechkin, surnommé Ovi, est une légende russe du hockey sur glace. Puissant et talentueux, il est considéré comme l'un des meilleurs buteurs de tous les temps. Son style de jeu spectaculaire et sa détermination ont captivé les fans du monde entier.",
                            EnVedette = "Non",
                            Equipe = "Capitals de Washington",
                            Favoris = false,
                            ImageURL = "/Images/8471214_3x__1_-removebg-preview.png",
                            Nom = "Alex Ovechkin",
                            NumeroDeChandail = 8,
                            ParentId = 3,
                            Position = "AG",
                            Salaire = 9
                        },
                        new
                        {
                            Id = 8,
                            Age = "32 ans",
                            Description = "Nick Jensen est un défenseur de hockey américain intelligent et discipliné. Il possède de bonnes aptitudes défensives et est efficace dans les transitions de jeu. Son jeu calme et fiable fait de lui un atout précieux pour son équipe.",
                            EnVedette = "Non",
                            Equipe = "Capitals de Washington",
                            Favoris = false,
                            ImageURL = "/Images/8475324_3x-removebg-preview_1.png",
                            Nom = "Nick Jensen",
                            NumeroDeChandail = 3,
                            ParentId = 3,
                            Position = "D",
                            Salaire = 3
                        },
                        new
                        {
                            Id = 9,
                            Age = "35 ans",
                            Description = "Jeff Petry est un défenseur de hockey américain de premier plan. Il est reconnu pour sa mobilité, son jeu physique et son habileté à générer des points. Un défenseur polyvalent et fiable.",
                            EnVedette = "Oui",
                            Equipe = "Penguins de Pittsburgh",
                            Favoris = false,
                            ImageURL = "/Images/8473507_3x-removebg-preview.png",
                            Nom = "Jeff Petry",
                            NumeroDeChandail = 26,
                            ParentId = 1,
                            Position = "D",
                            Salaire = 4
                        },
                        new
                        {
                            Id = 10,
                            Age = "32 ans",
                            Description = "Jan Rutta est un défenseur tchèque talentueux. Sa grande taille et sa force physique lui permettent d'être un excellent défenseur défensif. Il possède également une bonne vision du jeu et contribue offensivement avec son tir précis.",
                            EnVedette = "Oui",
                            Equipe = "Penguins de Pittsburgh",
                            Favoris = false,
                            ImageURL = "/Images/8480172_3x-removebg-preview.png",
                            Nom = "Jan Rutta",
                            NumeroDeChandail = 44,
                            ParentId = 1,
                            Position = "D",
                            Salaire = 3
                        },
                        new
                        {
                            Id = 11,
                            Age = "31 ans",
                            Description = "Bryan Rust est un attaquant polyvalent et dynamique. Sa vitesse, son tir précis et sa détermination en font un joueur redoutable en attaque. Il est également solide en jeu défensif et contribue régulièrement aux succès de son équipe",
                            EnVedette = "Oui",
                            Equipe = "Penguins de Pittsburgh",
                            Favoris = false,
                            ImageURL = "/Images/ç-removebg-preview.png",
                            Nom = "Bryan Rust",
                            NumeroDeChandail = 17,
                            ParentId = 1,
                            Position = "AD",
                            Salaire = 6
                        },
                        new
                        {
                            Id = 12,
                            Age = "38 ans",
                            Description = "Jeff Carter est un vétéran du hockey canadien. Son expérience et son talent en font un attaquant redoutable. Son tir puissant et sa présence physique lui permettent de marquer des buts importants.",
                            EnVedette = "Oui",
                            Equipe = "Penguins de Pittsburgh",
                            Favoris = false,
                            ImageURL = "/Images/8470604_3x-removebg-preview.png",
                            Nom = "Jeff Carter",
                            NumeroDeChandail = 77,
                            ParentId = 1,
                            Position = "C",
                            Salaire = 3
                        });
                });

            modelBuilder.Entity("tp2JordanCoutureLafranchise.Models.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParentId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("ParentId");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            ParentId = 1,
                            Description = "Équipe de hockey sur glace de la LNH basée à Pittsburgh",
                            ImageURL = "/Images/pittsburgh.png",
                            Nom = "Penguins de Pittsburgh"
                        },
                        new
                        {
                            ParentId = 2,
                            Description = "Équipe de hockey sur glace de la LNH basée à Montréal",
                            ImageURL = "/Images/Mon_projet_1.png",
                            Nom = "Canadiens de Montréal"
                        },
                        new
                        {
                            ParentId = 3,
                            Description = "Équipe de hockey sur glace de la LNH basée à Washington",
                            ImageURL = "/Images/capitals.png",
                            Nom = "Capitals de Washington"
                        });
                });

            modelBuilder.Entity("tp2JordanCoutureLafranchise.Models.Enfant", b =>
                {
                    b.HasOne("tp2JordanCoutureLafranchise.Models.Parent", "Parent")
                        .WithMany("Enfants")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("tp2JordanCoutureLafranchise.Models.Parent", b =>
                {
                    b.Navigation("Enfants");
                });
#pragma warning restore 612, 618
        }
    }
}
