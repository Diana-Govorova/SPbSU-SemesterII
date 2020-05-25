using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            using (StreamWriter sw = new StreamWriter("test.txt"))
            {
                sw.Write(@"#####
#@  #
##  #
#  ##
# # #");
            }

            var controller = new CursorController(@"test.txt");

            File.Delete("test.txt");

            eventLoop.LeftHandler += controller.OnLeft;
            eventLoop.RightHandler += controller.OnRight;
            eventLoop.UpHandler += controller.OnUp;
            eventLoop.DownHandler += controller.OnDown;

            controller.Print();

            eventLoop.Run();
        }
    }
}
