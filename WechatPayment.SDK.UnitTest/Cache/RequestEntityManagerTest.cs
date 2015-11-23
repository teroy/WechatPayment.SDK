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