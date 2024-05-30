namespace WebApiStudy.Common.Core.Base
{
    /// <summary>
    /// 操作执行结果
    /// </summary>
    /// <remarks>
    /// 继承此基类的参数类必须以Result为结尾
    /// </remarks>
    public class Result
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
        {
            get { return Code == "200"; }
            set { }
        }

        /// <summary>
        /// 操作反馈消息
        /// </summary>
        public string Msg
        {
            get;
            set;
        }
        /// <summary>
        /// 编码值
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        public Result()
        {
            Msg = "成功";
        }

        public Result(string _message)
        {
            Msg = _message;
        }

    }
    /// <summary>
    /// 操作执行结果
    /// </summary>
    /// <typeparam name="T">成功后返回的对象类型</typeparam>
    /// <remarks>
    /// 继承此基类的参数类必须以Result为结尾
    /// </remarks>
    public class Result<T> : Result
    {
        public Result() { }

        public Result(string _message)
        {
            Msg = _message;
        }

        /// <summary>
        /// 返回Result
        /// </summary>
        public Result PR
        {
            get { return this; }
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 文件流回参
    /// </summary>
    /// <typeparam name="T">成功后返回的对象类型</typeparam>
    /// <remarks>
    /// 继承此基类的参数类必须以Result为结尾
    /// </remarks>
    public class FileResult<T> : Result
    {
        public FileResult() { }

        public FileResult(string _message)
        {
            Msg = _message;
        }
        /// <summary>
        /// 返回数据
        /// </summary>
        public String FileContentType
        {
            get;
            set;
        }
        /// <summary>
        /// 文件名
        /// </summary>
        public String FileName
        {
            get;
            set;
        }
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data
        {
            get;
            set;
        }
    }
}
