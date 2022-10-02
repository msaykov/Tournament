namespace Football_Tournament.Data.Models
{
    using System.Collections.Generic;

    public class Tournament
    {
        public Tournament()
        {
            this.Groups = new List<Group>();
            this.Teams = new List<Team>();
        }
        public int Id { get; set; }

        public string Name { get; set; }  // UMAG Trophy, Sofia Cup

        public string Category { get; set; }  // U8, U9, ....

        public int MaxTeams { get; set; }     // UMAG Trophy --> max 8 groups, up to 8 teams in group => max 64 teams in 2 , 4  or 8 groups

        public ICollection<Group> Groups { get; set; }

        public ICollection<Team> Teams { get; set; }

        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }

    }
}
