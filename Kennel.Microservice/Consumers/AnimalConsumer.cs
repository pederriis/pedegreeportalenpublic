using Kennel.Application.ApplicationServices;
using MassTransit;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Consumers
{
    public static class AnimalConsumer
    {
        public class AmimalCreateConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.CreateAnimal>
        {
            private readonly AnimalApplicationService _applicationService;

            public AmimalCreateConsumer(AnimalApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.CreateAnimal> context)
            {
                var data = context.Message;

                AnimalCommandsDto.V1.CreateAnimal animal = new AnimalCommandsDto.V1.CreateAnimal();

                animal.AnimalId = data.AnimalId;
                animal.SubRaceId = data.SubRaceId.ToString();
                animal.RegNo = data.RegNo;
                animal.PedigreeName = data.PedigreeName;
                animal.BirthDate = data.BirthDate;
                animal.DeathDate = data.DeathDate;
                animal.Gender = data.Gender;
                animal.Color = data.Color;
                animal.IsBreedable = data.IsBreedable;
                animal.IsDeleted = data.IsDeleted;
                await _applicationService.Handle(animal);
            }
        }

        public class AmimalUpdateConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.UpdateAnimal>
        {
            private readonly AnimalApplicationService _applicationService;

            public AmimalUpdateConsumer(AnimalApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.UpdateAnimal> context)
            {
                var data = context.Message;

                AnimalCommandsDto.V1.UpdateAnimal animal = new AnimalCommandsDto.V1.UpdateAnimal();

                animal.AnimalId = data.AnimalId;
                animal.RegNo = data.RegNo;
                animal.PedigreeName = data.PedigreeName;
                animal.BirthDate = data.BirthDate;
                animal.DeathDate = data.DeathDate;
                animal.Gender = data.Gender;
                animal.Color = data.Color;
                animal.IsBreedable = data.IsBreedable;
                await _applicationService.Handle(animal);
            }
        }

        public class AmimalDeleteConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto.V1.DeleteAnimal>
        {
            private readonly AnimalApplicationService _applicationService;

            public AmimalDeleteConsumer(AnimalApplicationService applicationService)
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
