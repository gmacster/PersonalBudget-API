using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PersonalBudget.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BudgetPeriod",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetId = table.Column<Guid>(nullable: false),
                    PeriodEndDate = table.Column<DateTime>(nullable: false),
                    PeriodStartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetPeriod_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterCategory_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MasterCategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_MasterCategory_MasterCategoryId",
                        column: x => x.MasterCategoryId,
                        principalTable: "MasterCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BudgetTarget",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetPeriodId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Inflow = table.Column<decimal>(nullable: false),
                    Outflow = table.Column<decimal>(nullable: false),
                    Payee = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_BudgetId",
                table: "Account",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetPeriod_BudgetId",
                table: "BudgetPeriod",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTarget_BudgetPeriodId",
                table: "BudgetTarget",
                column: "BudgetPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTarget_CategoryId",
                table: "BudgetTarget",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MasterCategoryId",
                table: "Category",
                column: "MasterCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterCategory_BudgetId",
                table: "MasterCategory",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                table: "Transaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CategoryId",
                table: "Transaction",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetTarget");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "BudgetPeriod");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "MasterCategory");

            migrationBuilder.DropTable(
                name: "Budget");
        }
    }
}
