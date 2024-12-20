namespace MinimalProject.Endpoints;
public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder routeBuilder);
    string Group { get; }
    string Version { get; }
}