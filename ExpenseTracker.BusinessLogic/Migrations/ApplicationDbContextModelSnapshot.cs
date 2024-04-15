﻿// <auto-generated />
using System;
using ExpenseTracker.BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseTracker.BusinessLogic.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ExpenseTracker.BusinessLogic.DbSet.CodeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CodeValueClassificationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CodeValueClassificationId");

                    b.ToTable("CodeValues");
                });

            modelBuilder.Entity("ExpenseTracker.BusinessLogic.DbSet.CodeValueClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("CodeValueClassifications");
                });

            modelBuilder.Entity("ExpenseTracker.BusinessLogic.DbSet.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(19, 6)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReversed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoneySourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MoneySourceId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ExpenseTracker.BusinessLogic.DbSet.CodeValue", b =>
                {
                    b.HasOne("ExpenseTracker.BusinessLogic.DbSet.CodeValueClassification", "CodeValueClassification")
                        .WithMany("CodeValues")
                        .HasForeignKey("CodeValueClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CodeValueClassification");
                });

            modelBuilder.Entity("ExpenseTracker.BusinessLogic.DbSet.Transaction", b =>
                {
                    b.HasOne("ExpenseTracker.BusinessLogic.DbSet.CodeValue", "Category")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpenseTracker.BusinessLogic.DbSet.CodeValue", "MoneySource")
                        .WithMany("MoneySources")
                        .HasForeignKey("MoneySourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpenseTracker.BusinessLogic.DbSet.CodeValue", "TransactionType")
                        .WithMany("TransactionTypes")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("MoneySource");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("ExpenseTracker.BusinessLogic.DbSet.CodeValue", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("MoneySources");

                    b.Navigation("TransactionTypes");
                });

            modelBuilder.Entity("ExpenseTracker.BusinessLogic.DbSet.CodeValueClassification", b =>
                {
                    b.Navigation("CodeValues");
                });
#pragma warning restore 612, 618
        }
    }
}
