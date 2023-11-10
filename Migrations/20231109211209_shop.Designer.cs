﻿// <auto-generated />
using DropDown.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DropDown.Migrations
{
    [DbContext(typeof(OurDbContext))]
    [Migration("20231109211209_shop")]
    partial class shop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.24");

            modelBuilder.Entity("DropDown.Domain.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            GradeId = 1,
                            Description = "Small"
                        },
                        new
                        {
                            GradeId = 2,
                            Description = "Medium"
                        },
                        new
                        {
                            GradeId = 3,
                            Description = "Large"
                        },
                        new
                        {
                            GradeId = 4,
                            Description = "Very Large"
                        });
                });

            modelBuilder.Entity("DropDown.Domain.Shop", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GradeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StoreNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("StoreId");

                    b.HasIndex("GradeId");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            StoreId = 1,
                            Description = "Inside Cleveland Centre",
                            GradeId = 1,
                            StoreName = "Middlesbrough",
                            StoreNumber = 10
                        },
                        new
                        {
                            StoreId = 2,
                            Description = "Blah Blah Blah",
                            GradeId = 2,
                            StoreName = "Stockton",
                            StoreNumber = 11
                        },
                        new
                        {
                            StoreId = 3,
                            Description = "Blah Blah Blah",
                            GradeId = 3,
                            StoreName = "Thornaby",
                            StoreNumber = 12
                        },
                        new
                        {
                            StoreId = 4,
                            Description = "Blah Blah Blah",
                            GradeId = 4,
                            StoreName = "Redcar",
                            StoreNumber = 13
                        },
                        new
                        {
                            StoreId = 5,
                            Description = "Blah Blah Blah",
                            GradeId = 4,
                            StoreName = "Billingham",
                            StoreNumber = 14
                        },
                        new
                        {
                            StoreId = 6,
                            Description = "Blah Blah Blah",
                            GradeId = 3,
                            StoreName = "Saltburn",
                            StoreNumber = 15
                        },
                        new
                        {
                            StoreId = 7,
                            Description = "Blah Blah Blah",
                            GradeId = 2,
                            StoreName = "Darlington",
                            StoreNumber = 16
                        },
                        new
                        {
                            StoreId = 8,
                            Description = "Blah Blah Blah",
                            GradeId = 1,
                            StoreName = "Eston",
                            StoreNumber = 17
                        },
                        new
                        {
                            StoreId = 9,
                            Description = "Blah Blah Blah",
                            GradeId = 2,
                            StoreName = "Sunderland",
                            StoreNumber = 18
                        });
                });

            modelBuilder.Entity("DropDown.Domain.Shop", b =>
                {
                    b.HasOne("DropDown.Domain.Grade", "Grade")
                        .WithMany("Shop")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("DropDown.Domain.Grade", b =>
                {
                    b.Navigation("Shop");
                });
#pragma warning restore 612, 618
        }
    }
}