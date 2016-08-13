using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WechatPayment.SDK.Utility
{
    /// <summary>
    /// XmlSerializer包装类
    /// </summary>
    internal static class XmlSerializerWrapper
    {
        /// <summary>
        /// 将XML解析为泛型类T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        internal static T Deserialize<T>(string xmlStr)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlStr))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}