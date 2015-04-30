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
        public void Generate_DifferenctStrLengthParameter_ReturnStringLengthIsOk()
        {
            //arrange
            int strLengthNegative  = -1;
            int strLength0 = 0;
            int strLength32 = 32;

            //act
            string nonceStrNegative = RandomStringBulider.Generate(strLengthNegative);
            string nonceStr0 = RandomStringBulider.Generate(strLength0);
            string nonceStr32 = RandomStringBulider.Generate(strLength32);

            //assert
            Assert.IsTrue(nonceStrNegative.Length == 0);
            Assert.IsTrue(nonceStr0.Length == 0);
            Assert.IsTrue(nonceStr32.Length == 32);
        }
    }
}
