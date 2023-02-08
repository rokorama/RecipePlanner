﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipePlanner.Server.Data;

#nullable disable

namespace RecipePlanner.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecipePlanner.Shared.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UploadedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Vegan")
                        .HasColumnType("bit");

                    b.Property<bool>("Vegetarian")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Recipe");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"),
                            DateCreated = new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "A simple dish made only with leftover rice and an egg. Feel free to add any other ingredients like vegetables or meat.",
                            Name = "Egg fried rice",
                            UploadedBy = new Guid("9841dbcf-02a4-4be6-9545-35aff7db9c7b"),
                            Vegan = false,
                            Vegetarian = true
                        });
                });

            modelBuilder.Entity("RecipePlanner.Shared.RecipeIngredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Measurement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Optional")
                        .HasColumnType("bit");

                    b.Property<string>("Preparation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<Guid?>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredient");

                    b.HasData(
                        new
                        {
                            Id = new Guid("68698fb1-da0e-4058-9295-4b3d949e55e9"),
                            Measurement = "cup",
                            Name = "Rice",
                            Optional = false,
                            Preparation = "cooked",
                            Quantity = 1.0
                        },
                        new
                        {
                            Id = new Guid("97065633-14b7-457f-8f2e-ea31d2f78d8d"),
                            Measurement = "cup",
                            Name = "Egg",
                            Optional = false,
                            Quantity = 1.0
                        },
                        new
                        {
                            Id = new Guid("d365c0be-30ca-4a23-b876-b9e51da0b29e"),
                            Measurement = "tbsp",
                            Name = "Soy sauce",
                            Optional = false,
                            Quantity = 1.0
                        },
                        new
                        {
                            Id = new Guid("4516d7ed-0926-418f-9df7-a1a2f1855999"),
                            Measurement = "clove",
                            Name = "Garlic",
                            Optional = false,
                            Preparation = "minced",
                            Quantity = 1.0
                        },
                        new
                        {
                            Id = new Guid("1094e6b3-0ead-4783-a647-ea85a1ce7ceb"),
                            Measurement = "handful",
                            Name = "Frozen green peas",
                            Optional = true,
                            Quantity = 2.0
                        });
                });

            modelBuilder.Entity("RecipePlanner.Shared.RecipeStep", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<bool>("Optional")
                        .HasColumnType("bit");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeStep");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75325287-47b8-42d1-ad74-11f0b614522c"),
                            Content = "Heat a pan with some oil on medium-high heat",
                            Index = 0,
                            Optional = false,
                            RecipeId = new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651")
                        },
                        new
                        {
                            Id = new Guid("637bf9fc-3b13-4baf-b5d7-5ba8f9943c30"),
                            Content = "Crack in the egg and scramble vigorously to break it up into small chunks",
                            Index = 1,
                            Optional = false,
                            RecipeId = new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651")
                        },
                        new
                        {
                            Id = new Guid("de2b4f9b-681d-40c5-8d31-951e527c5fdf"),
                            Content = "Add the garlic and cook until fragrant",
                            Index = 2,
                            Optional = false,
                            RecipeId = new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651")
                        },
                        new
                        {
                            Id = new Guid("43e87089-2be8-48c2-bb63-48512a778b77"),
                            Content = "Dump in the rice and start breaking the clumps into individual grains",
                            Index = 3,
                            Optional = false,
                            RecipeId = new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651")
                        },
                        new
                        {
                            Id = new Guid("beef6720-d0c3-4bc0-9ab5-626bed117797"),
                            Content = "Once the rice is heated through and slightly toasty, add the soy sauce and mix throughout",
                            Index = 4,
                            Optional = false,
                            RecipeId = new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651")
                        },
                        new
                        {
                            Id = new Guid("fa1c36e4-d7c7-43aa-af82-2e5584662f5f"),
                            Content = "Add in any additional ingredients such as frozen peas and let them heat through",
                            Index = 5,
                            Optional = true,
                            RecipeId = new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651")
                        },
                        new
                        {
                            Id = new Guid("1a8d836e-db09-4a2c-8d1d-361a6ef73dda"),
                            Content = "Add in any additional ingredients such as frozen peas and let them heat through",
                            Index = 5,
                            Optional = true,
                            RecipeId = new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651")
                        });
                });

            modelBuilder.Entity("RecipePlanner.Shared.RecipeIngredient", b =>
                {
                    b.HasOne("RecipePlanner.Shared.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("RecipePlanner.Shared.RecipeStep", b =>
                {
                    b.HasOne("RecipePlanner.Shared.Recipe", "Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipePlanner.Shared.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}
