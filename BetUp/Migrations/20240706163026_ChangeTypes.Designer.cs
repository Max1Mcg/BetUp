﻿// <auto-generated />
using System;
using BetUp.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BetUp.Migrations
{
    [DbContext(typeof(BetUpContext))]
    [Migration("20240706163026_ChangeTypes")]
    partial class ChangeTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BetUp.DbModels.BK", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BKs");
                });

            modelBuilder.Entity("BetUp.DbModels.BKMatch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ForeignId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LocalMatchId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("Player1Odds")
                        .HasColumnType("double precision");

                    b.Property<double?>("Player2Odds")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("LocalMatchId");

                    b.ToTable("BKMatches");
                });

            modelBuilder.Entity("BetUp.DbModels.BKTeam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BkId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ForeignTeamId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BkId");

                    b.ToTable("BKTeams");
                });

            modelBuilder.Entity("BetUp.DbModels.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LocalTeam1Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocalTeam2Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("Player1Odds")
                        .HasColumnType("double precision");

                    b.Property<double?>("Player2Odds")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("LocalTeam1Id");

                    b.HasIndex("LocalTeam2Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BetUp.DbModels.MatchMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BKMatchId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MatchId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BKMatchId");

                    b.HasIndex("MatchId");

                    b.ToTable("MatchMapping");
                });

            modelBuilder.Entity("BetUp.DbModels.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("BetUp.DbModels.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BetUp.DbModels.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("BetUp.DbModels.TeamMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BKTeamId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("BKTeamId", "TeamId")
                        .IsUnique();

                    b.ToTable("TeamMapping");
                });

            modelBuilder.Entity("BetUp.DbModels.BKMatch", b =>
                {
                    b.HasOne("BetUp.DbModels.Match", "LocalMatch")
                        .WithMany()
                        .HasForeignKey("LocalMatchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LocalMatch");
                });

            modelBuilder.Entity("BetUp.DbModels.BKTeam", b =>
                {
                    b.HasOne("BetUp.DbModels.BK", "Bk")
                        .WithMany()
                        .HasForeignKey("BkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bk");
                });

            modelBuilder.Entity("BetUp.DbModels.Match", b =>
                {
                    b.HasOne("BetUp.DbModels.Team", "LocalTeam1")
                        .WithMany()
                        .HasForeignKey("LocalTeam1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BetUp.DbModels.Team", "LocalTeam2")
                        .WithMany()
                        .HasForeignKey("LocalTeam2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LocalTeam1");

                    b.Navigation("LocalTeam2");
                });

            modelBuilder.Entity("BetUp.DbModels.MatchMapping", b =>
                {
                    b.HasOne("BetUp.DbModels.BKMatch", "BKMatch")
                        .WithMany()
                        .HasForeignKey("BKMatchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BetUp.DbModels.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BKMatch");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("BetUp.DbModels.TeamMapping", b =>
                {
                    b.HasOne("BetUp.DbModels.BKTeam", "BKTeam")
                        .WithMany()
                        .HasForeignKey("BKTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BetUp.DbModels.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BKTeam");

                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
