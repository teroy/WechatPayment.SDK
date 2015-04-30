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
    public class MD5EncryptTest
    {
        [Test]
        public void Generate_Normal_ResultLength32()
        {
            //arrange
            string originalStr = "Test";

            //act
            string target = MD5Encrypt.Generate(originalStr);

            //assert
            Assert.IsTrue(target.Length == 32);
        }

        [Test]
        public void Generate_SameInput_ResultIsSame()
        {
            //arrange
            string originalStr1 = "Test";
            string originalStr2 = "Test";

            //act
            string target1 = MD5Encrypt.Generate(originalStr1);
            string target2 = MD5Encrypt.Generate(originalStr2);

            //assert
            Assert.IsTrue(target1 == target2);
        }
    }
}
