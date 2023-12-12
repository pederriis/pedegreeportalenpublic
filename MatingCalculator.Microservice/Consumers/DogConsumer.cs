using MassTransit;
using MatingCalculator.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatingCalculator.Microservice.Consumers
{
    public static class DogConsumer
    {
        public class DogCreateConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.CreateAnimal>
        {
            private readonly DogApplicationService _applicationService;

            public DogCreateConsumer(DogApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.CreateAnimal> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DogCommandsDto.V1.CreateDog dog = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DogCommandsDto.V1.CreateDog();


                dog.DogId = data.AnimalId;
                dog.UserinformationId = data.OwnerId;
                dog.Name = data.ShortName;
                dog.Gender = data.Gender;
                dog.SubRaceId = data.SubRaceId.ToString();
                dog.ChildAmount = 2;
                dog.IsDeleted = data.IsDeleted;


                await _applicationService.Handle(dog);
            }
        }

        public class DogUpdateConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.UpdateAnimal>
        {
            private readonly UserinformationApplicationService _applicationService;

            public DogUpdateConsumer(UserinformationApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.UpdateAnimal> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DogCommandsDto.V1.UpdateDog dog = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DogCommandsDto.V1.UpdateDog();

                dog.DogId = data.AnimalId;
                dog.Name = data.ShortName;
                dog.Gender = data.Gender;
                dog.ChildAmount = 2;

                await _applicationService.Handle(dog);
            }
        }


        public class DogDeleteConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.DeleteAnimal>
        {
            private readonly DogApplicationService _applicationService;

            public DogDeleteConsumer(DogApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.DeleteAnimal> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DogCommandsDto.V1.DeleteDog dog = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DogCommandsDto.V1.DeleteDog();


                dog.DogId = data.AnimalId;

                await _applicationService.Handle(dog);
            }
        }

        public class DogAddDogToLitterConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.AddAnimalToLitter>
        {
            private readonly DogApplicationService _applicationService;

            public DogAddDogToLitterConsumer(DogApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.AddAnimalToLitter> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DogCommandsDto.V1.AddDogToLitter dog = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DogCommandsDto.V1.AddDogToLitter();


                dog.DogId = data.AnimalId;
                dog.LitterId = data.LitterId;

                await _applicationService.Handle(dog);
            }
        }
    }
}
