using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Change_Tables_All_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyRecords_UserProfiles_UserProfileId",
                table: "BodyRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ColumnItems_UserProfiles_UserProfileId",
                table: "ColumnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DateAchievements_UserProfiles_UserProfileId",
                table: "DateAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_UserProfiles_UserProfileId",
                table: "Diaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_UserProfiles_UserProfileId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_UserProfiles_UserProfileId",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Meals",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_UserProfileId",
                table: "Meals",
                newName: "IX_Meals_UserId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Exercises",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_UserProfileId",
                table: "Exercises",
                newName: "IX_Exercises_UserId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Diaries",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Diaries_UserProfileId",
                table: "Diaries",
                newName: "IX_Diaries_UserId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "DateAchievements",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DateAchievements_UserProfileId",
                table: "DateAchievements",
                newName: "IX_DateAchievements_UserId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "ColumnItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ColumnItems_UserProfileId",
                table: "ColumnItems",
                newName: "IX_ColumnItems_UserId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "BodyRecords",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyRecords_UserProfileId",
                table: "BodyRecords",
                newName: "IX_BodyRecords_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyRecords_Users_UserId",
                table: "BodyRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColumnItems_Users_UserId",
                table: "ColumnItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DateAchievements_Users_UserId",
                table: "DateAchievements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_Users_UserId",
                table: "Diaries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Users_UserId",
                table: "Exercises",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Users_UserId",
                table: "Meals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyRecords_Users_UserId",
                table: "BodyRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ColumnItems_Users_UserId",
                table: "ColumnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DateAchievements_Users_UserId",
                table: "DateAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_Users_UserId",
                table: "Diaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Users_UserId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Users_UserId",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Meals",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_UserId",
                table: "Meals",
                newName: "IX_Meals_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Exercises",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises",
                newName: "IX_Exercises_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Diaries",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Diaries_UserId",
                table: "Diaries",
                newName: "IX_Diaries_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DateAchievements",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_DateAchievements_UserId",
                table: "DateAchievements",
                newName: "IX_DateAchievements_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ColumnItems",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ColumnItems_UserId",
                table: "ColumnItems",
                newName: "IX_ColumnItems_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BodyRecords",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyRecords_UserId",
                table: "BodyRecords",
                newName: "IX_BodyRecords_UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyRecords_UserProfiles_UserProfileId",
                table: "BodyRecords",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColumnItems_UserProfiles_UserProfileId",
                table: "ColumnItems",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DateAchievements_UserProfiles_UserProfileId",
                table: "DateAchievements",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_UserProfiles_UserProfileId",
                table: "Diaries",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_UserProfiles_UserProfileId",
                table: "Exercises",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_UserProfiles_UserProfileId",
                table: "Meals",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
