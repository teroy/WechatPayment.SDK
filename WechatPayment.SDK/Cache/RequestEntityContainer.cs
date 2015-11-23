using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Cache
{
    /// <summary>
    /// Request对象的缓存容器
    /// 将Request对象的反射信息缓存起来
    /// </summary>
    internal class RequestEntityContainer
    {
        /// <summary>
        /// 静态缓存字典
        /// key:Request对象的FullName
        /// value:Request对象的反射信息
        /// </summary>
        private static readonly Dictionary<string, RequestEntityInfo> DATA_DICT = new Dictionary<string, RequestEntityInfo>();

        /// <summary>
        /// 判断Request对象的反射信息是否在缓存字典中
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        internal static bool IsCached(Type type)
        {
            return DATA_DICT.ContainsKey(type.FullName);
        }

        /// <summary>
        /// 根据键值获取Type类型的反射信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static RequestEntityInfo GetBy(Type type)
        {
            return DATA_DICT[type.FullName];
        }

        /// <summary>
        /// 将type对象加入缓存中
        /// </summary>
        /// <param name="type"></param>
        internal static void Store(Type type)
        {
            lock (DATA_DICT)
            {
                if (!IsCached(type))
                {
                    RequestEntityInfo r = RequestEntityProvider.Generate(type);
                    DATA_DICT.Add(type.FullName, r);
                }
            }
        }
    }
}