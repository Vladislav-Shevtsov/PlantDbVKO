using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Flora.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "Taxanomies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Rank = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxanomies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxanomies_Taxanomies_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Taxanomies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificName = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TaxanomyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Taxanomies_TaxanomyId",
                        column: x => x.TaxanomyId,
                        principalTable: "Taxanomies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distributions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<Point>(type: "geometry", nullable: false),
                    RegionCode = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false),
                    CollectedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SpeciesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distributions_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    AltText = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    SpeciesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sequences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Accession = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<int>(type: "integer", nullable: false),
                    SpeciesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sequences_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TerrainDescription = table.Column<string>(type: "text", nullable: false),
                    SpeciesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Distributions_SpeciesId",
                table: "Distributions",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_SpeciesId",
                table: "Medias",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Sequences_SpeciesId",
                table: "Sequences",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_TaxanomyId",
                table: "Species",
                column: "TaxanomyId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxanomies_ParentId",
                table: "Taxanomies",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_SpeciesId",
                table: "Translations",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distributions");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Sequences");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Taxanomies");
        }
    }
}
