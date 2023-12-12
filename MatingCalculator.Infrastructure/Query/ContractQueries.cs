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
    public class ContractQueries
    {

        private readonly MatingCalculatorDbContext _context;

        public ContractQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }



        public async Task<List<ContractQueriesDto.ContractDetails>> GetAllContractDetails()
        {
            return await _context.Contracts.Select(x => new ContractQueriesDto.ContractDetails


            {
                ContractId = x.ContractId,
                CreationDate = x.CreationDate,
                FemaleDogName = x.FemaleDogName,
                MaleDogName = x.MaleDogName,
                FemaleDogOwnerName = x.FemaleDogOwnerName,
                MaleDogOwnerName = x.MaleDogOwnerName,
                IsDeleted = x.IsDeleted,

            }).AsNoTracking()
                .ToListAsync();



        }
    }
}
