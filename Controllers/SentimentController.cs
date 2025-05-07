using Microsoft.AspNetCore.Mvc;
using SentimentAnalysisAPI.Services;

namespace SentimentAnalysisAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentController : ControllerBase
    {
        private readonly SentimentService _sentimentService;

        public SentimentController(SentimentService sentimentService)
        {
            _sentimentService = sentimentService;
        }

        [HttpPost]
        public IActionResult Predict([FromBody] string input)
        {
            var result = _sentimentService.Predict(input);
            return Ok(new { Sentiment = result });
        }
    }
}
