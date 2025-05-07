using Microsoft.ML.Data;

namespace SentimentAnalysisAPI.MLModels
{
    public class SentimentData
    {
       
            [LoadColumn(0)]
            public string Text;

            [LoadColumn(1)]
            public bool Label;
        
    }
}
