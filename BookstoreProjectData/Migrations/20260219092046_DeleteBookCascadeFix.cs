using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreProjectData.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBookCascadeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Books_Books_BookId",
                table: "Publishers_Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_Books_Books_BookId",
                table: "Publishers_Books",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Books_Books_BookId",
                table: "Publishers_Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_Books_Books_BookId",
                table: "Publishers_Books",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
