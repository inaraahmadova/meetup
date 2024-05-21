
using Meetup.DataAccesLayer;
using Meetup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Meetup.Controllers
{
    public class HomeController(MeetupContext _context) : Controller
    {
       
        //List<Speakers> speakers = await _context.Speakers.ToListAsync();
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
