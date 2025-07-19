using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Migrations
{
    /// <inheritdoc />
    public partial class Addiconclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconClass",
                schema: "ads",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconClass",
                schema: "ads",
                table: "Category");
        }
    }
}
