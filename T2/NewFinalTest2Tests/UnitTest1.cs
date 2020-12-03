using NUnit.Framework;
using System;
using System.Collections.Generic;
using FinalTest2;

namespace Tests
{
	public class Tests
	{
		private IntZeroChecker checker;

		[SetUp]
		public void Setup()
		{
			checker = new IntZeroChecker();
		}

		[Test]
		public void ShouldCountCorrectlyTest1()
		{
			var list = new List<int> { 1, 2, 3, 4, 0, 0, 5 };
			Assert.AreEqual(2, Functions.CountZeroElements(list, checker));
		}

		[Test]
		public void ShouldCountCorrectlyTest2()
		{
			var list = new List<int> { 1, 2, 3, 4, 0, 0, 5, 0, 0, 7, 0 };
			Assert.AreEqual(5, Functions.CountZeroElements(list, checker));
		}

		[Test]
		public void ShouldCountCorrectNoZerosTest()
		{
			var list = new List<int> { 1, 2, 3, 4, 5, 6 };
			Assert.AreEqual(0, Functions.CountZeroElements(list, checker));
		}

		[Test]
		public void ShouldMakeExceptionTest()
		{
			var list = new List<char> { 'a', 'e', 'c', 'k', 'l', 'a' };
			Assert.Throws<ArgumentException>(() => Functions.CountZeroElements(list, checker));
		}

		[Test]
		public void ShouldCountNullList()
		{
			var list = new List<int>();
			Assert.AreEqual(0, Functions.CountZeroElements(list, checker));
		}
	}
}