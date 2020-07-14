﻿// <auto-generated />
using System;
using MMFI_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MMFI_Data.Migrations.RecipeDb
{
    [DbContext(typeof(RecipeDbContext))]
    partial class RecipeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MMFI_Entites.Models.Ingridient", b =>
                {
                    b.Property<int>("IngridientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IngridientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("IngridientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingridient");
                });

            modelBuilder.Entity("MMFI_Entites.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RecipeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeTime")
                        .HasColumnType("int");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("MMFI_Entites.Models.Ingridient", b =>
                {
                    b.HasOne("MMFI_Entites.Models.Recipe", null)
                        .WithMany("Ingridients")
                        .HasForeignKey("RecipeId");
                });
#pragma warning restore 612, 618
        }
    }
}
