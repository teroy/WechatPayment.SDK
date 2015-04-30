using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Attritubes
{
    /// <summary>
    /// 请求参数特性
    /// </summary>
    public class RequestParameterAttribute:Attribute
    {
        /// <summary>
        /// 请求参数名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 请求参数是否必须标记
        /// </summary>
        public bool IsRequire { get; private set; }

        /// <summary>
        /// 私有构造函数,不对外公布
        /// </summary>
        private RequestParameterAttribute()
        {

        }

        /// <summary>
        /// 公开构造函数
        /// </summary>
        /// <param name="name">请求参数名称</param>
        /// <param name="isRequire">请求参数是否必须标记</param>
        public RequestParameterAttribute(string name,bool isRequire = false)
        {
            Name = name;
            IsRequire = isRequire;
        }
    }
}
