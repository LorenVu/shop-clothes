using AutoMapper;
using Clothes.Application.Common.Dtos;
using Clothes.Domain.Entities;

namespace Clothes.Application.Common;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<SepayTransaction, SepayTransactionDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}