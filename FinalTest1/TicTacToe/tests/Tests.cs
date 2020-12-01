using NUnit.Framework;
using TicTacToe;

namespace tests
{
    public class Tests
    {
        private ClickHandler handler;

        [SetUp]
        public void Setup()
        {
            handler = new ClickHandler();
        }

        [Test]
        public void CanPlaceTest()
        {
            Assert.AreEqual('n', handler.getItem(1, 1));
            handler.handle((1, 1), 'X');
            Assert.AreEqual('X', handler.getItem(1, 1));
        }

        [Test]
        public void CantPlaceTest()
        {
            Assert.AreEqual('n', handler.getItem(1, 1));
            handler.handle((1, 1), 'X');
            Assert.IsFalse(handler.handle((1, 1), 'X'));
        }

        [Test]
        public void DetectEndTest()
        {
            Assert.IsFalse(handler.checkIfEnd());

            handler.handle((0, 0), 'X');
            handler.handle((0, 1), 'X');
            handler.handle((0, 2), 'X');

            Assert.IsTrue(handler.checkIfEnd());
        }

        [Test]
        public void DetectDrawTest()
        {
            var test = new char[3, 3] { { 'X', '0', 'X' }, { '0', '0', 'X' }, { 'X', 'X', '0' } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    handler.handle((i, j), test[i, j]);

                    if (i + j < 4)
                    {
                        Assert.IsFalse(handler.checkIfEnd());
                    }
                }
            }

            Assert.IsTrue(handler.checkIfEnd());
        }
    }
}