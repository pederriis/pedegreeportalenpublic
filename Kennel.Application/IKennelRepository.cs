using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kennel.Application
{
    public interface IKennelRepository
    {
        // Kennel 
        Task AddKennel(Domain.Kennel.Kennel entity);
        Task<bool> KennelExists(Guid id);
        Task<Domain.Kennel.Kennel> LoadKennel(Guid id);

        // Protokol
        Task AddProtokol(Domain.Protokol.Protokol entity);
        Task<bool> ProtokolExists(Guid id);
        Task<Domain.Protokol.Protokol> LoadProtokol(Guid id);
           
        // Owner
        Task AddOwner(Domain.Owner.Owner entity);
        Task<bool> OwnerExists(Guid id);
        Task<Domain.Owner.Owner> LoadOwner(Guid id);

        // Animal
        Task AddAnimal(Domain.Animal.Animal entity);
        Task<bool> AnimalExists(Guid id);
        Task<Domain.Animal.Animal> LoadAnimal(Guid id);

        // Parrent
        Task AddParrent(Domain.Parrent.Parrent entity);
        Task<bool> ParrentExists(Guid id);
        Task<Domain.Parrent.Parrent> LoadParrent(Guid id);

        // Parrent
        Task AddChild(Domain.Child.Child entity);
        Task<bool> ChildExists(Guid id);
        Task<Domain.Child.Child> LoadChild(Guid id);

        // Litter
        Task AddLitter(Domain.Litter.Litter entity);
        Task<bool> LitterExists(Guid id);
        Task<Domain.Litter.Litter> LoadLitter(Guid id);

        // HealthRecord
        Task AddHealthRecord(Domain.HealthRecord.HealthRecord entity);
        Task<bool> HealthRecordExists(Guid id);
        Task<Domain.HealthRecord.HealthRecord> LoadHealthRecord(Guid id);

        // Disease
        Task AddDisease(Domain.Disease.Disease entity);
        Task<bool> DiseaseExists(Guid id);
        Task<Domain.Disease.Disease> LoadDisease(Guid id);

        // Vaccination
        Task AddVaccination(Domain.Vaccination.Vaccination entity);
        Task<bool> VaccinationExists(Guid id);
        Task<Domain.Vaccination.Vaccination> LoadVaccination(Guid id);

        // HealthCertificate
        Task AddHealthCertificate(Domain.HealthCertificate.HealthCertificate entity);
        Task<bool> HealthCertificateExists(Guid id);
        Task<Domain.HealthCertificate.HealthCertificate> LoadHealthCertificate(Guid id);
    }
}
