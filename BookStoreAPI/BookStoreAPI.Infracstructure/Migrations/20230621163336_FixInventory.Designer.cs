﻿// <auto-generated />
using System;
using BookStoreAPI.Infracstructure.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreAPI.Infracstructure.Migrations
{
    [DbContext(typeof(DbContextClass))]
    [Migration("20230621163336_FixInventory")]
    partial class FixInventory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreAPI.Core.Model.Book", b =>
                {
                    b.Property<string>("Book_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Book_Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Book_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Book_ISBN")
                        .HasColumnType("int");

                    b.Property<float>("Book_Price")
                        .HasColumnType("real");

                    b.Property<string>("Book_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Book_Year_Public")
                        .HasColumnType("int");

                    b.Property<string>("Category_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Is_Book_Status")
                        .HasColumnType("bit");

                    b.HasKey("Book_Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.BookingRequest", b =>
                {
                    b.Property<string>("Request_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Book_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Import_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Is_Request_Status")
                        .HasColumnType("bit");

                    b.Property<float>("Request_Amount")
                        .HasColumnType("real");

                    b.Property<string>("Request_Book_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Request_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Request_Date_Done")
                        .HasColumnType("datetime2");

                    b.Property<string>("Request_Image_Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Request_Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Request_Price")
                        .HasColumnType("real");

                    b.Property<int>("Request_Quantity")
                        .HasColumnType("int");

                    b.HasKey("Request_Id");

                    b.HasIndex("Book_Id");

                    b.HasIndex("Import_Id");

                    b.ToTable("Request", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Category", b =>
                {
                    b.Property<string>("Category_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_Category_Status")
                        .HasColumnType("bit");

                    b.HasKey("Category_Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.ImageBook", b =>
                {
                    b.Property<int>("Image_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Image_Id"));

                    b.Property<string>("Book_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Image_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Image_Id");

                    b.HasIndex("Book_Id");

                    b.ToTable("Image", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Importation", b =>
                {
                    b.Property<string>("Import_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Import_Amount")
                        .HasColumnType("real");

                    b.Property<int>("Import_Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Is_Import_Status")
                        .HasColumnType("bit");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Import_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Importation", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.ImportationDetail", b =>
                {
                    b.Property<string>("Import_Detail_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Book_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Import_Detail_Amount")
                        .HasColumnType("real");

                    b.Property<float>("Import_Detail_Price")
                        .HasColumnType("real");

                    b.Property<int>("Import_Detail_Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Import_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Import_Detail_Id");

                    b.HasIndex("Book_Id");

                    b.HasIndex("Import_Id");

                    b.ToTable("ImportationDetail", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Inventory", b =>
                {
                    b.Property<string>("Inventory_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Book_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Inventory_Date_Into")
                        .HasColumnType("datetime2");

                    b.Property<string>("Inventory_Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory_Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Is_Inventory_Status")
                        .HasColumnType("bit");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Inventory_Id");

                    b.HasIndex("Book_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Order", b =>
                {
                    b.Property<string>("Order_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Is_Order_Status")
                        .HasColumnType("bit");

                    b.Property<float>("Order_Amount")
                        .HasColumnType("real");

                    b.Property<string>("Order_Customer_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order_Customer_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order_Customer_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Order_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order_Quantity")
                        .HasColumnType("int");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Order_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.OrderDetail", b =>
                {
                    b.Property<string>("Order_Detail_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Book_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Order_Detail_Amount")
                        .HasColumnType("real");

                    b.Property<float>("Order_Detail_Price")
                        .HasColumnType("real");

                    b.Property<int>("Order_Detail_Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Order_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Order_Detail_Id");

                    b.HasIndex("Book_Id");

                    b.HasIndex("Order_Id");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Role", b =>
                {
                    b.Property<int>("Role_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Role_Id"));

                    b.Property<string>("Role_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Role_Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.User", b =>
                {
                    b.Property<string>("User_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Is_User_Gender")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_User_Status")
                        .HasColumnType("bit");

                    b.Property<int>("Role_Id")
                        .HasColumnType("int");

                    b.Property<string>("User_Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id");

                    b.HasIndex("Role_Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Book", b =>
                {
                    b.HasOne("BookStoreAPI.Core.Model.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.BookingRequest", b =>
                {
                    b.HasOne("BookStoreAPI.Core.Model.Book", "Book")
                        .WithMany("BookingRequest")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Core.Model.Importation", "Importation")
                        .WithMany("BookingRequests")
                        .HasForeignKey("Import_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Importation");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.ImageBook", b =>
                {
                    b.HasOne("BookStoreAPI.Core.Model.Book", "Book")
                        .WithMany("Image_Book")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Importation", b =>
                {
                    b.HasOne("BookStoreAPI.Core.Model.User", "User")
                        .WithMany("Importation")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.ImportationDetail", b =>
                {
                    b.HasOne("BookStoreAPI.Core.Model.Book", "Book")
                        .WithMany("Importation_Detail")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Core.Model.Importation", "Importation")
                        .WithMany("ImportationDetails")
                        .HasForeignKey("Import_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Importation");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Inventory", b =>
                {
                    b.HasOne("BookStoreAPI.Core.Model.Book", "Books")
                        .WithMany("Inventory")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Core.Model.User", "User")
                        .WithMany("Inventory")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Order", b =>
                {
                    b.HasOne("BookStoreAPI.Core.Model.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.OrderDetail", b =>
                {
                    b.HasOne("BookStoreAPI.Core.Model.Book", "Book")
                        .WithMany("Order_Detail")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreAPI.Core.Model.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("Order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.User", b =>
                {
                    b.HasOne("BookStoreAPI.Core.Model.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Book", b =>
                {
                    b.Navigation("BookingRequest");

                    b.Navigation("Image_Book");

                    b.Navigation("Importation_Detail");

                    b.Navigation("Inventory");

                    b.Navigation("Order_Detail");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Importation", b =>
                {
                    b.Navigation("BookingRequests");

                    b.Navigation("ImportationDetails");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BookStoreAPI.Core.Model.User", b =>
                {
                    b.Navigation("Importation");

                    b.Navigation("Inventory");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
