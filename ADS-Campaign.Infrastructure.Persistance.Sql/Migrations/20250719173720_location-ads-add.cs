using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Migrations
{
    /// <inheritdoc />
    public partial class locationadsadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "ads",
                table: "Ad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                schema: "ads",
                table: "Ad");
        }
    }
}
