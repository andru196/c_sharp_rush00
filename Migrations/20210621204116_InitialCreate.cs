using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace c_sharp_rush00.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habbits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Motivation = table.Column<string>(type: "TEXT", nullable: false),
                    IsFinished = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habbits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HabitChecks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsChecked = table.Column<bool>(type: "INTEGER", nullable: false),
                    HabbitId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitChecks_Habbits_HabbitId",
                        column: x => x.HabbitId,
                        principalTable: "Habbits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitChecks_HabbitId",
                table: "HabitChecks",
                column: "HabbitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitChecks");

            migrationBuilder.DropTable(
                name: "Habbits");
        }
    }
}
