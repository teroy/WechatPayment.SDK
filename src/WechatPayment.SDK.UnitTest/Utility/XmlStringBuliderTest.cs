using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.UnitTest.Utility
{
    using WechatPayment.SDK.Utility;

    [TestFixture]
    public class XmlStringBuliderTest
    {
        [Test]
        public void Generate_输入非空的Dictionary_生成的XML字符串正确()
        {
            //arrange
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"a","1"},
                {"b","2"},
            };

            //act
            string target = XmlStringBulider.Generate(dict);

            //assert
            Assert.IsTrue(target == @"<xml><a>1</a><b>2</b></xml>");
        }
    }
}