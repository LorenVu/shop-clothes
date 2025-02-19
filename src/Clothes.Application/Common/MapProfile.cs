using System.Transactions;
using AutoMapper;
using Clothes.Application.Common.Dtos;

namespace Clothes.Application.Common;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Transaction, TransactionDto>();
    }
}