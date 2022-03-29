namespace Football_Tournament.Services.Teams
{
    using Football_Tournament.Models.Teams;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ITeamsService
    {
        void AddTeam(string name, string logo, int id);

        ICollection<TeamViewModel> AllTeams(int id);

    }
}
