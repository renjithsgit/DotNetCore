﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppCore.Models;

namespace WebAppCore.Migrations
{
    [DbContext(typeof(TestDBContext))]
    [Migration("20200121140213_RemovedEmail")]
    partial class RemovedEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppCore.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .HasColumnName("dept_id")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .HasColumnName("dept_name")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("DeptId")
                        .HasName("PK__Departme__DCA6597455DFCF34");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("WebAppCore.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .HasColumnName("emp_id")
                        .HasColumnType("int");

                    b.Property<int?>("DeptId")
                        .HasColumnName("dept_id")
                        .HasColumnType("int");

                    b.Property<string>("EmpName")
                        .HasColumnName("emp_name")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int?>("MngrId")
                        .HasColumnName("mngr_id")
                        .HasColumnType("int");

                    b.Property<int?>("Salary")
                        .HasColumnName("salary")
                        .HasColumnType("int");

                    b.HasKey("EmpId")
                        .HasName("PK__Employee__1299A86160218078");

                    b.HasIndex("DeptId");

                    b.HasIndex("MngrId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("WebAppCore.Models.Employee", b =>
                {
                    b.HasOne("WebAppCore.Models.Department", "Dept")
                        .WithMany("Employee")
                        .HasForeignKey("DeptId")
                        .HasConstraintName("FK__Employee__dept_i__286302EC");

                    b.HasOne("WebAppCore.Models.Employee", "Mngr")
                        .WithMany("InverseMngr")
                        .HasForeignKey("MngrId")
                        .HasConstraintName("FK__Employee__mngr_i__276EDEB3");
                });
#pragma warning restore 612, 618
        }
    }
}
