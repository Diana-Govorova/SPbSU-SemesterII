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
            Assert.AreEqual('n', handler.GetItem(1, 1));
            handler.Handle((1, 1), 'X');
            Assert.AreEqual('X', handler.GetItem(1, 1));
        }

        [Test]
        public void CantPlaceTest()
        {
            Assert.AreEqual('n', handler.GetItem(1, 1));
            handler.Handle((1, 1), 'X');
            Assert.IsFalse(handler.Handle((1, 1), 'X'));
        }

        [Test]
        public void DetectEndTest()
        {
            Assert.IsFalse(handler.CheckIfEnd());

            handler.Handle((0, 0), 'X');
            handler.Handle((0, 1), 'X');
            handler.Handle((0, 2), 'X');

            Assert.IsTrue(handler.CheckIfEnd());
        }

        [Test]
        public void DetectDrawTest()
        {
            var test = new char[3, 3] { { 'X', '0', 'X' }, { '0', '0', 'X' }, { 'X', 'X', '0' } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    handler.Handle((i, j), test[i, j]);

                    if (i + j < 4)
                    {
                        Assert.IsFalse(handler.CheckIfEnd());
                    }
                }
            }

            Assert.IsTrue(handler.CheckIfEnd());
        }
    }
}