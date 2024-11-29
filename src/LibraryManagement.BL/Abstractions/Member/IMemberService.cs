using LibraryManagement.Shared.Dtos.Member.Request;
using LibraryManagement.Shared.Dtos.Member.Response;

namespace LibraryManagement.BL.Abstractions.Member;

public interface IMemberService
{
    Task CreateMember(MemberRequestDto memberRequestDto);

    Task<IEnumerable<MemberResponseDto>> GetMembers();

    Task<MemberResponseDto> GetMemberById(long memberId);

    Task<MemberResponseDto> UpdateMemberById(
            long memberId,
            MemberRequestDto memberRequestDto);

    Task DeleteMemberById(long memberId);
}
