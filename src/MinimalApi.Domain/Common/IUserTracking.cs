namespace MinimalApi.Domain.Commnon;

public interface IUserTracking
{
    public string? CreatedUser { get; set; }
    public string? LastModifiedUser { get; set; }
}