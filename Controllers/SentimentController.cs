using Microsoft.AspNetCore.Mvc;
using SentimentAnalysisAPI.Models;
using SentimentAnalysisAPI.Services;

namespace SentimentAnalysisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SentimentController : ControllerBase
    {
        private readonly ISentimentService _sentimentService;

        public SentimentController(ISentimentService sentimentService)
        {
            _sentimentService = sentimentService;
        }

        [HttpPost("analyze")]
        public async Task<ActionResult<SentimentResponse>> Analyze([FromBody] SentimentRequest request)
        {
            var result = await _sentimentService.AnalyzeSentimentAsync(request);
            return Ok(result);
        }
    }
}
