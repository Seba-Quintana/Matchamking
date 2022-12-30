﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(MatchamkingContext))]
    [Migration("20221229064927_MigracionTres")]
    partial class MigracionTres
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("backend.Data.Models.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Goles")
                        .HasColumnType("int");

                    b.Property<int>("PartidoId")
                        .HasColumnType("int");

                    b.Property<bool>("Suplentes")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("backend.Data.Models.Equipo_Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.HasIndex("Nickname");

                    b.ToTable("Equipo_Jugadores");
                });

            modelBuilder.Entity("backend.Data.Models.Jugador", b =>
                {
                    b.Property<string>("Nickname")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Derrotas")
                        .HasColumnType("int");

                    b.Property<float>("Elo")
                        .HasColumnType("float");

                    b.Property<float>("Eloboost")
                        .HasColumnType("float");

                    b.Property<int>("Empates")
                        .HasColumnType("int");

                    b.Property<int>("GolesAFavor")
                        .HasColumnType("int");

                    b.Property<int>("GolesEnContra")
                        .HasColumnType("int");

                    b.Property<int>("Jugados")
                        .HasColumnType("int");

                    b.Property<int>("Racha")
                        .HasColumnType("int");

                    b.Property<bool>("Resaca")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Victorias")
                        .HasColumnType("int");

                    b.Property<int>("WinRate")
                        .HasColumnType("int");

                    b.HasKey("Nickname");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("backend.Data.Models.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cancha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("backend.Data.Models.Equipo", b =>
                {
                    b.HasOne("backend.Data.Models.Partido", "Partido")
                        .WithMany("Equipos")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partido");
                });

            modelBuilder.Entity("backend.Data.Models.Equipo_Jugador", b =>
                {
                    b.HasOne("backend.Data.Models.Equipo", "Equipo")
                        .WithMany("Equipo_Jugadores")
                        .HasForeignKey("EquipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Data.Models.Jugador", "Jugador")
                        .WithMany("Equipo_Jugadores")
                        .HasForeignKey("Nickname")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipo");

                    b.Navigation("Jugador");
                });

            modelBuilder.Entity("backend.Data.Models.Equipo", b =>
                {
                    b.Navigation("Equipo_Jugadores");
                });

            modelBuilder.Entity("backend.Data.Models.Jugador", b =>
                {
                    b.Navigation("Equipo_Jugadores");
                });

            modelBuilder.Entity("backend.Data.Models.Partido", b =>
                {
                    b.Navigation("Equipos");
                });
#pragma warning restore 612, 618
        }
    }
}