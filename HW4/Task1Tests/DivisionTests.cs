using System;
using NUnit.Framework;

namespace Task1
{
	public class DivisionTests
	{
		private Division division;
		private Number left;
		private Number right;

		[SetUp]
		public void Setup()
		{
			division = new Division();
			left = new Number(1);
			right = new Number(1);
			division.Left = left;
			division.Right = right;
		}

		[Test]
		public void DivisionTest()
		{
			left.Value = 12;
			right.Value = 3;
			Assert.AreEqual(4, division.Counting());
		}

		[Test]
		public void DivisionOfLargeValuesTest()
		{
			left.Value = 100000000;
			right.Value = 2;
			Assert.AreEqual(50000000, division.Counting());
		}

		[Test]
		public void DivisionOfNegativeValuesTest()
		{
			left.Value = -3;
			right.Value = -1;
			Assert.AreEqual(3, division.Counting());
		}

		[Test]
		public void DivisionOfDoubleValuesTest()
		{
			left.Value = 3.6;
			right.Value = 2.5;
			Assert.AreEqual(1.44, division.Counting());
		}

		[Test]
		public void DivisionByZeroTest()
		{
			left.Value = 34;
			right.Value = 0;
			Assert.Throws<DivideByZeroException>(() => division.Counting());
		}
	}
}