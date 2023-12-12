using Kennel.Domain.Kennel;
using Kennel.Domain.Owner;
using Kennel.Domain.Protokol;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Commands.KennelCommandsDto;

namespace Kennel.Application.ApplicationServices
{
    public class KennelApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKennelRepository _repository;

        public KennelApplicationService(IUnitOfWork unitOfWork, IKennelRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateKennel cmd => HandleCreate(cmd),

                V1.UpdateKennel cmd => HandleUpdate(cmd.KennelId,
                    c => c.UpdateKennel(
                         KennelName.FromString(cmd.KennelName)
                        , KennelSmiley.FromString(cmd.KennelSmiley))),
                        
                V1.DeleteKennel cmd => HandleUpdate(cmd.KennelId,
                    c => c.DeleteKennel(Domain.Kennel.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateKennel cmd)
        {
            if (await _repository.KennelExists(cmd.KennelId))
                throw new InvalidOperationException($"Entity with id {cmd.KennelId} already exists");

            var kennel = new Domain.Kennel.Kennel(

            new KennelId(cmd.KennelId),
            //new ProtokolId(cmd.ProtokolId),
            new OwnerId(cmd.OwnerId),
            new KennelName(cmd.KennelName),
            new KennelSmiley(cmd.KennelSmiley),
            new Domain.Kennel.IsDeleted(cmd.IsDeleted));

            await _repository.AddKennel(kennel);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid kennelId, Action<Domain.Kennel.Kennel> operation)
        {
            var kennel = await _repository.LoadKennel(kennelId);

            if (kennel == null)
                throw new InvalidOperationException($"Entity with id {kennelId} cannot be found");

            operation(kennel);

            await _unitOfWork.Commit();
        }
    }
}
