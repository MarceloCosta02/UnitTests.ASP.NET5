using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestsAspNet5Test
{
    [TestClass]
    public class StringAssertClassTest : TestBase
    {
        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "Steve Nystrom";
            string str2 = "Nystrom";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        public void StartsWithTest()
        {
            string str1 = "All Lower Case";
            string str2 = "All Lower";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        public void IsAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("all lower case", r);
        }

        [TestMethod]
        public void IsNotAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("All Lower Case", r);
        }
    }
}
