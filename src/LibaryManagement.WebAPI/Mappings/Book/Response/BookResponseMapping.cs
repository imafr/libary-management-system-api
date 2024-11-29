using AutoMapper;
using LibaryManagement.Shared.Dtos.Book.Response;
using LibaryMangement.DL.Entities;

namespace LibaryManagement.WebAPI.Mappings.Book.Response;

public class BookResponseMapping : Profile
{
    public BookResponseMapping()
    {
        CreateMap<BookEntity, BookResponseDto>();
    }
}
