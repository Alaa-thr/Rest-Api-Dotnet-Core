﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rest_api_dotnet_core.Data;

namespace rest_api_dotnet_core.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("rest_api_dotnet_core.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6d572d81-a649-4fc1-84ec-f43a9cdcbca1"),
                            CreatedAt = new DateTime(2022, 11, 17, 14, 1, 42, 754, DateTimeKind.Local).AddTicks(5806),
                            Text = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page"
                        },
                        new
                        {
                            Id = new Guid("8c562f81-0360-4ddf-8c95-0088d2e4dcef"),
                            CreatedAt = new DateTime(2022, 11, 17, 14, 1, 42, 758, DateTimeKind.Local).AddTicks(6210),
                            Text = "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
