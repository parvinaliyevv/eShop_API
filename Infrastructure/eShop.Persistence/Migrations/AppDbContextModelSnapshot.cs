﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShop.Persistence.Data.Contexts;

#nullable disable

namespace eShop.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5af53c6d-cd97-4c5a-b1b6-e4bbaf79ee39"),
                            CreatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6439),
                            Name = "Smartphone",
                            UpdatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6440)
                        });
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3afc4bbb-60b7-4b94-b84e-97820597b520"),
                            CreatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6370),
                            Name = "John",
                            Surname = "Doe",
                            UpdatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6371)
                        });
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f88f4d79-6e63-466e-86df-c1e31da62ce9"),
                            Address = "(217) 348-8633\r\n1418 6th St\r\nCharleston, Illinois(IL), 61920",
                            CreatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(4889),
                            CustomerId = new Guid("3afc4bbb-60b7-4b94-b84e-97820597b520"),
                            Description = "Iphone 11",
                            UpdatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(4901)
                        });
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8ca3b302-7a9c-4738-b5bf-1674bb298e29"),
                            CategoryId = new Guid("5af53c6d-cd97-4c5a-b1b6-e4bbaf79ee39"),
                            CreatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6223),
                            Description = "128 gb black",
                            Name = "Iphone 11",
                            Price = 1399.0,
                            Stock = 50,
                            UpdatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6226)
                        },
                        new
                        {
                            Id = new Guid("5c6460be-a137-4ab3-845c-43accca7dbcd"),
                            CategoryId = new Guid("5af53c6d-cd97-4c5a-b1b6-e4bbaf79ee39"),
                            CreatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6231),
                            Description = "64 gb white",
                            Name = "Iphone 11",
                            Price = 1199.0,
                            Stock = 50,
                            UpdatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6232)
                        },
                        new
                        {
                            Id = new Guid("0bd8cad2-1ea0-4302-9ebf-612c2c77ca95"),
                            CategoryId = new Guid("5af53c6d-cd97-4c5a-b1b6-e4bbaf79ee39"),
                            CreatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6255),
                            Description = "128 gb white",
                            Name = "Iphone 11",
                            Price = 1399.0,
                            Stock = 50,
                            UpdatedDateTime = new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6255)
                        });
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.ProductOrder", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("ProductOrders");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("8ca3b302-7a9c-4738-b5bf-1674bb298e29"),
                            OrderId = new Guid("f88f4d79-6e63-466e-86df-c1e31da62ce9")
                        },
                        new
                        {
                            ProductId = new Guid("5c6460be-a137-4ab3-845c-43accca7dbcd"),
                            OrderId = new Guid("f88f4d79-6e63-466e-86df-c1e31da62ce9")
                        });
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.Order", b =>
                {
                    b.HasOne("eShop.Domain.Entities.Concrete.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.Product", b =>
                {
                    b.HasOne("eShop.Domain.Entities.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.ProductOrder", b =>
                {
                    b.HasOne("eShop.Domain.Entities.Concrete.Order", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.Domain.Entities.Concrete.Product", "Product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.Order", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("eShop.Domain.Entities.Concrete.Product", b =>
                {
                    b.Navigation("ProductOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
