﻿// <auto-generated />
using System;
using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseTracker.Data.Migrations
{
    [DbContext(typeof(ExpenseTrackerDBContext))]
    [Migration("20230619133443_AddData")]
    partial class AddData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExpenseTracker.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Credit Card Loans",
                            Name = "Credit Card"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Food",
                            Name = "Food"
                        });
                });

            modelBuilder.Entity("ExpenseTracker.Domain.Entities.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePurchased")
                        .HasColumnType("datetime2");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ItemAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ExpenseId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            ExpenseId = 1,
                            CategoryId = 1,
                            DatePurchased = new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Item = "Camera",
                            ItemAmount = 55790.00m
                        },
                        new
                        {
                            ExpenseId = 2,
                            CategoryId = 2,
                            DatePurchased = new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Item = "Coffee",
                            ItemAmount = 250m
                        });
                });

            modelBuilder.Entity("ExpenseTracker.Domain.Entities.Expense", b =>
                {
                    b.HasOne("ExpenseTracker.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
