using NUnit.Framework;
using System.Data;

namespace Task1
{
	public class Tests
	{
		private Tree tree;

		[SetUp]
		public void Setup()
		{
			tree = new Tree();
		}

		[Test]
		public void ExpressionWithAdditionTest()
		{
			tree.BuildTree("(+ 13 7)");
			Assert.AreEqual(20, tree.Counting());
		}

		[Test]
		public void ExpressionWithSubtractionTest()
		{
			tree.BuildTree("(- 234 34)");
			Assert.AreEqual(200, tree.Counting());
		}

		[Test]
		public void ExpressionWithMultiplicationTest()
		{
			tree.BuildTree("(* 5 9)");
			Assert.AreEqual(45, tree.Counting());
		}

		[Test]
		public void ExpressionWithDivisionTest()
		{
			tree.BuildTree("(/ 45 4)");
			Assert.AreEqual(11.25, tree.Counting());
		}

		[Test]
		public void ExpressionWithAllOperationTest()
		{
			tree.BuildTree("(* (+ 1 1) 2)");
			Assert.AreEqual(4, tree.Counting());
		}

		[Test]
		public void InvalidExpressionTest1()
		{
			Assert.Throws<InvalidExpressionException>(() => tree.BuildTree("(- (* 25 (- 70 35))(/ (* (+ 15 110)) 7))"));
		}


		[Test]
		public void InvalidExpressionTest2()
		{
			Assert.Throws<InvalidExpressionException>(() => tree.BuildTree("(* (+ 1 1) / 2)"));
		}
	}
}