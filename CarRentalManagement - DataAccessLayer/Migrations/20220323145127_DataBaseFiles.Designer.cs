﻿// <auto-generated />
using System;
using CarRentalManagement___DataAccessLayer.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentalManagement___DataAccessLayer.Migrations
{
    [DbContext(typeof(CarDBContext))]
    [Migration("20220323145127_DataBaseFiles")]
    partial class DataBaseFiles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.AdminDto", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("AdminDtos");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.CarDto", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"), 1L, 1);

                    b.Property<int>("CarTypeCarId")
                        .HasColumnType("int");

                    b.Property<int>("ConditionCarID")
                        .HasColumnType("int");

                    b.Property<decimal>("DailyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DayDelayPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("CarTypeCarId");

                    b.HasIndex("ConditionCarID");

                    b.ToTable("CarDto");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.CarTypeDto", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"), 1L, 1);

                    b.Property<int>("Gears")
                        .HasColumnType("int");

                    b.Property<int>("transmitionCarID")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("transmitionCarID");

                    b.ToTable("CarTypeDto");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.Condition", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarID"), 1L, 1);

                    b.Property<string>("conditionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarID");

                    b.ToTable("Condition");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.IDProof", b =>
                {
                    b.Property<string>("IDNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Verification")
                        .HasColumnType("bit");

                    b.HasKey("IDNumber");

                    b.ToTable("IDProof");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int?>("AdminDtoAdminId")
                        .HasColumnType("int");

                    b.Property<int>("CarDetailsCarId")
                        .HasColumnType("int");

                    b.Property<bool>("OrderStatusIsPending")
                        .HasColumnType("bit");

                    b.Property<int>("OrderedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentDetailsPaymentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("AdminDtoAdminId");

                    b.HasIndex("CarDetailsCarId");

                    b.HasIndex("OrderStatusIsPending");

                    b.HasIndex("OrderedByUserId");

                    b.HasIndex("PaymentDetailsPaymentId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.Payment", b =>
                {
                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("PaymentAmount")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.Status", b =>
                {
                    b.Property<bool>("IsPending")
                        .HasColumnType("bit");

                    b.Property<bool>("DeliveryStatus")
                        .HasColumnType("bit");

                    b.Property<bool>("ReturnStatus")
                        .HasColumnType("bit");

                    b.HasKey("IsPending");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.Transmition", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarID"), 1L, 1);

                    b.Property<string>("GearType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarID");

                    b.ToTable("Transmition");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.UserDto", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("KycDetailsIDNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("KycDetailsIDNumber");

                    b.ToTable("UserDtos");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.CarDto", b =>
                {
                    b.HasOne("CarRentalManagement___DataAccessLayer.DTO.CarTypeDto", "CarType")
                        .WithMany()
                        .HasForeignKey("CarTypeCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalManagement___DataAccessLayer.DTO.Condition", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionCarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarType");

                    b.Navigation("Condition");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.CarTypeDto", b =>
                {
                    b.HasOne("CarRentalManagement___DataAccessLayer.DTO.Transmition", "transmition")
                        .WithMany()
                        .HasForeignKey("transmitionCarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("transmition");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.Order", b =>
                {
                    b.HasOne("CarRentalManagement___DataAccessLayer.DTO.AdminDto", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("AdminDtoAdminId");

                    b.HasOne("CarRentalManagement___DataAccessLayer.DTO.CarDto", "CarDetails")
                        .WithMany()
                        .HasForeignKey("CarDetailsCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalManagement___DataAccessLayer.DTO.Status", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusIsPending")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalManagement___DataAccessLayer.DTO.UserDto", "OrderedBy")
                        .WithMany("OrdersPlaced")
                        .HasForeignKey("OrderedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalManagement___DataAccessLayer.DTO.Payment", "PaymentDetails")
                        .WithMany()
                        .HasForeignKey("PaymentDetailsPaymentId");

                    b.Navigation("CarDetails");

                    b.Navigation("OrderStatus");

                    b.Navigation("OrderedBy");

                    b.Navigation("PaymentDetails");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.Payment", b =>
                {
                    b.HasOne("CarRentalManagement___DataAccessLayer.DTO.UserDto", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.UserDto", b =>
                {
                    b.HasOne("CarRentalManagement___DataAccessLayer.DTO.IDProof", "KycDetails")
                        .WithMany()
                        .HasForeignKey("KycDetailsIDNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KycDetails");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.AdminDto", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("CarRentalManagement___DataAccessLayer.DTO.UserDto", b =>
                {
                    b.Navigation("OrdersPlaced");
                });
#pragma warning restore 612, 618
        }
    }
}
