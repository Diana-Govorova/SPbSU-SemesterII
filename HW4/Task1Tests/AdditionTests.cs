using NUnit.Framework;

namespace Task1
{
	public class AdditionTests
	{
		private Addition addition;
		private Number left;
		private Number right;

		[SetUp]
		public void Setup()
		{
			addition = new Addition();
			left = new Number(1);
			right = new Number(1);
			addition.Left = left;
			addition.Right = right;
		}

		[Test]
		public void AdditionTest()
		{
			left.Value = 1000;
			right.Value = 100;
			Assert.AreEqual(1100, addition.Counting());
		}

		[Test]
		public void AdditionOfLargeValuesTest()
		{
			left.Value = 1000000000;
			right.Value = 1000000000;
			Assert.AreEqual(2000000000, addition.Counting());
		}

		[Test]
		public void AdditionOfNegativeValuesTest()
		{
			left.Value = -3;
			right.Value = -2;
			Assert.AreEqual(-5, addition.Counting());
		}

		[Test]
		public void AdditionOfDoubleValuesTest()
		{
			left.Value = 3.6;
			right.Value = 0.4;
			Assert.AreEqual(4, addition.Counting());
		}
	}
}
