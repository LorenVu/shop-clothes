using AutoMapper;
using Clothes.Domain.Entities;
using ClothesShop.API.Controllers.Dtos;

namespace ClothesShop.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SepayTransactionDto, SepayTransaction>();
        // .IgnoreAllNonExisting();
    }
}