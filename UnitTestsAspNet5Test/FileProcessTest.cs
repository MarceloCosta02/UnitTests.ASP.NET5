using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using UnitTestsAspNet5;

namespace UnitTestsAspNet5Test
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        private const string BAD_FILE_NAME = @"C:\NotExists.bad";         

        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            // Initialize for all tests in class
            tc.WriteLine("In ClassInitialize() method");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In TestInitialize() method");

            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    // Create the 'Good' file.
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }     

        [TestMethod]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
                       
            TestContext.WriteLine(@"Checking File " + _GoodFileName);

            fromCall = fp.FileExists(_GoodFileName);       

            Assert.IsTrue(fromCall);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("In TestCleanup() method");

            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                // Delete file
                if (File.Exists(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting file: " + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine(@"Checking File " + BAD_FILE_NAME);

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameIsNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            TestContext.WriteLine(@"Checking for a null or empty file");
            fp.FileExists(string.Empty);
        }

        [TestMethod]
        public void FileNameIsNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                TestContext.WriteLine(@"Checking for a null or empty file");
                fp.FileExists(string.Empty);
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Call to FileExists() did not throw an ArgumentNullException.");
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            // Clean up after all tests in class
        }
    }
}

