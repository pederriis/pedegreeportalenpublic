using MatingCalculator.Application.Intefaces;
using MatingCalculator.Domain.Disease;
using MatingCalculator.Domain.Dog;
using PedigreePortalen.Framework;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.ApplicationServices
{
    public class DiseaseApplicationService
    {
        private readonly IDiseaseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DiseaseApplicationService(IDiseaseRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 DiseaseCommandsDto.V1.CreateDisease cmd => HandleCreate(cmd),

                 DiseaseCommandsDto.V1.UpdateDisease cmd => HandleUpdate(cmd.DiseaseId,
                     c => c.UpdateDisease(Domain.Disease.Name.FromString(cmd.Name)
                         , Date.FromDateTime(cmd.Date)
                         , Note.FromString(cmd.Note) 
                         ,Probability.FromDouble(cmd.Probability)
                         ,IsHereditary.FromBool(cmd.IsHereditary) )),

                 DiseaseCommandsDto.V1.DeleteDisease cmd => HandleUpdate(cmd.DiseaseId,
                     c => c.DeleteDisease(Domain.Disease.IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(DiseaseCommandsDto.V1.CreateDisease cmd)
        {
            if (await _repository.DiseaseExists(cmd.DiseaseId))
                throw new InvalidOperationException($"Entity with id {cmd.DiseaseId} already exists");

            var disease = new Domain.Disease.Disease(

            new DiseaseId(cmd.DiseaseId),
            new Domain.HealthRecord.HealthRecordId(cmd.HealthRecordId),
            new Domain.Disease.Name(cmd.Name),
            new Date(cmd.Date),
            new Note(cmd.Note),
            new Probability(cmd.Probability),
            new IsHereditary(cmd.IsHereditary),

            new Domain.Disease.IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddDisease(disease);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid diseaseId, Action<Domain.Disease.Disease> operation)
        {
            var disease = await _repository.LoadDisease(diseaseId);

            if (disease == null)
                throw new InvalidOperationException($"Entity with id {diseaseId} cannot be found");

            operation(disease);

            await _unitOfWork.Commit();
        }
    }
}
