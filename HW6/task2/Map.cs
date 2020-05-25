using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task2
{
    /// <summary>
    /// Class, that defines map.
    /// </summary>
    public class Map
    {
        private int rows;

        public int Rows { get; }

        private int columns;

        public int Columns { get; }

        private char[,] mapArray;

        public char[,] MapArray { get => mapArray; }

        private (int, int) playerPosition = (-1, -1);

        public (int, int) PlayerPosition { get => playerPosition; }

        /// <summary>
        /// Constructor, that builds the map from input file.
        /// </summary>
        /// <param name="path">Path to the input file.</param>
        public Map(string path)
        {
            StreamReader reader = new StreamReader(path);

            char currentSymbol;
            int i = 1;
            int j = 0;

            while (reader.Peek() > -1)
            {
                currentSymbol = (char)reader.Read();
                if (currentSymbol != '\n')
                {
                    if(currentSymbol != '\r')
                    j++;
                }
                else
                {
                    i++;
                    j = 0;
                }
            }

            mapArray = new char[i, j];

            rows = i;
            columns = j;

            i = 0;
            j = 0;

            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            while (reader.Peek() > -1)
            {
                currentSymbol = (char)reader.Read();
                 if (currentSymbol == '#' || currentSymbol == ' ' || currentSymbol == '@')
                 {
                    if (currentSymbol != '\r')
                    {
                        mapArray[i, j] = currentSymbol;
                        if (currentSymbol == '@')
                        {
                            playerPosition = (i, j);
                        }
                        j++;
                    }
                 }
                 else if (currentSymbol == '\n')
                 {
                    i++;
                    j = 0;
                 }
            }

            reader.Close();
        }

        /// <summary>
        /// Checks if coordinates are within the map.
        /// </summary>
        /// <param name="x">Current row.</param>
        /// <param name="y">Current column.</param>
        /// <returns>If coordinates are within the map.</returns>
        private bool IsOnMap(int x, int y)
            => (x <= rows - 1) && (y <= columns - 1);

        /// <summary>
        /// Moves character up.
        /// </summary>
        public void MoveUp()
        {
            if (IsOnMap(playerPosition.Item1 - 1, playerPosition.Item2)
                && mapArray[playerPosition.Item1 - 1, playerPosition.Item2] != '#')
            {
                mapArray[playerPosition.Item1, playerPosition.Item2] = ' ';
                mapArray[playerPosition.Item1 - 1, playerPosition.Item2] = '@';
                playerPosition.Item1--;
            }
        }

        /// <summary>
        /// Moves character down.
        /// </summary>
        public void MoveDown()
        {
            if (IsOnMap(playerPosition.Item1 + 1, playerPosition.Item2)
                && mapArray[playerPosition.Item1 + 1, playerPosition.Item2] != '#')
            {
                mapArray[playerPosition.Item1, playerPosition.Item2] = ' ';
                mapArray[playerPosition.Item1 + 1, playerPosition.Item2] = '@';
                playerPosition.Item1++;
            }
        }

        /// <summary>
        /// Moves character left.
        /// </summary>
        public void MoveLeft()
        {
            if (IsOnMap(playerPosition.Item1, playerPosition.Item2 - 1)
                && mapArray[playerPosition.Item1, playerPosition.Item2 - 1] != '#')
            {
                mapArray[playerPosition.Item1, playerPosition.Item2] = ' ';
                mapArray[playerPosition.Item1, playerPosition.Item2 - 1] = '@';
                playerPosition.Item2--;
            }
        }

        /// <summary>
        /// Moves character right.
        /// </summary>
        public void MoveRight()
        {
            if (IsOnMap(playerPosition.Item1, playerPosition.Item2 + 1)
                && mapArray[playerPosition.Item1, playerPosition.Item2 + 1] != '#')
            {
                mapArray[playerPosition.Item1, playerPosition.Item2] = ' ';
                mapArray[playerPosition.Item1, playerPosition.Item2 + 1] = '@';
                playerPosition.Item2++;
            }
        }

        /// <summary>
        /// Print the map.
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(mapArray[i, j]);
                }
            }
        }
    }
}
