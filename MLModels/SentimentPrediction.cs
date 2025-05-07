using Microsoft.ML.Data;

namespace SentimentAnalysisAPI.MLModels
{
    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction;

        public float Probability;

        public float Score;
    }
}
