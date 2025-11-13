using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class New_Tables_Added1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColumnItems_Users_UserId1",
                table: "ColumnItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ColumnItems");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "ColumnItems",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ColumnItems_UserId1",
                table: "ColumnItems",
                newName: "IX_ColumnItems_UserProfileId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "DateAchievements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DateAchievements_UserProfileId",
                table: "DateAchievements",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColumnItems_Profiles_UserProfileId",
                table: "ColumnItems",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DateAchievements_Profiles_UserProfileId",
                table: "DateAchievements",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColumnItems_Profiles_UserProfileId",
                table: "ColumnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DateAchievements_Profiles_UserProfileId",
                table: "DateAchievements");

            migrationBuilder.DropIndex(
                name: "IX_DateAchievements_UserProfileId",
                table: "DateAchievements");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "DateAchievements");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "ColumnItems",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_ColumnItems_UserProfileId",
                table: "ColumnItems",
                newName: "IX_ColumnItems_UserId1");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ColumnItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ColumnItems_Users_UserId1",
                table: "ColumnItems",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
