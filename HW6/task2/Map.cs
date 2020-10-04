using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task2
{
	/// <summary>
	/// Class that defines map.
	/// </summary>
	public class Map
	{
		public char[,] MapArray { get; private set; }

		private (int, int) playerPosition = (-1, -1);

		public (int x, int y) PlayerPosition { get => playerPosition; set => playerPosition = value; }

		/// <summary>
		/// Constructor that builds the map from input file.
		/// </summary>
		/// <param name="path">Path to the input file.</param>
		public Map(string path)
		{
			var reader = new StreamReader(path) ;

			char currentSymbol;
			int i = 1;
			int j = 0;

			while (reader.Peek() > -1)
			{
				currentSymbol = (char)reader.Read();
				if (currentSymbol != '\n')
				{
					if (currentSymbol != '\r')
					j++;
				}
				else
				{
					i++;
					j = 0;
				}
			}

			var mapArray = new char[j, i];

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
						mapArray[j, i] = currentSymbol;
						if (currentSymbol == '@')
						{
							playerPosition = (j, i);
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
		/// <param name="x">Current column.</param>
		/// <param name="y">Current row.</param>
		/// <returns>If coordinates are within the map.</returns>
		private bool IsOnMap(int x, int y)
			=> (y <= rows - 1) && (x <= columns - 1) && (x >= 0) && (y >= 0);

		/// <summary>
		/// Checks if move coordinates are within the map.
		/// </summary>
		/// <param name="x">Current column.</param>
		/// <param name="y">Current row.</param>
		/// <returns>if move coordinates are within the map.</returns>
		public bool CanGo(int x, int y)
			=> IsOnMap(x, y) && (mapArray[x, y] != '#');

		/// <summary>
		/// Print the map.
		/// </summary>
		public void Print()
		{
			for (int i = 0; i < MapArray.GetLength(0); i++)
			{
				for (int j = 0; j < MapArray.GetLength(1); j++)
				{
					Console.Write(mapArray[j, i]);
				}
				Console.WriteLine();
			}
		}
	}
}