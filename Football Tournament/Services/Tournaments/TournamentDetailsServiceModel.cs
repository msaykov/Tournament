namespace Football_Tournament.Services.Tournaments
{
    using Football_Tournament.Data.Models;
    using System.Collections.Generic;

    public class TournamentDetailsServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public ICollection<Group> Groups { get; set; }

        public ICollection<Team> Teams { get; set; }

        public bool IsStarted { get; set; }

        public bool IsFinished { get; set; }

        public ICollection<ScheduleServiceModel> Matches { get; set; }
    }
}
