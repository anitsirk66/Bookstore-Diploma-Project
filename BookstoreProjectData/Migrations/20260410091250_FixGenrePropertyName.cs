using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreProjectData.Migrations
{
    /// <inheritdoc />
    public partial class FixGenrePropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desciption",
                table: "Genres",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Genres",
                newName: "Desciption");
        }
    }
}
