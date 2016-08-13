using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.UnitTest.Utility
{
    using WechatPayment.SDK.Utility;

    [TestFixture]
    public class SortDictionaryConverterTest
    {
        [Test]
        public void Convert_输入非空的Dictionary_转化为SortedDictionary成功()
        {
            //arrange
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"d","d"},
                {"a","a"},
                {"c","c"},
            };

            //act
            SortedDictionary<string, string> target = SortDictionaryConverter.Convert(dict);

            //assert
            Assert.IsTrue(target.Count == 3);
            string str = string.Empty;
            foreach (var item in target)
            {
                str += item.Key;
            }
            Assert.IsTrue(str == "acd");
        }
    }
}