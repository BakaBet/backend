﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BakaBack.Migrations
{
    [DbContext(typeof(SportsDbContext))]
    partial class SportsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("BakaBack.Models.Bookmaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MatchId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Bookmakers");
                });

            modelBuilder.Entity("BakaBack.Models.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookmakerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookmakerId");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("BakaBack.Models.Match", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AwayTeam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CommenceTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeTeam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SportKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BakaBack.Models.Outcome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MarketId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MarketId");

                    b.ToTable("Outcomes");
                });

            modelBuilder.Entity("BakaBack.Models.Bookmaker", b =>
                {
                    b.HasOne("BakaBack.Models.Match", "Match")
                        .WithMany("Bookmakers")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("BakaBack.Models.Market", b =>
                {
                    b.HasOne("BakaBack.Models.Bookmaker", "Bookmaker")
                        .WithMany("Markets")
                        .HasForeignKey("BookmakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bookmaker");
                });

            modelBuilder.Entity("BakaBack.Models.Outcome", b =>
                {
                    b.HasOne("BakaBack.Models.Market", "Market")
                        .WithMany("Outcomes")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Market");
                });

            modelBuilder.Entity("BakaBack.Models.Bookmaker", b =>
                {
                    b.Navigation("Markets");
                });

            modelBuilder.Entity("BakaBack.Models.Market", b =>
                {
                    b.Navigation("Outcomes");
                });

            modelBuilder.Entity("BakaBack.Models.Match", b =>
                {
                    b.Navigation("Bookmakers");
                });
#pragma warning restore 612, 618
        }
    }
}
