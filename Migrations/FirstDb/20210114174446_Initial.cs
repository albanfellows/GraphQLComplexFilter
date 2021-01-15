using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLComplexFilter.Migrations.FirstDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firsts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldOne = table.Column<string>(type: "TEXT", nullable: true),
                    FieldTwo = table.Column<int>(type: "INTEGER", nullable: true),
                    FieldThree = table.Column<decimal>(type: "TEXT", nullable: true),
                    FieldFour = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SecondId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firsts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Firsts",
                columns: new[] { "Id", "FieldFour", "FieldOne", "FieldThree", "FieldTwo", "SecondId" },
                values: new object[] { 1, null, "One", null, 1, 1 });

            migrationBuilder.InsertData(
                table: "Firsts",
                columns: new[] { "Id", "FieldFour", "FieldOne", "FieldThree", "FieldTwo", "SecondId" },
                values: new object[] { 2, null, "Two", null, 2, 1 });

            migrationBuilder.InsertData(
                table: "Firsts",
                columns: new[] { "Id", "FieldFour", "FieldOne", "FieldThree", "FieldTwo", "SecondId" },
                values: new object[] { 3, null, "Three", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Firsts",
                columns: new[] { "Id", "FieldFour", "FieldOne", "FieldThree", "FieldTwo", "SecondId" },
                values: new object[] { 4, null, "Four", null, 4, null });

            migrationBuilder.InsertData(
                table: "Firsts",
                columns: new[] { "Id", "FieldFour", "FieldOne", "FieldThree", "FieldTwo", "SecondId" },
                values: new object[] { 5, null, "Five", null, 5, 2 });

            migrationBuilder.InsertData(
                table: "Firsts",
                columns: new[] { "Id", "FieldFour", "FieldOne", "FieldThree", "FieldTwo", "SecondId" },
                values: new object[] { 6, null, "Six", null, null, 2 });

            migrationBuilder.InsertData(
                table: "Firsts",
                columns: new[] { "Id", "FieldFour", "FieldOne", "FieldThree", "FieldTwo", "SecondId" },
                values: new object[] { 7, null, "Seven", null, null, null });

            migrationBuilder.InsertData(
                table: "Firsts",
                columns: new[] { "Id", "FieldFour", "FieldOne", "FieldThree", "FieldTwo", "SecondId" },
                values: new object[] { 8, null, "Eight", null, null, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firsts");
        }
    }
}
