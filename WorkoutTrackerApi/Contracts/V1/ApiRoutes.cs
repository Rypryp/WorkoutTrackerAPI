using System;
namespace WorkoutTrackerApi.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;


        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Refresh = Base + "/identity/refresh";
        }

        public static class Workout
        {
            public const string GetAll = Base + "/workouts";

            public const string Get = Base + "/workouts/{id}";

            public const string Create = Base + "/workouts";

            public const string Update = Base + "/workouts/{id}";

            public const string Delete = Base + "/workouts/{id}";
        }
    }
}
