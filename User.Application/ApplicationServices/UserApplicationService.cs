using Animal.Domain;
using PedigreePortalen.Framework;
using System;
using System.Threading.Tasks;
using User.Domain.User;
using static PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto;

namespace User.Application.ApplicationServices
{
    public class UserApplicationService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateUser cmd => HandleCreate(cmd),

                V1.UpdateUser cmd => HandleUpdate(cmd.UserId,
                    c => c.UpdateUser(FirstName.FromString(cmd.FirstName)
                        ,LastName.FromString(cmd.LastName)
                        ,Email.FromString(cmd.Email)
                        ,PhoneNo.FromString(cmd.PhoneNo)
                        ,Street.FromString(cmd.Street)
                        ,City.FromString(cmd.City)
                        ,Zipcode.FromString(cmd.Zipcode)
                        ,ProfileText.FromString(cmd.ProfileText),
                        Domain.User.IsDeleted.FromBool(cmd.IsDeleted)
                        )),

                V1.DeleteUser cmd => HandleUpdate(cmd.UserId,
                    c => c.DeletedUser(Domain.User.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateUser cmd)
        {
            if (await _repository.UserExists(cmd.UserId))
                throw new InvalidOperationException($"Entity with id {cmd.UserId} already exists");

            var user = new Domain.User.User(

            new UserId(cmd.UserId),
            new LoginUserId(cmd.LoginUserId),
            new FirstName(cmd.FirstName),
            new LastName(cmd.LastName),
            new Email(cmd.Email),
            new PhoneNo(cmd.PhoneNo),
            new Street(cmd.Street),
            new City(cmd.City),
            new Zipcode(cmd.Zipcode),
            new ProfileText(cmd.ProfileText),
            new Domain.User.IsDeleted(cmd.IsDeleted)
            );

            await _repository.AddUser(user);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid userId, Action<Domain.User.User> operation)
        {
            var owner = await _repository.LoadUser(userId);

            if (owner == null)
                throw new InvalidOperationException($"Entity with id {userId} cannot be found");

            operation(owner);

            await _unitOfWork.Commit();
        }
    }
}
