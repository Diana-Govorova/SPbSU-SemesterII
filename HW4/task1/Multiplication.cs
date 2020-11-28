namespace Task1
{
	public class Multiplication : Operation
	{
		/// <summary>
		/// Sign of multiplication.
		/// </summary>
		protected override char OperationSign { get; } = '*';

		/// <summary>
		/// Multiplication's operation.
		/// </summary>
		/// <returns>Result of operation.</returns>
		public override double Counting()
			=> Left.Counting() * Right.Counting();
	}
}
