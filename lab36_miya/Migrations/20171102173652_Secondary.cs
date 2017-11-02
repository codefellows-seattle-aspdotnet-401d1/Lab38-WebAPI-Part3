using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace lab36_miya.Migrations
{
    public partial class Secondary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListID",
                table: "RequiredCoursework",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MajorsID",
                table: "RequiredCoursework",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequiredCoursework_MajorsID",
                table: "RequiredCoursework",
                column: "MajorsID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequiredCoursework_Majors_MajorsID",
                table: "RequiredCoursework",
                column: "MajorsID",
                principalTable: "Majors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequiredCoursework_Majors_MajorsID",
                table: "RequiredCoursework");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropIndex(
                name: "IX_RequiredCoursework_MajorsID",
                table: "RequiredCoursework");

            migrationBuilder.DropColumn(
                name: "ListID",
                table: "RequiredCoursework");

            migrationBuilder.DropColumn(
                name: "MajorsID",
                table: "RequiredCoursework");
        }
    }
}
