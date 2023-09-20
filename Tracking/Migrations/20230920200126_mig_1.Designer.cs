﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Tracking.Migrations
{
    [DbContext(typeof(ETicaretContext))]
    [Migration("20230920200126_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kitap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KitapAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SayfaSayisi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Kitaplar");
                });

            modelBuilder.Entity("KitapYazar", b =>
                {
                    b.Property<int>("KitaplarId")
                        .HasColumnType("int");

                    b.Property<int>("YazarlarId")
                        .HasColumnType("int");

                    b.HasKey("KitaplarId", "YazarlarId");

                    b.HasIndex("YazarlarId");

                    b.ToTable("KitapYazar");
                });

            modelBuilder.Entity("Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("KullaniciRol", b =>
                {
                    b.Property<int>("KullanicilarId")
                        .HasColumnType("int");

                    b.Property<int>("RollerId")
                        .HasColumnType("int");

                    b.HasKey("KullanicilarId", "RollerId");

                    b.HasIndex("RollerId");

                    b.ToTable("KullaniciRol");
                });

            modelBuilder.Entity("Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RolAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roller");
                });

            modelBuilder.Entity("Yazar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("YazarAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Yazarlar");
                });

            modelBuilder.Entity("KitapYazar", b =>
                {
                    b.HasOne("Kitap", null)
                        .WithMany()
                        .HasForeignKey("KitaplarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yazar", null)
                        .WithMany()
                        .HasForeignKey("YazarlarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KullaniciRol", b =>
                {
                    b.HasOne("Kullanici", null)
                        .WithMany()
                        .HasForeignKey("KullanicilarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rol", null)
                        .WithMany()
                        .HasForeignKey("RollerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
