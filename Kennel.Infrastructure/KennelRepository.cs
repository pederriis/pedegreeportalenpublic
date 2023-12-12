using Kennel.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kennel.Infrastructure
{
    public class KennelRepository : IKennelRepository, IDisposable
    {
        private readonly KennelDbContext _dbContext;

        public KennelRepository(KennelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        // Kennel 
        public async Task AddKennel(Domain.Kennel.Kennel entity)
           => await _dbContext.Kennels.AddAsync(entity);

        public async Task<bool> KennelExists(Guid id)
            => await _dbContext.Kennels.FindAsync(id) != null;

        public async Task<Domain.Kennel.Kennel> LoadKennel(Guid id)
            => await _dbContext.Kennels.FindAsync(id);

        // Protokol
        public async Task AddProtokol(Domain.Protokol.Protokol entity)
           => await _dbContext.Protokols.AddAsync(entity);

        public async Task<bool> ProtokolExists(Guid id)
            => await _dbContext.Protokols.FindAsync(id) != null;

        public async Task<Domain.Protokol.Protokol> LoadProtokol(Guid id)
            => await _dbContext.Protokols.FindAsync(id);

        // Owner
        public async Task AddOwner(Domain.Owner.Owner entity)
           => await _dbContext.Owners.AddAsync(entity);

        public async Task<bool> OwnerExists(Guid id)
            => await _dbContext.Owners.FindAsync(id) != null;

        public async Task<Domain.Owner.Owner> LoadOwner(Guid id)
            => await _dbContext.Owners.FindAsync(id);

        // Animal
        public async Task AddAnimal(Domain.Animal.Animal entity)
            => await _dbContext.Animals.AddAsync(entity);

        public async Task<bool> AnimalExists(Guid id)
            => await _dbContext.Animals.FindAsync(id) != null;

        public async Task<Domain.Animal.Animal> LoadAnimal(Guid id)
            => await _dbContext.Animals.FindAsync(id);

        // Parrent
        public async Task AddParrent(Domain.Parrent.Parrent entity)
            => await _dbContext.Parrents.AddAsync(entity);

        public async Task<bool> ParrentExists(Guid id)
            => await _dbContext.Parrents.FindAsync(id) != null;

        public async Task<Domain.Parrent.Parrent> LoadParrent(Guid id)
            => await _dbContext.Parrents.FindAsync(id);

        // Child
        public async Task AddChild(Domain.Child.Child entity)
            => await _dbContext.Children.AddAsync(entity);

        public async Task<bool> ChildExists(Guid id)
            => await _dbContext.Children.FindAsync(id) != null;

        public async Task<Domain.Child.Child> LoadChild(Guid id)
            => await _dbContext.Children.FindAsync(id);

        // Litter
        public async Task AddLitter(Domain.Litter.Litter entity)
            => await _dbContext.Litters.AddAsync(entity);

        public async Task<bool> LitterExists(Guid id)
            => await _dbContext.Litters.FindAsync(id) != null;

        public async Task<Domain.Litter.Litter> LoadLitter(Guid id)
            => await _dbContext.Litters.FindAsync(id);

        // HealthRecord
        public async Task AddHealthRecord(Domain.HealthRecord.HealthRecord entity)
            => await _dbContext.HealthRecords.AddAsync(entity);

        public async Task<bool> HealthRecordExists(Guid id)
            => await _dbContext.HealthRecords.FindAsync(id) != null;

        public async Task<Domain.HealthRecord.HealthRecord> LoadHealthRecord(Guid id)
            => await _dbContext.HealthRecords.FindAsync(id);

        // Disease
        public async Task AddDisease(Domain.Disease.Disease entity)
             => await _dbContext.Diseases.AddAsync(entity);

        public async Task<bool> DiseaseExists(Guid id)
            => await _dbContext.Diseases.FindAsync(id) != null;

        public async Task<Domain.Disease.Disease> LoadDisease(Guid id)
            => await _dbContext.Diseases.FindAsync(id);

        // Vaccination
        public async Task AddVaccination(Domain.Vaccination.Vaccination entity)
            => await _dbContext.Vaccinations.AddAsync(entity);

        public async Task<bool> VaccinationExists(Guid id)
            => await _dbContext.Vaccinations.FindAsync(id) != null;

        public async Task<Domain.Vaccination.Vaccination> LoadVaccination(Guid id)
            => await _dbContext.Vaccinations.FindAsync(id);

        // HealthCertificate
        public async Task AddHealthCertificate(Domain.HealthCertificate.HealthCertificate entity)
            => await _dbContext.HealthCertificates.AddAsync(entity);

        public async Task<bool> HealthCertificateExists(Guid id)
            => await _dbContext.HealthCertificates.FindAsync(id) != null;

        public async Task<Domain.HealthCertificate.HealthCertificate> LoadHealthCertificate(Guid id)
            => await _dbContext.HealthCertificates.FindAsync(id);
    }
}
