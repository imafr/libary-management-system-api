﻿using AutoMapper;
using LibraryManagement.Shared.Dtos.Book.Request;
using LibraryMangement.DL.Entities;

namespace LibraryManagement.WebAPI.Mappings.Book.Request;

public class BookRequestMapping : Profile
{
    public BookRequestMapping()
    {
        CreateMap<BookRequestDto, BookEntity>()
            .ForMember(dest => dest.BookId, opt => opt.Ignore())
            .ForMember(dest => dest.AvailabilityStatus, opt => opt.MapFrom(src => src.AvailabilityStatus.ToString()))
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());
    }
}
