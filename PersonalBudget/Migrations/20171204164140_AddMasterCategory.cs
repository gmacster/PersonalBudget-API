using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PersonalBudget.Migrations
{
    public partial class AddMasterCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MasterCategoryId",
                table: "Category",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MasterCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_MasterCategoryId",
                table: "Category",
                column: "MasterCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_MasterCategory_MasterCategoryId",
                table: "Category",
                column: "MasterCategoryId",
                principalTable: "MasterCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_MasterCategory_MasterCategoryId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "MasterCategory");

            migrationBuilder.DropIndex(
                name: "IX_Category_MasterCategoryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "MasterCategoryId",
                table: "Category");
        }
    }
}
