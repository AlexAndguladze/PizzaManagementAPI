using PizzaManagement.API.Infrastructure.Middlewares;

namespace PizzaManagement.API.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CultureMiddleware>();
        }
    }
}
