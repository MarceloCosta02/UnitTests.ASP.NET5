using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsAspNet5Test
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }
        protected string _GoodFileName;

        protected void WriteDescription(Type type)
        {
            string testName = TestContext.TestName;

            // Find the test method currently executing
            MemberInfo method = type.GetMethod(testName);
            if(method != null)
            {
                // See if the [Description] attribute exists on this test
                Attribute attr = method.GetCustomAttribute(typeof(DescriptionAttribute));
                if(attr != null)
                {
                    // Cast the attribute to a DescriptionAttribute
                    DescriptionAttribute dattr = (DescriptionAttribute)attr;

                    // Display the test description
                    TestContext.WriteLine("Test Description: " + dattr.Description);
                }
            }
        }

        protected void SetGoodFileName()
        {
            _GoodFileName = TestContext.Properties["GoodFileName"].ToString();
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
    }
}
