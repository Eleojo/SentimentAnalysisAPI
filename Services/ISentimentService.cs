using SentimentAnalysisAPI.Models;

namespace SentimentAnalysisAPI.Services
{
    public interface ISentimentService

    {
        Task<SentimentResponse> AnalyzeSentimentAsync(SentimentRequest request);
    }
    
}
