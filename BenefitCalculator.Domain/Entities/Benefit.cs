using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Domain.Entities
{
    public class Benefit
    {
        public int ProposalId { get; set; }
        public int ClassId { get; set; }
        public DateTime PlanEffectiveDate { get; set; }
        public int CalcAgeAtDateType { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public int EmpId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime DepBirthDate { get; set; }

    }
}
