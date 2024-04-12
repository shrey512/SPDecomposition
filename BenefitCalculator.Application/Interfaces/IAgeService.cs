using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Application.Interfaces
{
    public interface IAgeService
    {
        string AgeCalc(DateTime PlanEffectiveDate);

        DateTime? GetPlanEffectiveDate();
    }
}
