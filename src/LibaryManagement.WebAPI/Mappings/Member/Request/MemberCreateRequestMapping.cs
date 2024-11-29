using AutoMapper;
using LibaryManagement.Shared.Dtos.Member.Request;
using LibaryMangement.DL.Entities;

namespace LibaryManagement.WebAPI.Mappings.Member.Request;

public class MemberCreateRequestMapping : Profile
{
    public MemberCreateRequestMapping()
    {
        CreateMap<MemberRequestDto, MemberEntity>();
    }
}

