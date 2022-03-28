namespace Football_Tournament.Data.Models
{
    using System.Collections.Generic;

    public class Group
    {
        public Group()
        {
            this.Teams = new List<Team>();
        }
        public int Id { get; set; }

        public string Name { get; set; } // Group A, Group B

        public ICollection<Team> Teams { get; set; }

        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; }
    }
}
