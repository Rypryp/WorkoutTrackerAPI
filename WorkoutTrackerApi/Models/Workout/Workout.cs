using System;
using System.Collections.Generic;

namespace WorkoutTrackerApi.Models.Workout
{
    public class Workout
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public List<Exercise> Exercises { get; set; }

        public Workout()
        {
            Exercises = new List<Exercise>();
        }
    }
}
