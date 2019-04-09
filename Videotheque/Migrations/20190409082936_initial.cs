using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Videotheque.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    Commentaire = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    AgeMin = table.Column<int>(nullable: false),
                    Audiodescription = table.Column<bool>(nullable: false),
                    SupportPhysique = table.Column<bool>(nullable: false),
                    SupportNumerique = table.Column<bool>(nullable: false),
                    LangueVO = table.Column<int>(nullable: false),
                    LangueMedia = table.Column<int>(nullable: false),
                    Statut = table.Column<int>(nullable: false),
                    Affiche = table.Column<byte[]>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Duree = table.Column<TimeSpan>(nullable: true),
                    Saison_Duree = table.Column<int>(nullable: true),
                    NbSaison = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Civilite = table.Column<int>(nullable: false),
                    Prenom = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Nationalite = table.Column<int>(nullable: false),
                    PhotoProfil = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(nullable: true),
                    SaisonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episode_Media_SaisonId",
                        column: x => x.SaisonId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaGenre",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    MediaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGenre", x => new { x.GenreId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_MediaGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaGenre_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaPersonne",
                columns: table => new
                {
                    PersonneId = table.Column<int>(nullable: false),
                    MediaId = table.Column<int>(nullable: false),
                    Fonction = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaPersonne", x => new { x.PersonneId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_MediaPersonne_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaPersonne_Personne_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_SaisonId",
                table: "Episode",
                column: "SaisonId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaGenre_MediaId",
                table: "MediaGenre",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPersonne_MediaId",
                table: "MediaPersonne",
                column: "MediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "MediaGenre");

            migrationBuilder.DropTable(
                name: "MediaPersonne");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
