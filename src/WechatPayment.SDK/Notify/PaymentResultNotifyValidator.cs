using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WechatPayment.SDK.Notify
{
    using WechatPayment.SDK;
    using WechatPayment.SDK.Utility;

    /// <summary>
    /// 微信支付回调验证器
    /// </summary>
    public class PaymentResultNotifyValidator
    {
        /// <summary>
        /// 验证Sign参数是否正确
        /// </summary>
        /// <param name="sign"></param>
        /// <returns></returns>
        public static bool VerifySign(string notifyXmlStr)
        {
            //将notifyXmlStr转化为XElement
            XElement root = XElement.Parse(notifyXmlStr);

            //将参数转化为Dictionary
            Dictionary<string, string> parameterDict = root.Elements()
                .ToDictionary(x => x.Name.ToString(), x => x.Value);

            //参数中不存在sign
            if (!parameterDict.Keys.Contains("sign"))
            {
                return false;
            }

            //获取参数中的sign
            string originSign = parameterDict["sign"];

            //移除参数中的sign
            parameterDict.Remove("sign");

            //得到parameterDict排序后的SortedDictionary
            SortedDictionary<string, string> sortedParameterDict = SortDictionaryConverter.Convert(parameterDict);

            //计算得到sign
            string caculateSign = SignBulider.Generate(sortedParameterDict, WechatPaymentConfig.SECRET);

            //返回Sign是否相等的判断
            return originSign == caculateSign;
        }
    }
}