using NUnit.Framework;
using System.IO;

namespace Task2
{
    public class MapTests
    {

        private Map map;

        [SetUp]
        public void Setup()
        {
            var using (StreamWriter sw = new StreamWriter("test.txt"))
            {
                sw.Write(@"#####
#   #
# @ #
#   #
#####");
            }

            map = new Map("test.txt");
            File.Delete("test.txt");
        }

        [Test]
        public void ConstructorTest()
        {
            char[,] mapArrayTest = new char[5, 5] { { '#', '#', '#', '#', '#' }, { '#', ' ', ' ', ' ', '#' }, { '#', ' ', '@', ' ', '#' }, { '#', ' ', ' ', ' ', '#' }, { '#', '#', '#', '#', '#' } };

            Assert.AreEqual(mapArrayTest, map.MapArray);
        }

        [Test]
        public void MoveUpTest()
        {
            map.MoveUp();
            map.MoveUp();
            map.MoveUp();
            Assert.AreEqual((1, 2), map.PlayerPosition);
        }

        [Test]
        public void MoveDownTest()
        {
            map.MoveDown();
            map.MoveDown();
            Assert.AreEqual((3, 2), map.PlayerPosition);
        }

        [Test]
        public void MoveLeftTest()
        {
            map.MoveLeft();
            map.MoveLeft();
            Assert.AreEqual((2, 1), map.PlayerPosition);
        }

        [Test]
        public void MoveRightTest()
        {
            map.MoveRight();
            map.MoveRight();

            Assert.AreEqual((2, 3), map.PlayerPosition);
        }

        [Test]
        public void MoveRightMoveDown()
        {
            map.MoveRight();
            map.MoveDown();

            Assert.AreEqual((3, 3), map.PlayerPosition);
        }

        [Test]
        public void MoveLeftMoveDownMoveLeft()
        {
            map.MoveLeft();
            map.MoveDown();
            map.MoveLeft();

            Assert.AreEqual((3, 1), map.PlayerPosition);
        }
    }
}