﻿// <auto-generated />
using System;
using DayanaWeb.Shared.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DayanaWeb.Shared.EntityFramework.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230209070249_migmig")]
    partial class migmig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DayanaWeb.Shared.EntityFramework.Entities.Blog.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<long>("PostCategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("PostCategoryId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PostCategoryId");

                    b.HasIndex("PostCategoryId1");

                    b.ToTable("Post", "dbo");
                });

            modelBuilder.Entity("DayanaWeb.Shared.EntityFramework.Entities.Blog.PostCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("PostCategory", "dbo");
                });

            modelBuilder.Entity("DayanaWeb.Shared.EntityFramework.Entities.Blog.Post", b =>
                {
                    b.HasOne("DayanaWeb.Shared.EntityFramework.Entities.Blog.PostCategory", null)
                        .WithMany("Posts")
                        .HasForeignKey("PostCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DayanaWeb.Shared.EntityFramework.Entities.Blog.PostCategory", "PostCategory")
                        .WithMany()
                        .HasForeignKey("PostCategoryId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostCategory");
                });

            modelBuilder.Entity("DayanaWeb.Shared.EntityFramework.Entities.Blog.PostCategory", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
