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
    public class RequestEntityManagerTest
    {
        [Test]
        public void GetBy_输入类型参数_返回存储的类型一致()
        {
            //arrange
            Type t = typeof(UnifiedOrderRequest);

            //act
            RequestEntityInfo r = RequestEntityManager.GetBy(t);

            //assert
            Assert.IsTrue(t == r.RequestType);
        }
    }
}
