﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamMaker_WebApp.Data;

#nullable disable

namespace TeamMaker_WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TeamMaker_WebApp.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            Number = 19,
                            PlayerName = "Mark Himel",
                            Position = "Defender"
                        },
                        new
                        {
                            PlayerId = 2,
                            Number = 20,
                            PlayerName = "Clamat",
                            Position = "Forward"
                        },
                        new
                        {
                            PlayerId = 3,
                            Number = 30,
                            PlayerName = "Nipun",
                            Position = "Defender"
                        },
                        new
                        {
                            PlayerId = 4,
                            Number = 17,
                            PlayerName = "AlexRH",
                            Position = "Forward"
                        },
                        new
                        {
                            PlayerId = 5,
                            Number = 27,
                            PlayerName = "Ronald",
                            Position = "Forward"
                        },
                        new
                        {
                            PlayerId = 6,
                            Number = 11,
                            PlayerName = "Protik",
                            Position = "Midfielder"
                        },
                        new
                        {
                            PlayerId = 7,
                            Number = 9,
                            PlayerName = "Dhrubo",
                            Position = "Forward"
                        },
                        new
                        {
                            PlayerId = 8,
                            Number = 14,
                            PlayerName = "Chris",
                            Position = "Forward"
                        },
                        new
                        {
                            PlayerId = 9,
                            Number = 26,
                            PlayerName = "JWH (Joy Da)",
                            Position = "Midfielder"
                        },
                        new
                        {
                            PlayerId = 10,
                            Number = 7,
                            PlayerName = "O.T. Roy",
                            Position = "Midfielder"
                        },
                        new
                        {
                            PlayerId = 11,
                            Number = 1,
                            PlayerName = "Stanley",
                            Position = "Goalkeeper"
                        },
                        new
                        {
                            PlayerId = 12,
                            Number = 18,
                            PlayerName = "Hriday",
                            Position = "Goalkeeper"
                        },
                        new
                        {
                            PlayerId = 13,
                            Number = 43,
                            PlayerName = "Tanay D.TH",
                            Position = "Defender"
                        },
                        new
                        {
                            PlayerId = 14,
                            Number = 6,
                            PlayerName = "Mithun",
                            Position = "Forward"
                        },
                        new
                        {
                            PlayerId = 15,
                            Number = 10,
                            PlayerName = "Edward",
                            Position = "Midfielder"
                        });
                });

            modelBuilder.Entity("TeamMaker_WebApp.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TeamMaker_WebApp.Models.Player", b =>
                {
                    b.HasOne("TeamMaker_WebApp.Models.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("TeamMaker_WebApp.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
