using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WechatPayment.SDK.UnitTest.Cache
{
    using WechatPayment.SDK.Request;
    using WechatPayment.SDK.Cache;

    [TestFixture]
    public class RequestEntityProviderTest
    {
        [Test]
        public void Generate_RequestEntityInfo_IsOk()
        {
            //arrange
            Type type = typeof(UnifiedOrderRequest);

            //act
            RequestEntityInfo target = RequestEntityProvider.Generate(type);

            //assert
            Assert.IsTrue(target.RequestParameterDict.Count == 16);
            Assert.IsTrue(target.RequestIndexDict.Count == 16);
        }
    }
}
