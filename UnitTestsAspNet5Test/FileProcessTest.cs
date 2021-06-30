using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestsAspNet5;

namespace UnitTestsAspNet5Test
{
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Windows\Regedit.exe");

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Windows\Teste.txt");

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameIsNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists(string.Empty);
        }

        [TestMethod]
        public void FileNameIsNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExists(string.Empty);
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Call to FileExists() did not throw an ArgumentNullException.");
        }
    }
}

