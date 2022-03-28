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

        public int GroupId { get; set; }

        public Group Group { get; set; }

        //public int TournamentId { get; set; }

        //public Tournament Tournament { get; set; }


    }
}
