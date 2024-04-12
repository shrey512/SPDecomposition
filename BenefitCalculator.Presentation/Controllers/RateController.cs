using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RateCalculator.Application.Interfaces;
using RateCalculator.Domain.Entities;

namespace RateCalculator.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IAgeService _ageService;

        public RateController(IAgeService ageService)
        {
            _ageService = ageService;
        }

        //GET: api/Rate/GetRateDeterminants
        [HttpGet("GetRateDeterminants")]
        public IActionResult GetRateDeterminants(int proposal_id, int class_id)
        {
            try
            {
                var planeffDate = _ageService.GetPlanEffectiveDate();     

                if (proposal_id != 0 && class_id != 0 && planeffDate != null)
                {
                    var ageCalcResult = _ageService.AgeCalc(planeffDate.Value);
                    return Ok("GetRateDeterminants successful. AgeCalc result: " + ageCalcResult);
                }
                else
                {
                    return StatusCode(500, "GetRateDeterminants failed");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "GetRateDeterminants failed: " + ex.Message);
            }
        }
    }
}
