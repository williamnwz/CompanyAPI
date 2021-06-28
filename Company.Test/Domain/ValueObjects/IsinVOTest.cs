using Company.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Test.Domain.ValueObjects
{
    public class IsinVOTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        [TestCase("US0378331005")]
        [TestCase("US1104193065")]
        [TestCase("US1104193065")]
        public void ValidISIN(string isin)
        {
            IsinVO isinVO = new IsinVO(isin);
            bool isinVOValid = isinVO.IsValid();

            Assert.IsTrue(isinVOValid);
        }

        [Test]
        [TestCase("010378331005")]
        [TestCase("US110419306")]
        [TestCase("US11041930659")]
        public void InvalidISIN(string isin)
        {
            IsinVO isinVO = new IsinVO(isin);
            bool isinVOValid = isinVO.IsValid();

            Assert.IsFalse(isinVOValid);
        }
    }
}
