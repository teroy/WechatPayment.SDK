using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Utility
{
    /// <summary>
    /// MD5加密
    /// </summary>
    internal static class MD5Encrypt
    {
        /// <summary>
        /// 加密函数
        /// </summary>
        /// <param name="originalStr">原始字符串</param>
        /// <returns>MD5加密后的字符串</returns>
        internal static string Generate(string originalStr)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(originalStr));
            StringBuilder strBulider = new StringBuilder();
            foreach (byte item in data)
            {
                strBulider.Append(item.ToString("x2"));
            }
            return strBulider.ToString();
        }
    }
}