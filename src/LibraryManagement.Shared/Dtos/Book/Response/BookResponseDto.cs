using LibraryManagement.Shared.Enums;

namespace LibraryManagement.Shared.Dtos.Book.Response;

public class BookResponseDto
{
    public long BookId { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Genre { get; set; }

    public int PublishedYear { get; set; }

    public AvailabilityStatusEnum AvailabilityStatus { get; set; }
}