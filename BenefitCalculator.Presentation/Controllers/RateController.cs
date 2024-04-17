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
        private readonly IDocumentGenerationService _documentGenerationService;

        public RateController(IAgeService ageService, IDocumentGenerationService documentGenerationService)
        {
            _ageService = ageService;
            _documentGenerationService = documentGenerationService;
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

        [HttpGet("GenerateDocument")]
        public IActionResult GenerateDocument()
        {
            try
            {
                string filepath = "C:\\Users\\shreyansjain5\\Desktop\\Output\\NewSampleDoc";
                _documentGenerationService.CreateDocument(filepath + ".docx");
                _documentGenerationService.CreatePDF(filepath + ".pdf");
                _documentGenerationService.CreateHTML(filepath + ".html");
                return Ok($"Document successfully created at {filepath}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error generating document: {ex.Message}");
            }
        }
    }
}
