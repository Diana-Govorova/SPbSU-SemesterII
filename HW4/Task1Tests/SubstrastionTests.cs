using NUnit.Framework;

namespace Task1
{
	public class SubstrastionTests
	{
		private Substraction substraction;
		private Number left;
		private Number right;

		[SetUp]
		public void Setup()
		{
			substraction = new Substraction();
			left = new Number(1);
			right = new Number(1);
			substraction.Left = left;
			substraction.Right = right;
		}

		[Test]
		public void SubstractionTest()
		{
			left.Value = 34;
			right.Value = 5;
			Assert.AreEqual(29, substraction.Counting());
		}

		[Test]
		public void SubstractionOfLargeValuesTest()
		{
			left.Value = 1000000000;
			right.Value = 2000000000;
			Assert.AreEqual(-1000000000, substraction.Counting());
		}

		[Test]
		public void SubstractionOfNegativeValuesTest()
		{
			left.Value = -3;
			right.Value = -2;
			Assert.AreEqual(-1, substraction.Counting());
		}

		[Test]
		public void SubstractionOfDoubleValuesTest()
		{
			left.Value = 44.89;
			right.Value = 0.69;
			Assert.AreEqual(44.2, substraction.Counting());
		}
	}
}
