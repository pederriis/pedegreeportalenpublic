using Kennel.Domain.Owner;
using Kennel.Domain.Litter;
using Kennel.Domain.Protokol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Kennel.Domain.HealthRecord;
using Kennel.Domain.Disease;
using Kennel.Domain.Vaccination;
using Kennel.Domain.HealthCertificate;

namespace Kennel.Infrastructure
{
    public class KennelDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public KennelDbContext(DbContextOptions<KennelDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public KennelDbContext() { }

        public DbSet<Domain.Animal.Animal> Animals { get; set; }
        public DbSet<Domain.Kennel.Kennel> Kennels { get; set; }
        public DbSet<Domain.Parrent.Parrent> Parrents { get; set; }
        public DbSet<Domain.Child.Child> Children { get; set; }
        public DbSet<Litter> Litters { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Protokol> Protokols { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<HealthCertificate> HealthCertificates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParrentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ChildEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new KennelEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LitterEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProtokolEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HealthRecordEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DiseaseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VaccinationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HealthCertificateEntityTypeConfiguration());
        }
    }

    public class AnimalEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Animal.Animal>
    {
        public void Configure(EntityTypeBuilder<Domain.Animal.Animal> builder)
        {
            builder.HasKey(x => x.AnimalId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.SubRaceId);
            builder.OwnsOne(x => x.RegNo);
            builder.OwnsOne(x => x.PedigreeName);
            builder.OwnsOne(x => x.BirthDate);
            builder.OwnsOne(x => x.DeathDate);
            builder.OwnsOne(x => x.Gender);
            builder.OwnsOne(x => x.Color);
            builder.OwnsOne(x => x.IsBreedable);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Protokol)
                .WithMany(p => p.Animals)
                .HasForeignKey(p => p.ProtokolId);
        }
    }

    public class ParrentEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Parrent.Parrent>
    {
        public void Configure(EntityTypeBuilder<Domain.Parrent.Parrent> builder)
        {
            builder.HasKey(x => x.ParrentId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Animal)
                .WithMany(p => p.Parrents)
                .HasForeignKey(p => p.AnimalId);

            builder.HasOne(p => p.Litter)
                .WithMany(p => p.Parrents)
                .HasForeignKey(p => p.LitterId);
        }
    }

    public class ChildEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Child.Child>
    {
        public void Configure(EntityTypeBuilder<Domain.Child.Child> builder)
        {
            builder.HasKey(x => x.ChildId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Animal)
                .WithMany(p => p.Children)
                .HasForeignKey(p => p.AnimalId);

            builder.HasOne(p => p.Litter)
                .WithMany(p => p.Children)
                .HasForeignKey(p => p.LitterId);
        }
    }

    public class LitterEntityTypeConfiguration : IEntityTypeConfiguration<Litter>
    {
        public void Configure(EntityTypeBuilder<Litter> builder)
        {
            builder.HasKey(x => x.LitterId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.LitterName);
            builder.OwnsOne(x => x.LitterBirthDate);
            builder.OwnsOne(x => x.IsDeleted);
        }
    }

    public class OwnerEntityTypeConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(x => x.OwnerId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.FirstName);
            builder.OwnsOne(x => x.LastName);
            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.PhoneNo);
            builder.OwnsOne(x => x.Street);
            builder.OwnsOne(x => x.City);
            builder.OwnsOne(x => x.Zipcode);
            builder.OwnsOne(x => x.IsDeleted);
        }
    }

    public class KennelEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Kennel.Kennel>
    {
        public void Configure(EntityTypeBuilder<Domain.Kennel.Kennel> builder)
        {
            builder.HasKey(x => x.KennelId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.KennelName);
            builder.OwnsOne(x => x.KennelSmiley);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Owner)
               .WithOne(b => b.Kennel)
               .HasForeignKey<Domain.Kennel.Kennel>(b => b.OwnerId);
        }
    }

    public class ProtokolEntityTypeConfiguration : IEntityTypeConfiguration<Protokol>
    {
        public void Configure(EntityTypeBuilder<Protokol> builder)
        {
            builder.HasKey(x => x.ProtokolId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Kennel)
               .WithOne(b => b.Protokol)
               .HasForeignKey<Protokol>(b => b.KennelId);
        }
    }

    public class HealthRecordEntityTypeConfiguration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.HasKey(x => x.HealthRecordId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.Animal)
               .WithOne(b => b.HealthRecord)
               .HasForeignKey<HealthRecord>(b => b.AnimalId);
        }
    }

    public class HealthCertificateEntityTypeConfiguration : IEntityTypeConfiguration<HealthCertificate>
    {
        public void Configure(EntityTypeBuilder<HealthCertificate> builder)
        {
            builder.HasKey(x => x.HealthCertificateId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.HealthCertificateName);
            builder.OwnsOne(x => x.HealthCertificateDate);
            builder.OwnsOne(x => x.HealthCertificateNote);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.HealthRecord)
                .WithMany(p => p.HealthCertificates)
                .HasForeignKey(p => p.HealthRecordId);
        }
    }

    public class VaccinationEntityTypeConfiguration : IEntityTypeConfiguration<Vaccination>
    {
        public void Configure(EntityTypeBuilder<Vaccination> builder)
        {
            builder.HasKey(x => x.VaccinationId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.VaccinationName);
            builder.OwnsOne(x => x.VaccinationDate);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.HealthRecord)
                .WithMany(p => p.Vaccinations)
                .HasForeignKey(p => p.HealthRecordId);
        }
    }

    public class DiseaseEntityTypeConfiguration : IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            builder.HasKey(x => x.DiseaseId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.DiseaseName);
            builder.OwnsOne(x => x.DiseaseDate);
            builder.OwnsOne(x => x.DiseaseNote);
            builder.OwnsOne(x => x.IsHereditary);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.HealthRecord)
                .WithMany(p => p.Diseases)
                .HasForeignKey(p => p.HealthRecordId);
        }
    }
}

