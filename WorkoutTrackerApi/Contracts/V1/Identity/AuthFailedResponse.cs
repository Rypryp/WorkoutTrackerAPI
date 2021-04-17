using System;
using System.Collections.Generic;

namespace WorkoutTrackerApi.Contracts.V1.Identity
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
