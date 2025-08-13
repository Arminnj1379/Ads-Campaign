using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Migrations
{
    /// <inheritdoc />
    public partial class AdViewAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "ads",
                table: "Ad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                schema: "ads",
                table: "Ad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdViews",
                schema: "ads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ViewedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdViews_Ad_AdId",
                        column: x => x.AdId,
                        principalSchema: "ads",
                        principalTable: "Ad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdViews_AdId",
                schema: "ads",
                table: "AdViews",
                column: "AdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdViews",
                schema: "ads");

            migrationBuilder.DropColumn(
                name: "Number",
                schema: "ads",
                table: "Ad");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                schema: "ads",
                table: "Ad");
        }
    }
}
