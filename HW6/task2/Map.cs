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
		public bool[,] MapArray { get; private set; }

		private (int, int) playerPosition = (-1, -1);

		public (int x, int y) PlayerPosition { get => playerPosition; set => playerPosition = value; }

		/// <summary>
		/// Constructor that builds the map from input file.
		/// </summary>
		/// <param name="path">Path to the input file.</param>
		public Map(string path)
		{
			string line;
			using (var sr = new StreamReader(path))
			{
				line = sr.ReadToEnd();
			}
			ReadTheMap(line);
		}

		public void ReadTheMap(string line)
		{
			int column = 0;
			int maxColumn = 0;
			int stringCounter = 0;

			for (int i = 0; i < line.Length; i++)
			{
				if (line[i] != '\n' && line[i] != '\r')
				{
					column++;
				}
				if (line[i] == '\n' || i == line.Length - 1)
				{
					stringCounter++;
					if (column > maxColumn)
					{
						maxColumn = column;
					}
					column = 0;
				}
			}

			MapArray = new bool[stringCounter, maxColumn];

			int k = 0;
			int p = 0;
			for (int count = 0; count < line.Length; count++)
			{
				if (line[count] == '@')
				{
					playerPosition = (p, k);
				}
				if (line[count] == '#')
				{
					MapArray[k, p] = true;
				}
				if (line[count] == '\n')
				{
					k++;
					p = -1;
				}
				p++;
			}
		}

		/// <summary>
		/// Checks if coordinates are within the map.
		/// </summary>
		/// <param name="x">Current column.</param>
		/// <param name="y">Current row.</param>
		/// <returns>If coordinates are within the map.</returns>
		private bool IsOnMap(int x, int y)
			=> (y <= MapArray.GetLength(0) - 1) && (x <= MapArray.GetLength(1) - 1) && (x >= 0) && (y >= 0);

		/// <summary>
		/// Checks if move coordinates are within the map.
		/// </summary>
		/// <param name="x">Current column.</param>
		/// <param name="y">Current row.</param>
		/// <returns>if move coordinates are within the map.</returns>
		public bool CanGo(int x, int y)
			=> IsOnMap(x, y) && (MapArray[y, x] == false);

		/// <summary>
		/// Print the map.
		/// </summary>
		public void Print()
		{
			for (int i = 0; i < MapArray.GetLength(0); i++)
			{
				for (int j = 0; j < MapArray.GetLength(1); j++)
				{
					if (playerPosition == (j, i))
					{
						Console.Write('@');
					}
					else if (MapArray[i, j])
					{
						Console.Write('#');
					}
					else
					{
						Console.Write(' ');
					}
				}
				Console.WriteLine();
			}
		}
	}
}