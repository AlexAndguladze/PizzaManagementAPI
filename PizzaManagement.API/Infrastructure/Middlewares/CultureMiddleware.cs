﻿using System.Globalization;

namespace PizzaManagement.API.Infrastructure.Middlewares
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var cultureName = "Ka-GE";

            var queryCulture = context.Request.Headers["Accept-Language"].ToString();

            if (!string.IsNullOrWhiteSpace(queryCulture))
            {
                cultureName = queryCulture.Split(',')[0];
            }
            var culture = new CultureInfo(cultureName);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            await _next(context);
        }
    }
}
