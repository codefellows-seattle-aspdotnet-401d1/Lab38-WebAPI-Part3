using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Week8Project.Migrations
{
    public partial class addList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeListID",
                table: "Pokemon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeList", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_TypeListID",
                table: "Pokemon",
                column: "TypeListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_TypeList_TypeListID",
                table: "Pokemon",
                column: "TypeListID",
                principalTable: "TypeList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_TypeList_TypeListID",
                table: "Pokemon");

            migrationBuilder.DropTable(
                name: "TypeList");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_TypeListID",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "TypeListID",
                table: "Pokemon");
        }
    }
}
