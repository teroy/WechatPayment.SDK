using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace WechatPayment.SDK.Utility
{
    using WechatPayment.SDK;

    /// <summary>
    /// WebClient包装类
    /// </summary>
    internal class HttpRequestWrapper
    {
        /// <summary>
        /// POST请求提交Xml数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        internal static string PostXml(string url, string xmlStr)
        {
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlStr);
            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type", "text/xml");
            byte[] responseBytes = wc.UploadData(url, "POST", xmlBytes);
            string result = Encoding.UTF8.GetString(responseBytes);
            return result;
        }

        /// <summary>
        /// 带证书的POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        internal static string PostXmlWithCertificate(string url, string xmlStr)
        {
            //生成证书对象
            X509Certificate2 cert = new X509Certificate2(WechatPaymentConfig.CERT_FILE_PATH, WechatPaymentConfig.SYS_PARAMETER_DICT["mch_id"]);
            //验证服务器证书的回调
            ServicePointManager.ServerCertificateValidationCallback = (sender, certficate, chain, errors) =>
            {
                if (errors == SslPolicyErrors.None)
                {
                    return true;
                }
                return false;
            };
            //生成带证书的HttpWebRequest对象
            HttpWebRequest webRequest = HttpWebRequest.Create(url) as HttpWebRequest;
            webRequest.ClientCertificates.Add(cert);
            webRequest.Method = "POST";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlStr);
            using (Stream stream = webRequest.GetRequestStream())
            {
                stream.Write(xmlBytes, 0, xmlBytes.Length);
            }
            //生成HttpWebResponse对象
            HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
            string result = string.Empty;
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream(),Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
