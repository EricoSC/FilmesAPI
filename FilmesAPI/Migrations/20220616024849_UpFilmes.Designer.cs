﻿// <auto-generated />
using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FilmesAPI.Migrations
{
    [DbContext(typeof(FilmeContext))]
    [Migration("20220616024849_UpFilmes")]
    partial class UpFilmes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FilmesAPI.Model.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DuracaoMin")
                        .HasColumnType("integer");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}