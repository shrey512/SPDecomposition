using Microservice.Application.Interfaces;
using Microservice.Domain.Entities;
using Microservice.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Infra.Repository
{
    public class MicroserviceRepo : IMicroserviceRepo
    {
        private readonly MicroserviceDbContext _dbContext;

        public MicroserviceRepo(MicroserviceDbContext microserviceDbContext)
        {
            _dbContext = microserviceDbContext;
        }

        public async Task<XrxProposal> GetFirstProposalAsync()
        {
            return await _dbContext.XrxProposals.FirstOrDefaultAsync();
        }

        public async Task<XrxSubscriber> GetFirstSubscriberAsync()
        {
            return await _dbContext.XrxSubscribers.FirstOrDefaultAsync();
        }
    }
}
