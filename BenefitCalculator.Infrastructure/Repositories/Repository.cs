using Microsoft.EntityFrameworkCore;
using RateCalculator.Application.Interfaces;
using RateCalculator.Domain.Entities;
using RateCalculator.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly RateCalcDbContext _dbContext;

        public Repository(RateCalcDbContext rateCalcDbContext)
        {
            _dbContext = rateCalcDbContext;
        }

        public List<XrxEmpEvent> ExecuteSampleProcedure()
        {
            return _dbContext.XrxEmpEvents.FromSqlRaw("EXEC spSampleEvent").ToList();
        }

        public DateTime? GetPlanEffectiveDate()
        {
            var proposal = _dbContext.XrxProposals.FirstOrDefault();
            return proposal?.PlanEffectiveDate;
        }
    }
}
