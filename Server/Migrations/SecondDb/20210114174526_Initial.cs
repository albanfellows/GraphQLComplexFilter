using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLComplexFilter.Migrations.SecondDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seconds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldFive = table.Column<string>(type: "TEXT", nullable: true),
                    FieldSix = table.Column<int>(type: "INTEGER", nullable: true),
                    FieldSeven = table.Column<decimal>(type: "TEXT", nullable: true),
                    FieldEight = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FirstId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seconds", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Seconds",
                columns: new[] { "Id", "FieldEight", "FieldFive", "FieldSeven", "FieldSix", "FirstId" },
                values: new object[] { 1, null, "Uno", null, null, null });

            migrationBuilder.InsertData(
                table: "Seconds",
                columns: new[] { "Id", "FieldEight", "FieldFive", "FieldSeven", "FieldSix", "FirstId" },
                values: new object[] { 2, null, "Duo", null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seconds");
        }
    }
}
