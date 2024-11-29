using AutoMapper;
using LibaryManagement.Shared.Dtos.Member.Response;
using LibaryMangement.DL.Entities;

namespace LibaryManagement.WebAPI.Mappings.Member.Response;

public class MemberResponseMapping : Profile
{
    public MemberResponseMapping()
    {
        CreateMap<MemberEntity, MemberResponseDto>();
    }
}
