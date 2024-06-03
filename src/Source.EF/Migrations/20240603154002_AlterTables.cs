using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.EF.Migrations
{
    /// <inheritdoc />
    public partial class AlterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionInfomations_UserProfiles_UserCode",
                table: "SessionInfomations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionInfomations",
                table: "SessionInfomations");

            migrationBuilder.DropIndex(
                name: "IX_SessionInfomations_UserCode",
                table: "SessionInfomations");

            migrationBuilder.DropColumn(
                name: "AmendedBy",
                table: "SessionInfomations");

            migrationBuilder.DropColumn(
                name: "AmendedOn",
                table: "SessionInfomations");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "SessionInfomations");

            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "SessionInfomations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 3, 15, 40, 1, 113, DateTimeKind.Utc).AddTicks(9408),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(2129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "SessionInfomations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 3, 15, 40, 1, 114, DateTimeKind.Utc).AddTicks(2879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(5383));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "SessionInfomations",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SessionInfomations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationParameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 3, 15, 40, 1, 114, DateTimeKind.Utc).AddTicks(3693),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionInfomations",
                table: "SessionInfomations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ApplicationParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 3, 15, 40, 1, 114, DateTimeKind.Utc).AddTicks(3693));

            migrationBuilder.UpdateData(
                table: "ApplicationParameters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 3, 15, 40, 1, 114, DateTimeKind.Utc).AddTicks(3693));

            migrationBuilder.UpdateData(
                table: "ApplicationParameters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 3, 15, 40, 1, 114, DateTimeKind.Utc).AddTicks(3693));

            migrationBuilder.UpdateData(
                table: "ApplicationParameters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 3, 15, 40, 1, 114, DateTimeKind.Utc).AddTicks(3693));

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfomations_RefreshToken",
                table: "SessionInfomations",
                column: "RefreshToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfomations_UserId",
                table: "SessionInfomations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionInfomations_UserProfiles_UserId",
                table: "SessionInfomations",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionInfomations_UserProfiles_UserId",
                table: "SessionInfomations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionInfomations",
                table: "SessionInfomations");

            migrationBuilder.DropIndex(
                name: "IX_SessionInfomations_RefreshToken",
                table: "SessionInfomations");

            migrationBuilder.DropIndex(
                name: "IX_SessionInfomations_UserId",
                table: "SessionInfomations");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "SessionInfomations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SessionInfomations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(2129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 3, 15, 40, 1, 113, DateTimeKind.Utc).AddTicks(9408));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "SessionInfomations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(5383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 3, 15, 40, 1, 114, DateTimeKind.Utc).AddTicks(2879));

            migrationBuilder.AddColumn<string>(
                name: "AmendedBy",
                table: "SessionInfomations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AmendedOn",
                table: "SessionInfomations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "SessionInfomations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserCode",
                table: "SessionInfomations",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationParameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(6235),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 3, 15, 40, 1, 114, DateTimeKind.Utc).AddTicks(3693));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionInfomations",
                table: "SessionInfomations",
                column: "Code");

            migrationBuilder.UpdateData(
                table: "ApplicationParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "ApplicationParameters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "ApplicationParameters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "ApplicationParameters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfomations_UserCode",
                table: "SessionInfomations",
                column: "UserCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionInfomations_UserProfiles_UserCode",
                table: "SessionInfomations",
                column: "UserCode",
                principalTable: "UserProfiles",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
