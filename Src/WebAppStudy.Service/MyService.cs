using WebApiStudy.Service.Interface;

namespace WebApiStudy.Service
{
    /// <summary>
    /// 自定义服务
    /// </summary>
    public class MyService : IMyService
    {
        /// <summary>
        /// 执行某个操作
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public string DoSomething()
        {
            return "执行了某个操作";
        }
    }
}
