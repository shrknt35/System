using NUnit.Framework;
using System.Linq;

namespace Siemens.BASys.Internal.TestSuitHelper.Tests
{
	[TestFixture]
	public class Factory_On_TestRetriver_Instantiation
	{
		[Test]
		public void Should_Return_Proper_The_Tests_Classes()
		{
			var allTests = Factory.TestsRetriever.GetAllTests();
			Assert.AreEqual(4, allTests.Count());
			Assert.IsTrue(allTests.Select(type => type.Name).Contains("Factory_On_TestRetriver_Instantiation"));
			Assert.IsTrue(allTests.Select(type => type.Name).Contains("TestClass1"));
			Assert.IsTrue(allTests.Select(type => type.Name).Contains("TestClass2"));
			Assert.IsTrue(allTests.Select(type => type.Name).Contains("TestClass3"));

			allTests = Factory.TestsRetriever.GetUnitTests();
			Assert.AreEqual(1, allTests.Count());
			Assert.AreEqual("Factory_On_TestRetriver_Instantiation", allTests.First().Name);

			allTests = Factory.TestsRetriever.GetPerformanceTests();
			Assert.AreEqual(1, allTests.Count());
			Assert.AreEqual("TestClass1", allTests.First().Name);

			allTests = Factory.TestsRetriever.GetStressTests();
			Assert.AreEqual(1, allTests.Count());
			Assert.AreEqual("TestClass2", allTests.First().Name);

			allTests = Factory.TestsRetriever.GetIntegrationTests();
			Assert.AreEqual(1, allTests.Count());
			Assert.AreEqual("TestClass3", allTests.First().Name);
		}
	}

	[TestFixture]
	[PerformanceTest]
	public class TestClass1
	{
	}

	[TestFixture]
	[StressTest]
	public class TestClass2
	{
	}

	[TestFixture]
	[IntegrationTest]
	public class TestClass3
	{
	}
}