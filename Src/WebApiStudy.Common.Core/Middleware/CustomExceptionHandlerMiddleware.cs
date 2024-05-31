using Microsoft.AspNetCore.Http;
using Serilog;

namespace WebApiStudy.Common.Core.Middleware
{
    /// <summary>
    /// 自定义异常处理中间件
    /// </summary>
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public CustomExceptionHandlerMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                // 处理异常逻辑, 例如记录日志、返回错误响应等
                Log.Error(ex, "An error occurred");
                context.Response.StatusCode = 500; // 设置错误状态码
                await context.Response.WriteAsync("Internal Server Error");
            }
        }
    }
}
