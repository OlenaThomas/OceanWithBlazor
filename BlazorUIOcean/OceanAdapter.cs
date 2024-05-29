using OceanLibrary;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorUIOcean
{
    public static class OceanAdapter
    {
        const string IMAGEOBSTACLE = "<img src='images/obstacle.jpg' style='width: 60px; height: 50px;'/>";
        const string IMAGEPREY = "<img src='images/prey.jpg' style='width: 60px; height: 50px;'/>";
        const string IMAGEPREDATOR = "<img src='images/predator.jpg' style='width: 60px; height: 50px;'/>";

        public static void FillOutCells(string[,] cells, Ocean ocean)
        {
            int rows = cells.GetUpperBound(0) + 1;
            int columns = cells.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    cells[i, j] = GetImg(ocean[i, j]);
                }
            }
        }

        private static string GetImg(CellViewType cell)
        {
            string cellImg = string.Empty;

            switch (cell)
            {
                case CellViewType.Empty:
                    break;
                case CellViewType.Obstacle:
                    cellImg = IMAGEOBSTACLE;
                    break;
                case CellViewType.Prey:
                    cellImg = IMAGEPREY;
                    break;
                case CellViewType.Predator:
                    cellImg = IMAGEPREDATOR;
                    break;
                default:
                    break;
            }

            return cellImg;
        }
    }
}
