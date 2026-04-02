using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreProjectData.Migrations
{
    /// <inheritdoc />
    public partial class PropertyChangesToSubscriptionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Subscriptions",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Subscriptions",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Subscriptions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
