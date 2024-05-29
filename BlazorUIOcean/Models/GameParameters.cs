using System.ComponentModel.DataAnnotations;

namespace BlazorUIOcean.Models
{
    public class GameParameters
    {
        [Range(5, 100)]
        public int OceanWidth { get; set; }
        [Range(5, 100)]
        public int OceanHeight { get; set; }
        [Range(1, 10000)]
        public int NumberOfIteration { get; set; }
        public int NumberOfPreys { get; set; }
        public int NumberOfPredetors { get; set; }
        public int NumberOfObstacles { get; set; }
    }
}
