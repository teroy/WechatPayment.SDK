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
        public void GetBy_Normal_IsOk()
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
