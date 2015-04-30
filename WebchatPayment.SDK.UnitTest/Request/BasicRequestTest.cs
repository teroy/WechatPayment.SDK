using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WechatPayment.SDK.UnitTest.Request
{
    using WechatPayment.SDK.Request;
    using WechatPayment.SDK.Exceptions;

    [TestFixture]
    public class BasicRequestTest
    {
        [Test]
        public void Validate_ParameterIsFull_NotThrowException()
        {
            //arrange
            UnifiedOrderRequest request = new UnifiedOrderRequest();
            request.Desc = "Temp";
            request.TradeNum = "Temp";
            request.TotalFee = 100;
            request.SpbillCreateIp = "Temp";
            request.TradeType = "Temp";
            request.NotifyUrl = "www.baidu.com";
            request.NonceStr = "123456789";

            //act  
            request.Validate();

            //assert    
            
        }

        [Test]
        public void Validate_RequireParameterIsEmpty_ThrowException()
        {
            //arrange
            UnifiedOrderRequest request = new UnifiedOrderRequest();

            //act
            TestDelegate testDelegate = () => request.Validate();

            //assert
            Assert.Throws<RequestParameterIsRequireException>(testDelegate);
        }

        [Test]
        public void Validate_TradeTypeIsNATIVEProductIdIsEmpty_ThrowException()
        {
            //arrange
            UnifiedOrderRequest request = new UnifiedOrderRequest();
            request.Desc = "Temp";
            request.TradeNum = "Temp";
            request.TotalFee = 100;
            request.SpbillCreateIp = "Temp";
            request.TradeType = "NATIVE";
  
            //act
            TestDelegate testDelegate = () => request.Validate();

            //assert
            Assert.Throws<RequestParameterIsRequireException>(testDelegate);
        }

        [Test]
        public void GetParameterDict_Normal_IsOk()
        {
            //arrange
            UnifiedOrderRequest request = new UnifiedOrderRequest();
            request.Desc = "Desc";
            request.TradeNum = "TradeNum";
            request.TotalFee = 100;
            request.SpbillCreateIp = "SpbillCreateIp";
            request.TradeType = "TradeType";

            //act
            Dictionary<string, string> target = request.GetParameterDict();

            //assert
            Assert.IsTrue(target.Count == 5);
            Assert.IsTrue(target["body"] == "Desc");
            Assert.IsTrue(target["out_trade_no"] == "TradeNum");
            Assert.IsTrue(target["total_fee"] == "100");
            Assert.IsTrue(target["spbill_create_ip"] == "SpbillCreateIp");
            Assert.IsTrue(target["trade_type"] == "TradeType");
        } 
    }
}
