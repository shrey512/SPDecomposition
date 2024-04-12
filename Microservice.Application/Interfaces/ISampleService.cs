using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Application.Interfaces
{
    public interface ISampleService
    {
        Task<string> FetchBenefitDetails();
    }
}
