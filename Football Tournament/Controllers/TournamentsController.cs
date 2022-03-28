namespace Football_Tournament.Controllers
{
    using Football_Tournament.Models.Tournaments;
    using Football_Tournament.Services.Tournaments;
    using Microsoft.AspNetCore.Mvc;

    public class TournamentsController : Controller
    {
        private readonly ITournamentService tournament;
        public TournamentsController(ITournamentService tournamentService)
        {
            this.tournament = tournamentService;
        }
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddTournamentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.tournament.CreateTournament(model.Name, model.Category);


            return RedirectToAction("All","Tournaments");
        }

        public IActionResult All()
        {
            var allTournaments = tournament.AllTournaments();

            return View(new AllTournamentsServiceModel
            {
                Tournaments = allTournaments,
            });
        }


    }
}
