using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flora.Api.Migrations
{
    /// <inheritdoc />
    public partial class initialnax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxonomies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Rank = table.Column<string>(type: "text", nullable: true),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxonomies_Taxonomies_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Taxonomies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificName = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TaxonomyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Taxonomies_TaxonomyId",
                        column: x => x.TaxonomyId,
                        principalTable: "Taxonomies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distributions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    RegionCode = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
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
                    Url = table.Column<string>(type: "text", nullable: true),
                    AltText = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
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
                    Accession = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
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
                    LanguageCode = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TerrainDescription = table.Column<string>(type: "text", nullable: true),
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

            migrationBuilder.InsertData(
                table: "Taxonomies",
                columns: new[] { "Id", "Name", "ParentId", "Rank" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "Unknown", null, "Unknown" });

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
                name: "IX_Species_TaxonomyId",
                table: "Species",
                column: "TaxonomyId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomies_ParentId",
                table: "Taxonomies",
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
                name: "Taxonomies");
        }
    }
}
