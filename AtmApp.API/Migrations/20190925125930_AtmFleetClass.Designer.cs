﻿// <auto-generated />
using System;
using AtmApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AtmApp.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190925125930_AtmFleetClass")]
    partial class AtmFleetClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("AtmApp.API.Models.AtmFleet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BranchCode");

                    b.Property<string>("Brand");

                    b.Property<string>("Gateway");

                    b.Property<string>("Ip");

                    b.Property<string>("Location");

                    b.Property<string>("Region");

                    b.Property<string>("RegionalPersonnel");

                    b.Property<string>("TerminalId");

                    b.Property<string>("TerminalName");

                    b.Property<string>("Vendor");

                    b.HasKey("Id");

                    b.ToTable("AtmFleet");
                });

            modelBuilder.Entity("AtmApp.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AtmApp.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });
#pragma warning restore 612, 618
        }
    }
}