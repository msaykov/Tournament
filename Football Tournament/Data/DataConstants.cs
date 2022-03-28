namespace Football_Tournament.Data
{
    using System;

    public class DataConstants
    {
        public const int TournamentNameMaxLength = 50;
        public const int TournamentNameMinLength = 5;

        public const int CategoryMaxLength = 3;
        public const int CategoryMinLength = 2;

        public const string NamesErrorMsg = "The {0} must be between {2} and {1} characters long.";
    }
}
