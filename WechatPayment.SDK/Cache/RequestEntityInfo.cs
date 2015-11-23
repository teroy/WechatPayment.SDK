using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Cache
{
    using WechatPayment.SDK.Attritubes;

    /// <summary>
    /// 反射获取Request对象的信息基类
    /// </summary>
    internal class RequestEntityInfo
    {
        /// <summary>
        /// Request的Type类型
        /// </summary>
        internal Type RequestType { get; set; }

        /// <summary>
        /// RequestType的属性数组信息
        /// </summary>
        internal PropertyInfo[] PiArray { get; set; }

        /// <summary>
        ///   key:Property的名字
        /// value:Property在PiArray的序号
        /// </summary>
        internal readonly Dictionary<string, int> RequestIndexDict = new Dictionary<string, int>();

        /// <summary>
        ///   key:Property的名字
        /// value:Property上的RequestParameterAttribute
        /// </summary>
        internal readonly Dictionary<string, RequestParameterAttribute> RequestParameterDict = new Dictionary<string, RequestParameterAttribute>();
    }
}