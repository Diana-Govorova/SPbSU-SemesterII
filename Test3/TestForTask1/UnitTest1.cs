using NUnit.Framework;

namespace Task1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MTFTest1()
        {
            LinkedList alphabet = new LinkedList();
            int position = 0;
            for (int i = 97; i < 123; i++)
            {
                alphabet.AddNodeByPosition(position, (char)i);
                position++;
            }
            string str1 = "banana";
            int[] arrayOfIndex1 = new int[6];
            int[] answer1 = new int[6] { 1, 1, 13, 1, 1, 1 };
            arrayOfIndex1 = alphabet.MoveToFrontFunction(arrayOfIndex1, str1);
            Assert.AreEqual(answer1, arrayOfIndex1);
        }
        [Test]
        public void MTFTest2()
        {
            LinkedList alphabet = new LinkedList();
            int position = 0;
            for (int i = 97; i < 123; i++)
            {
                alphabet.AddNodeByPosition(position, (char)i);
                position++;
            }
            string str2 = "panama";
            int[] arrayOfIndex2 = new int[6];
            int[] answer2 = new int[6] { 15, 1, 14, 1, 14, 1 };
            arrayOfIndex2 = alphabet.MoveToFrontFunction(arrayOfIndex2, str2);
            Assert.AreEqual(answer2, arrayOfIndex2);
        }
    }
}