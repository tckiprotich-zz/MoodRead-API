using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using COLLINS.Services;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Completions;
using COLLINS.Models;
using COLLINS.DTOs;

namespace COLLINS.Services
{
    public class BookRecommendation : IBookRecommendation
    {
        private readonly string openAiApiKey;
        private readonly string googleBooksApiKey;
        private readonly OpenAIAPI openAiApi;
        private readonly HttpClient httpClient;

        public BookRecommendation()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = configurationBuilder.Build();

            openAiApiKey = configuration["AppSettings:OpenAiApiKey"];
            // console
            System.Console.WriteLine("Api key is" + openAiApiKey);
            googleBooksApiKey = configuration["AppSettings:GoogleBooksApiKey"];

            openAiApi = new OpenAIAPI(openAiApiKey);
            httpClient = new HttpClient();
        }

        public async Task<ServiceResponse<List<BookDetails>>> GetBookRecommendation(string mood)
        {
            // recommendation text
            string recommendationText = "";
            // console recommendation string from frontend
            System.Console.WriteLine(recommendationText);

            // Send prompt to OpenAI API for feedback
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = "Book recommendations: " + recommendationText + "\n";
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 1024;

            var completions = await openAiApi.Completions.CreateCompletionAsync(completionRequest);
            string feedback = completions.Completions[0].Text;
            // for debugging purposes
            // System.Console.WriteLine(JsonConvert.SerializeObject(feedback, Formatting.Indented));

            // Split feedback into individual book recommendations
            string[] recommendations = feedback.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            // Call Google Books API to get book details for each recommendation
            List<BookDetails> books = new List<BookDetails>();
            foreach (string recommendation in recommendations)
            {
                string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q={Uri.EscapeDataString(recommendation)}&maxResults=1&langRestrict=en&key={googleBooksApiKey}";

                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return ServiceResponse<List<BookDetails>>.BadRequest($"Failed to get book details from Google Books API. Status code: {response.StatusCode}");
                    }

                    string content = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonConvert.DeserializeObject<GoogleBooksApiResponse>(content);
                    var book = apiResponse.Items[0].VolumeInfo;
                    books.Add(new BookDetails
                    {
                        Title = book.Title,
                        Authors = book.Authors,
                        Publisher = book.Publisher,
                        PublishedDate = book.PublishedDate,
                        Description = book.Description,
                        PageCount = book.PageCount,
                        SmallThumbnail = book.ImageLinks.SmallThumbnail,
                        Thumbnail = book.ImageLinks.Thumbnail,
                        PreviewLink = book.PreviewLink,
                        InfoLink = book.InfoLink

                    });


                }


            }

            // Return books as a JSON response
            return ServiceResponse<List<BookDetails>>.Ok(books);
        }
    }
}