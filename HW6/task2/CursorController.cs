using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Class that shows the position of the player on the screen.
    /// </summary>
    class CursorController
    {
        private Map mapArray;

        /// <summary>
        /// Constructor, that builds the map from input file.
        /// </summary>
        /// <param name="path">Path to the input file.</param>
        public CursorController(string path)
        {
            mapArray = new Map(path);
        }

        /// <summary>
        /// Prints the map.
        /// </summary>
        public void Print()
        {
            mapArray.Print();
        }

        /// <summary>
        /// Moves up and print the updated map.
        /// </summary>
        public void OnUp(object sender, EventArgs args)
        {
            Console.Clear();
            mapArray.MoveUp();
            mapArray.Print();
        }

        /// <summary>
        /// Moves down and print the updated map.
        /// </summary>
        public void OnDown(object sender, EventArgs args)
        {
            Console.Clear();
            mapArray.MoveDown();
            mapArray.Print();
        }

        /// <summary>
        /// Moves left and print the updated map.
        /// </summary>
        public void OnLeft(object sender, EventArgs args)
        {
            Console.Clear();
            mapArray.MoveLeft();
            mapArray.Print();
        }

        /// <summary>
        /// Moves right and print the updated map.
        /// </summary>
        public void OnRight(object sender, EventArgs args)
        {
            Console.Clear();
            mapArray.MoveRight();
            mapArray.Print();
        }
    }
}
