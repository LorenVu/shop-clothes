using AutoMapper;
using Clothes.Application.Common.Dtos;
using Clothes.Domain.Entities;

namespace ClothesShop.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SepayTransactionDto, SepayTransaction>();
        // .IgnoreAllNonExisting();
    }
}