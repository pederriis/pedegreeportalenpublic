using Kennel.Domain.Animal;
using Kennel.Domain.Litter;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Commands.LitterCommandsDto;

namespace Kennel.Application.ApplicationServices
{
    public class LitterApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKennelRepository _repository;

        public LitterApplicationService(IUnitOfWork unitOfWork, IKennelRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateLitter cmd => HandleCreate(cmd),

                V1.UpdateLitter cmd => HandleUpdate(cmd.LitterId,
                    c => c.UpdateLitter(
                        LitterName.FromString(cmd.LitterName)
                        , LitterBirthDate.FromDateTime(cmd.LitterBirthDate))),

                V1.DeleteLitter cmd => HandleUpdate(cmd.LitterId,
                    c => c.DeleteLitter(Domain.Litter.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateLitter cmd)
        {
            if (await _repository.LitterExists(cmd.LitterId))
                throw new InvalidOperationException($"Entity with id {cmd.LitterId} already exists");

            var litter = new Litter(

            new LitterId(cmd.LitterId),
            new LitterName(cmd.LitterName),
            new LitterBirthDate(cmd.LitterBirthDate),
            
            new Domain.Litter.IsDeleted(cmd.IsDeleted));

            await _repository.AddLitter(litter);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid litterId, Action<Litter> operation)
        {
            var litter = await _repository.LoadLitter(litterId);

            if (litter == null)
                throw new InvalidOperationException($"Entity with id {litterId} cannot be found");

            operation(litter);

            await _unitOfWork.Commit();
        }
    }
}
