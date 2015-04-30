using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Cache
{
    using WechatPayment.SDK.Attritubes;
    using WechatPayment.SDK.Request;

    /// <summary>
    /// RequestEntity提供器
    /// </summary>
    internal class RequestEntityProvider
    {
        /// <summary>
        /// 通过反射获取type类型的必要信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static RequestEntityInfo Generate(Type type)
        {
            RequestEntityInfo result = new RequestEntityInfo
            {
                RequestType = type,
                PiArray = type.GetProperties()
            };

            for (int i = 0; i < result.PiArray.Length; i++)
            {
                RequestParameterAttribute attritube = Attribute.GetCustomAttribute(result.PiArray[i], typeof(RequestParameterAttribute)) as RequestParameterAttribute;
                if (attritube != null)
                {
                    string propertyName = result.PiArray[i].Name;
                    result.RequestParameterDict.Add(propertyName, attritube);
                    result.RequestIndexDict.Add(propertyName, i);
                    continue;
                }
            }

            return result;
        }
    }
}
