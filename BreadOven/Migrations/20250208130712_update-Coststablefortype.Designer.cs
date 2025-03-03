﻿// <auto-generated />
using BreadOven.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BreadOven.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20250208130712_update-Coststablefortype")]
    partial class updateCoststablefortype
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BreadOven.Models.Costs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("typeOfCosts");
                });

            modelBuilder.Entity("BreadOven.Models.Distrubutionfromitem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("FixedSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalOperatingSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VariableSalary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Distrubutionfromitems");
                });

            modelBuilder.Entity("BreadOven.Models.FactoryLines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FactoryLines");
                });

            modelBuilder.Entity("BreadOven.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("EnergyReq")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperatingHours")
                        .HasColumnType("int");

                    b.Property<int>("factoryLinesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("factoryLinesId");

                    b.ToTable("items");
                });

            modelBuilder.Entity("BreadOven.Models.ProductionLineDepreciation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OriginalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductionAgeYear")
                        .HasColumnType("int");

                    b.Property<string>("ValuePercentage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("valueDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("valueHour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("valueMonth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("valueYear")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ProductionLineDepreciations");
                });

            modelBuilder.Entity("BreadOven.Models.Distrubutionfromitem", b =>
                {
                    b.HasOne("BreadOven.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("BreadOven.Models.Item", b =>
                {
                    b.HasOne("BreadOven.Models.FactoryLines", "FactoryLines")
                        .WithMany()
                        .HasForeignKey("factoryLinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FactoryLines");
                });
#pragma warning restore 612, 618
        }
    }
}
