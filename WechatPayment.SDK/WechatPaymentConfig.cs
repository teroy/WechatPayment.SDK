using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK
{
    /// <summary>
    /// 微信支付配置参数
    /// </summary>
    public class WechatPaymentConfig
    {
        /// <summary>
        /// 秘匙
        /// </summary>
        internal static string SECRET = "";

        /// <summary>
        /// 微信支付证书路径
        /// </summary>
        internal static string CERT_FILE_PATH = "";

        /// <summary>
        /// 微信请求Api必传参数
        /// </summary>
        internal static Dictionary<string, string> SYS_PARAMETER_DICT = new Dictionary<string, string>
        {
            {"appid" , ""},//公众号Id
            {"mch_id", ""},//商户号Id
        };

        /// <summary>
        /// Request和Response调用（调用Notify不需要），初始化微信支付SDK所需外部参数，外部调用前一定要先调用Initalize方法
        /// </summary>
        /// <param name="secret">商户秘匙</param>
        /// <param name="appId">App分配Id</param>
        /// <param name="mchId">商户号Id</param>
        public static void Initalize(string secret, string appId, string mchId, string certFilePath)
        {
            SECRET = secret;
            SYS_PARAMETER_DICT["appid"] = appId;
            SYS_PARAMETER_DICT["mch_id"] = mchId;
            CERT_FILE_PATH = certFilePath;
        }
    }
}
