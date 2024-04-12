using Azure;
using Microservice.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitDetailController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public BenefitDetailController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }


        [HttpPost]
        public async Task<IActionResult> FetchBenefits(int EmpId)
        {
            try
            {
                if (EmpId != 0)
                {

                    // Read response content
                    var result = await _sampleService.FetchBenefitDetails();
                    return Ok("FetchBenefits Success. " + result);
                }
                else
                {
                    return StatusCode(500,"FetchBenefits failed");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "FetchBenefits failed: " + ex.Message);
            }
        }


        ////TEST
        //[HttpGet("DbTest")]
        //public async Task<IActionResult> DbTest()
        //{
        //    var proposals = await _dbContext.XrxProposals.ToListAsync();
        //    var subscribers = await _dbContext.XrxSubscribers.ToListAsync();
        //    var result = new
        //    {
        //        Proposals = proposals.Select(p => p.ProposalId),
        //        Subscribers = subscribers.Select(s => s.ClassId)
        //    };

        //    return Ok(result);
        //    //return Ok(await _dbContext.XrxProposals.ToListAsync());
        //}
    }
}
