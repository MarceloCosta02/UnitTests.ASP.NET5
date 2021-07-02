using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestsAspNet5;

namespace UnitTestsAspNet5Test
{
    [TestClass]
    public class GenericTest : TestBase
    {
        [TestMethod]
        public void AreEqualTest()
        {
            string str1 = "Marcelo";
            string str2 = "MARCELO";

            // Te parameter true its the ignore case sensitive
            Assert.AreEqual(str1, str2, true);
        }

        [TestMethod]
        public void AreNotEqualTest()
        {
            string str1 = "Marcelo";
            string str2 = "Bello";

            Assert.AreNotEqual(str1, str2);
        }

        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }
    }
}
