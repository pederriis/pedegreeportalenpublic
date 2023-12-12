using HealthRecord.Domain.HealthCertificate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Application
{
   public interface IHealthCertificateRepository
    {
        Task AddHealthCertificate(HealthCertificate entity);
        Task<bool> HealthCertificateExists(Guid id);
        Task<HealthCertificate> LoadHealthCertificate(Guid id);
    }
}
