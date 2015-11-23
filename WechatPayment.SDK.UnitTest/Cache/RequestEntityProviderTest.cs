using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.UnitTest.Cache
{
    using WechatPayment.SDK.Cache;
    using WechatPayment.SDK.Request;

    [TestFixture]
    public class RequestEntityProviderTest
    {
        [Test]
        public void Generate_输入类型参数_返回的RequestEntityInfo对象内部信息正确()
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