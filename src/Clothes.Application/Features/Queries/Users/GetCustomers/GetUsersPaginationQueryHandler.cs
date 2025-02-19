using Clothes.Application.Common.Dtos;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Seeds;
using MediatR;

namespace Clothes.Application.Features.Queries.Users.GetCustomers;

public class GetUsersPaginationQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUsersPaginationQuery, PagedList<UserDto>>
{
    public async Task<PagedList<UserDto>> Handle(GetUsersPaginationQuery request, CancellationToken cancellationToken)
    {
        var queryable = userRepository
            .GetAllAsync()
            .Select(u => new UserDto
            {
                UserName = u.UserName,
                Password = u.Password,
                FullName = u.FullName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PictureUrl = u.PictureUrl,
                EmailAddress = u.EmailAddress,
                IsDeleted = u.IsDeleted,
                IsActive = u.IsActive
            });

        // if (request.Filters is { Count: > 0 })
        //     queryable.Filtering(request.Filters);
        //
        // if (request.Orders is { Count: > 0 })
        //     queryable.Ordering(request.Orders);

        return await PagedList<UserDto>.ToPagedList(queryable, request.PageIndex, request.PageSize);
    }
}