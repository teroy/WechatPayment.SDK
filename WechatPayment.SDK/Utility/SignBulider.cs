using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Utility
{
    /// <summary>
    /// 签名生成器
    /// </summary>
    internal static class SignBulider
    {
        /// <summary>
        /// 生成签名操作
        /// </summary>
        /// <param name="sortedParameterDict">已排序的字典集合</param>
        /// <param name="appSecret">App秘匙</param>
        /// <returns></returns>
        internal static string Generate(SortedDictionary<string, string> sortedParameterDict, string appSecret)
        {
            string str = CreateJointStr(sortedParameterDict);
            str += "key=" + appSecret;
            string result = MD5Encrypt.Generate(str).ToUpper();
            return result;
        }

        /// <summary>
        /// 将sortedParameterDict的信息拼接成为连接字符
        /// </summary>
        /// <param name="sortedParameterDict"></param>
        /// <returns></returns>
        internal static string CreateJointStr(SortedDictionary<string, string> sortedParameterDict)
        {
            StringBuilder strBulider = new StringBuilder();
            foreach (var item in sortedParameterDict)
            {
                strBulider.Append(string.Format("{0}={1}&", item.Key, item.Value));
            }
            return strBulider.ToString();
        }
    }
}
