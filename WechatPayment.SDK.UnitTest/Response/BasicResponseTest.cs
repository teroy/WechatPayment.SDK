using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WechatPayment.SDK.UnitTest.Response
{
    using WechatPayment.SDK.Response;

    [TestFixture]
    public class BasicResponseTest
    {
        [Test]
        public void IsSuccess_BasicResponseCodeIsEmpty_ReturnFalse()
        {
            //arrange
            BasicResponse response = new BasicResponse();

            //act
            response.Code = "";
            
            //assert
            Assert.IsFalse(response.IsSuccess);
        }

        [Test]
        public void IsSuccess_CodeEqualsSUCCESS_ReturnTrue()
        {
            //arrange
            BasicResponse response = new BasicResponse();

            //act
            response.Code = "SUCCESS";

            //assert
            Assert.IsTrue(response.IsSuccess);
        }
    }
}
