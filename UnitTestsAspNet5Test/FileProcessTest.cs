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

        #region Class Initialize and Cleanup

        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            // Initialize for all tests in class
            tc.WriteLine("In ClassInitialize() method");
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            // Clean up after all tests in class
        }

        #endregion

        #region Test Initialize and Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In TestInitialize() method");

            WriteDescription(this.GetType());

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

        #endregion


        [TestMethod]
        [Description("Check to see if a file exists.")]
        [Owner("Marcelo")]
        [Priority(4)]
        [TestCategory("No Exception")]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine(@"Checking File " + _GoodFileName);

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if a file does not exists.")]
        [Owner("Marcelo")]
        [Priority(3)]
        [TestCategory("Exception")]
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
        [Description("Check for a thrown ArgumentNullException using ExpectedException.")]
        [Owner("Marcelo")]
        [Priority(2)]
        [TestCategory("Exception")]
        [Timeout(3000)]
        public void FileNameIsNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            TestContext.WriteLine(@"Checking for a null or empty file");
            fp.FileExists(string.Empty);
        }

        [TestMethod]
        [Description("Check for a thrown ArgumentNullException using try ... catch.")]
        [Owner("Marcelo")]
        [Priority(1)]
        [TestCategory("Exception")]
        //[Ignore]
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

        [TestMethod]
        [DataRow(1, 1, DisplayName = "First Test (1, 1)" )]
        [DataRow(42, 42, DisplayName = "Second Test (42, 42)")]
        public void AreNumbersEqual(int num1, int num2)
        {
            Assert.AreEqual(num1, num2);
        }

        [TestMethod]
        [DeploymentItem("FileToDeploy.txt")]
        [DataRow(@"C:\Windows\Regedit.exe", DisplayName = "Regedit.exe")]
        [DataRow("FileToDeploy.txt", DisplayName = "Deployment Item: FileToDeploy")]
        public void FileNameUsingDataRow(string fileName)
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            if (!fileName.Contains(@"\"))
            {
                fileName = TestContext.DeploymentDirectory + @"\" + fileName;
            }
            TestContext.WriteLine("Checking File " + fileName);
            fromCall = fp.FileExists(fileName);
            Assert.IsTrue(fromCall);
        }
    }
}

