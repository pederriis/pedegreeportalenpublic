using MatingCalculator.Application.Interfaces;
using PedigreePortalen.Framework;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.ApplicationServices
{
    public class UserinformationApplicationService
    {
        private readonly IUserinformationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserinformationApplicationService(IUserinformationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 UserinformationCommandsDto.V1.CreateUserinformation cmd => HandleCreate(cmd),

                 UserinformationCommandsDto.V1.UpdateUserinformation cmd => HandleUpdate(cmd.UserinformationId,
                     c => c.UpdateUserinformation(Domain.Userinformation.Email.FromString(cmd.Email)
                         , Domain.Userinformation.Name.FromString(cmd.Name)
                         , Domain.Userinformation.PhoneNo.FromString(cmd.PhoneNo))),

                 UserinformationCommandsDto.V1.DeleteUserinformation cmd => HandleUpdate(cmd.UserinformationId,
                      c => c.DeleteUserinformation(Domain.Userinformation.IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(UserinformationCommandsDto.V1.CreateUserinformation cmd)
        {
            if (await _repository.UserinformationExists(cmd.UserinformationId))
                throw new InvalidOperationException($"Entity with id {cmd.UserinformationId} already exists");

            var userinformation = new Domain.Userinformation.Userinformation(

            new Domain.Userinformation.UserinformationId(cmd.UserinformationId),
            new Domain.Userinformation.Email(cmd.Email),
            new Domain.Userinformation.Name(cmd.Name),
            new Domain.Userinformation.PhoneNo(cmd.PhoneNo),
            

            new Domain.Userinformation.IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddUserinformation(userinformation);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid userinformationId, Action<Domain.Userinformation.Userinformation> operation)
        {
            var userinformation = await _repository.LoadUserinformation(userinformationId);

            if (userinformation == null)
                throw new InvalidOperationException($"Entity with id {userinformationId} cannot be found");

            operation(userinformation);

            await _unitOfWork.Commit();
        }
    }
}
