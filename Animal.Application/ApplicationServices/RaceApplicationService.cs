using Animal.Domain.Race;
using PedigreePortalen.Framework;
using System;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.RaceCommandsDto;

namespace Animal.Application.ApplicationServices
{
    public class RaceApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnimalRepository _repository;

        public RaceApplicationService(IUnitOfWork unitOfWork, IAnimalRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateRace cmd => HandleCreate(cmd),

                V1.UpdateRace cmd => HandleUpdate(cmd.RaceId,
                    c => c.UpdateRace(
                        RaceName.FromString(cmd.RaceName))),

                V1.DeleteRace cmd => HandleUpdate(cmd.RaceId,
                    c => c.DeleteRace(IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateRace cmd)
        {
            if (await _repository.RaceExists(cmd.RaceId))
                throw new InvalidOperationException($"Entity with id {cmd.RaceId} already exists");

            var race = new Race(

            new RaceId(cmd.RaceId),
            new RaceName(cmd.RaceName),
            new IsDeleted(cmd.IsDeleted));

            await _repository.AddRace(race);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid raceId, Action<Race> operation)
        {
            var race = await _repository.LoadRace(raceId);

            if (race == null)
                throw new InvalidOperationException($"Entity with id {raceId} cannot be found");

            operation(race);

            await _unitOfWork.Commit();
        }
    }
}
