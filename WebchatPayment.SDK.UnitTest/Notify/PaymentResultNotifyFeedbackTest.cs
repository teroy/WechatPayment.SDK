using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WechatPayment.SDK.UnitTest.Notify
{
    using WechatPayment.SDK.Notify;

    [TestFixture]
    public class PaymentResultNotifyFeedbackTest
    {
        [Test]
        public void StandardizeXmlText_Normal_IsOk()
        {
            //arrange     
            PaymentResultNotifyFeedback feedback = new PaymentResultNotifyFeedback();

            //act
            string target = feedback.StandardizeXmlText("123");
            string targetWithEmptyString = feedback.StandardizeXmlText("");

            //assert
            Assert.IsTrue(target == "<![CDATA[123]]>");
            Assert.IsTrue(targetWithEmptyString == "<![CDATA[]]>");
        }

        [Test]
        public void GenerateXmlString_Normal_IsOk()
        {
            //arrange     
            PaymentResultNotifyFeedback feedback = new PaymentResultNotifyFeedback();
            feedback.ReturnCode = "SUCCESS";

            //act
            string target = feedback.GenerateXmlString();

            //assert
            Assert.IsTrue(target == @"<xml><return_code><![CDATA[SUCCESS]]></return_code><return_msg><![CDATA[]]></return_msg></xml>");
        }
    }
}
