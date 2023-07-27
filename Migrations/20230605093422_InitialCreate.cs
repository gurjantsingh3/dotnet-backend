using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tempo_Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptTerms",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "Token");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "users",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptTerms",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
