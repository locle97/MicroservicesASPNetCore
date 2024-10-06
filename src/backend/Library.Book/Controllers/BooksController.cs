using Library.Book.Domains.Entities;
using Library.Book.Domains.Exceptions;
using Library.Book.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Book.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet(Name = "Get Books")]
        public async Task<IActionResult> GetBooks()
        {
            IEnumerable<BookEntity> books = await _bookService.GetBooks();
            return Ok(books);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("{id}", Name = "Update Book")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookEntity updatedBook)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                BookEntity dbBook = await _bookService.UpdateBook(id, updatedBook);
                return Ok(dbBook);
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
