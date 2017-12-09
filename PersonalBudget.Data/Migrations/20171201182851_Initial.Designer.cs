﻿// <auto-generated />

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

using PersonalBudget.Data.DataAccessLayer;

namespace PersonalBudget.Data.Migrations
{
    [DbContext(typeof(PersonalBudgetContext))]
    [Migration("20171201182851_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalBudget.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("PersonalBudget.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<decimal>("Inflow");

                    b.Property<decimal>("Outflow");

                    b.Property<string>("Payee");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("PersonalBudget.Models.Transaction", b =>
                {
                    b.HasOne("PersonalBudget.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}