using System;
using AutoMapper;
using WorkoutTrackerApi.Contracts.V1.Workout;
using WorkoutTrackerApi.Models.Workout;

namespace WorkoutTrackerApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateWorkoutRequest, Workout>();
        }
    }
}
