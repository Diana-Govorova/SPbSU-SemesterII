using System;
using System.Linq;
using System.Windows.Forms;

namespace Task1
{
	public partial class CalculatorForm : Form
	{
		private CalculatorLogic calculator;

		public CalculatorForm()
		{
			InitializeComponent();
			calculator = new CalculatorLogic();

		}
		public void Operation()
		{
			if (!calculator.IsOperationPressedEarly)
			{
				calculator.SecondNumber = Convert.ToDouble(inputAndOutputLineOfResult.Text);
				inputAndOutputLineOfResult.Clear();
			}

			calculator.Operation();
			inputAndOutputLineOfResult.Text = calculator.FirstNumber.ToString();
		}

		private void CalculatorForm_Load(object sender, EventArgs e)
		{
			MaximizeBox = false;
		}

		private void equalButton_Click(object sender, EventArgs e)
		{
			if (inputAndOutputLineOfResult.Text.Length == 0)
			{
				return;
			}

			calculator.SecondNumber = Convert.ToDouble(inputAndOutputLineOfResult.Text);
			calculator.EqualButtonPressed();
			inputAndOutputLineOfResult.Text = calculator.FirstNumber.ToString();
			inputAndOutputLineOfOperation.Clear();
			calculator.IsDelete = false;
		}

		public void inputNumButton_Click(object sender, EventArgs e)
		{
			if (calculator.IsEqualPressed)
			{
				if (!calculator.IsDelete)
				{
					inputAndOutputLineOfResult.Clear();
					calculator.IsDelete = true;
				}
				inputAndOutputLineOfResult.Text += (sender as Button).Text;
				return;
			}

			inputAndOutputLineOfResult.Text += (sender as Button).Text;
			inputAndOutputLineOfOperation.Text += (sender as Button).Text;
		}

		private void inputSymbolButton_Click(object sender, EventArgs e)
		{
			calculator.IsContainDot = false;

			if (inputAndOutputLineOfResult.Text.Length == 0 && inputAndOutputLineOfOperation.Text.Length == 0)
			{
				return;
			}

			if (calculator.IsEqualPressed)
			{
				calculator.FirstNumber = Convert.ToDouble(inputAndOutputLineOfResult.Text);
				inputAndOutputLineOfOperation.Text += calculator.FirstNumber;
				calculator.IsEqualPressed = false;
			}

			if (!calculator.IsOperationPressedEarly)
			{
				try
				{
					calculator.FirstNumber = Convert.ToDouble(inputAndOutputLineOfResult.Text);
					inputAndOutputLineOfResult.Clear();
				}
				catch
				{
					inputAndOutputLineOfResult.Text = "IncorrectInput";
				}

				calculator.Symbol = (sender as Button).Text[0];
				inputAndOutputLineOfOperation.Text += calculator.Symbol;
			}
			else
			{
				try
				{
					calculator.SecondNumber = Convert.ToDouble(inputAndOutputLineOfResult.Text);
					inputAndOutputLineOfResult.Clear();
				}
				catch
				{
					inputAndOutputLineOfResult.Text = "IncorrectInput";
				}

				Operation();
				calculator.Symbol = (sender as Button).Text[0];
				inputAndOutputLineOfResult.Clear();
				inputAndOutputLineOfOperation.Text = calculator.FirstNumber.ToString();
				inputAndOutputLineOfOperation.Text += calculator.Symbol;
			}

			calculator.IsOperationPressedEarly = true;
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			calculator.Remove();
			inputAndOutputLineOfResult.Clear();
			inputAndOutputLineOfOperation.Clear();
			calculator.IsDelete = false;
			calculator.IsOperationPressedEarly = false;
		}

		private void oppositeMeaningButton_Click(object sender, EventArgs e)
		{
			if (inputAndOutputLineOfResult.Text != "")
			{
				if (inputAndOutputLineOfResult.Text[0] == '-')
				{
					inputAndOutputLineOfResult.Text = inputAndOutputLineOfResult.Text.Remove(0, 1);
				}
				else
				{
					inputAndOutputLineOfResult.Text = '-' + inputAndOutputLineOfResult.Text;
				}
			}

			if (inputAndOutputLineOfOperation.Text != "")
			{
				if (inputAndOutputLineOfOperation.Text[0] == '-')
				{
					inputAndOutputLineOfOperation.Text = inputAndOutputLineOfOperation.Text.Remove(0, 1);
				}
				else
				{
					inputAndOutputLineOfOperation.Text = '-' + inputAndOutputLineOfOperation.Text;
				}
			}
		}

