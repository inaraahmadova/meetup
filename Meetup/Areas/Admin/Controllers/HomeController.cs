using Meetup.DataAccesLayer;
using Meetup.Models;
using Meetup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meetup.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController(MeetupContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Speakers>speakers= await _context.Speakers.ToListAsync();
            return View(speakers);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetupVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _context.Speakers.AddAsync(new Speakers
            {
                Name = vm.Name,
                Icon = vm.Icon,
                Subtitle = vm.Subtitle,
                Image = vm.Image
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if(id == null || id<1) return BadRequest();
            Speakers speakers = await _context.Speakers.FindAsync(id);
            if (speakers == null) return NotFound();
            return View(speakers);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,CreateMeetupVM vm)
        {
            if (id == null || id < 1) return BadRequest();
            Speakers existed = await _context.Speakers.FindAsync(id);
            if (existed == null) return NotFound();
            existed.Name = vm.Name;
            existed.Icon = vm.Icon;
            existed.Subtitle = vm.Subtitle;
            existed.Image = vm.Image;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
          
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null || id<1) return BadRequest();
            var item = await _context.Speakers.FindAsync(id);
            _context.Speakers.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }










    }
}
