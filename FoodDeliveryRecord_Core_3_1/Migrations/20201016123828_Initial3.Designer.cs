﻿// <auto-generated />
using System;
using FoodDeliveryRecord_Core_3_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodDeliveryRecord_Core_3_1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201016123828_Initial3")]
    partial class Initial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectiveAction")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.FoodCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DetailId")
                        .HasColumnType("int");

                    b.Property<int?>("PackageConditionId")
                        .HasColumnType("int");

                    b.Property<int?>("PackageTemperatureId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductConditionId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductTemperatureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.HasIndex("PackageConditionId");

                    b.HasIndex("PackageTemperatureId");

                    b.HasIndex("ProductConditionId");

                    b.HasIndex("ProductTemperatureId");

                    b.ToTable("FoodConditions");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.PackageCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Acceptable")
                        .HasColumnType("bit");

                    b.Property<bool>("Unacceptable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PackageCondition");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.PackageTemperature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Acceptable")
                        .HasColumnType("bit");

                    b.Property<bool>("Unacceptable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PackageTemperature");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.ProductCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Acceptable")
                        .HasColumnType("bit");

                    b.Property<bool>("Unacceptable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ProductCondition");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.ProductTemperature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Acceptable")
                        .HasColumnType("bit");

                    b.Property<bool>("Unacceptable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ProductTemperature");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.Receiver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FoodConditionId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SignatureId")
                        .HasColumnType("int");

                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("int");

                    b.Property<int?>("VendorListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodConditionId");

                    b.HasIndex("SignatureId");

                    b.HasIndex("VendorListId");

                    b.ToTable("Receivers");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.Signature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateVerified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ManagerSignature")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Signatures");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.VendorList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Vendors")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VendorLists");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.FoodCondition", b =>
                {
                    b.HasOne("FoodDeliveryRecord_Core_3_1.Models.Detail", "Detail")
                        .WithMany()
                        .HasForeignKey("DetailId");

                    b.HasOne("FoodDeliveryRecord_Core_3_1.Models.PackageCondition", "PackageCondition")
                        .WithMany()
                        .HasForeignKey("PackageConditionId");

                    b.HasOne("FoodDeliveryRecord_Core_3_1.Models.PackageTemperature", "PackageTemperature")
                        .WithMany()
                        .HasForeignKey("PackageTemperatureId");

                    b.HasOne("FoodDeliveryRecord_Core_3_1.Models.ProductCondition", "ProductCondition")
                        .WithMany()
                        .HasForeignKey("ProductConditionId");

                    b.HasOne("FoodDeliveryRecord_Core_3_1.Models.ProductTemperature", "ProductTemperature")
                        .WithMany()
                        .HasForeignKey("ProductTemperatureId");
                });

            modelBuilder.Entity("FoodDeliveryRecord_Core_3_1.Models.Receiver", b =>
                {
                    b.HasOne("FoodDeliveryRecord_Core_3_1.Models.FoodCondition", "FoodCondition")
                        .WithMany()
                        .HasForeignKey("FoodConditionId");

                    b.HasOne("FoodDeliveryRecord_Core_3_1.Models.Signature", "Signature")
                        .WithMany()
                        .HasForeignKey("SignatureId");

                    b.HasOne("FoodDeliveryRecord_Core_3_1.Models.VendorList", "VendorList")
                        .WithMany()
                        .HasForeignKey("VendorListId");
                });
#pragma warning restore 612, 618
        }
    }
}
