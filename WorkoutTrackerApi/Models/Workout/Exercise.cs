using Microsoft.EntityFrameworkCore;

namespace WorkoutTrackerApi.Models
{
    [Owned]
    public class Exercise
    {
        public string Name { get; set; }

        public int Sets { get; set; }

        public int Repetitions { get; set; }

        public float Weight { get; set; }
    }
}
