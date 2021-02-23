﻿// <auto-generated />
using MVCore.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCore.Migrations
{
    [DbContext(typeof(PatientDal))]
    [Migration("20200712135808_ver572020")]
    partial class ver572020
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCore.Models.PatientModel", b =>
                {
                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PatientName");

                    b.ToTable("tblPatient");
                });

            modelBuilder.Entity("MVCore.Models.Problem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientProblem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("PatientName");

                    b.ToTable("tblProblem");
                });

            modelBuilder.Entity("MVCore.Models.Problem", b =>
                {
                    b.HasOne("MVCore.Models.PatientModel", "Patient")
                        .WithMany("Problems")
                        .HasForeignKey("PatientName");
                });
#pragma warning restore 612, 618
        }
    }
}