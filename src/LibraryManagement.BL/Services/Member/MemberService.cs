using AutoMapper;
using LibraryManagement.BL.Abstractions.Member;
using LibraryManagement.Shared.Dtos.Member.Request;
using LibraryManagement.Shared.Dtos.Member.Response;
using LibraryManagement.Shared.Exceptions;
using LibraryMangement.DL.Data;
using LibraryMangement.DL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.BL.Services.Member;

public class MemberService(ILogger<MemberService> logger, IMapper mapper, AppDbContext appDbContext) : IMemberService
{
    public async Task CreateMember(MemberRequestDto memberRequestDto)
    {
        MemberEntity memberEntity = mapper.Map<MemberEntity>(memberRequestDto);

        await appDbContext.Members.AddAsync(memberEntity);
        await appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<MemberResponseDto>> GetMembers()
    {
        List<MemberEntity> members = await appDbContext.Members
                                    .Where(member => member.IsDeleted == false)
                                    .ToListAsync();

        return mapper.Map<IEnumerable<MemberResponseDto>>(members);
    }

    public async Task<MemberResponseDto> GetMemberById(long memberId)
    {
        MemberEntity memberEntity = await GetMemberEntityById(memberId);

        return mapper.Map<MemberResponseDto>(memberEntity);
    }

    public async Task<MemberResponseDto> UpdateMemberById(long memberId, MemberRequestDto memberRequestDto)
    {
        MemberEntity existMember = await GetMemberEntityById(memberId);

        mapper.Map(memberRequestDto, existMember);

        await appDbContext.SaveChangesAsync();

        return mapper.Map<MemberResponseDto>(existMember);
    }

    public async Task DeleteMemberById(long memberId)
    {
        MemberEntity existMember = await GetMemberEntityById(memberId);
        existMember.IsDeleted = true;
        await appDbContext.SaveChangesAsync();
    }

    private async Task<MemberEntity> GetMemberEntityById(long memberId)
    {
        MemberEntity memberEntity = await appDbContext.Members
                                    .FirstOrDefaultAsync(member =>
                                            member.MemberId == memberId &&
                                            member.IsDeleted == false);

        if (memberEntity is null)
        {
            logger.LogInformation("Member with ID: {MemberId} not found", memberId);
            throw new RecordNotFoundException($"Member with ID: {memberId} not found.");
        }

        return memberEntity;
    }
}
