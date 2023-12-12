using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace User.Infrastructure
{
    public class UserDbContext : DbContext 
    {
        private readonly ILoggerFactory _loggerFactory;

        public UserDbContext(DbContextOptions<UserDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public UserDbContext() { }

        public DbSet<Domain.User.User> Users { get; set; }
        public DbSet<Domain.Animal.Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalEntityTypeConfiguration());
        }
    }

    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<Domain.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User.User> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.FirstName);
            builder.OwnsOne(x => x.LastName);
            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.PhoneNo);
            builder.OwnsOne(x => x.Street);
            builder.OwnsOne(x => x.City);
            builder.OwnsOne(x => x.Zipcode);
            builder.OwnsOne(x => x.ProfileText);
            builder.OwnsOne(x => x.IsDeleted);
            builder.OwnsOne(x => x.LoginUserId);
        }
    }

    public class AnimalEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Animal.Animal>
    {
        public void Configure(EntityTypeBuilder<Domain.Animal.Animal> builder)
        {
            builder.HasKey(x => x.AnimalId);
            builder.OwnsOne(x => x.Id);
            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.IsDeleted);

            builder.HasOne(p => p.User)
                .WithMany(p => p.Animals)
                .HasForeignKey(p => p.UserId);
        }
    }
}