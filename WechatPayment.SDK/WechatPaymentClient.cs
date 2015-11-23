using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK
{
    using WechatPayment.SDK.Notify;
    using WechatPayment.SDK.Request;
    using WechatPayment.SDK.Response;
    using WechatPayment.SDK.Utility;

    /// <summary>
    /// 微信支付请求处理器
    /// </summary>
    public static class WechatPaymentClient
    {
        /// <summary>
        /// Client执行接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static T Excute<T>(BasicRequest<T> request) where T : BasicResponse
        {
            //设置request对象的随机字符串
            request.NonceStr = RandomStringBulider.Generate(32);

            //1.首先执行参数验证，如果参数提供有误，会抛出异常
            request.Validate();

            //2.得到请求的所有参数字典,调用request.GetParameterDict()可以获得Request的应用参数，同时要将SYS_PARAMETER_DICT系统参数也加入
            Dictionary<string, string> paramterDict = request.GetParameterDict()
                .Concat(WechatPaymentConfig.SYS_PARAMETER_DICT).ToDictionary(k => k.Key, v => v.Value);

            //3.将参数字典的key值按字母顺序排序（按ASCII排序，例如a在b前面）
            SortedDictionary<string, string> sortedParameterDict = SortDictionaryConverter.Convert(paramterDict);

            //4.拼接计算Sign参数
            string sign = SignBulider.Generate(sortedParameterDict, WechatPaymentConfig.SECRET);

            //5.将sign参数加入到参数字典中
            paramterDict.Add("sign", sign);

            //6.将paramterDict字典转化为XML格式
            string requestXml = XmlStringBulider.Generate(paramterDict);

            //7.提交请求到微信服务器，获取响应的字符串
            //HACK(Teroy):退款API在POST的时候要带证书,其他API请求不用
            string responseXml = request.IsPostRequireCertificate ?
                HttpRequestWrapper.PostXmlWithCertificate(request.ApiUrl, requestXml) : HttpRequestWrapper.PostXml(request.ApiUrl, requestXml);

            //8.将响应的XML数据实例化为T类型
            T result = XmlSerializerWrapper.Deserialize<T>(responseXml);

            //9.将响应的XML数据预存到Body中
            result.Body = responseXml;

            return result;
        }

        /// <summary>
        /// 将微信支付自动通知的xml字符串数据转化为PaymentResultNotifyResponse对象
        /// </summary>
        /// <param name="notifyXmlStr">xml字符串数据</param>
        /// <returns></returns>
        public static PaymentResultNotify ToPaymentResultNotify(string notifyXmlStr)
        {
            PaymentResultNotify result = XmlSerializerWrapper.Deserialize<PaymentResultNotify>(notifyXmlStr);
            return result;
        }
    }
}