using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    /// <summary>
    /// Implementation of three list functions.
    /// </summary>
    public static class ListFunction
    {
        /// <summary>
        /// Applies the function to each element in the list.
        /// </summary>
        /// <param name="list">Input list.</param>
        /// <param name="func">Input function.</param>
        /// <returns>New list.</returns>
        public static List<int> Map(List<int> list, Func<int, int> func)
        {
            List<int> result = new List<int>();

            foreach (int element in list)
            {
                var tmp = func(element);
                result.Add(tmp);
            }

            return result;
        }

        /// <summary>
        /// Applies the function to each element in the list
        /// and if returned true, adds an element to the new list.
        /// </summary>
        /// <param name="list">Input list.</param>
        /// <param name="func">Input function.</param>
        /// <returns>New list.</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> func)
        {
            List<int> result = new List<int>();

            foreach (int element in list)
            {
                if (func(element))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        /// <summary>
        /// Applies an accumulative function to each element and return the final value.
        /// </summary>
        /// <param name="list">Input list.</param>
        /// <param name="startingValue">Starting value.</param>
        /// <param name="func">Input function.</param>
        /// <returns>Final value.</returns>
        public static int Fold(List<int> list, int startingValue, Func<int, int, int> func)
        {
            int result = startingValue;

            foreach (int element in list)
            {
                result = func(result, element);
            }

            return result;
        }
    }
}
