using System;
using System.Collections.Generic;
using System.Text;
using  MatingCalculator.Domain;
using MatingCalculator.Domain.Contract;
using MatingCalculator.Domain.MatingCalculation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;





namespace MatingCalculator.Infrastructure.Shared
{
    public class MatingCalculatorDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public MatingCalculatorDbContext(DbContextOptions<MatingCalculatorDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public MatingCalculatorDbContext() { }

        public DbSet<Domain.Dog.Dog> Dogs { get; set; }
        public DbSet<Domain.Disease.Disease> Diseases { get; set; }
        public DbSet<Domain.Litter.Litter> Litters { get; set; }
        public DbSet<Domain.MatingRules.MatingRules> MatingRules { get; set; }
        public DbSet<Domain.MatingCalculation.MatingCalculation> MatingCalculations { get; set; }
        public DbSet<Domain.Contract.Contract> Contracts { get; set; }
        public DbSet<Domain.Userinformation.Userinformation> Userinformations { get; set; }
        public DbSet<Domain.Parenting.Parenting> Parentings { get; set; }
        public DbSet<Domain.ContractUserinformation.ContractUserinformation> ContractUserinformations { get; set; }
        public DbSet<Domain.DogMatingCalculation.DogMatingCalculation> DogMatingCalculations { get; set; }
        public DbSet<Domain.CalculatedDisease.CalculatedDisease> CalculatedDiseases { get; set; }
        public DbSet<Domain.HealthRecord.HealthRecord> HealthRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DogEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DiseaseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LitterEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MatingRulesEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MatingCalculationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContractEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserinformationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContractUserinformationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DogMatingCalculationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParentingEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CalculatedDiseaseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HealthRecordEntityTypeConfiguration());


        }

        public class DogEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Dog.Dog>
        {
            public void Configure(EntityTypeBuilder<Domain.Dog.Dog> builder)
            {
                builder.HasKey(x => x.DogId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.Name);
                builder.OwnsOne(x => x.Gender);
               // builder.OwnsOne(x => x.RaceId);
                builder.OwnsOne(x => x.SubRaceId);
                builder.OwnsOne(x => x.ChildAmount);
                builder.OwnsOne(x => x.IsDeleted);

                builder.HasOne(p => p.Userinformation)
                .WithMany(p => p.Dogs)
                .HasForeignKey(p => p.UserinformationId);

                builder.HasOne(p => p.HomeLitter)
                    .WithMany(p => p.Dogs)
                    .HasForeignKey(p => p.HomeLitterId);

            }

        }

        public class DiseaseEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Disease.Disease>
        {
            public void Configure(EntityTypeBuilder<Domain.Disease.Disease> builder)
            {
                builder.HasOne(p => p.HealthRecord)
                .WithMany(p => p.Diseases)
                .HasForeignKey(p => p.HealthRecordId);

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

        public class HealthRecordEntityTypeConfiguration : IEntityTypeConfiguration<Domain.HealthRecord.HealthRecord>
        {
            public void Configure(EntityTypeBuilder<Domain.HealthRecord.HealthRecord> builder)
            {
                builder.HasKey(x => x.HealthRecordId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.IsDeleted);

                builder.HasOne(p => p.Dog)
                   .WithOne(b => b.HealthRecord)
                   .HasForeignKey<Domain.HealthRecord.HealthRecord>(b => b.DogId); // HealthRecord needs to be here when its a one to one relation between Animal and HealthRecord. and u dont want HealthRecord to exist without animal.
            }
        }

        public class ParentingEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Parenting.Parenting>
        {
            public void Configure(EntityTypeBuilder<Domain.Parenting.Parenting> builder)
            {
                builder.HasKey(x => x.ParentingId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.IsDeleted);

                builder.HasOne(p => p.Dog)
                    .WithMany(p => p.Parentings)
                    .HasForeignKey(p => p.DogId);

                builder.HasOne(p => p.Litter)
                    .WithMany(p => p.Parentings)
                    .HasForeignKey(p => p.LitterId);

            }
        }

        public class LitterEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Litter.Litter>
        {
            public void Configure(EntityTypeBuilder<Domain.Litter.Litter> builder)
            {
                builder.HasKey(x => x.LitterId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.Name);
                builder.OwnsOne(x => x.Date);
                builder.OwnsOne(x => x.Date);
                builder.OwnsOne(x => x.IsDeleted);

            }
        }
        public class MatingRulesEntityTypeConfiguration : IEntityTypeConfiguration<Domain.MatingRules.MatingRules>
        {
            public void Configure(EntityTypeBuilder<Domain.MatingRules.MatingRules> builder)
            {
                builder.HasKey(x => x.MatingRulesId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.InbreedingPercent);
                builder.OwnsOne(x => x.LitterAmount);
                builder.OwnsOne(x => x.IsDeleted);


            }

        }


        public class MatingCalculationEntityTypeConfiguration : IEntityTypeConfiguration<MatingCalculation>
        {
            public void Configure(EntityTypeBuilder<MatingCalculation> builder)
            {
                builder.HasKey(x => x.MatingCalculationId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.ExpectedChildren);
                builder.OwnsOne(x => x.InbreedingPercent);
                builder.OwnsOne(x => x.LitterAmount);
                builder.OwnsOne(x => x.IsLegal);
                builder.OwnsOne(x => x.IsDeleted);

                builder.HasOne(p => p.MatingRules)
               .WithMany(p => p.MatingCalculations)
               .HasForeignKey(p => p.MatingRulesId);

            }
        }

        public class CalculatedDiseaseEntityTypeConfiguration : IEntityTypeConfiguration<Domain.CalculatedDisease.CalculatedDisease>
        {
            public void Configure(EntityTypeBuilder<Domain.CalculatedDisease.CalculatedDisease> builder)
            {
                builder.HasOne(p => p.MatingCalculation)
                .WithMany(p => p.CalculatedDiseases)
                .HasForeignKey(p => p.MatingCalculationId);

               
                builder.HasKey(x => x.CalculatedDiseaseId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.Name);
                builder.OwnsOne(x => x.Probability);
                builder.OwnsOne(x => x.IsDeleted);

            }

        }


        public class ContractEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Contract.Contract>
        {
            public void Configure(EntityTypeBuilder<Domain.Contract.Contract> builder)
            {
                builder.HasKey(x => x.ContractId);
                builder.OwnsOne(x => x.Id);
                
                builder.OwnsOne(x => x.MaleDogName);
                builder.OwnsOne(x => x.FemaleDogName);
                builder.OwnsOne(x => x.MaleDogOwnerName);
                builder.OwnsOne(x => x.FemaleDogOwnerName);
                builder.OwnsOne(x => x.CreationDate);
                builder.OwnsOne(x => x.MatingDate);
                builder.OwnsOne(x => x.IsDeleted);

                builder.HasOne(p => p.MatingCalculation)
                    .WithOne(p => p.Contract)
                    .HasForeignKey<Contract>(p => p.MatingCalculationId);
            }
        }

        public class ContractUserinformationEntityTypeConfiguration : IEntityTypeConfiguration<Domain.ContractUserinformation.ContractUserinformation>
        {
            public void Configure(EntityTypeBuilder<Domain.ContractUserinformation.ContractUserinformation> builder)
            {
                builder.HasKey(x => x.ContractUserinformationId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.IsDeleted);

                builder.HasOne(p => p.Contract)
                    .WithMany(p => p.ContractUserinformations)
                    .HasForeignKey(p => p.ContractId);

                builder.HasOne(p => p.Userinformation)
                    .WithMany(p => p.ContractUserinformations)
                    .HasForeignKey(p => p.UserinformationId);

            }
        }

        public class UserinformationEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Userinformation.Userinformation>
        {
            public void Configure(EntityTypeBuilder<Domain.Userinformation.Userinformation> builder)
            {
                builder.HasKey(x => x.UserinformationId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.Name);
                builder.OwnsOne(x => x.PhoneNo);
                builder.OwnsOne(x => x.Email);
                builder.OwnsOne(x => x.IsDeleted);

                //builder.HasOne(p => p.Contract)
                //    .WithMany(p => p.Userinformations)
                //    .HasForeignKey(p => p.ContractId);

            }
        }

        public class DogMatingCalculationEntityTypeConfiguration : IEntityTypeConfiguration<Domain.DogMatingCalculation.DogMatingCalculation>
        {
            public void Configure(EntityTypeBuilder<Domain.DogMatingCalculation.DogMatingCalculation> builder)
            {
                builder.HasKey(x => x.DogMatingCalculationId);
                builder.OwnsOne(x => x.Id);
                builder.OwnsOne(x => x.IsDeleted);

                builder.HasOne(p => p.Dog)
                    .WithMany(p => p.DogMatingCalculations)
                    .HasForeignKey(p => p.DogId);

                builder.HasOne(p => p.MatingCalculation)
                    .WithMany(p => p.DogMatingCalculations)
                    .HasForeignKey(p => p.MatingCalculationId);

            }
        }

    }
}
