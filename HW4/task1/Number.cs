using System;

namespace Task1
{
	/// <summary>
	/// Implementation of Number class
	/// </summary>
	public class Number : INode
	{
		/// <summary>
		/// Number`s value.
		/// </summary>
		public double Value { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Number"/> class.
		/// </summary>
		/// <param name="value">Element`s value.</param>
		public Number(double value)
		{
			this.Value = value;
		}

		/// <summary>
		/// Print value.
		/// </summary>
		public void Print() 
			=> Console.Write(Value);

		/// <summary>
		/// Return value of element.
		/// </summary>
		/// <returns>Value.</returns>
		public double Counting()
			=> Value;
	}
}