﻿// <auto-generated />
using BookShelfMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookShelfMVC.Migrations
{
    [DbContext(typeof(BookShelfMVCContext))]
    [Migration("20171216235429_MadeBookFieldsRequired")]
    partial class MadeBookFieldsRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookShelfMVC.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorFirstName");

                    b.Property<string>("AuthorLastName");

                    b.Property<string>("CallNumber")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Book");
                });
#pragma warning restore 612, 618
        }
    }
}