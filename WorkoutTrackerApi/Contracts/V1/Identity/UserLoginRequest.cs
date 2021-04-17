using System;
using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackerApi.Contracts.V1.Identity
{
    public class UserLoginRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
