using Kennel.Domain.Animal;
using Kennel.Domain.Litter;
using Kennel.Domain.Parrent;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Commands.ParrentCommandsDto;

namespace Kennel.Application.ApplicationServices
{
    public class ParrentApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKennelRepository _repository;

        public ParrentApplicationService(IUnitOfWork unitOfWork, IKennelRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateParrent cmd => HandleCreate(cmd),

                V1.DeleteParrent cmd => HandleUpdate(cmd.ParrentId,
                    c => c.DeleteParrent(Domain.Parrent.IsDeleted.FromBool(cmd.IsDeleted))),

                V1.AddParrentToLitter cmd => HandleUpdate(cmd.ParrentId,
                    c => c.AddParrentToLitter(new LitterId(cmd.LitterId))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateParrent cmd)
        {
            if (await _repository.ParrentExists(cmd.ParrentId))
                throw new InvalidOperationException($"Entity with id {cmd.ParrentId} already exists");

            var parrent = new Parrent(

            new ParrentId(cmd.ParrentId),
            new AnimalId(cmd.AnimalId),
            new Domain.Parrent.IsDeleted(cmd.IsDeleted));

            await _repository.AddParrent(parrent);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid parrentId, Action<Parrent> operation)
        {
            var parrent = await _repository.LoadParrent(parrentId);

            if (parrent == null)
                throw new InvalidOperationException($"Entity with id {parrentId} cannot be found");

            operation(parrent);

            await _unitOfWork.Commit();
        }
    }
}
