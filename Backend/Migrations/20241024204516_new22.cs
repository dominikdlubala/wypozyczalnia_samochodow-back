using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class new22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarUser_Cars_FavouriteCarsId",
                table: "CarUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CarUser_Users_UsersFavouritesId",
                table: "CarUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarUser",
                table: "CarUser");

            migrationBuilder.RenameTable(
                name: "CarUser",
                newName: "UserFavouriteCars");

            migrationBuilder.RenameIndex(
                name: "IX_CarUser_UsersFavouritesId",
                table: "UserFavouriteCars",
                newName: "IX_UserFavouriteCars_UsersFavouritesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavouriteCars",
                table: "UserFavouriteCars",
                columns: new[] { "FavouriteCarsId", "UsersFavouritesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouriteCars_Cars_FavouriteCarsId",
                table: "UserFavouriteCars",
                column: "FavouriteCarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouriteCars_Users_UsersFavouritesId",
                table: "UserFavouriteCars",
                column: "UsersFavouritesId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouriteCars_Cars_FavouriteCarsId",
                table: "UserFavouriteCars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouriteCars_Users_UsersFavouritesId",
                table: "UserFavouriteCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavouriteCars",
                table: "UserFavouriteCars");

            migrationBuilder.RenameTable(
                name: "UserFavouriteCars",
                newName: "CarUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavouriteCars_UsersFavouritesId",
                table: "CarUser",
                newName: "IX_CarUser_UsersFavouritesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarUser",
                table: "CarUser",
                columns: new[] { "FavouriteCarsId", "UsersFavouritesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarUser_Cars_FavouriteCarsId",
                table: "CarUser",
                column: "FavouriteCarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarUser_Users_UsersFavouritesId",
                table: "CarUser",
                column: "UsersFavouritesId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
