﻿// <auto-generated />
using System;
using DreamRosterBuilding.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DreamRosterBuilding.Data.Migrations
{
    [DbContext(typeof(DreamRosterBuildingDbContext))]
    [Migration("20241028164823_AddingTeamAndPlayerCreatedUserField")]
    partial class AddingTeamAndPlayerCreatedUserField
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.FlagEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Flags");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.IconEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Icons");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.LeagueEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NationId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.NationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlagId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FlagId")
                        .IsUnique();

                    b.ToTable("Nations");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.PlayerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HairColor")
                        .HasColumnType("int");

                    b.Property<int>("IconId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NationId")
                        .HasColumnType("int");

                    b.Property<int>("Skin")
                        .HasColumnType("int");

                    b.Property<int?>("Tattoo")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IconId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("NationId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.PlayerPositionEntity", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PlayerId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("PlayerPositions");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.PlayerSkillEntity", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PlayerId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("PlayerSkills");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.PositionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.SkillEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.TeamEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IconId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IconId")
                        .IsUnique();

                    b.HasIndex("LeagueId");

                    b.HasIndex("NationId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserEntity");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.LeagueEntity", b =>
                {
                    b.HasOne("DreamRosterBuilding.Data.Entities.NationEntity", "Nation")
                        .WithMany("Leagues")
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nation");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.NationEntity", b =>
                {
                    b.HasOne("DreamRosterBuilding.Data.Entities.FlagEntity", "Flag")
                        .WithOne("Nation")
                        .HasForeignKey("DreamRosterBuilding.Data.Entities.NationEntity", "FlagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flag");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.PlayerEntity", b =>
                {
                    b.HasOne("DreamRosterBuilding.Data.Entities.IconEntity", "Icon")
                        .WithMany("Players")
                        .HasForeignKey("IconId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DreamRosterBuilding.Data.Entities.LeagueEntity", "League")
                        .WithMany("Players")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DreamRosterBuilding.Data.Entities.NationEntity", "Nation")
                        .WithMany("Players")
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DreamRosterBuilding.Data.Entities.TeamEntity", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Icon");

                    b.Navigation("League");

                    b.Navigation("Nation");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.PlayerPositionEntity", b =>
                {
                    b.HasOne("DreamRosterBuilding.Data.Entities.PlayerEntity", "Player")
                        .WithMany("PlayerPositions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DreamRosterBuilding.Data.Entities.PositionEntity", "Position")
                        .WithMany("PlayerPositions")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.PlayerSkillEntity", b =>
                {
                    b.HasOne("DreamRosterBuilding.Data.Entities.PlayerEntity", "Player")
                        .WithMany("PlayerSkills")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DreamRosterBuilding.Data.Entities.SkillEntity", "Skill")
                        .WithMany("PlayerSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.TeamEntity", b =>
                {
                    b.HasOne("DreamRosterBuilding.Data.Entities.IconEntity", "Icon")
                        .WithOne("Team")
                        .HasForeignKey("DreamRosterBuilding.Data.Entities.TeamEntity", "IconId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DreamRosterBuilding.Data.Entities.LeagueEntity", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DreamRosterBuilding.Data.Entities.NationEntity", "Nation")
                        .WithMany("Teams")
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Icon");

                    b.Navigation("League");

                    b.Navigation("Nation");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.FlagEntity", b =>
                {
                    b.Navigation("Nation")
                        .IsRequired();
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.IconEntity", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("Team")
                        .IsRequired();
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.LeagueEntity", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.NationEntity", b =>
                {
                    b.Navigation("Leagues");

                    b.Navigation("Players");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.PlayerEntity", b =>
                {
                    b.Navigation("PlayerPositions");

                    b.Navigation("PlayerSkills");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.PositionEntity", b =>
                {
                    b.Navigation("PlayerPositions");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.SkillEntity", b =>
                {
                    b.Navigation("PlayerSkills");
                });

            modelBuilder.Entity("DreamRosterBuilding.Data.Entities.TeamEntity", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
