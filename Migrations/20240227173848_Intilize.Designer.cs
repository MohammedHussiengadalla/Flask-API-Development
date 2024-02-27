﻿// <auto-generated />
using Flask_API_Development.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Flask_API_Development.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240227173848_Intilize")]
    partial class Intilize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.27");

            modelBuilder.Entity("Flask_API_Development.Model.ExecutionResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TestAssetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TestCaseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.ToTable("executionResults");
                });

            modelBuilder.Entity("Flask_API_Development.Model.TestCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("testCases");
                });

            modelBuilder.Entity("Flask_API_Development.Model.ExecutionResult", b =>
                {
                    b.HasOne("Flask_API_Development.Model.TestCase", "TestCase")
                        .WithMany("ExecutionResults")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestCase");
                });

            modelBuilder.Entity("Flask_API_Development.Model.TestCase", b =>
                {
                    b.Navigation("ExecutionResults");
                });
#pragma warning restore 612, 618
        }
    }
}
