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

            this.tournament.CreateTournament(model.Name, model.Category, model.MaxTeams);


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

        public IActionResult Start(int id)
        {
            this.tournament.SeedGroups(id);
            return RedirectToAction("Details", "Tournaments", new { id = id });
        }

        public IActionResult Finish()
        {
            return View();
        }

        public IActionResult Details(int id)
        => View(tournament.Details(id));
        

        public IActionResult History()
        {
            return View();
        }

    }
}
