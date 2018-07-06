using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaulSheriff;
using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace PaulSheriffTest
{
    [TestClass]
    public class ProcessTest
    {
        private const string BAD_FILENAME = @"C:\bad_filename.bad";
        private string _GoodFilename;
        private const string FILENAME = @"FileToDeploy.txt";

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        [Description("Called once for a class. Set up resources for all tests within a class.")]
        public static void ClassInitialize(TestContext testContext)
        {
            testContext.WriteLine("ClassInitialize: Enter.");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestInitialize]
        [Description("Called once for each test method. Set or reset resources needed for each test.")]
        public void TestInitialize()
        {
            if (TestContext.TestName == "FilenameDoesExist")
            {

            }
        }
        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "FilenameDoesExist")
            {

            }
        }

        [TestMethod]
        [Description("Validates whether a file exists.")]
        [Owner("Paul Sheriff")]
        [Priority(0)]
        public void FilenameDoesExist()
        {
            FileProcess fileProcess = new FileProcess();
            SetGoodFilename();
            File.AppendAllText(_GoodFilename, "Some Amazing Text");
            Assert.IsTrue(fileProcess.FileExists(_GoodFilename));
            File.Delete(_GoodFilename);
        }
        [TestMethod]
        public void FilenameDoesExistSimpleMessage()
        {
            FileProcess fileProcess = new FileProcess();
            SetGoodFilename();
            Assert.IsFalse(fileProcess.FileExists(_GoodFilename), "Simple Message");
        }
        [TestMethod]
        public void FilenameDoesExist_BetterFailMessage()
        {
            FileProcess fileProcess = new FileProcess();
            SetGoodFilename();
            File.AppendAllText(_GoodFilename, "Some Amazing Text");
            Assert.IsTrue(fileProcess.FileExists(_GoodFilename), "File '{0}' does not exist.", _GoodFilename);
            File.Delete(_GoodFilename);
        }
        [TestMethod]
        [DeploymentItem(FILENAME)]
        public void FilenameDoesExistUsingDeploymentItem()
        {
            FileProcess fileProcess = new FileProcess();
            string fileName = TestContext.DeploymentDirectory + @"\" + FILENAME;
            Assert.IsTrue(fileProcess.FileExists(fileName));
        }
        [TestMethod]
        [Owner("TimK")]
        [Priority(1)]
        public void FilenameDoesNotExist()
        {
            FileProcess fileProcess = new FileProcess();
            TestContext.WriteLine("tttest.  ******************************** ");
            Assert.IsFalse(fileProcess.FileExists(BAD_FILENAME));
        }
        [TestMethod]
        [Owner("Paul Sheriff")]
        [Priority(0)]
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
        [Owner("TimK")]
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
        [TestMethod]
        [Ignore]
        [Owner("TimK")]
        public void FilenameNullorEmpty2()
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
        [TestMethod]
        public void FilenameNullorEmpty3()
        {
            FileProcess fileProcess = new FileProcess();
            Assert.Inconclusive("What a message!");
        }
        [TestMethod]
        [Timeout(3000)]
        public void SimulateTimeOut()
        {
            System.Threading.Thread.Sleep(1);
        }
        public void SetGoodFilename()
        {
            _GoodFilename = ConfigurationManager.AppSettings["GoodFilename"];
            if (_GoodFilename.Contains("[AppPath]"))
            {
                _GoodFilename = _GoodFilename.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
        [TestMethod]
        public void IsInstanceOfTypeTest()
        {
            PersonManager personManager = new PersonManager();
            Person person;
            person = personManager.CreatePerson("Henry", "Winkler", true);
            Assert.IsInstanceOfType(person, typeof(Supervisor));
        }
        [TestMethod]
        public void IsNullTest()
        {
            PersonManager personManager = new PersonManager();
            Person person;
            person = personManager.CreatePerson("", "Winkler", false);
            Assert.IsNull(person);
        }
        [TestMethod]
        public void IsInstanceOfTypeTest2()
        {
            PersonManager personManager = new PersonManager();
            Person person;
            person = personManager.CreatePerson("Henry", "Winkler", false);
            Assert.IsInstanceOfType(person, typeof(Employee));
        }
        [TestMethod]
        public void IsAllLowerCaseText()
        {
            Regex regex = new Regex(@"^([^A-Z])+$");
            StringAssert.Matches("all lower cas", regex);
        }
        [TestMethod]
        public void StartsWithText()
        {
            string x1 = "Roger";
            string x2 = "Roger Rabbit";
            StringAssert.StartsWith(x2, x1);
        }
        [TestMethod]
        public void AreEqual()
        {
            string x1 = "Roger";
            string x2 = "Roger";
            Assert.AreEqual(x1, x2);
        }
        [TestMethod]
        public void AreSame()
        {
            Person person = new Person();
            Supervisor supervisor = new Supervisor();
            Assert.AreNotSame(person, supervisor);
        }
    }
}
