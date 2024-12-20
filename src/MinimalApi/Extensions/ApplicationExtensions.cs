namespace MinimalProject.Extensions;

public static class ApplicationExtensions
{
    public static void UseInfrastructure(this IApplicationBuilder app, WebApplicationBuilder builder)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", 
            $"{builder.Environment.ApplicationName} v1"));
        
        app.UseAuthentication();
        app.UseRouting();
        //app.UseHttpsRedirection(); //for production only
        
        app.UseAuthorization();

        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }
}