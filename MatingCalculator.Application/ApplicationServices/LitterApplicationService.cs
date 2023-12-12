using MatingCalculator.Application.Interfaces;
using MatingCalculator.Domain.Litter;
using PedigreePortalen.Framework;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.ApplicationServices
{
    public class LitterApplicationService
    {
        private readonly ILitterRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public LitterApplicationService(ILitterRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 LitterCommandsDto.V1.CreateLitter cmd => HandleCreate(cmd),

                 LitterCommandsDto.V1.UpdateLitter cmd => HandleUpdate(cmd.LitterId,
                     c => c.UpdateLitter(Name.FromString(cmd.Name)
                         , Date.FromDateTime(cmd.Date) )),

                 LitterCommandsDto.V1.DeleteLitter cmd => HandleUpdate(cmd.LitterId,
                     c => c.DeleteLitter(Domain.Litter.IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(LitterCommandsDto.V1.CreateLitter cmd)
        {
            if (await _repository.LitterExists(cmd.LitterId))
                throw new InvalidOperationException($"Entity with id {cmd.LitterId} already exists");

            var disease = new Litter(

            new LitterId(cmd.LitterId),
            new Name(cmd.Name),
            new Date(cmd.Date),
           
            new Domain.Litter.IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddLitter(disease);
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
