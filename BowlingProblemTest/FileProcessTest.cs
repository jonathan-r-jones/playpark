using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingProblem;
using System;
using System.Configuration;

namespace BowlingProblemTest
{
    [TestClass]
    public class ProcessTest
    {
        private const string BAD_FILENAME = @"C:\bad_filename.bad";
        //private string _GoodFilename;

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void FilenameDoesExist()
        {
            FileProcess fileProcess = new FileProcess();
            Assert.IsTrue(fileProcess.FileExists(@"c:\a\j1.txt"));
        }
        [TestMethod]
        public void FilenameDoesNotExist()
        {
            FileProcess fileProcess = new FileProcess();
            TestContext.WriteLine("tttest.  ******************************** ");
            Assert.IsFalse(fileProcess.FileExists(BAD_FILENAME));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilenameNullorEmpty_ThrowsArgumentNullException()
        {
            FileProcess fileProcess = new FileProcess();
            try
            {
                fileProcess.FileExists("");
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
        }
        [TestMethod]
        public void FilenameNullorEmpty()
        {
            FileProcess fileProcess = new FileProcess();
            try
            {
                fileProcess.FileExists("");
            }
            catch (ArgumentNullException)
            {
                // The test succeeded.
                return;
            }
            Assert.Fail("Call to FileExists.");
        }
        public void SetGoodFilename()
        {
            //_GoodFilename = ConfigurationManager.AppSettings["GoodFilename"];
            //if (_GoodFilename.Contains("[AppPath]"))
            //{
            //    _GoodFilename = _GoodFilename.Replace("[AppPath]",
            //        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //}
        }
    }
}
