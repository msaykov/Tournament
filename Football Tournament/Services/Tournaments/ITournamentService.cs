namespace Football_Tournament.Services.Tournaments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ITournamentService
    {
        void CreateTournament(string name, string category);

        ICollection<TournamentInfoServiceModel> AllTournaments();
    }
}
