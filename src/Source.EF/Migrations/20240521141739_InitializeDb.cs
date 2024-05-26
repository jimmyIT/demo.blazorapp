using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Source.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Editable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(6235)),
                    AmendedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmendedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedSecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneIDD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(2129)),
                    AmendedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmendedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SessionInfomations",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 21, 14, 17, 39, 122, DateTimeKind.Utc).AddTicks(5383)),
                    AmendedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmendedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionInfomations", x => x.Code);
                    table.ForeignKey(
                        name: "FK_SessionInfomations_UserProfiles_UserCode",
                        column: x => x.UserCode,
                        principalTable: "UserProfiles",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationParameters",
                columns: new[] { "Id", "AmendedBy", "AmendedOn", "Code", "CreateBy", "Description", "Editable", "Value" },
                values: new object[,]
                {
                    { 1, "", null, "EmailAddressRegex", "", "Email address regex", true, "\\w+([-!#$%&‘*'+–/=?^_{1}`.{|}~]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*" },
                    { 2, "", null, "PasswordStrength", "", "Password strength", true, "^.*(?=.{8,12})(?=.*[a-z])(?=.*[A-Z])(?=.*[\\d]).*$" },
                    { 3, "", null, "UseSecurityPin", "", "Use security pin", true, "false" },
                    { 4, "", null, "AutoGenerateUserCode", "", "Auto generate the user code when creating", true, "false" }
                });

            migrationBuilder.InsertData(
                table: "Errors",
                columns: new[] { "Id", "Code", "ErrorMessage", "ResourceKey" },
                values: new object[,]
                {
                    { 1, "001", "The user code is invalid", "invalid_user_code" },
                    { 400, "400", "Bad Request", "bad_request" },
                    { 404, "404", "Not Found", "not_found" },
                    { 500, "500", "Internal Server Error", "internal_server_error" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationParameters_Code",
                table: "ApplicationParameters",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationParameters_Id",
                table: "ApplicationParameters",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Errors_Code",
                table: "Errors",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Errors_Id",
                table: "Errors",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfomations_Code",
                table: "SessionInfomations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfomations_Id",
                table: "SessionInfomations",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfomations_UserCode",
                table: "SessionInfomations",
                column: "UserCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_Code",
                table: "UserProfiles",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_Id",
                table: "UserProfiles",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationParameters");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "SessionInfomations");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
