using System;
namespace WorkoutTrackerApi.Contracts.V1.Identity
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
