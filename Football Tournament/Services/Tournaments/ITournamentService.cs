namespace Football_Tournament.Services.Tournaments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ITournamentService
    {
        void CreateTournament(string name, string category, int maxTeams);

        ICollection<TournamentInfoServiceModel> AllTournaments();

        void SeedGroups(int id);

        TournamentDetailsServiceModel Details(int id);

        //void CreateSchedule(int id);
    }
}
