using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest2
{
	/// <summary>
	/// Class with CountZeroElement function.
	/// </summary>
	public static class Functions
	{
		/// <summary>
		/// Counts zero elements in list.
		/// </summary>
		public static int CountZeroElements<T>(List<T> list, IZeroChecker checker)
		{
			if (list == null)
			{
				throw new ArgumentException();
			}

			if (checker == null)
			{
				throw new ArgumentException();
			}

			int result = 0;

			foreach (var element in list)
			{
				if (checker.IsZero(element))
				{
					result++;
				}
			}

			return result;
		}
	}
}
