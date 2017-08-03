﻿// <auto-generated />
using EthanCommunion.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EthanCommunion.API.Migrations
{
    [DbContext(typeof(StarsContext))]
    [Migration("20170803011540_EthanCommunionDBAddingColumnAccept")]
    partial class EthanCommunionDBAddingColumnAccept
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview2-25794")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EthanCommunion.API.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("Country");

                    b.Property<string>("Postcode");

                    b.Property<int>("StarId");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.HasIndex("StarId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("EthanCommunion.API.Entities.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Accepted");

                    b.Property<DateTime>("AcceptedDate");

                    b.Property<int>("NumberOfAdultsAttending");

                    b.Property<int>("NumberOfChildrenAttending");

                    b.Property<int>("NumberOfInfantsAttending");

                    b.Property<int>("StarId");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.HasIndex("StarId");

                    b.ToTable("Invitation");
                });

            modelBuilder.Entity("EthanCommunion.API.Entities.Star", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Accept");

                    b.Property<int>("Adults");

                    b.Property<int>("Children");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Infants");

                    b.Property<string>("LastName");

                    b.Property<string>("Mobile");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Star");
                });

            modelBuilder.Entity("EthanCommunion.API.Entities.Address", b =>
                {
                    b.HasOne("EthanCommunion.API.Entities.Star", "Star")
                        .WithMany("Addresses")
                        .HasForeignKey("StarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EthanCommunion.API.Entities.Invitation", b =>
                {
                    b.HasOne("EthanCommunion.API.Entities.Star", "Star")
                        .WithMany()
                        .HasForeignKey("StarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
