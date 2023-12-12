using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthRecord.Domain.Disease;

namespace HealthRecord.Application
{
  public interface IDiseaseRepository
    {

      
            Task AddDisease(Disease entity);
            Task<bool> DiseaseExists(Guid id);
            Task<Disease> LoadDisease(Guid id);
        
    }
}
