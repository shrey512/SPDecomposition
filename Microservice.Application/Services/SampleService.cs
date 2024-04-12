using Microservice.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Application.Services
{
    public class SampleService : ISampleService
    {
        private readonly IMicroserviceRepo _microserviceRepo;

        public SampleService(IMicroserviceRepo microserviceRepo)
        {
            _microserviceRepo = microserviceRepo;
        }

        public async Task<string> FetchBenefitDetails()
        {
            var proposal = await _microserviceRepo.GetFirstProposalAsync();
            var subscriber = await _microserviceRepo.GetFirstSubscriberAsync();

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44318/");
            string url = $"api/Rate/GetRateDeterminants/?proposal_id={proposal.ProposalId}&class_id={subscriber.ClassId}";
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return "Details Fetched. " + result;
            }
            else
            {
                throw new HttpRequestException($"FetchBenefits failed: {response.ReasonPhrase}");
            }
        }
    }
}
