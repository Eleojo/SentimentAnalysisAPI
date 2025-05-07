using Microsoft.ML;

namespace SentimentAnalysisAPI.MLModels
{
    public class MLModelBuilder
    {
        private static readonly string _dataPath = Path.Combine("MLModels", "sentiment-data.tsv");
        private static readonly string _modelPath = Path.Combine("MLModels", "sentiment-model.zip");

        public static void TrainAndSaveModel()
        {
            var mlContext = new MLContext();

            var data = mlContext.Data.LoadFromTextFile<SentimentData>(_dataPath, hasHeader: false);

            var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());

            var model = pipeline.Fit(data);

            mlContext.Model.Save(model, data.Schema, _modelPath);
        }
    }
}
