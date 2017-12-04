﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ResidentCare.Models;
using System;

namespace ResidentCare.Migrations
{
    [DbContext(typeof(ResidentContext))]
    partial class ResidentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ResidentCare.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ResidentId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.HasKey("NoteId");

                    b.HasIndex("ResidentId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("ResidentCare.Models.Resident", b =>
                {
                    b.Property<int>("ResidentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Allergies")
                        .HasMaxLength(5000);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MedicalRequirements")
                        .HasMaxLength(5000);

                    b.HasKey("ResidentId");

                    b.ToTable("Resident");
                });

            modelBuilder.Entity("ResidentCare.Models.Note", b =>
                {
                    b.HasOne("ResidentCare.Models.Resident", "Resident")
                        .WithMany("Notes")
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
