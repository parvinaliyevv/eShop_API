using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace eShop.Persistence.Migrations;

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
                        Id = new Guid("44c82bb0-69da-4a9a-944d-85e7f2b34a5a"),
                        CreatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(4535),
                        Name = "Smartphone",
                        UpdatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(4538),
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
                        Id = new Guid("2611f479-f66d-4680-8c52-14356f2b41e0"),
                        CreatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(4199),
                        Name = "John",
                        Surname = "Doe",
                        UpdatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(4203)
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
                        Id = new Guid("12a82fd8-5b41-4be6-89e3-299c517ec0ee"),
                        Address = "(217) 348-8633\r\n1418 6th St\r\nCharleston, Illinois(IL), 61920",
                        CreatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(198),
                        Description = "Iphone 13",
                        UpdatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(213),
                        CustomerId = new Guid("2611f479-f66d-4680-8c52-14356f2b41e0")
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
                        Id = new Guid("55ea91c2-f379-48fe-81c7-916221214984"),
                        CreatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3755),
                        Description = "128 gb black",
                        Name = "Iphone 11",
                        Price = 1399.0,
                        Stock = 50,
                        UpdatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3760),
                        CategoryId = new Guid("44c82bb0-69da-4a9a-944d-85e7f2b34a5a")
                    },
                    new
                    {
                        Id = new Guid("36b09fbd-652c-4948-be89-d0566d5f0a74"),
                        CreatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3774),
                        Description = "64 gb white",
                        Name = "Iphone 11",
                        Price = 1199.0,
                        Stock = 50,
                        UpdatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3775),
                        CategoryId = new Guid("44c82bb0-69da-4a9a-944d-85e7f2b34a5a")
                    },
                    new
                    {
                        Id = new Guid("e88b8789-0174-49a5-ad7b-f6054b699af4"),
                        CreatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3780),
                        Description = "128 gb white",
                        Name = "Iphone 11",
                        Price = 1399.0,
                        Stock = 50,
                        UpdatedDateTime = new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3781),
                        CategoryId = new Guid("44c82bb0-69da-4a9a-944d-85e7f2b34a5a")
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
                        ProductId = new Guid("36b09fbd-652c-4948-be89-d0566d5f0a74"),
                        OrderId = new Guid("12a82fd8-5b41-4be6-89e3-299c517ec0ee")
                    },
                    new
                    {
                        ProductId = new Guid("55ea91c2-f379-48fe-81c7-916221214984"),
                        OrderId = new Guid("12a82fd8-5b41-4be6-89e3-299c517ec0ee")
                    },
                    new
                    {
                        ProductId = new Guid("e88b8789-0174-49a5-ad7b-f6054b699af4"),
                        OrderId = new Guid("12a82fd8-5b41-4be6-89e3-299c517ec0ee")
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
