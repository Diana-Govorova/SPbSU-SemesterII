using NUnit.Framework;
using System.IO;

namespace Task2
{
	public class MapTests
	{
		private Map map;

		private CursorController controller;

		[SetUp]
		public void Setup()
		{
			using (var sw = new StreamWriter("test.txt"))
			{
				sw.Write(@"#####
#   #
# @ #
#    
#####");
			}

			controller = new CursorController(@"test.txt", (int a, int b) => { });
			map = new Map(@"test.txt");

			File.Delete("test.txt");
		}

		[Test]
		public void ConstructorTest()
		{
			Assert.IsTrue(map.MapArray[0, 0]);
			Assert.IsFalse(map.MapArray[1, 2]);
			Assert.IsTrue(map.MapArray[0, 2]);
		}

		[Test]
		public void MoveUpTest()
		{
			controller.OnUp(null, null);
			Assert.AreEqual((2, 1), controller.PlayerPosition);
		}

		[Test]
		public void MoveDownTest()
		{
			controller.OnDown(null, null);
			Assert.AreEqual((2, 3), controller.PlayerPosition);
		}

		[Test]
		public void MoveLeftTest()
		{
			controller.OnLeft(null, null);
			Assert.AreEqual((1, 2), controller.PlayerPosition);
		}

		[Test]
		public void MoveRightTest()
		{
			controller.OnRight(null, null);
			Assert.AreEqual((3, 2), controller.PlayerPosition);
		}

		[Test]
		public void MoveRightMoveDown()
		{
			controller.OnRight(null, null);
			controller.OnDown(null, null);
			Assert.AreEqual((3, 3), controller.PlayerPosition);
		}

		[Test]
		public void LetTest()
		{
			controller.OnRight(null, null);
			controller.OnRight(null, null);
			Assert.AreEqual((3, 2), controller.PlayerPosition);
		}

		[Test]
		public void IsOnMapTest()
		{
			controller.OnRight(null, null);
			controller.OnDown(null, null);
			controller.OnRight(null, null);
			Assert.AreEqual((4, 3), controller.PlayerPosition);
		}

		[Test]
		public void MoveLeftMoveDownMoveLeft()
		{
			controller.OnLeft(null, null);
			controller.OnDown(null, null);
			controller.OnLeft(null, null);
			Assert.AreEqual((1, 3), controller.PlayerPosition);
		}
	}
} 