using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Domain.Entities
{
    public class BenefitDetails
    {
        public int ProposalId { get; set; }
        public int EmpId { get; set; }
        public int EventCode { get; set; }
        public string EmpXML { get; set; }
        public string DepXML { get; set; }
        public string Bene1XML { get; set; }
        public string Bene2XML { get; set; }
        public string Plan1XML { get; set; }
        public string CalcVarXML { get; set; }
    }
}
