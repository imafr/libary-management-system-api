using AutoMapper;
using LibraryManagement.Shared.Dtos.Member.Response;
using LibraryMangement.DL.Entities;

namespace LibraryManagement.WebAPI.Mappings.Member.Response;

public class MemberResponseMapping : Profile
{
    public MemberResponseMapping()
    {
        CreateMap<MemberEntity, MemberResponseDto>();
    }
}
