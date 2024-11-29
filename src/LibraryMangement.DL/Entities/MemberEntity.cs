using System.ComponentModel.DataAnnotations;

namespace LibraryMangement.DL.Entities;

public class MemberEntity : BaseEntity
{
    [Key]
    public long MemberId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime MembershipStartDate { get; set; }
}