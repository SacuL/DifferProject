using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Differ.Infra.Data.Migrations
{
    public partial class Diff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LeftDiffData = table.Column<string>(type: "varchar(4000)", nullable: true),
                    RightDiffData = table.Column<string>(type: "varchar(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diffs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diffs");
        }
    }
}
