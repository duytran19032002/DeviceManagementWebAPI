﻿// <auto-generated />
using System;
using EquipmentManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EquipmentManagement.Persistence.Migrations
{
    [DbContext(typeof(ManageEquipmentDbContext))]
    [Migration("20240416141416_DbInit")]
    partial class DbInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BorrowEquipment", b =>
                {
                    b.Property<string>("BorrowsBorrowId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EquipmentsEquipmentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BorrowsBorrowId", "EquipmentsEquipmentId");

                    b.HasIndex("EquipmentsEquipmentId");

                    b.ToTable("BorrowEquipment");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Borrow", b =>
                {
                    b.Property<string>("BorrowId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BorrowedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Borrower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnSide")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("RealReturnedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BorrowId");

                    b.HasIndex("ProjectName");

                    b.ToTable("Borrow");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Equipment", b =>
                {
                    b.Property<string>("EquipmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodeOfManager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipmentTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("YearOfSupply")
                        .HasColumnType("datetime2");

                    b.HasKey("EquipmentId");

                    b.HasIndex("EquipmentTypeId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ProjectName");

                    b.HasIndex("SupplierName");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.EquipmentType", b =>
                {
                    b.Property<string>("EquipmentTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipmentTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentTypeId");

                    b.ToTable("EquipmentType");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.GoogleForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("CheckSeen")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkGgDrive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MSSV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnSite")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GoogleForm");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Location", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureId"), 1L, 1);

                    b.Property<string>("EquipmentTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.HasKey("PictureId");

                    b.HasIndex("EquipmentTypeId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Project", b =>
                {
                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RealEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectName");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Specification", b =>
                {
                    b.Property<int>("SpecificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecificationId"), 1L, 1);

                    b.Property<string>("EquipmentTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecificationId");

                    b.HasIndex("EquipmentTypeId");

                    b.ToTable("Specification");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Supplier", b =>
                {
                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierName");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Tag", b =>
                {
                    b.Property<string>("TagId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TagDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("EquipmentTypeTag", b =>
                {
                    b.Property<string>("EquipmentTypesEquipmentTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TagsTagId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EquipmentTypesEquipmentTypeId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("EquipmentTypeTag");
                });

            modelBuilder.Entity("BorrowEquipment", b =>
                {
                    b.HasOne("EquipmentManagement.Domain.Borrow", null)
                        .WithMany()
                        .HasForeignKey("BorrowsBorrowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EquipmentManagement.Domain.Equipment", null)
                        .WithMany()
                        .HasForeignKey("EquipmentsEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Borrow", b =>
                {
                    b.HasOne("EquipmentManagement.Domain.Project", "Project")
                        .WithMany("Borrows")
                        .HasForeignKey("ProjectName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Equipment", b =>
                {
                    b.HasOne("EquipmentManagement.Domain.EquipmentType", "EquipmentType")
                        .WithMany()
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EquipmentManagement.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("EquipmentManagement.Domain.Project", "Project")
                        .WithMany("Equipments")
                        .HasForeignKey("ProjectName");

                    b.HasOne("EquipmentManagement.Domain.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentType");

                    b.Navigation("Location");

                    b.Navigation("Project");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Picture", b =>
                {
                    b.HasOne("EquipmentManagement.Domain.EquipmentType", "EquipmentType")
                        .WithMany("Pictures")
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentType");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Specification", b =>
                {
                    b.HasOne("EquipmentManagement.Domain.EquipmentType", "EquipmentType")
                        .WithMany("Specifications")
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentType");
                });

            modelBuilder.Entity("EquipmentTypeTag", b =>
                {
                    b.HasOne("EquipmentManagement.Domain.EquipmentType", null)
                        .WithMany()
                        .HasForeignKey("EquipmentTypesEquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EquipmentManagement.Domain.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquipmentManagement.Domain.EquipmentType", b =>
                {
                    b.Navigation("Pictures");

                    b.Navigation("Specifications");
                });

            modelBuilder.Entity("EquipmentManagement.Domain.Project", b =>
                {
                    b.Navigation("Borrows");

                    b.Navigation("Equipments");
                });
#pragma warning restore 612, 618
        }
    }
}
