using System;

namespace FinalTest2
{
	/// <summary>
	/// Class with checks if int is zero.
	/// </summary>
	public class IntZeroChecker : IZeroChecker
	{
		/// <summary>
		/// Checks if int is zero.
		/// </summary>
		public bool IsZero(object o)
		{
			if (!(o is int) || o == null)
			{
				throw new ArgumentException();
			}

			var that = o as int?;

			if (that == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
