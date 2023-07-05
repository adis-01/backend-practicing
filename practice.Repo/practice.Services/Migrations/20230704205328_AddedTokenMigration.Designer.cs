﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using practice.Services.Data;

#nullable disable

namespace practice.Services.Migrations
{
    [DbContext(typeof(PracticeContext))]
    [Migration("20230704205328_AddedTokenMigration")]
    partial class AddedTokenMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("practice.Services.Database.Korisnici", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LozinkaHash")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaSalt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VerifikacijskiToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("KorisnikId")
                        .HasName("PK__Korisnic__80B06D61817E0769");

                    b.ToTable("Korisnici", (string)null);
                });

            modelBuilder.Entity("practice.Services.Database.KorisniciUloge", b =>
                {
                    b.Property<int>("KorisnikUlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KorisnikUlogaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikUlogaId"));

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<int?>("UlogaId")
                        .HasColumnType("int")
                        .HasColumnName("UlogaID");

                    b.HasKey("KorisnikUlogaId")
                        .HasName("PK__Korisnic__1608720E772A604A");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("UlogaId");

                    b.ToTable("KorisniciUloge", (string)null);
                });

            modelBuilder.Entity("practice.Services.Database.Price", b =>
                {
                    b.Property<int>("PricaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PricaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PricaId"));

                    b.Property<bool>("Aktivna")
                        .HasColumnType("bit");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("NovcaniCilj")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PricaId")
                        .HasName("PK__Price__4A47B94CD4261BC9");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Price", (string)null);
                });

            modelBuilder.Entity("practice.Services.Database.Uloge", b =>
                {
                    b.Property<int>("UlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UlogaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UlogaId"));

                    b.Property<string>("NazivUloge")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OpisUloge")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UlogaId")
                        .HasName("PK__Uloge__DCAB23EBE0E99440");

                    b.ToTable("Uloge", (string)null);
                });

            modelBuilder.Entity("practice.Services.Database.KorisniciUloge", b =>
                {
                    b.HasOne("practice.Services.Database.Korisnici", "Korisnik")
                        .WithMany("KorisniciUloges")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK__Korisnici__Koris__286302EC");

                    b.HasOne("practice.Services.Database.Uloge", "Uloga")
                        .WithMany("KorisniciUloges")
                        .HasForeignKey("UlogaId")
                        .HasConstraintName("FK__Korisnici__Uloga__29572725");

                    b.Navigation("Korisnik");

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("practice.Services.Database.Price", b =>
                {
                    b.HasOne("practice.Services.Database.Korisnici", "Korisnik")
                        .WithMany("Prices")
                        .HasForeignKey("KorisnikId")
                        .IsRequired()
                        .HasConstraintName("FK__Price__KorisnikI__36B12243");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("practice.Services.Database.Korisnici", b =>
                {
                    b.Navigation("KorisniciUloges");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("practice.Services.Database.Uloge", b =>
                {
                    b.Navigation("KorisniciUloges");
                });
#pragma warning restore 612, 618
        }
    }
}