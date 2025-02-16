using System.Transactions;
using AutoMapper;
using MinimalApi.Application.Common.Dtos;

namespace MinimalApi.Application.Common;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Transaction, TransactionDto>();
    }
}