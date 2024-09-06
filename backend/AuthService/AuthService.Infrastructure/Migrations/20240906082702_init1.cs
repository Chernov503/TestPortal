using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BanRecords",
                columns: table => new
                {
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    BanMessage = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DateExp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanRecords", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "UserTestAccesses",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestAccesses", x => new { x.TestId, x.UserId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_BanRecords_Email",
                table: "BanRecords",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BanRecords");

            migrationBuilder.DropTable(
                name: "UserTestAccesses");
        }
    }
}
