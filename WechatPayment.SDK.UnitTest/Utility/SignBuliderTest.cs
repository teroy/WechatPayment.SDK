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
    public class SignBuliderTest
    {
        [Test]
        public void CreateJointStr_传入非空排序字典_链接字符串结果正确()
        {
            //arrange
            SortedDictionary<string, string> sortDict = new SortedDictionary<string, string>();
            sortDict.Add("a", "1");
            sortDict.Add("d", "2");
            sortDict.Add("b", "3");

            //act
            string jointStr = SignBulider.CreateJointStr(sortDict);

            //assert
            Assert.IsTrue(jointStr == "a=1&b=3&d=2&");
        }
    }
}
