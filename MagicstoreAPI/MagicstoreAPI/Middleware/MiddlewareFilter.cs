using MagicstoreAPI.Infrastructures;
using MagicstoreAPI.Infrastructures.Entities;
using Microsoft.AspNetCore.Html;

namespace MagicstoreAPI.Middleware
{
    public static class MiddlewareFilter
    {
        public static IApplicationBuilder UseMiddlewareFilter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareFilterRequest>();
        }
    }
    public class MiddlewareFilterRequest
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ILogger<MiddlewareFilterRequest> _logger;
        private readonly JwtSettings _jwtSettings;

        public MiddlewareFilterRequest(RequestDelegate next, IConfiguration configuration, ILogger<MiddlewareFilterRequest> logger, JwtSettings jwtSettings)
        {
            this._next = next;
            _configuration = configuration;
            _logger = logger;
            this._jwtSettings = jwtSettings;
        }
        public async Task InvokeAsync(HttpContext httpContext, ApplicationDBContext _dbContext)
        {
            try
            {
                #region TokenValidation          
                //Token needs to be save in the request authorization HEADERS **** ==>>>
                var token = httpContext.Request.Headers["Authorization"].ToString();
                if (!String.IsNullOrEmpty(token))
                {
                    await _next(httpContext);
                    return;
                }
                #endregion
            }
            catch (ApplicationException ex)
            {
                //este error ya se grabo en el Log desde el Filtro general de excepciones
                if (ex.Message != "Error no controlado en la API, ya se capturo en el archivo LOG.")
                    this._logger.LogError($"Error en el middleware de validacion de la APIKey, ApplicationException: {ex.Message}");

                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("Ocurrió un error interno en la API." + ex.Message);
                return;
            }
            catch (InvalidOperationException ex)
            {
                //throw new InvalidOperationException(ex.Message);
                this._logger.LogError($"Error en el middleware de validacion de la APIKey, InvalidOperationException: {ex.Message}");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("Ocurrió un error interno en la API." + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Error en el middleware de validacion de la APIKey: {ex.Message}");

                httpContext.Response.StatusCode = 400;
                await httpContext.Response.StartAsync();
                await httpContext.Response.WriteAsync(ex.Message);
                return;
            }
            await this._next(httpContext);
            }
    }
}