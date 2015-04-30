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
    public class PaymentResultNotifyValidatorTest
    {
        [Test]
        [Ignore]
        //HACK(Teroy): 运行这个测试必须要根据真实的数据生成sign 并替换下面的sign
        public void VerifySign_Normal_ReturnTrue()
        {
            //arrange
            string verifyXmlStr = @"<xml>
	                                    <appid>1</appid>
	                                    <mch_id>2</mch_id>
	                                    <nonce_str>XXX</nonce_str>
	                                    <out_trade_no>456</out_trade_no>
	                                    <transaction_id>123</transaction_id>
	                                    <sign>3672F4A5736CD5F16ED145ECA503FFFE</sign>
                                    </xml>";

            //act
            bool target = PaymentResultNotifyValidator.VerifySign(verifyXmlStr);

            //assert
            Assert.IsTrue(target);
        }

        [Test]
        public void VerifySign_InputWithoutSign_ReturnFalse()
        {
            //arrange
            string verifyXmlStr = @"<xml>
	                                    <appid>1</appid>
	                                    <mch_id>2</mch_id>
	                                    <nonce_str>XXX</nonce_str>
	                                    <out_trade_no>456</out_trade_no>
	                                    <transaction_id>123</transaction_id>
                                    </xml>";

            //act
            bool target = PaymentResultNotifyValidator.VerifySign(verifyXmlStr);

            //assert
            Assert.IsFalse(target);
        }
    }
}
