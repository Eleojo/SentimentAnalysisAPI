
using SentimentAnalysisAPI.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SentimentAnalysisAPI.Services
{

    public class SentimentService : ISentimentService
    {
        private readonly HttpClient _httpClient;

        public SentimentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SentimentResponse> AnalyzeSentimentAsync(SentimentRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            Console.WriteLine($"Sending: {json}");

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://127.0.0.1:8000/analyze", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(
                    $"Python API returned error {response.StatusCode}: {errorContent}");
            }


            var responseJson = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<SentimentResponse>(
                responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }

}