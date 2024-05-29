using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanGame
{
    internal class UI
    {
        /// <summary>
        /// Asks the user for the number of rows and columns.
        /// </summary>
        /// <param name="rows">number of rows</param>
        /// <param name="column">number of columns</param>
        /// <returns>bool The user set the number of rows and columns</returns>
        internal static bool GetSizeOfOcean(ref int rows, ref int column, int offset)
        {
            Console.SetCursorPosition(0, offset);

            bool result = false;
            Console.WriteLine("Do you want to change size of the ocean?  Y - Yes, any other key - No");
            char answer = Console.ReadKey(true).KeyChar;

            if (answer == 'Y')
            {
                Console.WriteLine("Enter the width of the Ocean ");
                string w = Console.ReadLine();
                int.TryParse(w, out column);

                Console.WriteLine("Enter the hight of the Ocean ");
                string h = Console.ReadLine();
                int.TryParse(h, out rows);
                result = true;
            }

            ClearRow(offset);
            
            return result;
        }

        private static void ClearRow(int offset)
        {
            Console.SetCursorPosition(0, offset);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.Write(' ');
                }
            }
            
            Console.SetCursorPosition(0, offset);
        }

        /// <summary>
        /// Asks the user for the number of iterations.
        /// </summary>
        /// <param name="numOfIteration">number of iterations</param>
        /// <returns>bool The user set the number of iterations</returns>
        internal static bool GetNumOfIteration(ref int numOfIteration, int offset)
        {
            bool result = false;

            Console.WriteLine("Do you want to change number of iterations?  Y - Yes, any other key - No");
            char answer = Console.ReadKey(true).KeyChar;

            if (answer == 'Y')
            {
                Console.WriteLine("Number of iterations ");
                string iterations = Console.ReadLine();
                int.TryParse(iterations, out numOfIteration);
                result = true;
            }

            ClearRow(offset);

            return result;
        }

        /// <summary>
        /// Asks the user for the number of preys and predetors.
        /// </summary>
        /// <param name="numPreys">number of preys</param>
        /// <param name="numPredetors">number of predetors</param>
        /// <returns>bool The user set the number of preys and predetors</returns>
        internal static bool GetNumOfAnimals(ref int numPreys, ref int numPredetors, int offset)
        {
            bool result = false;

            Console.WriteLine("Do you want to change number of preys and predetors?  Y - Yes, any other key - No");
            char answer = Console.ReadKey(true).KeyChar;

            if (answer == 'Y')
            {
                Console.WriteLine("Number of preys ");
                string preys = Console.ReadLine();
                int.TryParse(preys, out numPreys);

                Console.WriteLine("Number of predetors ");
                string predetors = Console.ReadLine();
                int.TryParse(predetors, out numPredetors);

                result = true;
            }

            ClearRow(offset);
           
            return result;
        }

        /// <summary>
        /// Asks the user for the number of obstacles.
        /// </summary>
        /// <param name="numObstacles">number of obstacles</param>
        /// <returns>bool The user set the number of obstacles</returns>
        internal static bool GetNumOfObstacles(ref int numObstacles, int offset)
        {
            bool result = false;

            Console.WriteLine("Do you want to change number of obstacles?  Y - Yes, any other key - No");
            char answer = Console.ReadKey(true).KeyChar;

            if (answer == 'Y')
            {
                Console.WriteLine("Number of obstacles ");
                string obstacles = Console.ReadLine();
                int.TryParse(obstacles, out numObstacles);
                result = true;
            }

            ClearRow(offset);
            
            return result;
        }
    }
}
