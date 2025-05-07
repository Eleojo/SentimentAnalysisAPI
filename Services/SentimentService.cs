using Microsoft.ML;
using SentimentAnalysisAPI.MLModels;

namespace SentimentAnalysisAPI.Services
{
    public class SentimentService
    {
        private readonly PredictionEngine<SentimentData, SentimentPrediction> _engine;

        public SentimentService()
        {
            var context = new MLContext();
            var model = context.Model.Load("MLModels/sentiment-model.zip", out _);
            _engine = context.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
        }

        public string Predict(string input)
        {
            var prediction = _engine.Predict(new SentimentData { Text = input });
            return prediction.Prediction ? "Positive" : "Negative";
        }
    }
}
