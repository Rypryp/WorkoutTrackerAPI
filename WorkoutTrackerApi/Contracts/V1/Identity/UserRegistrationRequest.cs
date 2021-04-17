using System;
using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackerApi.Contracts.V1.Identity
{
    public class UserRegistrationRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
