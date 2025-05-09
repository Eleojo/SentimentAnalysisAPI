using System.Text.Json.Serialization;

namespace SentimentAnalysisAPI.Models
{
    public class SentimentResponse
    {

        public string Label { get; set; }
        public float Score { get; set; }
    }
}