		private void arrowButton_Click(object sender, EventArgs e)
		{
			if (inputAndOutputLineOfResult.Text != "")
			{
				if (inputAndOutputLineOfOperation.Text != "")
				{
					inputAndOutputLineOfOperation.Text = inputAndOutputLineOfOperation.Text.Remove(inputAndOutputLineOfOperation.Text.Length - 1, 1);
				}

				inputAndOutputLineOfResult.Text = inputAndOutputLineOfResult.Text.Remove(inputAndOutputLineOfResult.Text.Length - 1, 1);

				if (calculator.IsEqualPressed)
				{
					calculator.FirstNumber = Convert.ToDouble(inputAndOutputLineOfResult.Text);
				}
				else
				{
					return;
				}
			}

			if (inputAndOutputLineOfOperation.Text != "")
			{
				inputAndOutputLineOfOperation.Text = inputAndOutputLineOfOperation.Text.Remove(inputAndOutputLineOfOperation.Text.Length - 1, 1);
			}

			if (!inputAndOutputLineOfResult.Text.Contains(","))
			{
				calculator.IsContainDot = false;
			}

			if (!inputAndOutputLineOfResult.Text.Contains(calculator.Symbol))
			{
				calculator.Symbol = ' ';
			}
		}

		private void SqrtButton_Click(object sender, EventArgs e)
		{
			if (inputAndOutputLineOfResult.Text.Length == 0)
			{
				return;
			}

			double resultOfSqrt = 0;
			int count = 0;

			try
			{
				calculator.FirstNumber = Convert.ToDouble(inputAndOutputLineOfResult.Text);
				count++;
			}
			catch
			{
				inputAndOutputLineOfResult.Text = "NoNumber";
			}

			if (calculator.FirstNumber < 0)
			{
				inputAndOutputLineOfResult.Clear();
				inputAndOutputLineOfOperation.Clear();
				count--;
			}
			else
			{
				calculator.SqrtMath(resultOfSqrt);
				inputAndOutputLineOfResult.Text = calculator.FirstNumber.ToString();
				inputAndOutputLineOfOperation.Text = calculator.FirstNumber.ToString();
				count--;
			}
		}

		private void DivisedOfOneButton_Click(object sender, EventArgs e)
		{
			if (inputAndOutputLineOfResult.Text.Length == 0)
			{
				return;
			}

			if ((calculator.FirstNumber == 0) || (calculator.SecondNumber == 0))
			{
				return;
			}

			double resultDivisedOfOne = 0;
			int count = 0;

			try
			{
				calculator.FirstNumber = Convert.ToDouble(inputAndOutputLineOfResult.Text);
				count++;
			}
			catch
			{
				inputAndOutputLineOfResult.Text = "NoNumber";
			}

			if (calculator.FirstNumber == 0)
			{
				inputAndOutputLineOfResult.Clear();
				inputAndOutputLineOfResult.Text += "0";
				count--;
			}
			else
			{
				calculator.DivisedOfOne(resultDivisedOfOne);
				inputAndOutputLineOfResult.Text = calculator.FirstNumber.ToString();
				inputAndOutputLineOfOperation.Text = calculator.FirstNumber.ToString();
				count--;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			inputAndOutputLineOfOperation.TextAlign = HorizontalAlignment.Right;
			inputAndOutputLineOfOperation.Focus();
			inputAndOutputLineOfOperation.SelectionStart = inputAndOutputLineOfOperation.MaxLength;
		}

		private void inputAndOutputLine_TextChanged(object sender, EventArgs e)
		{
			inputAndOutputLineOfResult.TextAlign = HorizontalAlignment.Right;
			inputAndOutputLineOfResult.SelectionStart = inputAndOutputLineOfOperation.MaxLength;
		}

		private void buttonSymbolDot_Click(object sender, EventArgs e)
		{
			if (!inputAndOutputLineOfResult.Text.Contains(","))
			{
				if (inputAndOutputLineOfResult.Text.Length > 0)
				{
					inputAndOutputLineOfResult.Text += (sender as Button).Text;
					inputAndOutputLineOfOperation.Text += (sender as Button).Text;
					calculator.IsContainDot = true;
				}
			}
		}
	}
}
