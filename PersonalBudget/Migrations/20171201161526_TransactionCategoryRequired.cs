using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PersonalBudget.Migrations
{
    public partial class TransactionCategoryRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Category_CategoryId",
                table: "Transaction");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Transaction",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Category_CategoryId",
                table: "Transaction",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Category_CategoryId",
                table: "Transaction");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Transaction",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Category_CategoryId",
                table: "Transaction",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
