namespace LibaryManagement.Shared.Dtos.Member.Response;

public class MemberResponseDto
{
    public long MemberId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime MembershipStartDate { get; set; }
}