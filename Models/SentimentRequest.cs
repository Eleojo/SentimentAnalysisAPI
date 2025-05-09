using System.Text.Json.Serialization;

namespace SentimentAnalysisAPI.Models
{
    public class SentimentRequest
    {
        [JsonPropertyName("text")]

        public string Text { get; set; }
    }
}
