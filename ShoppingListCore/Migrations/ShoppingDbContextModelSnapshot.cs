﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingListCoreProject.Models;

#nullable disable

namespace ShoppingListCore.Migrations
{
    [DbContext(typeof(ShoppingDbContext))]
    partial class ShoppingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShoppingListProject.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Meyve&Sebze"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Et&Tavuk&Balık"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Temel Gıda"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Kahvaltılık"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "İçecek"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Fırın"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Atıştırmalık"
                        });
                });

            modelBuilder.Entity("ShoppingListProject.Models.List", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListId"), 1L, 1);

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ListId");

                    b.HasIndex("UserId");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("ShoppingListProject.Models.ListDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.HasIndex("ProductId");

                    b.ToTable("ListDetails");
                });

            modelBuilder.Entity("ShoppingListProject.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 4,
                            Image = "yumurta.jpeg",
                            ProductName = "Yumurta"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 4,
                            Image = "zeytin.jpg",
                            ProductName = "Zeytin"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            Image = "salca.jpg",
                            ProductName = "Salça"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 6,
                            Image = "ekmek.jpg",
                            ProductName = "Ekmek"
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 1,
                            Image = "muz.jpg",
                            ProductName = "Muz"
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            Image = "elma.jpg",
                            ProductName = "Elma"
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            Image = "domates.jpg",
                            ProductName = "Domates"
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 7,
                            Image = "cikolata.jpg",
                            ProductName = "Çikolata"
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 2,
                            Image = "balik.jpg",
                            ProductName = "Balık"
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 2,
                            Image = "tavuk.jpg",
                            ProductName = "Tavuk"
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 4,
                            Image = "peynir.jpg",
                            ProductName = "Peynir"
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 1,
                            Image = "kabak.jpg",
                            ProductName = "Kabak"
                        },
                        new
                        {
                            ProductId = 13,
                            CategoryId = 2,
                            Image = "kavurmalıket.jpg",
                            ProductName = "Kavurmalık Et"
                        },
                        new
                        {
                            ProductId = 14,
                            CategoryId = 3,
                            Image = "un.jpg",
                            ProductName = "Un"
                        },
                        new
                        {
                            ProductId = 15,
                            CategoryId = 5,
                            Image = "su.jpg",
                            ProductName = "Su"
                        },
                        new
                        {
                            ProductId = 16,
                            CategoryId = 5,
                            Image = "süt.jpg",
                            ProductName = "Süt"
                        },
                        new
                        {
                            ProductId = 17,
                            CategoryId = 5,
                            Image = "soda.jpg",
                            ProductName = "Maden Suyu"
                        },
                        new
                        {
                            ProductId = 18,
                            CategoryId = 5,
                            Image = "meyvesuyu.jpg",
                            ProductName = "Meyve Suyu"
                        },
                        new
                        {
                            ProductId = 19,
                            CategoryId = 4,
                            Image = "sucuk.jpg",
                            ProductName = "Sucuk"
                        },
                        new
                        {
                            ProductId = 20,
                            CategoryId = 3,
                            Image = "makarna.jpg",
                            ProductName = "Makarna"
                        },
                        new
                        {
                            ProductId = 21,
                            CategoryId = 7,
                            Image = "cips.jpg",
                            ProductName = "Cips"
                        });
                });

            modelBuilder.Entity("ShoppingListProject.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<bool>("UserAdminStatus")
                        .HasColumnType("bit");

                    b.Property<string>("UserMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            UserAdminStatus = true,
                            UserMail = "admin@mail.com",
                            UserName = "Administrator",
                            UserPassword = "Admin123+-",
                            UserSurname = "Admin"
                        });
                });

            modelBuilder.Entity("ShoppingListProject.Models.List", b =>
                {
                    b.HasOne("ShoppingListProject.Models.User", "User")
                        .WithMany("Lists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoppingListProject.Models.ListDetail", b =>
                {
                    b.HasOne("ShoppingListProject.Models.List", "List")
                        .WithMany("ListDetails")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingListProject.Models.Product", "Product")
                        .WithMany("ListDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShoppingListProject.Models.Product", b =>
                {
                    b.HasOne("ShoppingListProject.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShoppingListProject.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShoppingListProject.Models.List", b =>
                {
                    b.Navigation("ListDetails");
                });

            modelBuilder.Entity("ShoppingListProject.Models.Product", b =>
                {
                    b.Navigation("ListDetails");
                });

            modelBuilder.Entity("ShoppingListProject.Models.User", b =>
                {
                    b.Navigation("Lists");
                });
#pragma warning restore 612, 618
        }
    }
}