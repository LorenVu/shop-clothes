namespace Clothes.Application.Common.Constrants.Requests;

public record TokenRequest(Guid Uid, string UserName, string Role);