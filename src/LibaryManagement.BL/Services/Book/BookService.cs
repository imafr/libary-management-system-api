using AutoMapper;
using LibaryManagement.BL.Abstractions.Book;
using LibaryManagement.Shared.Dtos.Book.Request;
using LibaryManagement.Shared.Dtos.Book.Response;
using LibaryManagement.Shared.Enums;
using LibaryManagement.Shared.Exceptions;
using LibaryMangement.DL.Data;
using LibaryMangement.DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibaryManagement.BL.Services.Book;

public class BookService(ILogger<BookService> logger, IMapper mapper, AppDbContext appDbContext) : IBookService
{
    public async Task CreateBook(BookRequestDto bookRequestDto)
    {
        BookEntity bookEntity = mapper.Map<BookEntity>(bookRequestDto);

        await appDbContext.Books.AddAsync(bookEntity);
        await appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<BookResponseDto>> GetBooks()
    {
        List<BookEntity> books = await appDbContext.Books
                                    .Where(book => book.IsDeleted == false)
                                    .ToListAsync();

        return mapper.Map<IEnumerable<BookResponseDto>>(books);
    }

    public async Task<BookResponseDto> GetBookById(long bookId)
    {
        BookEntity bookEntity = await GetBookEntityById(bookId);

        return mapper.Map<BookResponseDto>(bookEntity);
    }

    public async Task<BookResponseDto> UpdateBookById(long bookId, BookRequestDto bookRequestDto)
    {
        BookEntity existBook = await GetBookEntityById(bookId);

        mapper.Map(bookRequestDto, existBook);

        await appDbContext.SaveChangesAsync();

        return mapper.Map<BookResponseDto>(existBook);
    }

    public async Task DeleteBookById(long bookId)
    {
        BookEntity existBook = await GetBookEntityById(bookId);
        existBook.IsDeleted = true;
        await appDbContext.SaveChangesAsync();
    }

    public async Task BorrowBook(long bookId)
    {
        BookEntity bookEntity = await appDbContext.Books
                                    .FirstOrDefaultAsync(book =>
                                            book.BookId == bookId &&
                                            book.IsDeleted == false &&
                                            book.AvailabilityStatus == nameof(AvailabilityStatusEnum.Available));
        if (bookEntity is null)
        {
            logger.LogInformation("The book with ID {BookId} is not currently available", bookId);
            throw new RecordNotFoundException($"The book with ID {bookId} is not currently available.");
        }

        bookEntity.AvailabilityStatus = nameof(AvailabilityStatusEnum.Borrowed);
        await appDbContext.SaveChangesAsync();
    }

    private async Task<BookEntity> GetBookEntityById(long bookId)
    {
        BookEntity bookEntity = await appDbContext.Books
                                    .FirstOrDefaultAsync(book =>
                                            book.BookId == bookId &&
                                            book.IsDeleted == false);

        if (bookEntity is null)
        {
            logger.LogInformation("Book with ID: {BookId} not found", bookId);
            throw new RecordNotFoundException($"Book with ID: {bookId} not found.");
        }

        return bookEntity;
    }
}
