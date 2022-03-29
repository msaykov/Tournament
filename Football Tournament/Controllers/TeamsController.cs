﻿namespace Football_Tournament.Controllers
{
    using Football_Tournament.Models.Teams;
    using Football_Tournament.Services.Teams;
    using Microsoft.AspNetCore.Mvc;

    public class TeamsController : Controller
    {
        private readonly ITeamsService team;
        public TeamsController(ITeamsService teamService)
        {
            this.team = teamService;
        }

        public IActionResult Add() => View();


        [HttpPost]
        public IActionResult Add(TeamViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.team.AddTeam(model.Name, model.Logo, id);

            return RedirectToAction("All", "Tournaments");
        }

        public IActionResult All(int id)
        {
            var allTeams = team.AllTeams(id);

            return View(new ViewTeamsServiceModel
            {
                Teams = allTeams,
            });
        }



    }
}
