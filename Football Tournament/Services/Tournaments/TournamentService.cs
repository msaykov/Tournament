namespace Football_Tournament.Services.Tournaments
{
    using Football_Tournament.Data;
    using Football_Tournament.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class TournamentService : ITournamentService
    {
        private readonly TournamentDbContext data;

        public TournamentService(TournamentDbContext data)
        => this.data = data;

        public ICollection<TournamentInfoServiceModel> AllTournaments()
            => this.data
            .Tournaments
            .Select(t => new TournamentInfoServiceModel
            {
                Name = t.Name,
                Category = t.Category,
            })
            .ToList();

        
        public void CreateTournament(string name, string category)
        {           

            var tournamentEntity = new Tournament
            {
                Name = name,
                Category = category,
            };

            this.data                
                .Add(tournamentEntity);
            this.data.SaveChanges();

        }

        
    }
}
