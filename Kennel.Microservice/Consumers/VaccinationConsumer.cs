using Kennel.Application.ApplicationServices;
using MassTransit;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Consumers
{
    public static class VaccinationConsumer
    {
        public class CreateVaccinationConsumer : IConsumer<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.VaccinationCommandsDTO.V1.CreateVaccination>
        {
            private readonly VaccinationApplicationService _applicationService;

            public CreateVaccinationConsumer(VaccinationApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.VaccinationCommandsDTO.V1.CreateVaccination> context)
            {
                var data = context.Message;

                VaccinationCommandsDto.V1.CreateVaccination vaccination = new VaccinationCommandsDto.V1.CreateVaccination();

                vaccination.VaccinationId = data.VaccinationId;
                vaccination.HealthRecordId = data.HealthRecordId;
                vaccination.VaccinationName = data.Name;
                vaccination.VaccinationDate = data.Date;
                vaccination.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(vaccination);
            }
        }

        public class UpdateVaccinationConsumer : IConsumer<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.VaccinationCommandsDTO.V1.UpdateVaccination>
        {
            private readonly VaccinationApplicationService _applicationService;

            public UpdateVaccinationConsumer(VaccinationApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.VaccinationCommandsDTO.V1.UpdateVaccination> context)
            {
                var data = context.Message;

                VaccinationCommandsDto.V1.UpdateVaccination vaccination = new VaccinationCommandsDto.V1.UpdateVaccination();

                vaccination.VaccinationId = data.VaccinationId;
                vaccination.VaccinationName = data.Name;
                vaccination.VaccinationDate = data.Date;

                await _applicationService.Handle(vaccination);
            }
        }

        public class DeleteVaccinationConsumer : IConsumer<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.VaccinationCommandsDTO.V1.DeleteVaccination>
        {
            private readonly VaccinationApplicationService _applicationService;

            public DeleteVaccinationConsumer(VaccinationApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.VaccinationCommandsDTO.V1.DeleteVaccination> context)
            {
                var data = context.Message;

                VaccinationCommandsDto.V1.DeleteVaccination vaccination = new VaccinationCommandsDto.V1.DeleteVaccination();

                vaccination.VaccinationId = data.VaccinationId;
                vaccination.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(vaccination);
            }
        }
    }
}
