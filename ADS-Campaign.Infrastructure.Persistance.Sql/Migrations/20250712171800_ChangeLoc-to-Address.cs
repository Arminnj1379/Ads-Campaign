using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLoctoAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                schema: "ads",
                table: "Ad",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                schema: "ads",
                table: "Ad",
                newName: "Location");
        }
    }
}
