using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStudy.Service.Interface;

namespace WebApiStudy.Service
{
    /// <summary>
    /// 自定义过滤器
    /// 使用Filter并支持依赖注入
    /// </summary>
    public class MyFilter : IFilterFactory // 1.创建一个实现了IFilterFactory接口的Filter
    {
        private readonly IMyService _myService;

        public MyFilter(IMyService myService)
        {
            _myService = myService;
        }

        public bool IsReusable => throw new NotImplementedException();

        /// <summary>
        /// 创建一个自定义过滤器实例
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new MyFilter(_myService);
        }
    }

    /// <summary>
    /// 自定义过滤器实例
    /// </summary>
    public class MyFilterInstance : IAsyncActionFilter
    {
        private readonly IMyService _myService;

        public MyFilterInstance(IMyService myService)
        {
            _myService = myService;
        }

        /// <summary>
        /// 在Action执行前执行
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // 在执行操作之前执行一些操作
            _myService.DoSomething();
            // 继续执行请求处理管道中的下一个阶段
            var resultContext = await next();
            // 在操作执行后执行一些操作
        }
    }
}
