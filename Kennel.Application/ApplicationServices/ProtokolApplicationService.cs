using Kennel.Domain.Kennel;
using Kennel.Domain.Protokol;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Commands.ProtokolCommandsDto;

namespace Kennel.Application.ApplicationServices
{
    public class ProtokolApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKennelRepository _repository;

        public ProtokolApplicationService(IUnitOfWork unitOfWork, IKennelRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateProtokol cmd => HandleCreate(cmd),

                V1.DeleteProtokol cmd => HandleUpdate(cmd.ProtokolId,
                    c => c.DeleteProtokol(Domain.Protokol.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateProtokol cmd)
        {
            if (await _repository.ProtokolExists(cmd.ProtokolId))
                throw new InvalidOperationException($"Entity with id {cmd.ProtokolId} already exists");

            var protokol = new Protokol(

            new ProtokolId(cmd.ProtokolId),
            new KennelId(cmd.KennelId),
            new Domain.Protokol.IsDeleted(cmd.IsDeleted));

            await _repository.AddProtokol(protokol);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid protokolId, Action<Protokol> operation)
        {
            var protokol = await _repository.LoadProtokol(protokolId);

            if (protokol == null)
                throw new InvalidOperationException($"Entity with id {protokolId} cannot be found");

            operation(protokol);

            await _unitOfWork.Commit();
        }
    }
}
