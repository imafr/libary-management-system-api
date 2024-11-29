using LibaryManagement.BL.Abstractions.Book;
using LibaryManagement.Shared.Dtos.Book.Request;
using Microsoft.AspNetCore.Mvc;

namespace LibaryManagement.WebAPI.Controllers.BookManagement;

[ApiController]
[Route("api/v1/books")]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] BookRequestDto bookRequestDto)
    {
        await bookService.CreateBook(bookRequestDto);

        return Created((string)null, null);
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        return Ok(await bookService.GetBooks());
    }

    [HttpGet("{bookId:long}")]
    public async Task<IActionResult> GetBookById([FromRoute] long bookId)
    {
        return Ok(await bookService.GetBookById(bookId));
    }

    [HttpPut("{bookId:long}")]
    public async Task<IActionResult> UpdateBookById(
        [FromRoute] long bookId,
        [FromBody] BookRequestDto bookRequestDto)
    {
        return Ok(await bookService.UpdateBookById(bookId, bookRequestDto));
    }

    [HttpDelete("{bookId:long}")]
    public async Task<IActionResult> DeleteBookById([FromRoute] long bookId)
    {
        await bookService.DeleteBookById(bookId);
        return NoContent();
    }


    [HttpPost("{bookId:long}/borrow")]
    public async Task<IActionResult> BorrowBook([FromRoute] long bookId)
    {
        await bookService.BorrowBook(bookId);

        return Accepted();
    }
}
