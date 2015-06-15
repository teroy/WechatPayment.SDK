using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WechatPayment.SDK.UnitTest.Utility
{
    using WechatPayment.SDK.Response;
    using WechatPayment.SDK.Utility;

    [TestFixture]
    public class XmlSerializerWrapperTest
    {
        [Test]
        public void Deserialize_输入UnifiedOrderResponse对象的xml字符串_解析正确()
        {
            //arrange
            string xmlStr = @"
                            <xml>
                                <return_code><![CDATA[SUCCESS]]></return_code>
                                <return_msg><![CDATA[OK]]></return_msg>
                                <appid><![CDATA[wx2421b1c4370ec43b]]></appid>
                                <mch_id><![CDATA[10000100]]></mch_id>
                                <nonce_str><![CDATA[IITRi8Iabbblz1Jc]]></nonce_str>
                                <sign><![CDATA[7921E432F65EB8ED0CE9755F0E86D72F]]></sign>
                                <result_code><![CDATA[SUCCESS]]></result_code>
                                <prepay_id><![CDATA[wx201411101639507cbf6ffd8b0779950874]]></prepay_id>
                                <trade_type><![CDATA[JSAPI]]></trade_type>
                            </xml>";
            
            //act
            UnifiedOrderResponse target = XmlSerializerWrapper.Deserialize<UnifiedOrderResponse>(xmlStr);

            //assert
            Assert.IsTrue(target.Code == "SUCCESS");
            Assert.IsTrue(target.Message == "OK");
            Assert.IsTrue(target.IsSuccess);
        }
    }
}
