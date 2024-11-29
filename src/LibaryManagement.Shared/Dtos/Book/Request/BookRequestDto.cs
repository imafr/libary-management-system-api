using LibaryManagement.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibaryManagement.Shared.Dtos.Book.Request;

public class BookRequestDto
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    public string Genre { get; set; }

    [Required]
    [Range(1000, 9999, ErrorMessage = "Please enter a valid year.")]
    public int PublishedYear { get; set; }

    public AvailabilityStatusEnum AvailabilityStatus { get; set; }
}