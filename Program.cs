using SentimentAnalysisAPI.MLModels;
using SentimentAnalysisAPI.Services;

namespace SentimentAnalysisAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Train the ML model once at startup
            MLModelBuilder.TrainAndSaveModel();

            // Register services
            builder.Services.AddControllers();
            builder.Services.AddSingleton<SentimentService>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers(); // ← This was missing!

            app.Run();
        }
    }
}
