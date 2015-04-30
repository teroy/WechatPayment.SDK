using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WechatPayment.SDK.UnitTest.Utility
{
    using WechatPayment.SDK.Utility;

    [TestFixture]
    public class XmlStringBuliderTest
    {
        [Test]
        public void Generate_Normal_ResultOk()
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
