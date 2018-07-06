using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaulSheriff;

namespace UnitTestProject4
{
	/// <summary>
	/// Summary description for CollectionAssertClassTest
	/// </summary>
	[TestClass]
	public class CollectionAssertClassTest
	{
		public CollectionAssertClassTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AreCollectionsEqualFailsBecauseNoComparerTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();
            peopleExpected.Add(new Person() { FirstName = "Paul", LastName = "Sheriff" });
            peopleExpected.Add(new Person() { FirstName = "Jared", LastName = "Kushner" });
            peopleExpected.Add(new Person() { FirstName = "Marco", LastName = "Rubio" });
            peopleActual = personManager.GetPeople();
            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }
        [TestMethod]
        public void AreCollectionsEqualWithComparerTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Paul", LastName = "Sheriff" });
            peopleExpected.Add(new Person() { FirstName = "Jared", LastName = "Kushner" });
            peopleExpected.Add(new Person() { FirstName = "Marco", LastName = "Rubio" });

            peopleActual = personManager.GetPeople();
            CollectionAssert.AreEqual(peopleExpected, peopleActual,
               (Comparer<Person>.Create((x, y) => x.FirstName == y.FirstName &&
                x.LastName == y.LastName ? 0 : 1)));
        }
        [TestMethod]
        public void AreCollectionsEqualTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = personManager.GetPeople();
            peopleExpected = peopleActual;
            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }
        [TestMethod]
        [Description("Equivalent does an order independent comparison, which can be useful.")]
        public void AreCollectionEquivalentTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = personManager.GetPeople();
            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);
            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }
    }
}
