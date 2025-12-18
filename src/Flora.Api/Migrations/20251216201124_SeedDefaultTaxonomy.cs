using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flora.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultTaxonomy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Taxonomies",
                columns: new[] { "Id", "Name", "ParentId", "Rank" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "Unknown", null, "Unknown" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Taxonomies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));
        }
    }
}
