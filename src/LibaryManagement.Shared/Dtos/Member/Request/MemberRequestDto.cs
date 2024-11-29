using System.ComponentModel.DataAnnotations;

namespace LibaryManagement.Shared.Dtos.Member.Request;

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