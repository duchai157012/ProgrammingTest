using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Change_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyRecords_Profiles_ProfileId",
                table: "BodyRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ColumnItems_Profiles_UserProfileId",
                table: "ColumnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DateAchievements_Profiles_UserProfileId",
                table: "DateAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_Profiles_ProfileId",
                table: "Diaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Profiles_ProfileId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Profiles_ProfileId",
                table: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "DateAchievements");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Meals",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_ProfileId",
                table: "Meals",
                newName: "IX_Meals_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Exercises",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_ProfileId",
                table: "Exercises",
                newName: "IX_Exercises_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Diaries",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Diaries_ProfileId",
                table: "Diaries",
                newName: "IX_Diaries_UserProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "BodyRecords",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyRecords_ProfileId",
                table: "BodyRecords",
                newName: "IX_BodyRecords_UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "Profiles");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Meals",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_UserProfileId",
                table: "Meals",
                newName: "IX_Meals_ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Exercises",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_UserProfileId",
                table: "Exercises",
                newName: "IX_Exercises_ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Diaries",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Diaries_UserProfileId",
                table: "Diaries",
                newName: "IX_Diaries_ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "BodyRecords",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_BodyRecords_UserProfileId",
                table: "BodyRecords",
                newName: "IX_BodyRecords_ProfileId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "DateAchievements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyRecords_Profiles_ProfileId",
                table: "BodyRecords",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_Profiles_ProfileId",
                table: "Diaries",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Profiles_ProfileId",
                table: "Exercises",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Profiles_ProfileId",
                table: "Meals",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
