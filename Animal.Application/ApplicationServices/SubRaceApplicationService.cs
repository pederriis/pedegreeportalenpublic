using Animal.Domain.Race;
using Animal.Domain.SubRace;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.SubRaceCommandsDto;

namespace Animal.Application.ApplicationServices
{
    public class SubRaceApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnimalRepository _repository;

        public SubRaceApplicationService(IUnitOfWork unitOfWork, IAnimalRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateSubRace cmd => HandleCreate(cmd),

                V1.UpdateSubRace cmd => HandleUpdate(cmd.SubRaceId,
                    c => c.UpdateSubRace(
                        SubRaceName.FromString(cmd.SubRaceName))),

                V1.DeleteSubRace cmd => HandleUpdate(cmd.SubRaceId,
                    c => c.DeleteSubRace(Domain.SubRace.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateSubRace cmd)
        {
            if (await _repository.SubRaceExists(cmd.SubRaceId))
                throw new InvalidOperationException($"Entity with id {cmd.SubRaceId} already exists");

            var subRace = new SubRace(

            new SubRaceId(cmd.SubRaceId),
            new RaceId(cmd.RaceId),
            new SubRaceName(cmd.SubRaceName),
            new Domain.SubRace.IsDeleted(cmd.IsDeleted));

            await _repository.AddSubRace(subRace);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid subRaceId, Action<SubRace> operation)
        {
            var subRace = await _repository.LoadSubRace(subRaceId);

            if (subRace == null)
                throw new InvalidOperationException($"Entity with id {subRaceId} cannot be found");

            operation(subRace);

            await _unitOfWork.Commit();
        }
    }
}
