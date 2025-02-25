namespace BuildingBlock.Shared.DTOs.Identity;

public record TokenRequest(Guid Uid, string UserName, string Role);