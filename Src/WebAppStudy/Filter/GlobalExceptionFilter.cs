using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace WebApiStudy.Api.Filter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 处理异常，例如记录日志等
            Log.Error(context.Exception, "An error occurred");
            // 返回自定义错误响应
            context.Result = new ObjectResult("Internal Server Error")
            {
                StatusCode = 500
            };
            // 标记异常已处理
            context.ExceptionHandled = true;
        }
    }
}
