using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dometrain.Movies.InMemoryDataStore.Migrations
{
    /// <inheritdoc />
    public partial class AddsSlugToMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Movies");
        }
    }
}
