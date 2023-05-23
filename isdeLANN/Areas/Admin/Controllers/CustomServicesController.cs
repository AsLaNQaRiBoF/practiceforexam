using isdeLANN.DAL;
using isdeLANN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace isdeLANN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomServicesController : Controller
    {
        
        private readonly AppDbContect _context;

        public CustomServicesController(AppDbContect context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            
            return View( await _context.customServices.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomServices customServices)
        {
            
            if (!ModelState.IsValid) { return View(); }
            if(customServices == null) { return NotFound(); }
            await _context.customServices.AddAsync(customServices); 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CustomServices services = await _context.customServices.FirstOrDefaultAsync(x => x.Id == id);
            return View(services);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomServices customServices)
        {
            if (!ModelState.IsValid) { return View(); }
            if (customServices == null) { return NotFound(); }
            CustomServices services = await _context.customServices.FirstOrDefaultAsync(x => x.Id == customServices.Id);
            services.Title=customServices.Title;
            services.Description=customServices.Description;
            services.logo=customServices.logo;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            CustomServices services = await _context.customServices.FirstOrDefaultAsync(x => x.Id == id);
            if (services == null)
            {
                return NotFound();
            }
            _context.customServices.Remove(services);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
