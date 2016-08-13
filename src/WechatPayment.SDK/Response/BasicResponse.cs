using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WechatPayment.SDK.Response
{
    /// <summary>
    /// 微信支付SDK的Response基类
    /// </summary>
    public class BasicResponse
    {
        /// <summary>
        /// 状态码
        /// <example>SUCCESS/FAIL</example>
        /// </summary>
        [XmlElement("return_code")]
        public string Code { get; set; }

        /// <summary>
        /// 错误描述信息
        /// </summary>
        [XmlElement("return_msg")]
        public string Message { get; set; }

        /// <summary>
        /// 判断响应是否成功标记
        /// </summary>
        public bool IsSuccess { get { return Code == "SUCCESS"; } }

        /// <summary>
        /// 请求响应XML数据
        /// </summary>
        public string Body { get; set; }
    }
}