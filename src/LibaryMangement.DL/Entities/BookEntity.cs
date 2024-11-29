using System.ComponentModel.DataAnnotations;

namespace LibaryMangement.DL.Entities;

public class BookEntity : BaseEntity
{
    [Key]
    public long BookId { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Genre { get; set; }

    public int PublishedYear { get; set; }

    public string AvailabilityStatus { get; set; }
}