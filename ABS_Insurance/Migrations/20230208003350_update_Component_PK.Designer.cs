﻿// <auto-generated />
using ABS_Insurance.Data.AppDBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ABSInsurance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230208003350_update_Component_PK")]
    partial class updateComponentPK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ABS_Insurance.Model.Components", b =>
                {
                    b.Property<int>("ComponentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ComponentsId"));

                    b.Property<double>("FlatValue")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Operation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PercentageValue")
                        .HasColumnType("integer");

                    b.Property<int>("Pol_Id")
                        .HasColumnType("integer");

                    b.Property<int>("Sequence")
                        .HasColumnType("integer");

                    b.HasKey("ComponentsId");

                    b.HasIndex("Pol_Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("ABS_Insurance.Model.Policy", b =>
                {
                    b.Property<int>("PolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PolicyId"));

                    b.Property<string>("PolicyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PolicyId");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("ABS_Insurance.Model.Components", b =>
                {
                    b.HasOne("ABS_Insurance.Model.Policy", "Policy")
                        .WithMany("ComponentsList")
                        .HasForeignKey("Pol_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("ABS_Insurance.Model.Policy", b =>
                {
                    b.Navigation("ComponentsList");
                });
#pragma warning restore 612, 618
        }
    }
}
