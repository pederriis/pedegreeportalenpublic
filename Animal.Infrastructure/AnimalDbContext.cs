using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Animal.Domain.HealthRecord;

namespace Animal.Infrastructure
{
    public class AnimalDbContext :DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public AnimalDbContext(DbContextOptions<AnimalDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public AnimalDbContext() { }

        public DbSet<Domain.Animal.Animal> Animals { get; set; }
        public DbSet<Domain.Parenting.Parenting> Parentings { get; set; }
        public DbSet<Domain.ExhibitionTitle.ExhibitionTitle> ExhibitionTitles { get; set; }
        public DbSet<Domain.HealthRecord.HealthRecord> HealthRecords { get; set; }
        public DbSet<Domain.Human.Human> Humans { get; set; }
        public DbSet<Domain.Litter.Litter> Litters { get; set; }
        public DbSet<Domain.Race.Race> Races { get; set; }
        public DbSet<Domain.SubRace.SubRace> SubRaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParentingEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ExhibitionTitleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HealthRecordEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HumanEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LitterEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RaceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubRaceEntityTypeConfiguration());
        }
    }

    public class AnimalEntityTypeConfiguration :IEntityTypeConfiguration<Domain.Animal.Animal>
    {
        public void Configure(EntityTypeBuilder<Domain.Animal.Animal> builder)
        {
            builder.HasKey(x => x.AnimalId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.RegNo);
            builder.OwnsOne(x => x.PedigreeName);
            builder.OwnsOne(x => x.ShortName);
            builder.OwnsOne(x => x.BirthDate);
            builder.OwnsOne(x => x.DeathDate);
            builder.OwnsOne(x => x.Gender);
            builder.OwnsOne(x => x.Color);
            builder.OwnsOne(x => x.WeightInKg);
            builder.OwnsOne(x => x.IsBreedable);
            builder.OwnsOne(x => x.ProfileText);;
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Owner)
                .WithMany(p => p.Animals)
                .HasForeignKey(p => p.OwnerId);

            builder.HasOne(p => p.SubRace)
                .WithMany(p => p.Animals)
                .HasForeignKey(p => p.SubRaceId);

            builder.HasOne(p => p.Litter)
                .WithMany(p => p.Animals)
                .HasForeignKey(p => p.LitterId);
        }
    }

    public class HealthRecordEntityTypeConfiguration : IEntityTypeConfiguration<Domain.HealthRecord.HealthRecord>
    {
        public void Configure(EntityTypeBuilder<Domain.HealthRecord.HealthRecord> builder)
        {
            builder.HasKey(x => x.HealthRecordId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Animal)
               .WithOne(b => b.HealthRecord)
               .HasForeignKey<HealthRecord>(b => b.AnimalId);
        }
    }

    public class ParentingEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Parenting.Parenting>
    {
        public void Configure(EntityTypeBuilder<Domain.Parenting.Parenting> builder)
        {
            builder.HasKey(x => x.ParentingId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Animal)
                .WithMany(p => p.Parentings)
                .HasForeignKey(p => p.AnimalId);

            builder.HasOne(p => p.Litter)
                .WithMany(p => p.Parentings)
                .HasForeignKey(p => p.LitterId);
        }
    }

    public class ExhibitionTitleEntityTypeConfiguration :IEntityTypeConfiguration<Domain.ExhibitionTitle.ExhibitionTitle>
    {
        public void Configure(EntityTypeBuilder<Domain.ExhibitionTitle.ExhibitionTitle> builder)
        {
            builder.HasKey(x => x.ExhibitionTitleId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.Date);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Animal)
                .WithMany(p => p.ExhibitionTitles)
                .HasForeignKey(p => p.AnimalId);
        }
    }

    public class HumanEntityTypeConfiguration :IEntityTypeConfiguration<Domain.Human.Human>
    {
        public void Configure(EntityTypeBuilder<Domain.Human.Human> builder)
        {
            builder.HasKey(x => x.HumanId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.IsDeleted);
        }
    }

    public class LitterEntityTypeConfiguration :IEntityTypeConfiguration<Domain.Litter.Litter>
    {
        public void Configure(EntityTypeBuilder<Domain.Litter.Litter> builder)
        {
            builder.HasKey(x => x.LitterId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.LitterName);
            builder.OwnsOne(x => x.LitterBirthDate);
            builder.OwnsOne(x => x.MatingDate);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.BreedBy)
                .WithMany(p => p.Litters)
                .HasForeignKey(p => p.BreedById);
        }
    }

    public class RaceEntityTypeConfiguration :IEntityTypeConfiguration<Domain.Race.Race>
    {
        public void Configure(EntityTypeBuilder<Domain.Race.Race> builder)
        {
            builder.HasKey(x => x.RaceId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.RaceName);
            builder.OwnsOne(x => x.IsDeleted);
        }
    }

    public class SubRaceEntityTypeConfiguration :IEntityTypeConfiguration<Domain.SubRace.SubRace>
    {
        public void Configure(EntityTypeBuilder<Domain.SubRace.SubRace> builder)
        {
            builder.HasKey(x => x.SubRaceId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.SubRaceName);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Race)
                .WithMany(p => p.SubRaces)
                .HasForeignKey(p => p.RaceId);
        }
    }
}

