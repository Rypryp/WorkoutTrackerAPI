using System;
namespace WorkoutTrackerApi.Contracts.V1.Workout
{
    public class UpdateWorkoutRequest : CreateWorkoutRequest
    {
        public string UserId { get; set; }
    }
}
