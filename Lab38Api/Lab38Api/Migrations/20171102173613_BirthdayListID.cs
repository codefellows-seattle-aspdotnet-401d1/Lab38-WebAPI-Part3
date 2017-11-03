using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lab38Api.Migrations
{
    public partial class BirthdayListID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthdayPlan_BirthdayList_BirthdayID",
                table: "BirthdayPlan");

            migrationBuilder.AlterColumn<int>(
                name: "BirthdayID",
                table: "BirthdayPlan",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BirthdayPlan_BirthdayList_BirthdayID",
                table: "BirthdayPlan",
                column: "BirthdayID",
                principalTable: "BirthdayList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthdayPlan_BirthdayList_BirthdayID",
                table: "BirthdayPlan");

            migrationBuilder.AlterColumn<int>(
                name: "BirthdayID",
                table: "BirthdayPlan",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthdayPlan_BirthdayList_BirthdayID",
                table: "BirthdayPlan",
                column: "BirthdayID",
                principalTable: "BirthdayList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
