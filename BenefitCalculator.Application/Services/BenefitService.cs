using Microsoft.EntityFrameworkCore;
using RateCalculator.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Application.Services
{
    public class BenefitService : IBenefitService
    {
        private readonly IRepository _repository;

        public BenefitService(IRepository repository)
        {
            _repository = repository;
        }

        public string BenefitLevelAgeCalc(DateTime PlanEffectiveDate)
        {
            try
            {
                if(PlanEffectiveDate != null)
                {
                    // Perform calculations
                    //var SP = _dbContext.XrxEmpEvents.FromSqlRaw("EXEC spSampleEvent").ToList();

                    var SP = _repository.ExecuteSampleProcedure();

                    var resultid = SP.Select(s=>s.Eventid).FirstOrDefault();
                    var resultcode = SP.Select(s => s.Eventcode).FirstOrDefault();

                    // If calculations succeed, return success message
                    return "BenefitLevelAgeCalc successful: SP success - output: EventId - " + resultid + "& EventCode - " + resultcode;
                }
                else
                {
                    return "BenefitLevelAgeCalc failed";
                }
            }
            catch (Exception ex)
            {
                return "BenefitLevelAgeCalc failed: " + ex.Message;
            }
        }
    }
}

