using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using HealthRecord.Domain.HealthRecord;

namespace HealthRecord.Application
{
    public interface IHealthRecordRepository
    {

        Task AddHealthRecord(Domain.HealthRecord.HealthRecord entity);
        Task<bool> HealthRecordExists(Guid id);
        Task<Domain.HealthRecord.HealthRecord> LoadHealthRecord(Guid id);

    }
}
