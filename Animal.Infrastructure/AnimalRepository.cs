using Animal.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Infrastructure
{
    public class AnimalRepository :IAnimalRepository, IDisposable
    {
        private readonly AnimalDbContext _dbContext;

        public AnimalRepository(AnimalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        // Animal
        public async Task AddAnimal(Domain.Animal.Animal entity)
            => await _dbContext.Animals.AddAsync(entity);

        public async Task<bool> AnimalExists(Guid id)
            => await _dbContext.Animals.FindAsync(id) != null;

        public async Task<Domain.Animal.Animal> LoadAnimal(Guid id)
            => await _dbContext.Animals.FindAsync(id);

        // Parentings
        public async Task AddParenting(Domain.Parenting.Parenting entity)
            => await _dbContext.Parentings.AddAsync(entity);

        public async Task<bool> ParentingExists(Guid id)
            => await _dbContext.Parentings.FindAsync(id) != null;

        public async Task<Domain.Parenting.Parenting> LoadParenting(Guid id)
            => await _dbContext.Parentings.FindAsync(id);

        // ExhibitionTitle
        public async Task AddExhibitionTitle(Domain.ExhibitionTitle.ExhibitionTitle entity)
            => await _dbContext.ExhibitionTitles.AddAsync(entity);

        public async Task<bool> ExhibitionTitleExists(Guid id)
            => await _dbContext.ExhibitionTitles.FindAsync(id) != null;

        public async Task<Domain.ExhibitionTitle.ExhibitionTitle> LoadExhibitionTitle(Guid id)
            => await _dbContext.ExhibitionTitles.FindAsync(id);

        // HealthRecord
        public async Task AddHealthRecord(Domain.HealthRecord.HealthRecord entity)
            => await _dbContext.HealthRecords.AddAsync(entity);

        public async Task<bool> HealthRecordExists(Guid id)
            => await _dbContext.HealthRecords.FindAsync(id) != null;

        public async Task<Domain.HealthRecord.HealthRecord> LoadHealthRecord(Guid id)
            => await _dbContext.HealthRecords.FindAsync(id);

        // Human
        public async Task AddHuman(Domain.Human.Human entity)
            => await _dbContext.Humans.AddAsync(entity);

        public async Task<bool> HumanExists(Guid id)
            => await _dbContext.Humans.FindAsync(id) != null;

        public async Task<Domain.Human.Human> LoadHuman(Guid id)
            => await _dbContext.Humans.FindAsync(id);

        // Litter
        public async Task AddLitter(Domain.Litter.Litter entity)
            => await _dbContext.Litters.AddAsync(entity);

        public async Task<bool> LitterExists(Guid id)
            => await _dbContext.Litters.FindAsync(id) != null;

        public async Task<Domain.Litter.Litter> LoadLitter(Guid id)
            => await _dbContext.Litters.FindAsync(id);

        // Race
        public async Task AddRace(Domain.Race.Race entity)
            => await _dbContext.Races.AddAsync(entity);

        public async Task<bool> RaceExists(Guid id)
            => await _dbContext.Races.FindAsync(id) != null;

        public async Task<Domain.Race.Race> LoadRace(Guid id)
            => await _dbContext.Races.FindAsync(id);

        // SubRace
        public async Task AddSubRace(Domain.SubRace.SubRace entity)
            => await _dbContext.SubRaces.AddAsync(entity);

        public async Task<bool> SubRaceExists(Guid id)
            => await _dbContext.SubRaces.FindAsync(id) != null;

        public async Task<Domain.SubRace.SubRace> LoadSubRace(Guid id)
            => await _dbContext.SubRaces.FindAsync(id);
    }
}
