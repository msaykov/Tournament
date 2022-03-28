namespace Football_Tournament.Services.Tournaments
{
    using System.Collections.Generic;

    public class AllTournamentsServiceModel
    {
        public ICollection<TournamentInfoServiceModel> Tournaments { get; set; }
    }
}
