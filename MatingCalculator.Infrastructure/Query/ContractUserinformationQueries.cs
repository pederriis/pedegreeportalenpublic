using MatingCalculator.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Query
{
    public class ContractUserinformationQueries
    {
        private readonly MatingCalculatorDbContext _context;

        public ContractUserinformationQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }



        public async Task<List<ContractUserinformationQueriesDto.ContractUserinformationDetails>> GetAllContractUserinformationDetails()
        {
            return await _context.ContractUserinformations.Select(x => new ContractUserinformationQueriesDto.ContractUserinformationDetails


            {
                ContractUserinformationId = x.ContractUserinformationId,
                ContractId = x.ContractId,
                UserinformationId = x.UserinformationId,
                IsDeleted = x.IsDeleted,


            }).AsNoTracking()
              .ToListAsync();



        }
    }
}
