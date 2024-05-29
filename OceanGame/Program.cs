using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OceanLibrary;



namespace OceanGame
{
    class Program
    {        
        static void Main(string[] args)
        {
            const int INDENT = 3;

            int offset = 0;

            Game gameOne = StartGame(offset);
            offset += gameOne.OceanHeight + INDENT;
            bool gameOneIsNotOver = true;

            Game gameSecond = StartGame(offset);
            offset += gameSecond.OceanHeight + INDENT;
            bool gameSecondIsNotOver = true;

            for (int systemTime = 0; systemTime < 1000; systemTime++)
            {
                if (!gameOneIsNotOver && !gameSecondIsNotOver)
                {
                    break;
                }

                if (gameOneIsNotOver)
                {
                    gameOneIsNotOver = gameOne.RunGame();
                }

                if (!gameOneIsNotOver)
                {
                    OceanConsoleVeiwer.ShowGameOver(gameOne.OceanHeight, gameOne.OceanOffset);
                }

                if (gameSecondIsNotOver)
                {
                    gameSecondIsNotOver = gameSecond.RunGame();
                }

                if (!gameSecondIsNotOver)
                {
                    OceanConsoleVeiwer.ShowGameOver(gameSecond.OceanHeight, gameSecond.OceanOffset);
                }

                System.Threading.Thread.Sleep(500);
            }

            Console.ReadKey();
        }

        private static Game StartGame(int offset)
        {
            Game game = new Game(offset);
            game.ShowInitialCondition();
            
            return game;
        }
    }
}
