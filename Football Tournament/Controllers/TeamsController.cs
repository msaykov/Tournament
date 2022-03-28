namespace Football_Tournament.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TeamsController : Controller
    {
        public IActionResult Add() => View();

        public IActionResult All() => View();
        
    }
}
