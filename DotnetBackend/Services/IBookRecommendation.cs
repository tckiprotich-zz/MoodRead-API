namespace DotnetBackend.Services
{
    public interface IBookRecommendation
    {
        public  Task<ServiceResponse<List<BookDetails>>> GetBookRecommendation(string mood);
    }
}