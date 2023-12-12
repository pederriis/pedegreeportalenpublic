using HealthRecord.Domain.Vaccination;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PedigreePortalen.Shared.HealthRecordMicroservice.Commands;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Commands.VaccinationCommandsDTO;
using HealthRecord.Domain.HealthRecord;

namespace HealthRecord.Application
{
    public class VaccinationApplicationService
    {
        private readonly IVaccinationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public VaccinationApplicationService(IVaccinationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 V1.CreateVaccination cmd => HandleCreate(cmd),

                 V1.UpdateVaccination cmd => HandleUpdate(cmd.VaccinationId,
                     c => c.UpdateVaccination(Name.FromString(cmd.Name)
                         , Date.FromDateTime(cmd.Date)
                         , IsDeleted.FromBool(cmd.IsDeleted))),

                 V1.DeleteVaccination cmd => HandleUpdate(cmd.VaccinationId,
                     c => c.DeleteVaccination(IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(V1.CreateVaccination cmd)
        {
            if (await _repository.VaccinationExists(cmd.VaccinationId))
                throw new InvalidOperationException($"Entity with id {cmd.VaccinationId} already exists");

            var vaccination = new Vaccination(

            new VaccinationId(cmd.VaccinationId),
            new HealthRecordId(cmd.HealthRecordId),
            new Name(cmd.Name),
            new Date(cmd.Date),
            new IsDeleted(cmd.IsDeleted)

                );

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
