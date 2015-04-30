using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace WechatPayment.SDK.Utility
{
    /// <summary>
    /// XmlString生成器
    /// </summary>
    internal static class XmlStringBulider
    {
        /// <summary>
        /// 将dict的键值字典生成xml字符串
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        internal static string Generate(Dictionary<string, string> dict)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement rootElement = xmlDoc.CreateElement("xml");
            foreach (var item in dict)
            {
                XmlElement e = xmlDoc.CreateElement(item.Key);
                e.InnerText = item.Value;
                rootElement.AppendChild(e);
            }
            xmlDoc.AppendChild(rootElement);
            return xmlDoc.InnerXml;
        }
    }
}
