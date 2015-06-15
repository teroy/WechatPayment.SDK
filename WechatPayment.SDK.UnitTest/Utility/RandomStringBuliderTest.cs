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
    public class RandomStringBuliderTest
    {
        [Test]
        public void Generate_输入大于0的生成随机数长度_返回参数长度一致()
        {
            //arrange
            int strLength32 = 32;
            int strLength12 = 12;

            //act
            string nonceStr32 = RandomStringBulider.Generate(strLength32);
            string nonceStr12 = RandomStringBulider.Generate(strLength12);

            //assert
            Assert.IsTrue(nonceStr32.Length == 32);
            Assert.IsTrue(nonceStr32.Length == 12);
        }
    }
}
