using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStack.API.Migrations
{
    /// <inheritdoc />
    public partial class AlterUSerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "USers",
                newName: "Picture");

            migrationBuilder.AddColumn<string>(
                name: "Auth0Id",
                table: "USers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "USers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auth0Id",
                table: "USers");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "USers");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "USers",
                newName: "Password");
        }
    }
}
