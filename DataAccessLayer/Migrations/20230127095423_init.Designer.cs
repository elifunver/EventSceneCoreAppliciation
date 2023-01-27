﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230127095423_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Admin", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("adminId"));

                    b.Property<string>("adminAd")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("adminMail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("adminSifre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("adminTur")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("silindi")
                        .HasColumnType("bit");

                    b.HasKey("adminId");

                    b.ToTable("adminler");
                });

            modelBuilder.Entity("EntityLayer.Bilet", b =>
                {
                    b.Property<int>("biletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("biletId"));

                    b.Property<DateTime>("biletKesimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<double>("fiyat")
                        .HasColumnType("float");

                    b.Property<int>("kullaniciId")
                        .HasColumnType("int");

                    b.Property<bool>("odemeTipi")
                        .HasColumnType("bit");

                    b.Property<int>("seansId")
                        .HasColumnType("int");

                    b.Property<string>("seriNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("seyirciAd")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("seyirciSoyad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("seyirciTc")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("seyirciTur")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("silindi")
                        .HasColumnType("bit");

                    b.HasKey("biletId");

                    b.HasIndex("kullaniciId");

                    b.HasIndex("seansId");

                    b.ToTable("biletler");
                });

            modelBuilder.Entity("EntityLayer.Etkinlik", b =>
                {
                    b.Property<int>("etkinlikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("etkinlikId"));

                    b.Property<string>("aciklama")
                        .IsRequired()
                        .HasMaxLength(6000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("etkinlikAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("etkinlikAfis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("silindi")
                        .HasColumnType("bit");

                    b.Property<int>("turId")
                        .HasColumnType("int");

                    b.HasKey("etkinlikId");

                    b.HasIndex("turId");

                    b.ToTable("etkinlikler");
                });

            modelBuilder.Entity("EntityLayer.Kullanici", b =>
                {
                    b.Property<int>("kullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("kullaniciId"));

                    b.Property<DateTime>("dogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("kullaniciAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("kullaniciMail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("kullaniciSifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("kullaniciTc")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("kullaniciTel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("silindi")
                        .HasColumnType("bit");

                    b.HasKey("kullaniciId");

                    b.ToTable("kullanicilar");
                });

            modelBuilder.Entity("EntityLayer.Menu", b =>
                {
                    b.Property<int>("menuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("menuId"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("parentId")
                        .HasColumnType("int");

                    b.Property<string>("seoUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("silindi")
                        .HasColumnType("bit");

                    b.HasKey("menuId");

                    b.HasIndex("parentId");

                    b.ToTable("menuler");
                });

            modelBuilder.Entity("EntityLayer.Salon", b =>
                {
                    b.Property<int>("salonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("salonId"));

                    b.Property<int>("kapasite")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("salonAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("silindi")
                        .HasColumnType("bit");

                    b.HasKey("salonId");

                    b.ToTable("salonlar");
                });

            modelBuilder.Entity("EntityLayer.Seans", b =>
                {
                    b.Property<int>("seansId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("seansId"));

                    b.Property<int>("etkinlikId")
                        .HasColumnType("int");

                    b.Property<string>("saat")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("salonId")
                        .HasColumnType("int");

                    b.Property<bool>("silindi")
                        .HasColumnType("bit");

                    b.Property<string>("sure")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("tarih")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.HasKey("seansId");

                    b.HasIndex("etkinlikId");

                    b.HasIndex("salonId");

                    b.ToTable("seanslar");
                });

            modelBuilder.Entity("EntityLayer.Slider", b =>
                {
                    b.Property<int>("sliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sliderId"));

                    b.Property<string>("resimUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("silindi")
                        .HasColumnType("bit");

                    b.Property<string>("sliderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("sliderId");

                    b.ToTable("slider");
                });

            modelBuilder.Entity("EntityLayer.Tur", b =>
                {
                    b.Property<int>("turId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("turId"));

                    b.Property<bool>("silindi")
                        .HasColumnType("bit");

                    b.Property<string>("turAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("turId");

                    b.ToTable("turler");
                });

            modelBuilder.Entity("EntityLayer.Bilet", b =>
                {
                    b.HasOne("EntityLayer.Kullanici", "kullanici")
                        .WithMany("biletler")
                        .HasForeignKey("kullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Seans", "seans")
                        .WithMany("biletler")
                        .HasForeignKey("seansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kullanici");

                    b.Navigation("seans");
                });

            modelBuilder.Entity("EntityLayer.Etkinlik", b =>
                {
                    b.HasOne("EntityLayer.Tur", "tur")
                        .WithMany("etkinlikler")
                        .HasForeignKey("turId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tur");
                });

            modelBuilder.Entity("EntityLayer.Menu", b =>
                {
                    b.HasOne("EntityLayer.Menu", "parent")
                        .WithMany("children")
                        .HasForeignKey("parentId");

                    b.Navigation("parent");
                });

            modelBuilder.Entity("EntityLayer.Seans", b =>
                {
                    b.HasOne("EntityLayer.Etkinlik", "etkinlik")
                        .WithMany("seanslar")
                        .HasForeignKey("etkinlikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Salon", "salon")
                        .WithMany("seanslar")
                        .HasForeignKey("salonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("etkinlik");

                    b.Navigation("salon");
                });

            modelBuilder.Entity("EntityLayer.Etkinlik", b =>
                {
                    b.Navigation("seanslar");
                });

            modelBuilder.Entity("EntityLayer.Kullanici", b =>
                {
                    b.Navigation("biletler");
                });

            modelBuilder.Entity("EntityLayer.Menu", b =>
                {
                    b.Navigation("children");
                });

            modelBuilder.Entity("EntityLayer.Salon", b =>
                {
                    b.Navigation("seanslar");
                });

            modelBuilder.Entity("EntityLayer.Seans", b =>
                {
                    b.Navigation("biletler");
                });

            modelBuilder.Entity("EntityLayer.Tur", b =>
                {
                    b.Navigation("etkinlikler");
                });
#pragma warning restore 612, 618
        }
    }
}
