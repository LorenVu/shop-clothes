namespace MinimalProject.Endpoints.Banks;

public class BanksEndpoint : IEndpoint
{
    public string Group => nameof(BanksEndpoint).Split("Endpoint").First().ToLower();
    public string Version => "api/v1";
    
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        
    }
}