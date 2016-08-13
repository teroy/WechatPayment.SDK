using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Exceptions
{
    /// <summary>
    /// Request参数未填异常
    /// </summary>
    public class RequestParameterIsRequireException : ApplicationException
    {
        /// <summary>
        /// RequestParameterIsRequireException构造函数
        /// </summary>
        /// <param name="parameterName">请求参数名称</param>
        public RequestParameterIsRequireException(string parameterName)
            : base(string.Format("请求参数{0}为必填项", parameterName))
        {
        }
    }
}