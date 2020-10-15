using System;

namespace Task1
{
	/// <summary>
	/// Operation's class.
	/// </summary>
	public abstract class Operation : INode
	{
		protected virtual char OperationSign { get; }
		
		public INode Left { get; set; }

        public INode Right { get; set; }

		/// <summary>
		/// Print the expression.
		/// </summary>
        public void Print()
		{
			Console.Write("(");
			Left.Print();
			Console.Write(OperationSign);
			Right.Print();
			Console.Write(")");
		}

		/// <summary>
		/// Expression's counting.
		/// </summary>
		/// <returns>Result.</returns>
		abstract public double Counting();
    }
}
