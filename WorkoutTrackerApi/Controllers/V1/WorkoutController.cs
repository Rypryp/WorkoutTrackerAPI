using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkoutTrackerApi.Contracts.V1;
using WorkoutTrackerApi.Contracts.V1.Workout;
using WorkoutTrackerApi.Extensions;
using WorkoutTrackerApi.Models.Workout;
using WorkoutTrackerApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkoutTrackerApi.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet(ApiRoutes.Workout.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var userId = HttpContext.GetUserId();
            var workouts = await _workoutService.GetWorkoutsAsync(userId);

            return Ok(workouts);
        }

        [HttpGet(ApiRoutes.Workout.Get)]
        public async Task<IActionResult> Get(string id)
        {
            var userId = HttpContext.GetUserId();
            var workout = await _workoutService.GetWorkoutAsync(id, userId);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpPost(ApiRoutes.Workout.Create)]
        public async Task<ActionResult> Post([FromBody] CreateWorkoutRequest request)
        {
            var workout = _mapper.Map<CreateWorkoutRequest, Workout>(request);

            workout.Id = Guid.NewGuid().ToString();
            workout.UserId = HttpContext.GetUserId();

            var created = await _workoutService.CreateWorkoutAsync(workout);

            if (!created)
            {
                BadRequest();
            }

            return Ok();
        }

        [HttpPut(ApiRoutes.Workout.Update)]
        public async Task<IActionResult> Put(string id, [FromBody] Workout request)
        {
            var userOwnsWorkout = await _workoutService.UserOwnsWorkoutAsync(id, HttpContext.GetUserId());

            if (!userOwnsWorkout)
            {
                return BadRequest(new { error = "User does not own this workout" });
            }

            var updated = await _workoutService.UpdateWorkoutAsync(request);

            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete(ApiRoutes.Workout.Delete)]
        public async Task<IActionResult> Delete(string id)
        {
            var userOwnsWorkout = await _workoutService.UserOwnsWorkoutAsync(id, HttpContext.GetUserId());

            if (!userOwnsWorkout)
            {
                return BadRequest(new { error = "User does not own this workout" });
            }

            var deleted = await _workoutService.DeleteWorkoutAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
