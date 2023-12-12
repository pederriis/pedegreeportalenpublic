using MassTransit;
using System.Threading.Tasks;
using PedigreePortalen.Shared.UserMicroserviceDto.Commands;
using User.Application.ApplicationServices;

namespace User.Microservice.Consumers
{
    public static class AnimalConsumer
    {
        public class CreateAmimalConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.CreateAnimal>
        {
            private readonly AnimalApplicationService _applicationService;

            public CreateAmimalConsumer(AnimalApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.CreateAnimal> context)
            {
                var data = context.Message;

                AnimalCommandsDto.V1.CreateAnimal animal = new AnimalCommandsDto.V1.CreateAnimal();

                animal.AnimalId = data.AnimalId;
                animal.UserId = data.OwnerId;
                animal.Name = data.ShortName;
                animal.IsDeleted = data.IsDeleted;
                await _applicationService.Handle(animal);
            }
        }

        public class UpdateAnimalConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.UpdateAnimal>
        {
            private readonly AnimalApplicationService _applicationService;

            public UpdateAnimalConsumer(AnimalApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.UpdateAnimal> context)
            {
                var data = context.Message;

                AnimalCommandsDto.V1.UpdateAnimal animal = new AnimalCommandsDto.V1.UpdateAnimal();

                animal.AnimalId = data.AnimalId;
                animal.UserId = data.HumanId;
                animal.Name = data.ShortName;
                await _applicationService.Handle(animal);
            }
        }

        public class DeleteAnimalConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.DeleteAnimal>
        {
            private readonly AnimalApplicationService _applicationService;

            public DeleteAnimalConsumer(AnimalApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.DeleteAnimal> context)
            {
                var data = context.Message;

                AnimalCommandsDto.V1.DeleteAnimal animal = new AnimalCommandsDto.V1.DeleteAnimal();

                animal.AnimalId = data.AnimalId;
                animal.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(animal);
            }
        }
    }
}
