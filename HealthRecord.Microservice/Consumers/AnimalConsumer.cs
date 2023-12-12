using HealthRecord.Application;
using MassTransit;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using PedigreePortalen.Shared.HealthRecordMicroservice.Commands;
using System.Threading.Tasks;

namespace HealthRecord.Microservice.Consumers
{
    public static class AnimalConsumer
    {
        public class AmimalCreateConsumer : IConsumer<AnimalCommandsDto.V1.CreateAnimal>
        {
            private readonly AnimalApplicationService _applicationService;
            public AmimalCreateConsumer(AnimalApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<AnimalCommandsDto.V1.CreateAnimal> context)
            {
                var data = context.Message;

                AnimalCommandsDTO.V1.CreateAnimal animal = new AnimalCommandsDTO.V1.CreateAnimal();
                animal.AnimalId = data.AnimalId;
                animal.Name = data.ShortName;
                animal.OwnerId = data.OwnerId.ToString();
                animal.IsDeleted = data.IsDeleted;
                await _applicationService.Handle(animal);
            }


        }

        public class AmimalUpdateConsumer : IConsumer<AnimalCommandsDto.V1.UpdateAnimal>
        {
            private readonly AnimalApplicationService _applicationService;
            public AmimalUpdateConsumer(AnimalApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<AnimalCommandsDto.V1.UpdateAnimal> context)
            {
                var data = context.Message;

                AnimalCommandsDTO.V1.UpdateAnimal animal = new AnimalCommandsDTO.V1.UpdateAnimal();
                animal.AnimalId = data.AnimalId;
                animal.Name = data.ShortName;
                animal.OwnerId = "en ownerid";
                animal.IsDeleted = false;
                await _applicationService.Handle(animal);
            }


        }


        public class AmimalDeleteConsumer : IConsumer<AnimalCommandsDto.V1.DeleteAnimal>
        {
            private readonly AnimalApplicationService _applicationService;
            public AmimalDeleteConsumer(AnimalApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<AnimalCommandsDto.V1.DeleteAnimal> context)
            {
                var data = context.Message;

                AnimalCommandsDTO.V1.DeleteAnimal animal = new AnimalCommandsDTO.V1.DeleteAnimal();
               animal.AnimalId = data.AnimalId;
                animal.IsDeleted = data.IsDeleted;
                await _applicationService.Handle(animal);
            }


        }
    }
}
