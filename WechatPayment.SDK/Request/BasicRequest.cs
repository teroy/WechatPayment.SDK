using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Request
{
    using WechatPayment.SDK.Attritubes;
    using WechatPayment.SDK.Cache;
    using WechatPayment.SDK.Response;
    using WechatPayment.SDK.Exceptions;
    using WechatPayment.SDK.Utility;

    /// <summary>
    /// Request基础对象
    /// </summary>
    /// <typeparam name="T">继承于BasicResponse的类</typeparam>
    public abstract class BasicRequest<T> where T:BasicResponse
    {
        /// <summary>
        /// 访问微信支付的Url
        /// </summary>
        public abstract string ApiUrl { get; }

        /// <summary>
        /// 默认使用不需要调用证书的POST请求
        /// </summary>
        public virtual bool IsPostRequireCertificate { get { return false; } }

        /// <summary>
        /// 获取请求参数字典集合
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, string> GetParameterDict()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            RequestEntityInfo requestEntityInfo = RequestEntityManager.GetBy(this.GetType());
            foreach (var item in requestEntityInfo.RequestParameterDict)
            {
                string propertyName = item.Key;
                RequestParameterAttribute parameterAttritube = item.Value;
                string parameterName = parameterAttritube.Name;
                int piIndex = requestEntityInfo.RequestIndexDict[propertyName];
                object value = requestEntityInfo.PiArray[piIndex].GetValue(this, null);
                if (value != null && value.ToString() != string.Empty)
                {
                    result.Add(parameterName, value.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// 检验参数是否为必填项
        /// </summary>
        public virtual void Validate()
        {
            RequestEntityInfo requestEntityInfo = RequestEntityManager.GetBy(this.GetType());
            foreach (var item in requestEntityInfo.RequestParameterDict)
            {
                string propertyName = item.Key;
                RequestParameterAttribute parameterAttritube = item.Value;
                if (parameterAttritube.IsRequire)
                {
                    int piIndex = requestEntityInfo.RequestIndexDict[propertyName];                   
                    object o = requestEntityInfo.PiArray[piIndex].GetValue(this, null);
                    if (o == null || o.ToString() == string.Empty)
                    {
                        throw new RequestParameterIsRequireException(propertyName);
                    }
                }
            }
        }

        /// <summary>
        /// 每一个请求都要携带的随机字符串
        /// </summary>
        [RequestParameter("nonce_str", true)]
        public string NonceStr { get; set; }
    }
}
