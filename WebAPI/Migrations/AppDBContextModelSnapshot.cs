﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace WebAPI.Migrations {
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot {
        protected override void BuildModel(ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("DeadLine");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<bool>("Status");

                    b.Property<int?>("ToDoListId");

                    b.HasKey("Id");

                    b.HasIndex("ToDoListId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("WebAPI.Entities.ToDoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Name");

                    b.Property<string>("UserInfoEmail");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoEmail");

                    b.ToTable("ToDoList");
                });

            modelBuilder.Entity("WebAPI.Entities.UserInfo", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.HasKey("Email");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("WebAPI.Entities.Item", b =>
                {
                    b.HasOne("WebAPI.Entities.ToDoList")
                        .WithMany("Items")
                        .HasForeignKey("ToDoListId");
                });

            modelBuilder.Entity("WebAPI.Entities.ToDoList", b =>
                {
                    b.HasOne("WebAPI.Entities.UserInfo")
                        .WithMany("ToDoLists")
                        .HasForeignKey("UserInfoEmail");
                });
#pragma warning restore 612, 618
        }
    }
}
