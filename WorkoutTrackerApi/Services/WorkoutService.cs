using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkoutTrackerApi.Data;
using WorkoutTrackerApi.Models.Workout;

namespace WorkoutTrackerApi.Services
{
    public interface IWorkoutService
    {
        public Task<List<Workout>> GetWorkoutsAsync(string userId);
        public Task<Workout> GetWorkoutAsync(string id, string userId);
        public Task<bool> CreateWorkoutAsync(Workout newWorkout);
        public Task<bool> UpdateWorkoutAsync(Workout workout);
        public Task<bool> DeleteWorkoutAsync(string workoutId);
        public Task<bool> UserOwnsWorkoutAsync(string workoutId, string userId);
    }

    public class WorkoutService : IWorkoutService
    {
        private readonly DataContext _context;

        public WorkoutService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateWorkoutAsync(Workout newWorkout)
        {
            await _context.Workouts.AddAsync(newWorkout);
            var created = await _context.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeleteWorkoutAsync(string workoutId)
        {
            Workout workout = await _context.Workouts
                .Where(x => x.Id == workoutId)
                .FirstOrDefaultAsync();

            if (workout == null)
            {
                return false;
            }

            _context.Workouts.Remove(workout);
            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<Workout> GetWorkoutAsync(string id, string userId)
        {
            return await _context.Workouts
                .Where(x => x.Id.ToString() == id && x.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Workout>> GetWorkoutsAsync(string userId)
        {
            return await _context.Workouts
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> UpdateWorkoutAsync(Workout workout)
        {
            _context.Workouts.Update(workout);
            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> UserOwnsWorkoutAsync(string workoutId, string userId)
        {
            var workout = await _context.Workouts
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == workoutId);

            if (workout == null)
            {
                return false;
            }

            if (workout.UserId != userId)
            {
                return false;
            }

            return true;
        }
    }
}
