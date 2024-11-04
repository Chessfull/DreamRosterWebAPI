namespace DreamRosterBuilding.WebApi.Middlewares
{
    public static class MiddlewareExtensions // -> This is for program.cs usage if you dont do this you can describe like UseMiddleware<MaintenanceMiddleware> in program.cs as well
    {
        public static IApplicationBuilder UseMaintenanceMode(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<MaintenanceMiddleware>();
        }
    }
}
