using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OceanLibrary;

namespace OceanGame
{
    internal class OceanConsoleVeiwer
    {
        /// <summary>
        /// Displays the ocean on the console
        /// </summary>
        /// <param name="ocean">IOcean ocean</param>
        internal static void Show(IOcean ocean, int offset)
        {
            Console.SetCursorPosition(0, offset);
            for (int i = 0; i < ocean.Height; i++)
            {
                for (int j = 0; j < ocean.Width; j++)
                {
                    Console.Write((char)ocean[i, j]);
                }
                Console.WriteLine();
            }
        }

        internal static void ShowCell(int x, int y, CellViewType cellViewType, int offset)
        {
            Console.SetCursorPosition(x, (y + offset));
            Console.Write((char)cellViewType);
        }

        /// <summary>
        /// Displays the number of predetors and preys
        /// </summary>
        /// <param name="numPredetors"> number of predetors</param>
        /// <param name="numPreys">number of preys</param>
        internal static void ShowResult(int numPredetors, int numPreys, int offset, int height)
        {
            Console.SetCursorPosition(0, (offset + height));
            Console.WriteLine("NumPredetors = {0}, NumPrey = {1}  ", numPredetors, numPreys);
        }

        internal static void ShowGameOver( int height, int offset)
        {
            Console.SetCursorPosition(0, (height + offset + 1));
            Console.WriteLine("Came is over");
        }
    }
}
