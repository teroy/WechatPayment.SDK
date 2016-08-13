using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Utility
{
    /// <summary>
    /// 随机字符串生成器
    /// </summary>
    internal static class RandomStringBulider
    {
        /// <summary>
        /// 数字和大写字母的数组集合
        /// </summary>
        internal static readonly string[] CHAR_ARRAY = new string[]
        {
            "0","1","2","3","4","5","6","7","8","9",
            "A","B","C","D","E","F","G","H","I","J",
            "K","L","M","N","O","P","Q","R","S","T",
            "U","V","W","X","Y","Z",
        };

        /// <summary>
        /// 生成数字和大写字母组合的随机字符串
        /// </summary>
        /// <param name="strLength">规定随机字符串的长度</param>
        /// <returns></returns>
        internal static string Generate(int strLength)
        {
            Random random = new Random();
            StringBuilder strBulider = new StringBuilder();
            for (int i = 0; i < strLength; i++)
            {
                int index = random.Next(CHAR_ARRAY.Length);
                strBulider.Append(CHAR_ARRAY[index]);
            }
            return strBulider.ToString();
        }
    }
}