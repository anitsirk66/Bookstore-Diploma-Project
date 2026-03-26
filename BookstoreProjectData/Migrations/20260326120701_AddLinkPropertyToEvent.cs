using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreProjectData.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkPropertyToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Events");
        }
    }
}
