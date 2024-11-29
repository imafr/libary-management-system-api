using AutoMapper;
using LibraryManagement.Shared.Dtos.Member.Request;
using LibraryMangement.DL.Entities;

namespace LibraryManagement.WebAPI.Mappings.Member.Request;

public class MemberCreateRequestMapping : Profile
{
    public MemberCreateRequestMapping()
    {
        CreateMap<MemberRequestDto, MemberEntity>();
    }
}

