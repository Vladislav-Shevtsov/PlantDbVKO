using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flora.Api.Migrations
{
    /// <inheritdoc />
    public partial class MakeTaxonomyIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Species_Taxonomies_TaxonomyId",
                table: "Species");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaxonomyId",
                table: "Species",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Taxonomies_TaxonomyId",
                table: "Species",
                column: "TaxonomyId",
                principalTable: "Taxonomies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Species_Taxonomies_TaxonomyId",
                table: "Species");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaxonomyId",
                table: "Species",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Taxonomies_TaxonomyId",
                table: "Species",
                column: "TaxonomyId",
                principalTable: "Taxonomies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
