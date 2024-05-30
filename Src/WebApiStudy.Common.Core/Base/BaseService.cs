using System.Reflection;

namespace WebApiStudy.Common.Core.Base
{
    public class BaseService
    {
        /// <summary>
        /// 检查是否有权限
        /// </summary>
        /// <param name="key">权限值</param>
        /// <returns>1=有权限；0=无权限；-1未登录；-2=数据异常</returns>
        protected int CheckPermission(string key)
        {
            return 0;
        }

        /// <summary>
        /// 返回成功信息
        /// </summary>
        /// <param name="data">附加内容</param>
        /// <param name="msg">成功信息</param>
        /// <param name="code">编码</param>
        /// <returns>返回Result格式信息</returns>
        public Result<T> SuccessResult<T>(T data, string msg = "成功", string code = "200")
        {
            return new Result<T>()
            {
                Code = code,
                Msg = msg,
                Data = data
            };
        }

        /// <summary>
        /// 返回错误信息
        /// </summary>
        /// <param name="msg">错误信息</param>
        /// <param name="code">通用型：10001未登录（状态码401）；10002登录过期（状态码401）；204无内容；10021接口维护；10022接口停用；10023接口需要升级</param>
        /// <returns>返回Result格式信息</returns>
        public Result<T> ErrorResult<T>(string msg, string code = "0")
        {
            return new Result<T>()
            {
                Code = code,
                Msg = msg,
            };
        }

        /// <summary>
        /// 返回成功信息
        /// </summary>
        /// <param name="data">附加内容</param>
        /// <param name="msg">成功信息</param>
        /// <param name="code">编码</param>
        /// <returns>返回Result格式信息</returns>
        public Result<object> SuccessResult(object data = null, string msg = "成功", string code = "200")
        {
            return new Result<object>()
            {
                Code = code,
                Msg = msg,
                Data = data == null ? new { } : data
            };
        }

        /// <summary>
        /// 返回错误信息
        /// </summary>
        /// <param name="msg">错误信息</param>
        /// <param name="code">通用型：10001未登录（状态码401）；10002登录过期（状态码401）；204无内容；10021接口维护；10022接口停用；10023接口需要升级</param>
        /// <returns>返回Result格式信息</returns>
        public Result<object> ErrorResult(string msg, string code = "0", object data = null)
        {
            return new Result<object>()
            {
                Code = code,
                Msg = msg,
                Data = data,
            };
        }

        /// <summary>
        /// 返回成功信息(文件流)
        /// </summary>
        /// <param name="data">附加内容</param>
        /// <param name="msg">成功信息</param>
        /// <param name="code">编码</param>
        /// <returns>返回Result格式信息</returns>
        public FileResult<Stream> SuccessFileResult(string contenttype, string filename, Stream data = null, string msg = "成功", string code = "200")
        {
            return new FileResult<Stream>()
            {
                FileContentType = contenttype,
                FileName = filename,
                Code = code,
                Msg = msg,
                Data = data == null ? null : data
            };
        }

        /// <summary>
        /// 返回错误信息(文件流)
        /// </summary>
        /// <param name="msg">错误信息</param>
        /// <param name="code">通用型：10001未登录（状态码401）；10002登录过期（状态码401）；204无内容；10021接口维护；10022接口停用；10023接口需要升级</param>
        /// <returns>返回Result格式信息</returns>
        public FileResult<Stream> ErrorFileResult(string msg, string code = "0")
        {
            return new FileResult<Stream>()
            {
                Code = code,
                Msg = msg
            };
        }

        /// <summary>
        /// 当前方法名
        /// </summary>
        public string GetMethodName(MethodBase method)
        {
            return $"{method.DeclaringType.FullName}.{method.Name}";
        }
    }
}
