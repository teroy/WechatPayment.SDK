using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WechatPayment.SDK.UnitTest
{
    using WechatPayment.SDK;
    using WechatPayment.SDK.Request;
    using WechatPayment.SDK.Response;
    using WechatPayment.SDK.Notify;

    [TestFixture]
    public class WechatPaymentClientTest
    {
        [Test]
        [Ignore]
        //HACK(Teroy):这个测试一定要在GlobalTestFixture中的Setup方法中配置正确的信息才可以正确运行
        public void Excute_传入OrderQueryRequest_执行成功()
        {
            //arrange
            OrderQueryRequest request = new OrderQueryRequest
            {
                TradeNum = "TEMP"
            };

            //act
            OrderQueryResponse target = WechatPaymentClient.Excute(request);

            //assert
            Assert.IsTrue(target.IsSuccess == true);
        }

        [Test]
        public void ToPaymentResultNotify_输入常规的通知Xml字符串_对象转化正确()
        {
            //arrange
            string xmlStr = @"<xml>
                                <appid><![CDATA[wx2421b1c4370ec43b]]></appid>
                                <attach><![CDATA[支付测试]]></attach>
                                <bank_type><![CDATA[CFT]]></bank_type>
                                <fee_type><![CDATA[CNY]]></fee_type>
                                <is_subscribe><![CDATA[Y]]></is_subscribe>
                                <mch_id><![CDATA[10000100]]></mch_id>
                                <nonce_str><![CDATA[5d2b6c2a8db53831f7eda20af46e531c]]></nonce_str>
                                <openid><![CDATA[oUpF8uMEb4qRXf22hE3X68TekukE]]></openid>
                                <out_trade_no><![CDATA[1409811653]]></out_trade_no>
                                <result_code><![CDATA[SUCCESS]]></result_code>
                                <return_code><![CDATA[SUCCESS]]></return_code>
                                <sign><![CDATA[B552ED6B279343CB493C5DD0D78AB241]]></sign>
                                <sub_mch_id><![CDATA[10000100]]></sub_mch_id>
                                <time_end><![CDATA[20140903131540]]></time_end>
                                <total_fee>1</total_fee>
                                <trade_type><![CDATA[JSAPI]]></trade_type>
                                <transaction_id><![CDATA[1004400740201409030005092168]]></transaction_id>
                             </xml>";

            //act
            PaymentResultNotify target = WechatPaymentClient.ToPaymentResultNotify(xmlStr);

            //asset
            Assert.IsTrue(target.AppId == "wx2421b1c4370ec43b");
            Assert.IsTrue(target.Attach == "支付测试");
            Assert.IsTrue(target.BankType == "CFT");
            Assert.IsTrue(target.FeeType == "CNY");
            Assert.IsTrue(target.IsSubscribe == "Y");
            Assert.IsTrue(target.MerchantId == "10000100");
            Assert.IsTrue(target.NonceStr == "5d2b6c2a8db53831f7eda20af46e531c");
            Assert.IsTrue(target.OpenId == "oUpF8uMEb4qRXf22hE3X68TekukE");
            Assert.IsTrue(target.TradeNum == "1409811653");
            Assert.IsTrue(target.ResultCode == "SUCCESS");
            Assert.IsTrue(target.Code == "SUCCESS");
            Assert.IsTrue(target.Sign == "B552ED6B279343CB493C5DD0D78AB241");
            Assert.IsTrue(target.TimeEnd == "20140903131540");
            Assert.IsTrue(target.TotalFee == 1);
            Assert.IsTrue(target.TradeType == "JSAPI");
            Assert.IsTrue(target.TransactionId == "1004400740201409030005092168");
        }
    }
}
