﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Week8Project.Data;

namespace Week8Project.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    [Migration("20171102172708_addList")]
    partial class addList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Week8Project.Models.Pokemon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Species");

                    b.Property<string>("Type");

                    b.Property<int?>("TypeListID");

                    b.HasKey("ID");

                    b.HasIndex("TypeListID");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("Week8Project.Models.TypeList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("TypeList");
                });

            modelBuilder.Entity("Week8Project.Models.Pokemon", b =>
                {
                    b.HasOne("Week8Project.Models.TypeList")
                        .WithMany("Members")
                        .HasForeignKey("TypeListID");
                });
#pragma warning restore 612, 618
        }
    }
}
