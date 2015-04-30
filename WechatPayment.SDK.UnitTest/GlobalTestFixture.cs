using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WechatPayment.SDK.UnitTest
{
    using WechatPayment.SDK;

    /// <summary>
    /// 全局测试，在该命名空间下的所有测试运行前都会自动运行这个类设置的方法
    /// </summary>
    [SetUpFixture]
    public class GlobalTestFixture
    {
        [SetUp]
        public void Setup()
        {
            //|||||||||||||||||||||||||||||||||||||||||||||||||||||
            //运行该类的测试的时候一定要先在这里配置相关的信息
            //|||||||||||||||||||||||||||||||||||||||||||||||||||||
            WechatPaymentConfig.Initalize(
                secret: "Test1",
                appId: "Test1",
                mchId: "Test1",
                certFilePath: ""
            );
        }
    }
}
