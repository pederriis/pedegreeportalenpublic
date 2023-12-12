﻿// <auto-generated />
using System;
using Animal.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Animal.Infrastructure.Migrations
{
    [DbContext(typeof(AnimalDbContext))]
    [Migration("20210416112554_Am")]
    partial class Am
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Animal.Domain.Animal.Animal", b =>
                {
                    b.Property<Guid>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubRaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("AnimalId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("SubRaceId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Animal.Domain.AnimalLitter.AnimalLitter", b =>
                {
                    b.Property<Guid>("AnimalLitterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LitterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AnimalLitterId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("LitterId");

                    b.ToTable("AnimalLitters");
                });

            modelBuilder.Entity("Animal.Domain.ExhibitionTitle.ExhibitionTitle", b =>
                {
                    b.Property<Guid>("ExhibitionTitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExhibitionTitleId");

                    b.HasIndex("AnimalId");

                    b.ToTable("ExhibitionTitles");
                });

            modelBuilder.Entity("Animal.Domain.HealthRecord.HealthRecord", b =>
                {
                    b.Property<Guid>("HealthRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HealthRecordId");

                    b.ToTable("HealthRecords");
                });

            modelBuilder.Entity("Animal.Domain.Human.Human", b =>
                {
                    b.Property<Guid>("HumanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HumanId");

                    b.ToTable("Humans");
                });

            modelBuilder.Entity("Animal.Domain.Litter.Litter", b =>
                {
                    b.Property<Guid>("LitterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BreedById")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LitterId");

                    b.HasIndex("BreedById");

                    b.ToTable("Litters");
                });

            modelBuilder.Entity("Animal.Domain.Race.Race", b =>
                {
                    b.Property<Guid>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RaceId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Animal.Domain.SubRace.SubRace", b =>
                {
                    b.Property<Guid>("SubRaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SubRaceId");

                    b.HasIndex("RaceId");

                    b.ToTable("SubRaces");
                });

            modelBuilder.Entity("Animal.Domain.Animal.Animal", b =>
                {
                    b.HasOne("Animal.Domain.Human.Human", "Owner")
                        .WithMany("Animals")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Animal.Domain.SubRace.SubRace", "SubRace")
                        .WithMany("Animals")
                        .HasForeignKey("SubRaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Animal.Domain.Animal.AnimalId", "Id", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.Animal.BirthDate", "BirthDate", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.Animal.Color", "Color", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.Animal.DeathDate", "DeathDate", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.Animal.Gender", "Gender", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.Animal.IsBreedable", "IsBreedable", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.Animal.PedigreeName", "PedigreeName", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.Animal.ProfileText", "ProfileText", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.Animal.RegNo", "RegNo", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.Animal.ShortName", "ShortName", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.Animal.WeightInKg", "WeightInKg", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.OwnsOne("Animal.Domain.IsDeleted", "IsDeleted", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("AnimalId");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId");
                        });

                    b.Navigation("BirthDate");

                    b.Navigation("Color");

                    b.Navigation("DeathDate");

                    b.Navigation("Gender");

                    b.Navigation("Id");

                    b.Navigation("IsBreedable");

                    b.Navigation("IsDeleted");

                    b.Navigation("Owner");

                    b.Navigation("PedigreeName");

                    b.Navigation("ProfileText");

                    b.Navigation("RegNo");

                    b.Navigation("ShortName");

                    b.Navigation("SubRace");

                    b.Navigation("WeightInKg");
                });

            modelBuilder.Entity("Animal.Domain.AnimalLitter.AnimalLitter", b =>
                {
                    b.HasOne("Animal.Domain.Animal.Animal", "Animal")
                        .WithMany("Litters")
                        .HasForeignKey("AnimalId");

                    b.HasOne("Animal.Domain.Litter.Litter", "Litter")
                        .WithMany("Parrents")
                        .HasForeignKey("LitterId");

                    b.OwnsOne("Animal.Domain.AnimalLitter.AnimalLitterId", "Id", b1 =>
                        {
                            b1.Property<Guid>("AnimalLitterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("AnimalLitterId");

                            b1.ToTable("AnimalLitters");

                            b1.WithOwner()
                                .HasForeignKey("AnimalLitterId");
                        });

                    b.OwnsOne("Animal.Domain.AnimalLitter.IsDeleted", "IsDeleted", b1 =>
                        {
                            b1.Property<Guid>("AnimalLitterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("AnimalLitterId");

                            b1.ToTable("AnimalLitters");

                            b1.WithOwner()
                                .HasForeignKey("AnimalLitterId");
                        });

                    b.Navigation("Animal");

                    b.Navigation("Id");

                    b.Navigation("IsDeleted");

                    b.Navigation("Litter");
                });

            modelBuilder.Entity("Animal.Domain.ExhibitionTitle.ExhibitionTitle", b =>
                {
                    b.HasOne("Animal.Domain.Animal.Animal", "Animal")
                        .WithMany("ExhibitionTitles")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Animal.Domain.ExhibitionTitle.Date", "Date", b1 =>
                        {
                            b1.Property<Guid>("ExhibitionTitleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2");

                            b1.HasKey("ExhibitionTitleId");

                            b1.ToTable("ExhibitionTitles");

                            b1.WithOwner()
                                .HasForeignKey("ExhibitionTitleId");
                        });

                    b.OwnsOne("Animal.Domain.ExhibitionTitle.ExhibitionTitleId", "Id", b1 =>
                        {
                            b1.Property<Guid>("ExhibitionTitleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ExhibitionTitleId");

                            b1.ToTable("ExhibitionTitles");

                            b1.WithOwner()
                                .HasForeignKey("ExhibitionTitleId");
                        });

                    b.OwnsOne("Animal.Domain.ExhibitionTitle.IsDeleted", "IsDeleted", b1 =>
                        {
                            b1.Property<Guid>("ExhibitionTitleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("ExhibitionTitleId");

                            b1.ToTable("ExhibitionTitles");

                            b1.WithOwner()
                                .HasForeignKey("ExhibitionTitleId");
                        });

                    b.OwnsOne("Animal.Domain.ExhibitionTitle.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("ExhibitionTitleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ExhibitionTitleId");

                            b1.ToTable("ExhibitionTitles");

                            b1.WithOwner()
                                .HasForeignKey("ExhibitionTitleId");
                        });

                    b.Navigation("Animal");

                    b.Navigation("Date");

                    b.Navigation("Id");

                    b.Navigation("IsDeleted");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Animal.Domain.HealthRecord.HealthRecord", b =>
                {
                    b.HasOne("Animal.Domain.Animal.Animal", "Animal")
                        .WithOne("HealthRecord")
                        .HasForeignKey("Animal.Domain.HealthRecord.HealthRecord", "HealthRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Animal.Domain.HealthRecord.HealthRecordId", "Id", b1 =>
                        {
                            b1.Property<Guid>("HealthRecordId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("HealthRecordId");

                            b1.ToTable("HealthRecords");

                            b1.WithOwner()
                                .HasForeignKey("HealthRecordId");
                        });

                    b.OwnsOne("Animal.Domain.HealthRecord.IsDeleted", "IsDeleted", b1 =>
                        {
                            b1.Property<Guid>("HealthRecordId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("HealthRecordId");

                            b1.ToTable("HealthRecords");

                            b1.WithOwner()
                                .HasForeignKey("HealthRecordId");
                        });

                    b.Navigation("Animal");

                    b.Navigation("Id");

                    b.Navigation("IsDeleted");
                });

            modelBuilder.Entity("Animal.Domain.Human.Human", b =>
                {
                    b.OwnsOne("Animal.Domain.Human.HumanId", "Id", b1 =>
                        {
                            b1.Property<Guid>("HumanId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("HumanId");

                            b1.ToTable("Humans");

                            b1.WithOwner()
                                .HasForeignKey("HumanId");
                        });

                    b.OwnsOne("Animal.Domain.Human.IsDeleted", "IsDeleted", b1 =>
                        {
                            b1.Property<Guid>("HumanId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("HumanId");

                            b1.ToTable("Humans");

                            b1.WithOwner()
                                .HasForeignKey("HumanId");
                        });

                    b.Navigation("Id");

                    b.Navigation("IsDeleted");
                });

            modelBuilder.Entity("Animal.Domain.Litter.Litter", b =>
                {
                    b.HasOne("Animal.Domain.Human.Human", "BreedBy")
                        .WithMany("Litters")
                        .HasForeignKey("BreedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Animal.Domain.Litter.IsDeleted", "IsDeleted", b1 =>
                        {
                            b1.Property<Guid>("LitterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("LitterId");

                            b1.ToTable("Litters");

                            b1.WithOwner()
                                .HasForeignKey("LitterId");
                        });

                    b.OwnsOne("Animal.Domain.Litter.LitterBirthDate", "LitterBirthDate", b1 =>
                        {
                            b1.Property<Guid>("LitterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2");

                            b1.HasKey("LitterId");

                            b1.ToTable("Litters");

                            b1.WithOwner()
                                .HasForeignKey("LitterId");
                        });

                    b.OwnsOne("Animal.Domain.Litter.LitterId", "Id", b1 =>
                        {
                            b1.Property<Guid>("LitterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("LitterId");

                            b1.ToTable("Litters");

                            b1.WithOwner()
                                .HasForeignKey("LitterId");
                        });

                    b.OwnsOne("Animal.Domain.Litter.MatingDate", "MatingDate", b1 =>
                        {
                            b1.Property<Guid>("LitterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("datetime2");

                            b1.HasKey("LitterId");

                            b1.ToTable("Litters");

                            b1.WithOwner()
                                .HasForeignKey("LitterId");
                        });

                    b.OwnsOne("Animal.Domain.Litter.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("LitterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LitterId");

                            b1.ToTable("Litters");

                            b1.WithOwner()
                                .HasForeignKey("LitterId");
                        });

                    b.Navigation("BreedBy");

                    b.Navigation("Id");

                    b.Navigation("IsDeleted");

                    b.Navigation("LitterBirthDate");

                    b.Navigation("MatingDate");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Animal.Domain.Race.Race", b =>
                {
                    b.OwnsOne("Animal.Domain.Race.IsDeleted", "IsDeleted", b1 =>
                        {
                            b1.Property<Guid>("RaceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("RaceId");

                            b1.ToTable("Races");

                            b1.WithOwner()
                                .HasForeignKey("RaceId");
                        });

                    b.OwnsOne("Animal.Domain.Race.RaceId", "Id", b1 =>
                        {
                            b1.Property<Guid>("RaceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("RaceId");

                            b1.ToTable("Races");

                            b1.WithOwner()
                                .HasForeignKey("RaceId");
                        });

                    b.OwnsOne("Animal.Domain.Race.RaceName", "RaceName", b1 =>
                        {
                            b1.Property<Guid>("RaceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RaceId");

                            b1.ToTable("Races");

                            b1.WithOwner()
                                .HasForeignKey("RaceId");
                        });

                    b.Navigation("Id");

                    b.Navigation("IsDeleted");

                    b.Navigation("RaceName");
                });

            modelBuilder.Entity("Animal.Domain.SubRace.SubRace", b =>
                {
                    b.HasOne("Animal.Domain.Race.Race", "Race")
                        .WithMany("SubRaces")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Animal.Domain.SubRace.IsDeleted", "IsDeleted", b1 =>
                        {
                            b1.Property<Guid>("SubRaceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Value")
                                .HasColumnType("bit");

                            b1.HasKey("SubRaceId");

                            b1.ToTable("SubRaces");

                            b1.WithOwner()
                                .HasForeignKey("SubRaceId");
                        });

                    b.OwnsOne("Animal.Domain.SubRace.SubRaceId", "Id", b1 =>
                        {
                            b1.Property<Guid>("SubRaceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("SubRaceId");

                            b1.ToTable("SubRaces");

                            b1.WithOwner()
                                .HasForeignKey("SubRaceId");
                        });

                    b.OwnsOne("Animal.Domain.SubRace.SubRaceName", "SubRaceName", b1 =>
                        {
                            b1.Property<Guid>("SubRaceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SubRaceId");

                            b1.ToTable("SubRaces");

                            b1.WithOwner()
                                .HasForeignKey("SubRaceId");
                        });

                    b.Navigation("Id");

                    b.Navigation("IsDeleted");

                    b.Navigation("Race");

                    b.Navigation("SubRaceName");
                });

            modelBuilder.Entity("Animal.Domain.Animal.Animal", b =>
                {
                    b.Navigation("ExhibitionTitles");

                    b.Navigation("HealthRecord");

                    b.Navigation("Litters");
                });

            modelBuilder.Entity("Animal.Domain.Human.Human", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Litters");
                });

            modelBuilder.Entity("Animal.Domain.Litter.Litter", b =>
                {
                    b.Navigation("Parrents");
                });

            modelBuilder.Entity("Animal.Domain.Race.Race", b =>
                {
                    b.Navigation("SubRaces");
                });

            modelBuilder.Entity("Animal.Domain.SubRace.SubRace", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
