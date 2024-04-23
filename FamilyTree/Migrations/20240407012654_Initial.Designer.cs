﻿// <auto-generated />
using System;
using FamilyTree.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FamilyTree.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240407012654_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FamilyTree.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("FamilyTree.Models.PersonPerson", b =>
                {
                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("ChildId")
                        .HasColumnType("int");

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("PeoplePeople");
                });

            modelBuilder.Entity("FamilyTree.Models.PersonPerson", b =>
                {
                    b.HasOne("FamilyTree.Models.Person", "Child")
                        .WithMany("Parents")
                        .HasForeignKey("ChildId")
                        .IsRequired();

                    b.HasOne("FamilyTree.Models.Person", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("FamilyTree.Models.Person", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Parents");
                });
#pragma warning restore 612, 618
        }
    }
}