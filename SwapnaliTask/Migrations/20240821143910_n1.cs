using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwapnaliTask.Migrations
{
    /// <inheritdoc />
    public partial class n1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "entries",
                columns: table => new
                {
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entries", x => x.EntryID);
                    table.ForeignKey(
                        name: "FK_entries_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "audits",
                columns: table => new
                {
                    AuditID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryID = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audits", x => x.AuditID);
                    table.ForeignKey(
                        name: "FK_audits_entries_EntryID",
                        column: x => x.EntryID,
                        principalTable: "entries",
                        principalColumn: "EntryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_audits_EntryID",
                table: "audits",
                column: "EntryID");

            migrationBuilder.CreateIndex(
                name: "IX_entries_UserID",
                table: "entries",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audits");

            migrationBuilder.DropTable(
                name: "entries");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
