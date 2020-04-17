using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Calculator
    {
        public Calculator(IStack stack)
           => this.stack = stack;

        private IStack stack;

        public (float, bool) CalculateExpressionValue(string expression)
        {
            var number = string.Empty;
            foreach (char symbol in expression)
            {
                if (char.IsDigit(symbol))
                {
                    number = string.Concat(number, char.ToString(symbol));
                    continue;
                }

                if (number.Length > 0)
                {
                    stack.Push(float.Parse(number));
                    number = string.Empty;
                    continue;
                }

                if (symbol == ' ')
                {
                    continue;
                }

                switch (symbol)
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        {
                            if (stack.IsEmpty())
                            {
                                return (0, false);
                            }

                            var topElement = stack.Pop();

                            if (stack.IsEmpty() || topElement == 0 && symbol == '/')
                            {
                                return (0, false);
                            }

                            stack.Push(topElement);
                            PerformOperation(symbol);
                            break;
                        }
                    default:
                        {
                            return (0, false);
                        }
                }
            }

            if (stack.IsEmpty())
            {
                return (0, false);
            }
            var result = stack.Pop();

            if (stack.IsEmpty())
            {
                return (result, true);
            }

            stack.Clear();
            return (0, false);
        }

        /// <summary>
        /// Perform operation.
        /// </summary>
        /// <param name="symbol">Operation.</param>
        private void PerformOperation(char symbol)
        {
            var secondSymbol = stack.Pop();

            var firstSymbol = stack.Pop();
            if (symbol == '+')
            {
                stack.Push(firstSymbol + secondSymbol);
            }
            if (symbol == '-')
            {
                stack.Push(firstSymbol - secondSymbol);
            }
            if (symbol == '*')
            {
                stack.Push(firstSymbol * secondSymbol);
            }
            if (symbol == '/')
            {
                stack.Push(firstSymbol / secondSymbol);
            }
        }
    }
}