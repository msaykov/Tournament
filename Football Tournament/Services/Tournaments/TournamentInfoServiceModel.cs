namespace Football_Tournament.Services.Tournaments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TournamentInfoServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int TeamsCount { get; set; }

        public int GroupsCount { get; set; }

        public int MaxTeams { get; set; }

        public bool IsStarted { get; set; }

        public bool IsFinished { get; set; }


    }
}
