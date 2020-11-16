using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    /// <summary>
    /// Int comparator.
    /// </summary>
    public class IntComparer : IComparer<int>
    {
        public int Compare(int first, int second)
            => first > second ? 1 : first == second ? 0 : -1;
    }
}
