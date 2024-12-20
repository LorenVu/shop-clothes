using AutoMapper;

namespace MinimalApi.Application.Common.Map;

public interface IMapFrom<T>
{
    public void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}