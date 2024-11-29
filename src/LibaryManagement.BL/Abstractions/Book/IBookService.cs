using LibaryManagement.Shared.Dtos.Book.Request;
using LibaryManagement.Shared.Dtos.Book.Response;

namespace LibaryManagement.BL.Abstractions.Book;

public interface IBookService
{
    Task CreateBook(BookRequestDto bookRequestDto);

    Task<IEnumerable<BookResponseDto>> GetBooks();

    Task<BookResponseDto> GetBookById(long bookId);

    Task<BookResponseDto> UpdateBookById(
            long bookId,
            BookRequestDto bookRequestDto);

    Task DeleteBookById(long bookId);

    Task BorrowBook(long bookId);
}
