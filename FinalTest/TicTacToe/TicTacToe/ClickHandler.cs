using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ClickHandler
    {
        private char[,] field;
        private string status;

        public ClickHandler()
        {
            field = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j] = 'n';
                }
            }
        }

        public char GetItem(int x, int y)
        {
            return field[x, y];
        }

        public string GetStatus()
        {
            return status;
        }

        private bool CheckHorizontal()
        {
            for (int i = 0; i < 3; i++)
            {
                char current = 'n';
                char previous = 'n';

                bool won = true;

                for (int j = 1; j < 3; j++)
                {
                    previous = field[i, j - 1];
                    current = field[i, j];

                    if (current != previous || current == 'n')
                    {
                        won = false;
                        break;
                    }
                }

                if (won)
                {
                    status = $"{current} won";
                    return true;
                }
            }

            return false;
        }

        private bool CheckVertical()
        {
            for (int i = 0; i < 3; i++)
            {
                char current = 'n';
                char previous = 'n';

                bool won = true;

                for (int j = 1; j < 3; j++)
                {
                    previous = field[j - 1, i];
                    current = field[j, i];

                    if (current != previous || current == 'n')
                    {
                        won = false;
                        break;
                    }
                }

                if (won)
                {
                    status = $"{current} won";
                    return true;
                }
            }

            return false;
        }

        private bool CheckDiagonal()
        {
            char current = 'n';
            char previous = 'n';

            bool won = true;

            for (int i = 1; i < 3; i++)
            {
                previous = field[i - 1, i - 1];
                current = field[i, i];

                if (current != previous || current == 'n')
                {
                    won = false;
                    break;
                }
            }

            if (won)
            {
                status = $"{current} won";
                return true;
            }

            won = true;

            for (int i = 1; i < 3; i++)
            {
                previous = field[i - 1, 2 - (i - 1)];
                current = field[i, 2 - i];

                if (current != previous || current == 'n')
                {
                    won = false;
                    break;
                }
            }

            if (won)
            {
                status = $"{current} won";
                return true;
            }

            return false;
        }

        private bool CheckDraw()
        {
            foreach (var ch in field)
            {
                if (ch == 'n')
                {
                    return false;
                }
            }

            status = "Draw";
            return true;
        }

        public bool CheckIfEnd()
        {
            return CheckHorizontal() || CheckVertical() || CheckDiagonal() || CheckDraw();
        }

        public bool Handle((int, int) location, char currentSign)
        {
            if (field[location.Item1, location.Item2] == 'n')
            {
                field[location.Item1, location.Item2] = currentSign;

                return true;
            }

            return false;
        }
    }
}
