using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Notify
{
    /// <summary>
    /// 微信支付异步结果通知反馈
    /// </summary>
    public class PaymentResultNotifyFeedback
    {
        /// <summary>
        /// 返回状态码
        /// <example>SUCCESS | FAIL</example>
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMessage { get; set; }

        /// <summary>
        /// 用<![CDATA[]]>包装str
        /// </summary>
        /// <returns></returns>
        internal string StandardizeXmlText(string str)
        {
            return string.Format(@"<![CDATA[{0}]]>", str);
        }

        /// <summary>
        /// 返回Feedback的XML字符串
        /// </summary>
        /// <returns></returns>
        public string GenerateXmlString()
        {
            string result = string.Format("<xml><return_code>{0}</return_code><return_msg>{1}</return_msg></xml>",
                StandardizeXmlText(ReturnCode), StandardizeXmlText(ReturnMessage));

            return result;
        }
    }
}