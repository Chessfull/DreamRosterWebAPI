using DreamRosterBuilding.Business.Operations.Setting;

namespace DreamRosterBuilding.WebApi.Middlewares
{
    public class MaintenanceMiddleware // -> This is for controlling maintenance as middleware 
    {
        private readonly RequestDelegate _next;

        public MaintenanceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var _settingService = context.RequestServices.GetRequiredService<ISettingService>(); // -> prop injection

            bool maintenanceMode = _settingService.GetMaintenanceState();

            // ▼ This part for admin autharization and can access login request for login as admin I created exception endpoints ▼
            if (context.Request.Path.StartsWithSegments("/api/v1/auth/login") || context.Request.Path.StartsWithSegments("/api/v1/Settings/toggle-maintenance"))
            {
                await _next(context);
                return;
            }
            
            // ▼ Checking maintenance mode ▼
            if (maintenanceMode)
            {
                await context.Response.WriteAsync("Service is closed now ...");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
