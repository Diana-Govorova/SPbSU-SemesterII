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
                    stack.Push(number);
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

                            var topElement = float.Parse(stack.Pop());

                            if (stack.IsEmpty() || topElement == 0 && symbol == '/')
                            {
                                return (0, false);
                            }

                            stack.Push(topElement.ToString());
                            var secondSymbol = float.Parse(stack.Pop());
                            var firstSymbol = float.Parse(stack.Pop());
                            if (symbol == '+')
                            {
                                stack.Push((firstSymbol + secondSymbol).ToString());
                            }
                            if (symbol == '-')
                            {
                                stack.Push((firstSymbol - secondSymbol).ToString());
                            }
                            if (symbol == '*')
                            {
                                stack.Push((firstSymbol * secondSymbol).ToString());
                            }
                            if (symbol == '/')
                            {
                                stack.Push((firstSymbol / secondSymbol).ToString());
                            }
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
            var result = float.Parse(stack.Pop());

            if (stack.IsEmpty())
            {
                return (result, true);
            }

            stack.Clear();
            return (0, false);
        }
    }
}