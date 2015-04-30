using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Utility
{
    /// <summary>
    /// SortDictionary转接器
    /// </summary>
    internal static class SortDictionaryConverter
    {
        /// <summary>
        /// 将Dictionary转接为SortDictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <returns></returns>
        internal static SortedDictionary<TKey, TValue> Convert<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            SortedDictionary<TKey, TValue> result = new SortedDictionary<TKey, TValue>();
            foreach (var item in dict)
            {
                result.Add(item.Key, item.Value);
            }
            return result;
        }
    }
}
