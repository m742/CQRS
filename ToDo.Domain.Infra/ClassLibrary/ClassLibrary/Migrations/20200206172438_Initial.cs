using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 120, nullable: true),
                    Done = table.Column<bool>(maxLength: 120, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    RefUser = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_RefUser",
                table: "Todos",
                column: "RefUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
