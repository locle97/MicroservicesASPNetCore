using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Book.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        public BooksController()
        {
        }

        [HttpGet(Name = "Get Books")]
        public async Task<IActionResult> GetBooks()
        {
            string[] books = ["A", "B"];
            return Ok(books);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost(Name = "Update Book")]
        public async Task<IActionResult> UpdateBook(int id, string name)
        {
            return Ok(new { id, name });
        }
    }
}
