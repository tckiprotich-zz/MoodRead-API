using System.Collections.Generic;
using System.Threading.Tasks;
using COLLINS.Models;
using COLLINS.Services;
using Microsoft.AspNetCore.Mvc;



namespace COLLINS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookDetailsController : ControllerBase
    {
        private readonly IBookRecommendation bookRecommendation;

        public BookDetailsController(IBookRecommendation bookRecommendation)
        {
            this.bookRecommendation = bookRecommendation;
        }

        [HttpGet("{mood}")]
        public async Task<ActionResult<ServiceResponse<List<BookDetails>>>> Get(string mood)
        {
            return Ok(await bookRecommendation.GetBookRecommendation(mood));
        }
    }
}