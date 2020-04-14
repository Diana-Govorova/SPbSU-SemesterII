using System;

namespace Task2
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                var list = new UniqueList<string>();
                list.DeleteValueByValue("cat");
                Console.WriteLine(list.Contains("cat"));
            }
            catch (ItemAlreadyImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DeleteNonexistentItemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
