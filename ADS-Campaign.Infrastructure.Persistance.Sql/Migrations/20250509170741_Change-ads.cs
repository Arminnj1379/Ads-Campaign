using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Migrations
{
    /// <inheritdoc />
    public partial class Changeads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdImage_Ads_AdId",
                schema: "ads",
                table: "AdImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AspNetUsers_UserId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Ads_AdId",
                schema: "ads",
                table: "Campaign");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                table: "Ads");

            migrationBuilder.RenameTable(
                name: "Ads",
                newName: "Ad",
                newSchema: "ads");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_UserId",
                schema: "ads",
                table: "Ad",
                newName: "IX_Ad_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_CategoryId",
                schema: "ads",
                table: "Ad",
                newName: "IX_Ad_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ad",
                schema: "ads",
                table: "Ad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_AspNetUsers_UserId",
                schema: "ads",
                table: "Ad",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Category_CategoryId",
                schema: "ads",
                table: "Ad",
                column: "CategoryId",
                principalSchema: "ads",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdImage_Ad_AdId",
                schema: "ads",
                table: "AdImage",
                column: "AdId",
                principalSchema: "ads",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Ad_AdId",
                schema: "ads",
                table: "Campaign",
                column: "AdId",
                principalSchema: "ads",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_AspNetUsers_UserId",
                schema: "ads",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Category_CategoryId",
                schema: "ads",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_AdImage_Ad_AdId",
                schema: "ads",
                table: "AdImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Ad_AdId",
                schema: "ads",
                table: "Campaign");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ad",
                schema: "ads",
                table: "Ad");

            migrationBuilder.RenameTable(
                name: "Ad",
                schema: "ads",
                newName: "Ads");

            migrationBuilder.RenameIndex(
                name: "IX_Ad_UserId",
                table: "Ads",
                newName: "IX_Ads_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ad_CategoryId",
                table: "Ads",
                newName: "IX_Ads_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ads",
                table: "Ads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdImage_Ads_AdId",
                schema: "ads",
                table: "AdImage",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AspNetUsers_UserId",
                table: "Ads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalSchema: "ads",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Ads_AdId",
                schema: "ads",
                table: "Campaign",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
