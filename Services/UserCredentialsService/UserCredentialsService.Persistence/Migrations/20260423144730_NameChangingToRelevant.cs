using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserCredentialsService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NameChangingToRelevant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "IdentityUsers",
                newName: "UserRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "IdentityUsers",
                newName: "Role");
        }
    }
}
