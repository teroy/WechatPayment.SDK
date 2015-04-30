using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Cache
{
    /// <summary>
    /// RequestEntityInfo管理器
    /// </summary>
    internal static class RequestEntityManager
    {
        /// <summary>
        /// 根据t获取RequestEntityInfo
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        internal static RequestEntityInfo GetBy(Type t)
        {
            if (!RequestEntityContainer.IsCached(t))
            {
                RequestEntityContainer.Store(t);
            }

            return RequestEntityContainer.GetBy(t);
        }
    }
}
