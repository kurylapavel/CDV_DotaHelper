﻿// <auto-generated />
using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataModel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220205160246_Added_Table_HeroRatingEnemy")]
    partial class Added_Table_HeroRatingEnemy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DataModel.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<double>("AverageKDA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0);

                    b.Property<string>("HeroName")
                        .HasColumnType("text");

                    b.Property<int>("MatchesCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Hero");
                });

            modelBuilder.Entity("DataModel.Entities.HeroRatingEnemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("EnemyHeroId")
                        .HasColumnType("integer");

                    b.Property<double>("FantasyPoint")
                        .HasColumnType("double precision");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer");

                    b.Property<int>("ParsedMatches")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EnemyHeroId");

                    b.HasIndex("HeroId");

                    b.ToTable("HeroRatingEnemy");
                });

            modelBuilder.Entity("DataModel.Entities.HeroRatingTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<double>("FantasyPoint")
                        .HasColumnType("double precision");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer");

                    b.Property<int>("ParsedMatches")
                        .HasColumnType("integer");

                    b.Property<int>("TeamHeroId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.HasIndex("TeamHeroId");

                    b.ToTable("HeroRatingTeam");
                });

            modelBuilder.Entity("DataModel.Entities.ParsedMatches", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<decimal>("LastParsedMatchId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("ParsedMatchesCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ParsedMatches");
                });

            modelBuilder.Entity("DataModel.Entities.HeroRatingEnemy", b =>
                {
                    b.HasOne("DataModel.Entities.Hero", "TeamHero")
                        .WithMany("EnemyHeroesEnemy")
                        .HasForeignKey("EnemyHeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.Entities.Hero", "Hero")
                        .WithMany("TeamHeroesEnemy")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");

                    b.Navigation("TeamHero");
                });

            modelBuilder.Entity("DataModel.Entities.HeroRatingTeam", b =>
                {
                    b.HasOne("DataModel.Entities.Hero", "Hero")
                        .WithMany("EnemyHeroes")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.Entities.Hero", "TeamHero")
                        .WithMany("TeamHeroes")
                        .HasForeignKey("TeamHeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");

                    b.Navigation("TeamHero");
                });

            modelBuilder.Entity("DataModel.Entities.Hero", b =>
                {
                    b.Navigation("EnemyHeroes");

                    b.Navigation("EnemyHeroesEnemy");

                    b.Navigation("TeamHeroes");

                    b.Navigation("TeamHeroesEnemy");
                });
#pragma warning restore 612, 618
        }
    }
}
