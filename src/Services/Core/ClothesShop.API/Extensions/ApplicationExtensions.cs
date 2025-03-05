using Shared.Middlewares;

namespace ClothesShop.API.Extensions;

public static class ApplicationExtensions
{
    public static void UseInfrastructure(this IApplicationBuilder app, WebApplicationBuilder builder)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
            $"{builder.Environment.ApplicationName} v1"));

        app.UseResponseCompression();
        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());
        app.UseRouting();
        // app.UseHttpsRedirection(); //for production only
        app.UseResponseCaching();
        app.UseRequestTimeouts();
        app.UseExceptionHandling();
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.Map("/", context => Task.Run(() =>
                context.Response.Redirect("/swagger/index.html")));
            endpoints.MapDefaultControllerRoute();
        });
    }
}   