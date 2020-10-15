namespace Task1
{
    /// <summary>
    /// Addition class.
    /// </summary>
    public class Addition : Operation
    {
		/// <summary>
		/// Sign of addition.
		/// </summary>
		protected override char OperationSign { get; } = '+';

		/// <summary>
		/// Addition's operation.
		/// </summary>
		/// <returns>Result of operation.</returns>
		public override double Counting()
			=> Left.Counting() + Right.Counting();
    }
}
