namespace Task1
{
	/// <summary>
	/// Substraction's class.
	/// </summary>
	public class Substraction : Operation
	{
		/// <summary>
		/// Sign of substraction.
		/// </summary>
		protected override char OperationSign { get; } = '-';

		/// <summary>
		/// Substruction's operation.
		/// </summary>
		/// <returns>Result of operation.</returns>
		public override double Counting()
			=> Left.Counting() - Right.Counting();
	}
}
