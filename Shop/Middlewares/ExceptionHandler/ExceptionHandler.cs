using System.Text;
using Microsoft.AspNetCore.Diagnostics;

namespace Shop.Middlewares.ExceptionHandler{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
                
                return true;
        }
    }
}
