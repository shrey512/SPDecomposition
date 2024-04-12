using Microsoft.EntityFrameworkCore;
using RateCalculator.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Application.Services
{
    public class AgeService : IAgeService
    {
        private readonly IBenefitService _benefitService;
        private readonly IRepository _repository;

        public AgeService(IBenefitService benefitService, IRepository repository)
        {
            _benefitService = benefitService;
            _repository = repository;
        }

        public string AgeCalc(DateTime PlanEffectiveDate)
        {
            try
            {
                if(PlanEffectiveDate != null)
                {

                        // Call BenefitLevelAgeCalc
                        var benefitLevelAgeCalcResult = _benefitService.BenefitLevelAgeCalc(PlanEffectiveDate);

                        // If BenefitLevelAgeCalc succeeds, return success message
                        return "AgeCalc successful. BenefitLevelAgeCalc result : " + benefitLevelAgeCalcResult;
                }
                else
                {
                    return "AgeCalc failed";
                }
            }
            catch (Exception ex)
            {
                return "AgeCalc failed: " + ex.Message;
            }
        }

        public DateTime? GetPlanEffectiveDate()
        {
            return _repository.GetPlanEffectiveDate();
        }
    }
}
