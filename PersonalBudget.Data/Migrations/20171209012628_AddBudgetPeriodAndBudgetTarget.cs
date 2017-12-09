using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PersonalBudget.Data.Migrations
{
    public partial class AddBudgetPeriodAndBudgetTarget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetPeriod",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PeriodEndDate = table.Column<DateTime>(nullable: false),
                    PeriodStartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetPeriod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetTarget",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetPeriodId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Target = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetTarget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetTarget_BudgetPeriod_BudgetPeriodId",
                        column: x => x.BudgetPeriodId,
                        principalTable: "BudgetPeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetTarget_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTarget_BudgetPeriodId",
                table: "BudgetTarget",
                column: "BudgetPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTarget_CategoryId",
                table: "BudgetTarget",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetTarget");

            migrationBuilder.DropTable(
                name: "BudgetPeriod");
        }
    }
}
