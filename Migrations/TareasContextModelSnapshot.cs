﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReplicandoAPI.Context;

#nullable disable

namespace ReplicandoAPI.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReplicandoAPI.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("20769474-d3b8-44c4-a55d-8f22d45e085e"),
                            Nombre = "Personales",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("34dcc8e6-3f78-4d7c-bb7a-a0210dec424d"),
                            Nombre = "Laborales",
                            Peso = 20
                        });
                });

            modelBuilder.Entity("ReplicandoAPI.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int");

                    b.Property<Guid>("categoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TareId");

                    b.HasIndex("categoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareId = new Guid("71c3ac95-768d-4d95-bff8-e523f2a37210"),
                            FechaCreacion = new DateTime(2023, 9, 12, 13, 44, 50, 544, DateTimeKind.Local).AddTicks(3198),
                            Nombre = "Ir GYM",
                            Prioridad = 0,
                            categoriaId = new Guid("20769474-d3b8-44c4-a55d-8f22d45e085e")
                        },
                        new
                        {
                            TareId = new Guid("71c3ac95-768d-4d95-bff8-e523f2a37211"),
                            FechaCreacion = new DateTime(2023, 9, 12, 13, 44, 50, 544, DateTimeKind.Local).AddTicks(3220),
                            Nombre = "Presentar API",
                            Prioridad = 2,
                            categoriaId = new Guid("34dcc8e6-3f78-4d7c-bb7a-a0210dec424d")
                        });
                });

            modelBuilder.Entity("ReplicandoAPI.Models.Tarea", b =>
                {
                    b.HasOne("ReplicandoAPI.Models.Categoria", "Categoria")
                        .WithMany("Tarea")
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ReplicandoAPI.Models.Categoria", b =>
                {
                    b.Navigation("Tarea");
                });
#pragma warning restore 612, 618
        }
    }
}
