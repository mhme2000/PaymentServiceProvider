﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PaymentServiceProvider.Infrastructure.Contexts;

#nullable disable

namespace PaymentServiceProvider.Infrastructure.Migrations
{
    [DbContext(typeof(TransactionContext))]
    partial class TransactionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PaymentServiceProvider.Domain.Entities.Payable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<double>("Fee")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("Payable");
                });

            modelBuilder.Entity("PaymentServiceProvider.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("CardCvv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CardExpireDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("NumberOfInstallments")
                        .HasColumnType("bigint");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("PaymentServiceProvider.Domain.Entities.Payable", b =>
                {
                    b.HasOne("PaymentServiceProvider.Domain.Entities.Transaction", "Transaction")
                        .WithMany("Payables")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("PaymentServiceProvider.Domain.Entities.Transaction", b =>
                {
                    b.Navigation("Payables");
                });
#pragma warning restore 612, 618
        }
    }
}
