using Kennel.Domain.HealthRecord;
using Kennel.Domain.Vaccination;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Commands.VaccinationCommandsDto;

namespace Kennel.Application.ApplicationServices
{
    public class VaccinationApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKennelRepository _repository;

        public VaccinationApplicationService(IUnitOfWork unitOfWork, IKennelRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateVaccination cmd => HandleCreate(cmd),

                V1.UpdateVaccination cmd => HandleUpdate(cmd.VaccinationId,
                    c => c.UpdateVaccination(
                        VaccinationName.FromString(cmd.VaccinationName)
                        , VaccinationDate.FromDateTime(cmd.VaccinationDate))),

                V1.DeleteVaccination cmd => HandleUpdate(cmd.VaccinationId,
                    c => c.DeleteVaccination(Domain.Vaccination.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateVaccination cmd)
        {
            if (await _repository.AnimalExists(cmd.VaccinationId))
                throw new InvalidOperationException($"Entity with id {cmd.VaccinationId} already exists");

            var vaccination = new Vaccination(

            new VaccinationId(cmd.VaccinationId),
            new HealthRecordId(cmd.HealthRecordId),
            new VaccinationName(cmd.VaccinationName),
            new VaccinationDate(cmd.VaccinationDate),
            new Domain.Vaccination.IsDeleted(cmd.IsDeleted));

            await _repository.AddVaccination(vaccination);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid vaccinationId, Action<Vaccination> operation)
        {
            var vaccination = await _repository.LoadVaccination(vaccinationId);

            if (vaccination == null)
                throw new InvalidOperationException($"Entity with id {vaccinationId} cannot be found");

            operation(vaccination);

            await _unitOfWork.Commit();
        }
    }
}
