using AutoMapper;
using LibraryManagement.Shared.Dtos.Book.Response;
using LibraryMangement.DL.Entities;

namespace LibraryManagement.WebAPI.Mappings.Book.Response;

public class BookResponseMapping : Profile
{
    public BookResponseMapping()
    {
        CreateMap<BookEntity, BookResponseDto>();
    }
}
