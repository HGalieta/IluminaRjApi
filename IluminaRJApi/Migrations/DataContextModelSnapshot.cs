﻿// <auto-generated />
using IluminaRJApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IluminaRJApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("IluminaRJApi.Models.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("ArrecadaCip")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("GastoIp")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PontosLed")
                        .HasColumnType("int");

                    b.Property<int>("TotalPontos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Municipios");
                });
#pragma warning restore 612, 618
        }
    }
}