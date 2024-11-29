using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Shared.Dtos.Member.Request;

public class MemberRequestDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public DateTime MembershipStartDate { get; set; }
}