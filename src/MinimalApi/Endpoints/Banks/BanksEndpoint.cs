namespace MinimalProject.Endpoints.Banks;

public class BanksEndpoint : IEndpoint
{
    public string Group { get; }
    public string Version { get; }
    
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        throw new NotImplementedException();
    }
}