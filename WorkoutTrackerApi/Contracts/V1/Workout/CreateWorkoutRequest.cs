using System;
using System.Collections.Generic;
using WorkoutTrackerApi.Models;

namespace WorkoutTrackerApi.Contracts.V1.Workout
{
    public class CreateWorkoutRequest
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}
