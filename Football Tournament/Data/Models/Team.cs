namespace Football_Tournament.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        public int Points { get; set; }

        public int GoalsFwd { get; set; }

        public int GoalsAg { get; set; }

        public int GoalDifference { get; set; }

        public int Penalities { get; set; }   

        public int Fwr { get; set; }       // Fifa World Ranking

        public int? GroupId { get; set; }

        public Group Group { get; set; }

        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; }

        public bool IsSelected { get; set; }


    }
}
