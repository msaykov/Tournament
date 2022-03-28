namespace Football_Tournament.Data.Models
{
    using System.Collections.Generic;

    public class Tournament
    {
        public Tournament()
        {
            this.Groups = new List<Group>();
            //this.Teams = new List<Team>();
        }
        public int Id { get; set; }

        public string Name { get; set; }  // UMAG Trophy, Sofia Cup

        public string Category { get; set; }  // U8, U9, ....

        public ICollection<Group> Groups { get; set; }

        //public ICollection<Team> Teams { get; set; }

    }
}
