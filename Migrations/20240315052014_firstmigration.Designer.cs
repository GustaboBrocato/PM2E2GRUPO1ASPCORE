﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PM2E2GRUPO1ASPCORE.Data;

#nullable disable

namespace PM2E2GRUPO1ASPCORE.Migrations
{
    [DbContext(typeof(SitiosDB))]
    [Migration("20240315052014_firstmigration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PM2E2GRUPO1ASPCORE.Models.Sitio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AudioFile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Latitud")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitud")
                        .HasColumnType("double precision");

                    b.Property<string>("VideoDigital")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sitios");
                });
#pragma warning restore 612, 618
        }
    }
}
