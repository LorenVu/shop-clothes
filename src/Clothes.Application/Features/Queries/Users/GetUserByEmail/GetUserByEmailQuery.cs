using Clothes.Domain.Entities;
using MediatR;

namespace Clothes.Application.Features.Queries.Users.GetUserByEmail;

public record GetUserByEmailQuery(string Email) : IRequest<User?>;