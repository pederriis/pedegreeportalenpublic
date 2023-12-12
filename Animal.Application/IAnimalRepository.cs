using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Application
{
    public interface IAnimalRepository
    {
        // Animal
        Task AddAnimal(Domain.Animal.Animal entity);
        Task<bool> AnimalExists(Guid id);
        Task<Domain.Animal.Animal> LoadAnimal(Guid id);

        // Parentings
        Task AddParenting(Domain.Parenting.Parenting entity);
        Task<bool> ParentingExists(Guid id);
        Task<Domain.Parenting.Parenting> LoadParenting(Guid id);

        // ExhibitionTitle
        Task AddExhibitionTitle(Domain.ExhibitionTitle.ExhibitionTitle entity);
        Task<bool> ExhibitionTitleExists(Guid id);
        Task<Domain.ExhibitionTitle.ExhibitionTitle> LoadExhibitionTitle(Guid id);

        // HealthRecord
        Task AddHealthRecord(Domain.HealthRecord.HealthRecord entity);
        Task<bool> HealthRecordExists(Guid id);
        Task<Domain.HealthRecord.HealthRecord> LoadHealthRecord(Guid id);

        // Human
        Task AddHuman(Domain.Human.Human entity);
        Task<bool> HumanExists(Guid id);
        Task<Domain.Human.Human> LoadHuman(Guid id);

        // Litter
        Task AddLitter(Domain.Litter.Litter entity);
        Task<bool> LitterExists(Guid id);
        Task<Domain.Litter.Litter> LoadLitter(Guid id);

        // Race
        Task AddRace(Domain.Race.Race entity);
        Task<bool> RaceExists(Guid id);
        Task<Domain.Race.Race> LoadRace(Guid id);

        // SubRace
        Task AddSubRace(Domain.SubRace.SubRace entity);
        Task<bool> SubRaceExists(Guid id);
        Task<Domain.SubRace.SubRace> LoadSubRace(Guid id);
    }
}
