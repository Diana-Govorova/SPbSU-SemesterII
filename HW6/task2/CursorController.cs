using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
	/// <summary>
	/// Class that shows the position of the player on the screen.
	/// </summary>
	public class CursorController
	{
		private Map mapArray;

		private Action<int, int> action;

		public (int, int) PlayerPosition { get => mapArray.PlayerPosition; }

		/// <summary>
		/// Constructor that builds the map from input file.
		/// </summary>
		/// <param name="path">Path to the input file.</param>
		/// <param name="action">Move to coordinates.</param>
		public CursorController(string path, Action<int, int> action)
		{
			mapArray = new Map(path);
			this.action = action;
		}

		/// <summary>
		/// Prints the map.
		/// </summary>
		public void Print()
			=> mapArray.Print();

		/// <summary>
		/// Change location of character.
		/// </summary>
		/// <param name="x">Current  rows.</param>
		/// <param name="y">Current columns.</param>
		public void OnAction(int x, int y)
		{
			var (x1, y1) = mapArray.PlayerPosition;
			if (mapArray.CanGo(x1 + x, y1 + y))
			{
				action(x1, y1);
				Console.Write(' ');
				action(x1 + x, y1 + y);
				Console.Write('@');
				mapArray.PlayerPosition = (x1 + x, y1 + y);
			}
		}

		/// <summary>
		/// Moves up and print the updated map.
		/// </summary>
		public void OnUp(object sender, EventArgs args) => OnAction(0, -1);

		/// <summary>
		/// Moves down and print the updated map.
		/// </summary>
		public void OnDown(object sender, EventArgs args) => OnAction(0, 1);

		/// <summary>
		/// Moves left and print the updated map.
		/// </summary>
		public void OnLeft(object sender, EventArgs args) => OnAction(-1, 0);

		/// <summary>
		/// Moves right and print the updated map.
		/// </summary>
		public void OnRight(object sender, EventArgs args) => OnAction(1, 0);
	}
}