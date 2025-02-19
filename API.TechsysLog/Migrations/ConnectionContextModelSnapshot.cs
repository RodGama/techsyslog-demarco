﻿// <auto-generated />
using System;
using API.TechsysLog.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.TechsysLog.Migrations
{
    [DbContext(typeof(ConnectionContext))]
    partial class ConnectionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.TechsysLog.Domain.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("OrderNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderNumber");

                    b.ToTable("Delivery", (string)null);
                });

            modelBuilder.Entity("API.TechsysLog.Domain.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NotifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId")
                        .IsUnique();

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("API.TechsysLog.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrderNumber")
                        .HasColumnType("bigint");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("OrderNumber");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("API.TechsysLog.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("API.TechsysLog.Models.UserOrders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("OrderNumber")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderNumber", "UserId");

                    b.ToTable("User_order", (string)null);
                });

            modelBuilder.Entity("API.TechsysLog.Domain.Notification", b =>
                {
                    b.HasOne("API.TechsysLog.Domain.Delivery", null)
                        .WithOne("Notification")
                        .HasForeignKey("API.TechsysLog.Domain.Notification", "DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.TechsysLog.Domain.Order", b =>
                {
                    b.HasOne("API.TechsysLog.Domain.Delivery", "Delivery")
                        .WithMany()
                        .HasForeignKey("DeliveryId");

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("API.TechsysLog.Domain.Delivery", b =>
                {
                    b.Navigation("Notification");
                });
#pragma warning restore 612, 618
        }
    }
}
