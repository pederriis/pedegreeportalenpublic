using System;
using System.Collections.Generic;
using System.Text;
using HealthRecord.Domain.Animal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;




namespace HealthRecord.Infrastructure.Shared
{
    public class HealthRecordDbContext: DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public HealthRecordDbContext(DbContextOptions<HealthRecordDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public HealthRecordDbContext() { }

        public DbSet<Domain.HealthRecord.HealthRecord> HealthRecord { get; set; }
        public DbSet<Domain.Animal.Animal> Animals { get; set; }
        public DbSet<Domain.Disease.Disease> Diseases { get; set; }
        public DbSet<Domain.HealthCertificate.HealthCertificate> HealthCertificates { get; set; }
        public DbSet<Domain.Vaccination.Vaccination> Vaccinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HealthRecordEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HealthCertificateEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VaccinationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DiseaseEntityTypeConfiguration());

        }

        public class HealthRecordEntityTypeConfiguration : IEntityTypeConfiguration<Domain.HealthRecord.HealthRecord>
        {
            public void Configure(EntityTypeBuilder<Domain.HealthRecord.HealthRecord> builder)
            {
                
                builder.HasKey(x => x.HealthRecordId);
                builder.OwnsOne(x => x.Id);

                //builder.HasOne(p => p.Animal)
                //    .WithOne(p => p.HealthRecord)
                //    .HasForeignKey<Domain.HealthRecord.HealthRecord>(p => p.AnimalId);

                
                builder.HasOne(p => p.Animal)
             .WithOne(b => b.HealthRecord)
             .HasForeignKey<Domain.HealthRecord.HealthRecord>(b => b.AnimalId);


            }

        }

        public class AnimalEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Animal.Animal>
        {
            public void Configure(EntityTypeBuilder<Domain.Animal.Animal> builder)
            {
                //builder.HasOne(a => a.HealthRecord)
                //    .WithOne(b => b.Animal)
                //    .HasForeignKey<Domain.HealthRecord.HealthRecord>(b => b.HealthRecordId);


                builder.HasKey(x => x.AnimalId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.Name);
                builder.OwnsOne(x => x.OwnerId);
                builder.OwnsOne(x => x.IsDeleted);

            }

        }

        public class DiseaseEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Disease.Disease>
        {
            public void Configure(EntityTypeBuilder<Domain.Disease.Disease> builder)
            {
                builder.HasOne(p => p.HealthRecord)
                .WithMany(p => p.Diseases)
                .HasForeignKey(p => p.HealtRecordId);

                builder.HasKey(x => x.DiseaseId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.Name);
                builder.OwnsOne(x => x.Date);
                builder.OwnsOne(x => x.Note);
                builder.OwnsOne(x => x.Probability);
                builder.OwnsOne(x => x.IsHereditary);
                builder.OwnsOne(x => x.IsDeleted);

            }

        }

        public class HealthCertificateEntityTypeConfiguration : IEntityTypeConfiguration<Domain.HealthCertificate.HealthCertificate>
        {
            public void Configure(EntityTypeBuilder<Domain.HealthCertificate.HealthCertificate> builder)
            {
                builder.HasOne(p => p.HealthRecord)
                .WithMany(p => p.HealthCertificates)
                .HasForeignKey(p => p.HealthRecordId);


                builder.HasKey(x => x.HealthCertificateId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.Name);
                builder.OwnsOne(x => x.Date);
                builder.OwnsOne(x => x.Note);
                builder.OwnsOne(x => x.IsDeleted);

            }

        }
        public class VaccinationEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Vaccination.Vaccination>
        {
            public void Configure(EntityTypeBuilder<Domain.Vaccination.Vaccination> builder)
            {
                builder.HasOne(p => p.HealthRecord)
                .WithMany(p => p.Vaccinations)
                .HasForeignKey(p => p.HealthRecordId);

                builder.HasKey(x => x.VaccinationId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.Name);
                builder.OwnsOne(x => x.Date);
                builder.OwnsOne(x => x.IsDeleted);

            }

        }
    }
}
