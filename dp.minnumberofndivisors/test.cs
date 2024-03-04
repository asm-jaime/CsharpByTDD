using NUnit.Framework;

namespace dpminnumberofndivisors;


    [TestFixture]
    public static class MinNbDivTests
    {

        [Test]
        public static void Test1()
        {
            Assert.AreEqual(1, MinNbDiv.FindMinNum(1));
            Assert.AreEqual(64, MinNbDiv.FindMinNum(7));
            Assert.AreEqual(24, MinNbDiv.FindMinNum(8));
            Assert.AreEqual(36, MinNbDiv.FindMinNum(9));
            Assert.AreEqual(12, MinNbDiv.FindMinNum(6));
        }
    }
