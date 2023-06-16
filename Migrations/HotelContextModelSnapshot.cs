﻿// <auto-generated />
using System;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelReservation.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelReservation.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("HotelReservation.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("salary")
                        .HasColumnType("float");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HotelReservation.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("balance")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("HotelReservation.Models.Hotel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("NumOfRooms")
                        .HasColumnType("int");

                    b.Property<int>("Rates")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CityId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelReservation.Models.Reservation", b =>
                {
                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationNum")
                        .HasColumnType("int");

                    b.Property<DateTime>("StReservDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndReservDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GuestId", "RoomId", "HotelId", "ReservationNum", "StReservDate");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelReservation.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("available")
                        .HasColumnType("bit");

                    b.Property<string>("imgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("offer")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelReservation.Models.Employee", b =>
                {
                    b.HasOne("HotelReservation.Models.Hotel", "Hotel")
                        .WithMany("Employees")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelReservation.Models.Hotel", b =>
                {
                    b.HasOne("HotelReservation.Models.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("HotelReservation.Models.Reservation", b =>
                {
                    b.HasOne("HotelReservation.Models.Guest", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservation.Models.Hotel", "Hotel")
                        .WithMany("Reservations")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservation.Models.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelReservation.Models.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("HotelReservation.Models.Guest", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelReservation.Models.Hotel", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelReservation.Models.Room", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}